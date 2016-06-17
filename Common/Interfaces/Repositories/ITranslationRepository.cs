using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturne.Common.Models;

namespace Nocturne.Common.Interfaces.Repositories
{
    public interface ITranslationRepository
    {
        Translation[] GetTranslationsByMultiLangStringId(int id);
        Translation[] GetAllTranslations();

    }
}
