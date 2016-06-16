using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.WCF.ServiceReference;
using Nocturne.Common.Interfaces.Repositories;

namespace DAL.WCF.Repositories
{
    public class SessionRepository : WcfRepository, ISessionRepository
    {
        public int GetActiveSessionCount()
        {
            return Service.GetActiveSessionCount();
        }

        public SessionRepository(NocturneServiceClient service): base(service)
        {
                
        }
    }
}
