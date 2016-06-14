using Nocturne.BL.Services;
using Nocturne.Common.Models;

namespace Nocturne.WcfService
{
    public class NocturneService : INocturneService
    {
        private static readonly NLog.ILogger _logger = NLog.LogManager.GetCurrentClassLogger();

        public NocturneService()
        {
            _logger.Trace("Instance created");
        }

        public void InitializeDatabase()
        {
            _logger.Trace("InitializeDatabase");
            new DatabaseDataStore().Initialize();
        }

        #region Client

        public Client[] GetAllClients()
        {
            _logger.Trace("GetAllClients");
            return new ClientService().Find(c => true);
        }

        public Client GetClient(int id)
        {
            _logger.Trace("GetClient");
            return new ClientService().GetClient(id);
        }

        public ValidationResult<int> SaveClient(Client customer)
        {
            _logger.Trace("SaveClient");
            return new ClientService().SaveClient(customer);
        }

        #endregion Client

        #region Product

        public Product[] GetAllProducts()
        {
            return new ProductService().GetAllProducts();
        }

        public Product GetProduct(int id)
        {
            return new ProductService().GetProductById(id);
        }

        public ValidationResult<int> SaveProduct(Product product)
        {
            return new ProductService().SaveProduct(product);
        }

        #endregion Product

        #region Discount Type

        public DiscountType[] GetAllDiscountTypes()
        {
            return new DiscountTypeService().GetAllDiscountTypes();
        }

        public DiscountType GetDiscountType(int id)
        {
            return new DiscountTypeService().GetDiscountTypeById(id);
        }

        public ValidationResult<int> SaveDiscountType(DiscountType discountType)
        {
            return new DiscountTypeService().SaveDiscountType(discountType);
        }

        #endregion Discount Type

        #region Discount

        public Discount[] GetAllDiscounts()
        {
            return new DiscountService().GetAllDiscounts();
        }

        public Discount GetDiscount(int id)
        {
            return new DiscountService().GetDiscountById(id);
        }

        public ValidationResult<int> SaveDiscount(Discount discount)
        {
            return new DiscountService().SaveDiscount(discount);
        }

        #endregion Discount


        #region User

        public User[] GetAllUsers()
        {
            return new UserService().Find(u => true);
        }

        public User GetUser(int id)
        {
            return new UserService().GetUser(id);
        }

        public ValidationResult<int> SaveUser(User user)
        {
            return new UserService().SaveUser(user);
        }
        public Role[] GetAvaliableRoles()
        {
            return new UserService().GetAvaliableRoles();
        }

        #endregion User
    }
}
