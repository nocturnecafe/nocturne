using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturne.Common.Interfaces;
using Nocturne.Common.Models;

namespace Nocturne.BL.Services
{
    public class MultiLangStringService : IMultiLangStringService
    {
        public MultiLangString[] GetAllMultiLangStrings()
        {
            using (var dc = new NocturneContext())
            {
                return dc.MultiLangStrings.ToArray();
            }
        }

        public MultiLangString GetMultiLangStringById(int id)
        {
            using (var dc = new NocturneContext())
            {
                return dc.MultiLangStrings.SingleOrDefault(s => s.MultiLangStringId == id);
            }
        }
    }
}
