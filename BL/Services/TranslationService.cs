using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturne.Common.Interfaces;
using Nocturne.Common.Models;

namespace Nocturne.BL.Services
{
    public class TranslationService: ITranslationService
    {
        public Translation[] GetTranslationsByMultiLangStringId(int id)
        {
            using (var dc = new NocturneContext())
            {
                return dc.Translations.Where(t => t.MultiLangStringId == id).ToArray();
            }
        }

        public Translation[] GetAllTranslations()
        {
            using (var dc = new NocturneContext())
            {
                return dc.Translations.ToArray();
            }
        }
    }
}
