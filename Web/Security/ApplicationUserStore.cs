﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Nocturne.Common.Interfaces;
using Web.Models;

namespace Nocturne.Web.Security
{
    public class ApplicationUserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>, IUserLockoutStore<ApplicationUser, string>, IUserTwoFactorStore<ApplicationUser,string>
    {
        private readonly IUOW _uow;
        
        public ApplicationUserStore()
        {
            _uow = DependencyResolver.Current.GetService<IUOW>();

        }

        public Task CreateAsync(ApplicationUser user)
        {
            throw new NotSupportedException();
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            throw new NotSupportedException();
        }

        public void Dispose()
        {
        }

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
                var client = _uow.Users.GetAllUsers().FirstOrDefault(c => c.Id == int.Parse(userId));
                if (client == null)
                    return null;
                return Task.FromResult(new ApplicationUser
                {
                    Id = client.Id.ToString(),
                    UserName = client.DisplayName
                });
        }

        public Task<ApplicationUser> FindByNameAsync(string userName)
        {
                var client = _uow.Users.GetAllUsers().FirstOrDefault(c => c.RegCode == userName);
                if (client == null)
                    return null;
                return Task.FromResult(new ApplicationUser
                {
                    Id = client.Id.ToString(),
                    UserName = client.DisplayName
                });
        }

        public Task<int> GetAccessFailedCountAsync(ApplicationUser user)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(ApplicationUser user)
        {
            return Task.FromResult(false);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(ApplicationUser user)
        {
            throw new NotSupportedException();
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            // System uses ID-card based authentication in other parts, so it doesn't have passwords.
            // No working ID-card support for asp.net, seems to be a config hell.
            return Task.FromResult("superuser");
        }

        public Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user)
        {
            return Task.FromResult(false);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            throw new NotSupportedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(ApplicationUser user)
        {
            return Task.FromResult(0);
        }

        public Task ResetAccessFailedCountAsync(ApplicationUser user)
        {
            return Task.FromResult(0);
        }

        public Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled)
        {
            throw new NotSupportedException();
        }

        public Task SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotSupportedException();
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            throw new NotSupportedException();
        }

        public Task SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled)
        {
             return Task.FromResult(false);
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            throw new NotSupportedException();
        }
    }
}