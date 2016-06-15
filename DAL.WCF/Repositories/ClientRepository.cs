using DAL.WCF.ServiceReference;
using Nocturne.Common.Interfaces.Repositories;
using Nocturne.Common.Models;

namespace DAL.WCF.Repositories
{
    public class ClientRepository: WcfRepository, IClientRepository
    {
        public Client[] GetAllClients()
        {
            return Service.GetAllClients();
        }

        public Client GetClient(int id)
        {
            return Service.GetClient(id);
        }

        public ValidationResult<int> SaveClient(Client customer)
        {
            return Service.SaveClient(customer);
        }

        public ClientRepository(NocturneServiceClient service) : base(service)
        {
        }
    }
}
