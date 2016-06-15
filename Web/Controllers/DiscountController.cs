using Nocturne.Common.Interfaces;
using Nocturne.Common.Models;
using Nocturne.Web.ServiceReference;
using System.Linq;
using System.Web.Mvc;

namespace Nocturne.Web.Controllers
{
    [Authorize]
    public class DiscountController : Controller
    {
        private readonly IUOW _uow;

        public DiscountController(IUOW uow)
        {
            _uow = uow;
        }


        // GET: Discount
        public ActionResult Index()
        {
            var discounts = _uow.Discounts.GetAllDiscounts().ToList();
            var discountTypes = _uow.DiscountTypes.GetAllDiscountTypes();
            var products = _uow.Products.GetAllProducts();
            discounts.ForEach(d => d.DiscountType = discountTypes.Single(dt => dt.Id == d.DiscountTypeId));
            discounts.ForEach(d => d.Product = products.Single(p => p.Id == d.ProductId));
            return View(discounts.OrderBy(c => c.Id));
        }

        // GET: Discount/Details/5
        public ActionResult Details(int id)
        {
            var discount = _uow.Discounts.GetDiscount(id);
            var discountTypes = _uow.DiscountTypes.GetAllDiscountTypes();
            var products = _uow.Products.GetAllProducts();
            discount.DiscountType = discountTypes.Single(dt => dt.Id == discount.DiscountTypeId);
            discount.Product = products.Single(p => p.Id == discount.ProductId);
            return View(discount);
        }

        // GET: Discount/Create
        public ActionResult Create()
        {
            var discount = new Discount();
            FillDropdowns();
            return View(discount);
        }

        // POST: Discount/Create
        [HttpPost]
        public ActionResult Create(Discount discount)
        {
            try
            {
                var validationResult = _uow.Discounts.SaveDiscount(discount);
                if (validationResult.HasValidationMessageType<ValidationErrorMessage>())
                {
                    foreach (var validationMessage in validationResult.Messages)
                    {
                        foreach (var message in validationMessage.Value)
                        {
                            ModelState.AddModelError(validationMessage.Key, message.Message);
                        }
                    }

                    FillDropdowns();

                    return View(discount);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "System error. Try again later.");
            }
            FillDropdowns();
            return View(discount);
        }

        // GET: Discount/Edit/5
        public ActionResult Edit(int id)
        {
            var discount = _uow.Discounts.GetDiscount(id);
            FillDropdowns();

            return View(discount);
        }

        // POST: Discount/Edit/5
        [HttpPost]
        public ActionResult Edit(Discount discount)
        {
            try
            {
                var validationResult = _uow.Discounts.SaveDiscount(discount);
                if (validationResult.HasValidationMessageType<ValidationErrorMessage>())
                {
                    foreach (var validationMessage in validationResult.Messages)
                    {
                        foreach (var message in validationMessage.Value)
                        {
                            ModelState.AddModelError(validationMessage.Key, message.Message);
                        }
                    }

                    FillDropdowns();
                    return View(discount);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "System error. Try again later.");
            }
            FillDropdowns();
            return View(discount);
        }

        private void FillDropdowns()
        {
            var discountTypes = _uow.DiscountTypes.GetAllDiscountTypes();
            ViewBag.DiscountTypeSelector = new SelectList(discountTypes, "Id", "Name.Value");
            var products = _uow.Products.GetAllProducts();
            ViewBag.ProductsSelector = new SelectList(products, "Id", "Name.Value");
        }
    }
}
