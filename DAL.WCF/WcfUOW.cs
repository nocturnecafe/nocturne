using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.WCF.Repositories;
using DAL.WCF.ServiceReference;
using Nocturne.Common.Interfaces;
using Nocturne.Common.Interfaces.Repositories;

namespace DAL.WCF
{
    public class WcfUOW: IUOW, IDisposable
    {
        private readonly NocturneServiceClient _serviceClient = new NocturneServiceClient();

        private readonly IDictionary<Type, Func<NocturneServiceClient, object>> _repositoryFactories;
       
        private readonly IDictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public WcfUOW()
        {
            _repositoryFactories = GetCustomFactories();
        }

        private IDictionary<Type, Func<NocturneServiceClient, object>> GetCustomFactories()
        {
            return new Dictionary<Type, Func<NocturneServiceClient, object>>
            {
                {typeof(IClientRepository), (serviceClient) => new ClientRepository(serviceClient) },
                {typeof(IProductRepository), (serviceClient) => new ProductRepository(serviceClient)},
                {typeof(IDiscountTypeRepository), (serviceClient) => new DiscountTypeRepository(serviceClient)},
                {typeof(IDiscountRepository), (serviceClient) => new DiscountRepository(serviceClient)},
                {typeof(IUserRepository), (serviceClient) => new UserRepository(serviceClient)},
                {typeof(IMultiLangStringRepository), (serviceClient) => new MultiLangStringRepository(serviceClient)},
                {typeof(ITranslationRepository), (serviceClient) => new TranslationRepository(serviceClient)},
                {typeof(ISessionRepository), (serviceClient) => new SessionRepository(serviceClient) }

            };
        }

        public T GetRepository<T>() where T : class
        {
            object repo;
            _repositories.TryGetValue(typeof(T), out repo);
            if (repo != null)
            {
                return (T) repo;
            }
            return MakeRepository<T>();
        }

        private T MakeRepository<T>() where T : class
        {

            // repo factory (delegate), not yet initialized
            Func<NocturneServiceClient, object> repoFactory;

            // try to get factroy for this repo type
            _repositoryFactories.TryGetValue(typeof(T), out repoFactory);
            if (repoFactory == null)
            {
                throw new NotImplementedException("No factory for repository type: " + typeof(T).FullName);
            }

            // make the repo
            var repo = (T)repoFactory(_serviceClient);

            // save it to dictionary
            _repositories[typeof(T)] = repo;

            //return it
            return repo;
        }

        public IClientRepository Clients => GetRepository<IClientRepository>();
        public IProductRepository Products => GetRepository<IProductRepository>();
        public IDiscountTypeRepository DiscountTypes => GetRepository<IDiscountTypeRepository>();
        public IDiscountRepository Discounts => GetRepository<IDiscountRepository>();
        public IUserRepository Users => GetRepository<IUserRepository>();
        public IMultiLangStringRepository MultiLangStrings => GetRepository<IMultiLangStringRepository>();
        public ITranslationRepository Translations => GetRepository<ITranslationRepository>();
        public ISessionRepository Sessions => GetRepository<ISessionRepository>();
        

        public void Commit()
        {
        }

        public void Dispose()
        {
        }
    }
}
