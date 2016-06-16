using Nocturne.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Models
{
    public class DiscountTypeIndexViewModel: ViewModelBase
    {
        public DiscountType [] DiscountTypes { get; set; }
    }

    public class DiscountTypeCreateEditDetailsViewModel: ViewModelBase
    {
        public DiscountType DiscountType { get; set; }
    }
}