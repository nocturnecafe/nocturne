using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nocturne.Common.Interfaces;

namespace Web.Models
{
    public class ViewModelBase
    {
        public string Title { get; set; }

        public int ClientCount { get; set; }

        public ViewModelBase()
        {
            ClientCount = DependencyResolver.Current.GetService<IUOW>().Sessions.GetActiveSessionCount();
        }

    }
}