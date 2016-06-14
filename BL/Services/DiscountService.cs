using Nocturne.Common.Interfaces;
using Nocturne.Common.Models;
using System.Linq;

namespace Nocturne.BL.Services
{
    public class DiscountService : IDiscountService
    {
        public decimal? CalculateDiscountPriceForProduct(Product product)
        {
            decimal res;
            using (var dc = new NocturneContext())
            {
                res = dc.Discounts.Where(d => d.ProductId == product.Id)
                    .Where(d => d.DiscountType.IsActive)
                    .Where(d => d.IsActive)
                    .Sum(d => d.AmountPercent) * product.Price / 100;
            }

            if (res >= product.Price && product.Price != 0) return 0;
            else if (res > 0) return product.Price - res;

            return null;
        }

        public void DeleteDiscount(int id)
        {
            using (var dc = new NocturneContext())
            {
                var discount = dc.Discounts.Single(q => q.Id == id);
                discount.IsActive = false;
                dc.SaveChanges();
            }
        }

        public Discount GetDiscountById(int id)
        {
            using (var dc = new NocturneContext())
            {
                return dc.Discounts.Where(p => p.Id == id).SingleOrDefault();
            }
        }

        public Discount[] GetAllDiscounts()
        {
            using (var dc = new NocturneContext())
            {
                return dc.Discounts
                    .Where(q => q.Product.IsActive)
                    .Where(q => q.DiscountType.IsActive)
                    .Where(q => q.IsActive).ToArray();
            }
        }

        public ValidationResult<int> SaveDiscount(Discount discount)
        {
            var validationResult = ValidateDiscount(discount);
            if (validationResult.HasValidationMessageType<ValidationErrorMessage>()) { return validationResult; }

            using (var dc = new NocturneContext())
            {
                Discount discountDb;
                if (discount.Id > 0)
                {
                    discountDb = dc.Discounts.Single(q => q.Id == discount.Id);
                }
                else
                {
                    discountDb = new Discount();
                    discountDb.IsActive = true;
                    dc.Discounts.Add(discountDb);
                }

                discountDb.AmountPercent = discount.AmountPercent;
                discountDb.DiscountTypeId = discount.DiscountTypeId;
                discountDb.ProductId = discount.ProductId;

                dc.SaveChanges();
                discount.Id = discountDb.Id;
                validationResult.Result = discount.Id;
            }

            validationResult.Result = discount.Id;
            return validationResult;
        }

        private int GetDiscountPercentForProduct(int productId, int discountId)
        {
            using (var dc = new NocturneContext())
            {
                var discounts = dc.Discounts.Where(d => d.ProductId == productId && d.Id != discountId).ToArray();
                return discounts.Sum(d => d.AmountPercent);
            }
        }

        private ValidationResult<int> ValidateDiscount(Discount discount)
        {
            var result = new ValidationResult<int>();

            result.ValidateProperty(
                    (msg) =>
                    {
                        return discount.AmountPercent + GetDiscountPercentForProduct(discount.ProductId, discount.Id) > 100 ?
                                new ValidationErrorMessage(msg) : null;
                    },
                    "Total discount percent for product can't exceed 100.",
                    nameof(discount.AmountPercent)
                    );

            result.ValidateProperty((msg) => { return discount.AmountPercent < 0 || discount.AmountPercent > 100 ? new ValidationErrorMessage(msg) : null; },
                "Amount percent must be between 0 and 100.",
                nameof(discount.AmountPercent));

            result.ValidateProperty((msg) => { return discount.DiscountTypeId == 0 ? new ValidationErrorMessage(msg) : null; },
                "You must select a discount type.",
                nameof(discount.DiscountTypeId));

            result.ValidateProperty((msg) => { return discount.ProductId == 0 ? new ValidationErrorMessage(msg) : null; },
                "You must select a product to discount.",
                nameof(discount.ProductId));

            return result;
        }
    }
}
