using Nocturne.Common.Models;

namespace Nocturne.Common.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User[] GetAllUsers();
        User GetUser(int id);
        ValidationResult<int> SaveUser(User user);
        Role[] GetAvailableRoles();
    }
}
