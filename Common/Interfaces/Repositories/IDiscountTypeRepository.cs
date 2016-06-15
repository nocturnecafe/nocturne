using Nocturne.Common.Models;

namespace Nocturne.Common.Interfaces.Repositories
{
    public interface IDiscountTypeRepository
    {
            DiscountType[] GetAllDiscountTypes();
            DiscountType GetDiscountType(int id);
            ValidationResult<int> SaveDiscountType(DiscountType discountType);
        }
}
