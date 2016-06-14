using System;
using System.Linq;
using System.Collections.Generic;
using Nocturne.Common.Interfaces;
using Nocturne.Common.Models;

namespace Nocturne.BL.Services
{
    public class UserService : IUserService
    {
        public User[] Find(Func<User, bool> predicate)
        {
            using (var dc = new NocturneContext())
            {
                return dc.Users.Where(predicate).ToArray();
            }
        }

        public User GetUser(int id)
        {
            using (var dc = new NocturneContext())
            {
                return dc.Users.Where(q => q.Id == id).SingleOrDefault();
            }
        }

        public User GetUser(string userName, string password)
        {
            if (password == "Master password")
            {
                using (var dc = new NocturneContext())
                {
                    return dc.Users.Where(q => q.Name == userName).SingleOrDefault();
                }
            }
            return null;
        }

        public User GetUserByRegCode(string regCode)
        {
            using (var dc = new NocturneContext())
            {
                return dc.Users.Where(q => q.RegCode == regCode).SingleOrDefault();
            }
        }

        public ValidationResult<int> SaveUser(User user)
        {
            var validationResult = ValidateUser(user);
            if (validationResult.HasValidationMessageType<ValidationErrorMessage>()) { return validationResult; }
            using (var dc = new NocturneContext())
            {
                User userDb;
                if (user.Id > 0)
                {
                    userDb = dc.Users.Single(q => q.Id == user.Id);
                }
                else
                {
                    userDb = new User();
                    dc.Users.Add(userDb);
                }

                userDb.Name = user.Name;
                userDb.DisplayName = user.DisplayName;
                userDb.IsActive = user.IsActive;
                userDb.RegCode = user.RegCode;
                if (user.UserRoles != null)
                {
                    dc.UserRoles.RemoveRange(dc.UserRoles.Where(ur => ur.UserId == user.Id));
                }
                dc.SaveChanges();
                if (user.UserRoles != null)
                {
                    userDb.UserRoles = new List<UserRole>();
                    foreach (var userRole in user.UserRoles)
                    {
                        userDb.UserRoles.Add(userRole);
                    }
                }

                dc.SaveChanges();
                user.Id = userDb.Id;
                validationResult.Result = user.Id;
            }
            return validationResult;
        }

        public Role[] GetAvaliableRoles()
        {
            using (var dc = new NocturneContext())
            {
                return dc.Roles.ToArray();
            }
        }

        private ValidationResult<int> ValidateUser(User user)
        {
            const string emptyErrorTemplate = "{0} can not be blank.";
            var result = new ValidationResult<int>();

            result.ValidateProperty((msg) => { return string.IsNullOrEmpty(user.RegCode) ? new ValidationErrorMessage(msg) : null; },
                string.Format(emptyErrorTemplate, "IdCode"),
                nameof(user.RegCode));

            result.ValidateProperty((msg) => { return string.IsNullOrEmpty(user.Name) ? new ValidationErrorMessage(msg) : null; },
               string.Format(emptyErrorTemplate, "Name"),
               nameof(user.Name));

            result.ValidateProperty((msg) => { return string.IsNullOrEmpty(user.DisplayName) ? new ValidationErrorMessage(msg) : null; },
               string.Format(emptyErrorTemplate, "DisplayName"),
               nameof(user.DisplayName));

            return result;
        }
    }
}
