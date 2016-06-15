using DAL.WCF.ServiceReference;
using Nocturne.Common.Interfaces.Repositories;
using Nocturne.Common.Models;

namespace DAL.WCF.Repositories
{
    public class MultiLangStringRepository: WcfRepository, IMultiLangStringRepository
    {
        public MultiLangString[] GetAllMultiLangStrings()
        {
            return Service.GetAllMultiLangStrings();
        }

        public MultiLangString GetMultiLangString(int id)
        {
            return Service.GetMultiLangStringById(id);
        }
        
        public MultiLangStringRepository(NocturneServiceClient service) : base(service)
        {
        }
    }
}
