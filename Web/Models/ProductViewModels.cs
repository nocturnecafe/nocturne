using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Nocturne.Common.Models;
using Web.Models;

namespace Web.Models
{
    public class ProductIndexViewModel: ViewModelBase
    {
        public Product [] Products { get; set; }
    }

    public class ProductCreateEditDetailsViewModel : ViewModelBase
    {
        public Product Product { get; set; }

        /*[MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }*/
    }
}