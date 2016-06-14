using System.ServiceModel;
using Nocturne.Common.Interfaces;
using Nocturne.Common.Models;

namespace Nocturne.WcfService
{
    [ServiceContract]
    public interface INocturneService
    {
        [OperationContract]
        void InitializeDatabase();


        // Client

        [OperationContract]
        Client[] GetAllClients();

        [OperationContract]
        Client GetClient(int id);

        [OperationContract]
        ValidationResult<int> SaveClient(Client customer);

        //Product

        [OperationContract]
        Product[] GetAllProducts();

        [OperationContract]
        Product GetProduct(int id);

        [OperationContract]
        ValidationResult<int> SaveProduct(Product product);



        //Discount Type

        [OperationContract]
        DiscountType[] GetAllDiscountTypes();

        [OperationContract]
       DiscountType GetDiscountType(int id);

        [OperationContract]
        ValidationResult<int> SaveDiscountType(DiscountType discountType);


        //Discount

        [OperationContract]
        Discount[] GetAllDiscounts();

        [OperationContract]
        Discount GetDiscount(int id);

        [OperationContract]
        ValidationResult<int> SaveDiscount(Discount discount);

        // User

        [OperationContract]
        User[] GetAllUsers();

        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        ValidationResult<int> SaveUser(User user);

        [OperationContract]
        Role[] GetAvaliableRoles();
    }
}
