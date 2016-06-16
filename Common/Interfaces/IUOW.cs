using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturne.Common.Interfaces.Repositories;

namespace Nocturne.Common.Interfaces
{
    public interface IUOW
    {
        void Commit();

        T GetRepository<T>() where T : class;

        IClientRepository Clients { get; }
        IProductRepository Products { get; }
        IDiscountTypeRepository DiscountTypes { get; }
        IDiscountRepository Discounts { get; }
        IUserRepository Users { get; }
        IMultiLangStringRepository MultiLangStrings { get; }
        ITranslationRepository Translations { get; }
        ISessionRepository Sessions { get; }

    }
}