using Nocturne.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Models
{
    public class ClientIndexViewModel: ViewModelBase
    {
        public Client[] Clients { get; set; }
    }

    public class ClientCreateEditDetailsViewModel : ViewModelBase
    {
        public Client Client { get; set; }
    }

}