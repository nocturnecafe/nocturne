using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturne.Common.Models;

namespace Nocturne.Common.Interfaces
{
    public interface IMultiLangStringService
    {
        MultiLangString GetMultiLangStringById(int id);
        MultiLangString[] GetAllMultiLangStrings();
    }
}
