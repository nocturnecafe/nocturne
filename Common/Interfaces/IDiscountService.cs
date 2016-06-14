using Nocturne.Common.Models;

namespace Nocturne.Common.Interfaces
{
    /// <summary>
    /// Service interface to manage discounts. Actual implementations are in Services directory.
    /// </summary>
    public interface IDiscountService
    {
        Discount GetDiscountById(int id);    
        Discount[] GetAllDiscounts();

        /// <summary>
        /// Calculates the difference between product price and the sum of all discounts for that product.
        /// </summary>
        /// <param name="product">Product to calculate the discount for.</param>              
        /// <returns>
        /// 0 = product is free
        /// null = no discount price
        /// decimal between 0 and product price = discount price
        /// </returns>
        decimal? CalculateDiscountPriceForProduct(Product product);

        /// <summary>
        /// Validates and if validation was successful, saves discount.
        /// </summary>
        /// <param name="discount"></param>
        /// <returns>
        /// ValidationResult object contains errors if validation was unsuccessful.
        /// </returns>
        ValidationResult<int> SaveDiscount(Discount discount);

        void DeleteDiscount(int id);
    }
}
