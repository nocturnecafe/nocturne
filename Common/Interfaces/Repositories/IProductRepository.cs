using Nocturne.Common.Models;

namespace Nocturne.Common.Interfaces.Repositories
{
    public interface IProductRepository
    {
            Product[] GetAllProducts();
            Product GetProduct(int id);
            ValidationResult<int> SaveProduct(Product product);
    }
}
