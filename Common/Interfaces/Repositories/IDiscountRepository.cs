using Nocturne.Common.Models;

namespace Nocturne.Common.Interfaces.Repositories
{
    public interface IDiscountRepository
    {
        Discount[] GetAllDiscounts();
        Discount GetDiscount(int id);
        ValidationResult<int> SaveDiscount(Discount discount);
    }
}
