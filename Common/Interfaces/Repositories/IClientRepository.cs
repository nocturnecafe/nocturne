using Nocturne.Common.Models;

namespace Nocturne.Common.Interfaces.Repositories
{
    public interface IClientRepository
    {
        Client[] GetAllClients();
        Client GetClient(int id);
        ValidationResult<int> SaveClient(Client customer);
    }
}
