using Nocturne.Common.Models;

namespace Nocturne.Common.Interfaces
{
    /// <summary>
    /// Service interface to manage products.
    /// </summary>
    public interface IProductService
    {
        Product GetProductById(int id);
        Product[] GetAllProducts();
        ValidationResult<int> SaveProduct(Product product);
        void DeleteProduct(int id);
    }
}
