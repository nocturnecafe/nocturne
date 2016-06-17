﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.WCF.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.INocturneService")]
    public interface INocturneService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetActiveSessionCount", ReplyAction="http://tempuri.org/INocturneService/GetActiveSessionCountResponse")]
        int GetActiveSessionCount();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetActiveSessionCount", ReplyAction="http://tempuri.org/INocturneService/GetActiveSessionCountResponse")]
        System.Threading.Tasks.Task<int> GetActiveSessionCountAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetAllMultiLangStrings", ReplyAction="http://tempuri.org/INocturneService/GetAllMultiLangStringsResponse")]
        Nocturne.Common.Models.MultiLangString[] GetAllMultiLangStrings();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetAllMultiLangStrings", ReplyAction="http://tempuri.org/INocturneService/GetAllMultiLangStringsResponse")]
        System.Threading.Tasks.Task<Nocturne.Common.Models.MultiLangString[]> GetAllMultiLangStringsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetMultiLangStringById", ReplyAction="http://tempuri.org/INocturneService/GetMultiLangStringByIdResponse")]
        Nocturne.Common.Models.MultiLangString GetMultiLangStringById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetMultiLangStringById", ReplyAction="http://tempuri.org/INocturneService/GetMultiLangStringByIdResponse")]
        System.Threading.Tasks.Task<Nocturne.Common.Models.MultiLangString> GetMultiLangStringByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetAllTranslations", ReplyAction="http://tempuri.org/INocturneService/GetAllTranslationsResponse")]
        Nocturne.Common.Models.Translation[] GetAllTranslations();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetAllTranslations", ReplyAction="http://tempuri.org/INocturneService/GetAllTranslationsResponse")]
        System.Threading.Tasks.Task<Nocturne.Common.Models.Translation[]> GetAllTranslationsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetTranslationsByMultiLangStringId", ReplyAction="http://tempuri.org/INocturneService/GetTranslationsByMultiLangStringIdResponse")]
        Nocturne.Common.Models.Translation[] GetTranslationsByMultiLangStringId(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetTranslationsByMultiLangStringId", ReplyAction="http://tempuri.org/INocturneService/GetTranslationsByMultiLangStringIdResponse")]
        System.Threading.Tasks.Task<Nocturne.Common.Models.Translation[]> GetTranslationsByMultiLangStringIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetAllClients", ReplyAction="http://tempuri.org/INocturneService/GetAllClientsResponse")]
        Nocturne.Common.Models.Client[] GetAllClients();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetAllClients", ReplyAction="http://tempuri.org/INocturneService/GetAllClientsResponse")]
        System.Threading.Tasks.Task<Nocturne.Common.Models.Client[]> GetAllClientsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetClient", ReplyAction="http://tempuri.org/INocturneService/GetClientResponse")]
        Nocturne.Common.Models.Client GetClient(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetClient", ReplyAction="http://tempuri.org/INocturneService/GetClientResponse")]
        System.Threading.Tasks.Task<Nocturne.Common.Models.Client> GetClientAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/SaveClient", ReplyAction="http://tempuri.org/INocturneService/SaveClientResponse")]
        Nocturne.Common.Models.ValidationResult<int> SaveClient(Nocturne.Common.Models.Client customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/SaveClient", ReplyAction="http://tempuri.org/INocturneService/SaveClientResponse")]
        System.Threading.Tasks.Task<Nocturne.Common.Models.ValidationResult<int>> SaveClientAsync(Nocturne.Common.Models.Client customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetAllProducts", ReplyAction="http://tempuri.org/INocturneService/GetAllProductsResponse")]
        Nocturne.Common.Models.Product[] GetAllProducts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetAllProducts", ReplyAction="http://tempuri.org/INocturneService/GetAllProductsResponse")]
        System.Threading.Tasks.Task<Nocturne.Common.Models.Product[]> GetAllProductsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetProduct", ReplyAction="http://tempuri.org/INocturneService/GetProductResponse")]
        Nocturne.Common.Models.Product GetProduct(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetProduct", ReplyAction="http://tempuri.org/INocturneService/GetProductResponse")]
        System.Threading.Tasks.Task<Nocturne.Common.Models.Product> GetProductAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/SaveProduct", ReplyAction="http://tempuri.org/INocturneService/SaveProductResponse")]
        Nocturne.Common.Models.ValidationResult<int> SaveProduct(Nocturne.Common.Models.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/SaveProduct", ReplyAction="http://tempuri.org/INocturneService/SaveProductResponse")]
        System.Threading.Tasks.Task<Nocturne.Common.Models.ValidationResult<int>> SaveProductAsync(Nocturne.Common.Models.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetAllDiscountTypes", ReplyAction="http://tempuri.org/INocturneService/GetAllDiscountTypesResponse")]
        Nocturne.Common.Models.DiscountType[] GetAllDiscountTypes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetAllDiscountTypes", ReplyAction="http://tempuri.org/INocturneService/GetAllDiscountTypesResponse")]
        System.Threading.Tasks.Task<Nocturne.Common.Models.DiscountType[]> GetAllDiscountTypesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetDiscountType", ReplyAction="http://tempuri.org/INocturneService/GetDiscountTypeResponse")]
        Nocturne.Common.Models.DiscountType GetDiscountType(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetDiscountType", ReplyAction="http://tempuri.org/INocturneService/GetDiscountTypeResponse")]
        System.Threading.Tasks.Task<Nocturne.Common.Models.DiscountType> GetDiscountTypeAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/SaveDiscountType", ReplyAction="http://tempuri.org/INocturneService/SaveDiscountTypeResponse")]
        Nocturne.Common.Models.ValidationResult<int> SaveDiscountType(Nocturne.Common.Models.DiscountType discountType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/SaveDiscountType", ReplyAction="http://tempuri.org/INocturneService/SaveDiscountTypeResponse")]
        System.Threading.Tasks.Task<Nocturne.Common.Models.ValidationResult<int>> SaveDiscountTypeAsync(Nocturne.Common.Models.DiscountType discountType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetAllDiscounts", ReplyAction="http://tempuri.org/INocturneService/GetAllDiscountsResponse")]
        Nocturne.Common.Models.Discount[] GetAllDiscounts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetAllDiscounts", ReplyAction="http://tempuri.org/INocturneService/GetAllDiscountsResponse")]
        System.Threading.Tasks.Task<Nocturne.Common.Models.Discount[]> GetAllDiscountsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetDiscount", ReplyAction="http://tempuri.org/INocturneService/GetDiscountResponse")]
        Nocturne.Common.Models.Discount GetDiscount(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetDiscount", ReplyAction="http://tempuri.org/INocturneService/GetDiscountResponse")]
        System.Threading.Tasks.Task<Nocturne.Common.Models.Discount> GetDiscountAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/SaveDiscount", ReplyAction="http://tempuri.org/INocturneService/SaveDiscountResponse")]
        Nocturne.Common.Models.ValidationResult<int> SaveDiscount(Nocturne.Common.Models.Discount discount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/SaveDiscount", ReplyAction="http://tempuri.org/INocturneService/SaveDiscountResponse")]
        System.Threading.Tasks.Task<Nocturne.Common.Models.ValidationResult<int>> SaveDiscountAsync(Nocturne.Common.Models.Discount discount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetAllUsers", ReplyAction="http://tempuri.org/INocturneService/GetAllUsersResponse")]
        Nocturne.Common.Models.User[] GetAllUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetAllUsers", ReplyAction="http://tempuri.org/INocturneService/GetAllUsersResponse")]
        System.Threading.Tasks.Task<Nocturne.Common.Models.User[]> GetAllUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetUser", ReplyAction="http://tempuri.org/INocturneService/GetUserResponse")]
        Nocturne.Common.Models.User GetUser(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetUser", ReplyAction="http://tempuri.org/INocturneService/GetUserResponse")]
        System.Threading.Tasks.Task<Nocturne.Common.Models.User> GetUserAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/SaveUser", ReplyAction="http://tempuri.org/INocturneService/SaveUserResponse")]
        Nocturne.Common.Models.ValidationResult<int> SaveUser(Nocturne.Common.Models.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/SaveUser", ReplyAction="http://tempuri.org/INocturneService/SaveUserResponse")]
        System.Threading.Tasks.Task<Nocturne.Common.Models.ValidationResult<int>> SaveUserAsync(Nocturne.Common.Models.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetAvaliableRoles", ReplyAction="http://tempuri.org/INocturneService/GetAvaliableRolesResponse")]
        Nocturne.Common.Models.Role[] GetAvaliableRoles();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INocturneService/GetAvaliableRoles", ReplyAction="http://tempuri.org/INocturneService/GetAvaliableRolesResponse")]
        System.Threading.Tasks.Task<Nocturne.Common.Models.Role[]> GetAvaliableRolesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INocturneServiceChannel : DAL.WCF.ServiceReference.INocturneService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NocturneServiceClient : System.ServiceModel.ClientBase<DAL.WCF.ServiceReference.INocturneService>, DAL.WCF.ServiceReference.INocturneService {
        
        public NocturneServiceClient() {
        }
        
        public NocturneServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NocturneServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NocturneServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NocturneServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetActiveSessionCount() {
            return base.Channel.GetActiveSessionCount();
        }
        
        public System.Threading.Tasks.Task<int> GetActiveSessionCountAsync() {
            return base.Channel.GetActiveSessionCountAsync();
        }
        
        public Nocturne.Common.Models.MultiLangString[] GetAllMultiLangStrings() {
            return base.Channel.GetAllMultiLangStrings();
        }
        
        public System.Threading.Tasks.Task<Nocturne.Common.Models.MultiLangString[]> GetAllMultiLangStringsAsync() {
            return base.Channel.GetAllMultiLangStringsAsync();
        }
        
        public Nocturne.Common.Models.MultiLangString GetMultiLangStringById(int id) {
            return base.Channel.GetMultiLangStringById(id);
        }
        
        public System.Threading.Tasks.Task<Nocturne.Common.Models.MultiLangString> GetMultiLangStringByIdAsync(int id) {
            return base.Channel.GetMultiLangStringByIdAsync(id);
        }
        
        public Nocturne.Common.Models.Translation[] GetAllTranslations() {
            return base.Channel.GetAllTranslations();
        }
        
        public System.Threading.Tasks.Task<Nocturne.Common.Models.Translation[]> GetAllTranslationsAsync() {
            return base.Channel.GetAllTranslationsAsync();
        }
        
        public Nocturne.Common.Models.Translation[] GetTranslationsByMultiLangStringId(int id) {
            return base.Channel.GetTranslationsByMultiLangStringId(id);
        }
        
        public System.Threading.Tasks.Task<Nocturne.Common.Models.Translation[]> GetTranslationsByMultiLangStringIdAsync(int id) {
            return base.Channel.GetTranslationsByMultiLangStringIdAsync(id);
        }
        
        public Nocturne.Common.Models.Client[] GetAllClients() {
            return base.Channel.GetAllClients();
        }
        
        public System.Threading.Tasks.Task<Nocturne.Common.Models.Client[]> GetAllClientsAsync() {
            return base.Channel.GetAllClientsAsync();
        }
        
        public Nocturne.Common.Models.Client GetClient(int id) {
            return base.Channel.GetClient(id);
        }
        
        public System.Threading.Tasks.Task<Nocturne.Common.Models.Client> GetClientAsync(int id) {
            return base.Channel.GetClientAsync(id);
        }
        
        public Nocturne.Common.Models.ValidationResult<int> SaveClient(Nocturne.Common.Models.Client customer) {
            return base.Channel.SaveClient(customer);
        }
        
        public System.Threading.Tasks.Task<Nocturne.Common.Models.ValidationResult<int>> SaveClientAsync(Nocturne.Common.Models.Client customer) {
            return base.Channel.SaveClientAsync(customer);
        }
        
        public Nocturne.Common.Models.Product[] GetAllProducts() {
            return base.Channel.GetAllProducts();
        }
        
        public System.Threading.Tasks.Task<Nocturne.Common.Models.Product[]> GetAllProductsAsync() {
            return base.Channel.GetAllProductsAsync();
        }
        
        public Nocturne.Common.Models.Product GetProduct(int id) {
            return base.Channel.GetProduct(id);
        }
        
        public System.Threading.Tasks.Task<Nocturne.Common.Models.Product> GetProductAsync(int id) {
            return base.Channel.GetProductAsync(id);
        }
        
        public Nocturne.Common.Models.ValidationResult<int> SaveProduct(Nocturne.Common.Models.Product product) {
            return base.Channel.SaveProduct(product);
        }
        
        public System.Threading.Tasks.Task<Nocturne.Common.Models.ValidationResult<int>> SaveProductAsync(Nocturne.Common.Models.Product product) {
            return base.Channel.SaveProductAsync(product);
        }
        
        public Nocturne.Common.Models.DiscountType[] GetAllDiscountTypes() {
            return base.Channel.GetAllDiscountTypes();
        }
        
        public System.Threading.Tasks.Task<Nocturne.Common.Models.DiscountType[]> GetAllDiscountTypesAsync() {
            return base.Channel.GetAllDiscountTypesAsync();
        }
        
        public Nocturne.Common.Models.DiscountType GetDiscountType(int id) {
            return base.Channel.GetDiscountType(id);
        }
        
        public System.Threading.Tasks.Task<Nocturne.Common.Models.DiscountType> GetDiscountTypeAsync(int id) {
            return base.Channel.GetDiscountTypeAsync(id);
        }
        
        public Nocturne.Common.Models.ValidationResult<int> SaveDiscountType(Nocturne.Common.Models.DiscountType discountType) {
            return base.Channel.SaveDiscountType(discountType);
        }
        
        public System.Threading.Tasks.Task<Nocturne.Common.Models.ValidationResult<int>> SaveDiscountTypeAsync(Nocturne.Common.Models.DiscountType discountType) {
            return base.Channel.SaveDiscountTypeAsync(discountType);
        }
        
        public Nocturne.Common.Models.Discount[] GetAllDiscounts() {
            return base.Channel.GetAllDiscounts();
        }
        
        public System.Threading.Tasks.Task<Nocturne.Common.Models.Discount[]> GetAllDiscountsAsync() {
            return base.Channel.GetAllDiscountsAsync();
        }
        
        public Nocturne.Common.Models.Discount GetDiscount(int id) {
            return base.Channel.GetDiscount(id);
        }
        
        public System.Threading.Tasks.Task<Nocturne.Common.Models.Discount> GetDiscountAsync(int id) {
            return base.Channel.GetDiscountAsync(id);
        }
        
        public Nocturne.Common.Models.ValidationResult<int> SaveDiscount(Nocturne.Common.Models.Discount discount) {
            return base.Channel.SaveDiscount(discount);
        }
        
        public System.Threading.Tasks.Task<Nocturne.Common.Models.ValidationResult<int>> SaveDiscountAsync(Nocturne.Common.Models.Discount discount) {
            return base.Channel.SaveDiscountAsync(discount);
        }
        
        public Nocturne.Common.Models.User[] GetAllUsers() {
            return base.Channel.GetAllUsers();
        }
        
        public System.Threading.Tasks.Task<Nocturne.Common.Models.User[]> GetAllUsersAsync() {
            return base.Channel.GetAllUsersAsync();
        }
        
        public Nocturne.Common.Models.User GetUser(int id) {
            return base.Channel.GetUser(id);
        }
        
        public System.Threading.Tasks.Task<Nocturne.Common.Models.User> GetUserAsync(int id) {
            return base.Channel.GetUserAsync(id);
        }
        
        public Nocturne.Common.Models.ValidationResult<int> SaveUser(Nocturne.Common.Models.User user) {
            return base.Channel.SaveUser(user);
        }
        
        public System.Threading.Tasks.Task<Nocturne.Common.Models.ValidationResult<int>> SaveUserAsync(Nocturne.Common.Models.User user) {
            return base.Channel.SaveUserAsync(user);
        }
        
        public Nocturne.Common.Models.Role[] GetAvaliableRoles() {
            return base.Channel.GetAvaliableRoles();
        }
        
        public System.Threading.Tasks.Task<Nocturne.Common.Models.Role[]> GetAvaliableRolesAsync() {
            return base.Channel.GetAvaliableRolesAsync();
        }
    }
}
