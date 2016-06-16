using System.Data.Entity;
using Nocturne.Common.Interfaces;
using Nocturne.Common.Models;
using System.Linq;

namespace Nocturne.BL.Services
{
    public class ProductService : IProductService
    {
        public void DeleteProduct(int id)
        {
            using (var dc = new NocturneContext())
            {
                var product = dc.Products.Single(q => q.Id == id);
                product.IsActive = false;
                dc.SaveChanges();
            }
        }

        public Product[] GetAllProducts()
        {
            using (var dc = new NocturneContext())
            {
                return dc.Products.Where(q=> q.IsActive)
                    .Include(q => q.Name)
                    .Include(q => q.Description).ToArray();
            }
        }

        public Product GetProductById(int id)
        {
            using (var dc = new NocturneContext())
            {
                return dc.Products.Where(p => p.Id == id)
                    .Include(q => q.Name).
                    Include(q => q.Description).SingleOrDefault();
            }
        }

        public ValidationResult<int> SaveProduct(Product product)
        {
            var validationResult = ValidateProduct(product);
            if (validationResult.HasValidationMessageType<ValidationErrorMessage>()) { return validationResult; }
            using (var dc = new NocturneContext())
            {
                Product productDb;
                if (product.Id > 0)
                {
                    productDb = dc.Products.Single(q => q.Id == product.Id);
                }
                else
                {
                    productDb = new Product();
                    productDb.IsActive = true;
                    dc.Products.Add(productDb);
                }

                productDb.Name = product.Name;
                productDb.Description = product.Description;
                productDb.Price = product.Price;
                productDb.DisplayImage = product.DisplayImage;

                dc.SaveChanges();
                product.Id = productDb.Id;
                validationResult.Result = product.Id;
            }                                        
            return validationResult;
        }

        private ValidationResult<int> ValidateProduct(Product product)
        {
            const string emptyErrorTemplate = "{0} cannot be blank.";
            var result = new ValidationResult<int>();

            result.ValidateProperty((msg) => { return product.Description == null /*string.IsNullOrEmpty(product.Description) || product.Description.Trim().Length == 0*/ ? new ValidationErrorMessage(msg) : null; },
                string.Format(emptyErrorTemplate, "Description"),
                nameof(product.Description));

            result.ValidateProperty((msg) => { return product.Name == null /* string.IsNullOrEmpty(product.Name) || product.Name.Trim().Length == 0*/ ? new ValidationErrorMessage(msg) : null; },
               string.Format(emptyErrorTemplate, "Name"),
               nameof(product.Name));

            result.ValidateProperty((msg) => { return product.Price < 0 ? new ValidationErrorMessage(msg) : null; },
                "Product price must be 0 or greater",
               nameof(product.Price));

            return result;
        }

        //private IQueryable<Product> SelectProduct(IQueryable<Product> query)
        //{
        //    return query.Select(u => new Product
        //    {
        //        Description = u.Description,
        //        Id = u.Id,
        //        Name = u.Name,
        //        Price = u.Price,
        //        DisplayImage = u.DisplayImage
        //    });
        //}    
    }
}
