using DAL.WCF.ServiceReference;
using Nocturne.Common.Models;
using Nocturne.Common.Interfaces.Repositories;

namespace DAL.WCF.Repositories
{
    public class UserRepository: WcfRepository, IUserRepository
    {
        public User[] GetAllUsers()
        {
            return Service.GetAllUsers();
        }

        public User GetUser(int id)
        {
            return Service.GetUser(id);
        }

        public ValidationResult<int> SaveUser(User user)
        {
            return Service.SaveUser(user);
        }

        public Role[] GetAvailableRoles()
        {
            return Service.GetAvaliableRoles();
        }

        public UserRepository(NocturneServiceClient service) : base(service)
        {
        }
    }
}
