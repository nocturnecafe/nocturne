using Nocturne.Common.Interfaces;
using Nocturne.Common.Models;
using System.Linq;

namespace Nocturne.BL.Services
{
    public class DiscountTypeService : IDiscountTypeService
    {
        public DiscountType[] GetAllDiscountTypes()
        {
            using (var dc = new NocturneContext())
            {
                return dc.DiscountTypes.Where(q => q.IsActive).ToArray();
            }
        }

        public DiscountType GetDiscountTypeById(int id)
        {
            using (var dc = new NocturneContext())
            {
                return dc.DiscountTypes.Where(p => p.Id == id).SingleOrDefault();
            }
        }

        public ValidationResult<int> SaveDiscountType(DiscountType type)
        {
            var validationResult = ValidateDiscountType(type);
            if (validationResult.HasValidationMessageType<ValidationErrorMessage>()) { return validationResult; }

            using (var dc = new NocturneContext())
            {
                DiscountType typeDb;
                if (type.Id > 0)
                {
                    typeDb = dc.DiscountTypes.Single(q => q.Id == type.Id);
                }
                else
                {
                    typeDb = new DiscountType();   
                    dc.DiscountTypes.Add(typeDb);
                }

                typeDb.Name = type.Name;
                typeDb.IsActive = type.IsActive;

                dc.SaveChanges();
                type.Id = typeDb.Id;
                validationResult.Result = type.Id;
            }

            return validationResult;
        }

        private ValidationResult<int> ValidateDiscountType(DiscountType type)
        {
            var result = new ValidationResult<int>();

            result.ValidateProperty((msg) => { return string.IsNullOrEmpty(type.Name) ? new ValidationErrorMessage(msg) : null; },
                "Name cannot be blank.",
                nameof(type.Name));

            return result;
        }

        public void DeleteDiscountType(int id)
        {
            using (var dc = new NocturneContext())
            {
                var discountType = dc.DiscountTypes.Single(q => q.Id == id);
                discountType.IsActive = false;
                dc.SaveChanges();
            }
        }

       
    }
}
