using Nocturne.Common.Models;
using Nocturne.Web.ServiceReference;
using System.Linq;
using System.Web.Mvc;

namespace Nocturne.Web.Controllers
{
    [Authorize]
    public class DiscountController : Controller
    {
        // GET: Discount
        public ActionResult Index()
        {
            using (var service = new NocturneServiceClient())
            {
                var discounts = service.GetAllDiscounts().ToList();
                var discountTypes = service.GetAllDiscountTypes();
                var products = service.GetAllProducts();
                discounts.ForEach(d => d.DiscountType = discountTypes.Single(dt => dt.Id == d.DiscountTypeId));
                discounts.ForEach(d => d.Product = products.Single(p => p.Id == d.ProductId));
                return View(discounts.OrderBy(c => c.Id));
            }
        }

        // GET: Discount/Details/5
        public ActionResult Details(int id)
        {
            using (var service = new NocturneServiceClient())
            {
                var discount = service.GetDiscount(id);
                var discountTypes = service.GetAllDiscountTypes();
                var products = service.GetAllProducts();
                discount.DiscountType = discountTypes.Single(dt => dt.Id == discount.DiscountTypeId);
                discount.Product = products.Single(p => p.Id == discount.ProductId);
                return View(discount);
            }
        }

        // GET: Discount/Create
        public ActionResult Create()
        {
            var discount = new Discount();
            using (var service = new NocturneServiceClient())
            {
                FillDropdowns(service);
            }
            return View(discount);
        }

        // POST: Discount/Create
        [HttpPost]
        public ActionResult Create(Discount discount)
        {
            try
            {
                using (var service = new NocturneServiceClient())
                {
                    var validationResult = service.SaveDiscount(discount);
                    if (validationResult.HasValidationMessageType<ValidationErrorMessage>())
                    {
                        foreach (var validationMessage in validationResult.Messages)
                        {
                            foreach (var message in validationMessage.Value)
                            {
                                ModelState.AddModelError(validationMessage.Key, message.Message);
                            }
                        }

                        FillDropdowns(service);

                        return View(discount);
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "System error. Try again later.");
            }
            using (var service = new NocturneServiceClient())
            {
                FillDropdowns(service);
            }
            return View(discount);
        }

        // GET: Discount/Edit/5
        public ActionResult Edit(int id)
        {
            using (var service = new NocturneServiceClient())
            {
                var discount = service.GetDiscount(id);
                FillDropdowns(service);

                return View(discount);
            }
        }

        // POST: Discount/Edit/5
        [HttpPost]
        public ActionResult Edit(Discount discount)
        {
            try
            {
                using (var service = new NocturneServiceClient())
                {
                    var validationResult = service.SaveDiscount(discount);
                    if (validationResult.HasValidationMessageType<ValidationErrorMessage>())
                    {
                        foreach (var validationMessage in validationResult.Messages)
                        {
                            foreach (var message in validationMessage.Value)
                            {
                                ModelState.AddModelError(validationMessage.Key, message.Message);
                            }
                        }

                        FillDropdowns(service);
                        return View(discount);
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "System error. Try again later.");
            }
            using (var service = new NocturneServiceClient())
            {
                FillDropdowns(service);
            }
            return View(discount);
        }

        private void FillDropdowns(NocturneServiceClient service)
        {
            var discountTypes = service.GetAllDiscountTypes();
            ViewBag.DiscountTypeSelector = new SelectList(discountTypes, "Id", "Name");
            var products = service.GetAllProducts();
            ViewBag.ProductsSelector = new SelectList(products, "Id", "Name");
        }
    }
}
