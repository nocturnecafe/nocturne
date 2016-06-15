using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.WCF.ServiceReference;

namespace DAL.WCF.Repositories
{
    public class WcfRepository
    {
        private NocturneServiceClient _service;

        protected NocturneServiceClient Service
        {
            get { return _service; }
            private set { _service = value; }
        }

        public WcfRepository(NocturneServiceClient service)
        {
            _service = service;
        }

    }
}
