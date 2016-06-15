using DAL.WCF.ServiceReference;
using Nocturne.Common.Interfaces.Repositories;
using Nocturne.Common.Models;

namespace DAL.WCF.Repositories
{
    public class DiscountTypeRepository: WcfRepository, IDiscountTypeRepository
    {
        public DiscountType[] GetAllDiscountTypes()
        {
            return Service.GetAllDiscountTypes();
        }

        public DiscountType GetDiscountType(int id)
        {
            return Service.GetDiscountType(id);
        }

        public ValidationResult<int> SaveDiscountType(DiscountType discountType)
        {
            return Service.SaveDiscountType(discountType);
        }

        public DiscountTypeRepository(NocturneServiceClient service) : base(service)
        {
        }
    }
}
