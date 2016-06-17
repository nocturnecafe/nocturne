using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.WCF.ServiceReference;
using Nocturne.Common.Interfaces.Repositories;
using Nocturne.Common.Models;

namespace DAL.WCF.Repositories
{
    public class TranslationRepository : WcfRepository, ITranslationRepository
    {
        public Translation[] GetAllTranslations()
        {
            return Service.GetAllTranslations();
        }

        public Translation[] GetTranslationsByMultiLangStringId(int id)
        {
            return Service.GetTranslationsByMultiLangStringId(id);
        }

        public TranslationRepository(NocturneServiceClient service): base(service)
        {
                
        }
    }
}
