using DAL.WCF.ServiceReference;
using Nocturne.Common.Interfaces.Repositories;
using Nocturne.Common.Models;

namespace DAL.WCF.Repositories
{
    public class DiscountRepository: WcfRepository, IDiscountRepository
    {
        public Discount[] GetAllDiscounts()
        {
            return Service.GetAllDiscounts();
        }

        public Discount GetDiscount(int id)
        {
            return Service.GetDiscount(id);
        }

        public ValidationResult<int> SaveDiscount(Discount discount)
        {
            return Service.SaveDiscount(discount);
        }

        public DiscountRepository(NocturneServiceClient service) : base(service)
        {
        }
    }
}
