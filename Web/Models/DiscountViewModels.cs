using Nocturne.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Models
{
    public class DiscountIndexViewModel: ViewModelBase
    {
        public Discount [] Discounts { get; set; }
    }

    public class DiscountDetailsViewModel: ViewModelBase
    {
        public Discount Discount { get; set; }
    }

    public class DiscountCreateEditViewModel: ViewModelBase
    {
        public Discount Discount { get; set; }
        public SelectList DiscountTypeSelector { get; set; }
        public SelectList ProductsSelector { get; set; }
    }
}