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
        public Translation GetTranslationByMultiLangStringId(int id, string culture)
        {
            using (var dc = new NocturneContext())
            {
                return dc.Translations.SingleOrDefault(s => s.MultiLangStringId == id && s.Culture.Equals(culture));
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
