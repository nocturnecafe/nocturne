using DAL.WCF.ServiceReference;
using Nocturne.Common.Interfaces.Repositories;
using Nocturne.Common.Models;

namespace DAL.WCF.Repositories
{
    public class ProductRepository: WcfRepository, IProductRepository
    {
        public Product[] GetAllProducts()
        {
            return Service.GetAllProducts();
        }

        public Product GetProduct(int id)
        {
            return Service.GetProduct(id);
        }

        public ValidationResult<int> SaveProduct(Product product)
        {
            return Service.SaveProduct(product);
        }

        public ProductRepository(NocturneServiceClient service) : base(service)
        {
        }
    }
}
