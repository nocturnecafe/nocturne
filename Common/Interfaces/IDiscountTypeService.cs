using Nocturne.Common.Models;

namespace Nocturne.Common.Interfaces
{
    /// <summary>
    /// Service interface to manage discount types.
    /// </summary>
    public interface IDiscountTypeService
    {
        DiscountType GetDiscountTypeById(int id);
        DiscountType[] GetAllDiscountTypes();
        ValidationResult<int> SaveDiscountType(DiscountType discount);
        void DeleteDiscountType(int id);
    }
}
