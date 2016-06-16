using Nocturne.Common.Interfaces;
using Nocturne.Common.Models;
using System.Linq;
using System.Web.Mvc;
using Web.Models;

namespace Nocturne.Web.Controllers
{
    [Authorize]
    public class DiscountController : BaseController
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
            return View(new DiscountIndexViewModel() { Discounts = discounts.OrderBy(c => c.Id).ToArray() });
        }

        // GET: Discount/Details/5
        public ActionResult Details(int id)
        {
            var discount = _uow.Discounts.GetDiscount(id);
            var discountTypes = _uow.DiscountTypes.GetAllDiscountTypes();
            var products = _uow.Products.GetAllProducts();
            discount.DiscountType = discountTypes.Single(dt => dt.Id == discount.DiscountTypeId);
            discount.Product = products.Single(p => p.Id == discount.ProductId);
            return View(new DiscountDetailsViewModel() { Discount = discount });
        }

        // GET: Discount/Create
        public ActionResult Create()
        {
            var discount = new Discount();
            var vm = new DiscountCreateEditViewModel() { Discount = discount };
            FillDropdowns(vm);
            return View(vm);
        }

        // POST: Discount/Create
        [HttpPost]
        public ActionResult Create(DiscountCreateEditViewModel vm)
        {
            try
            {
                var validationResult = _uow.Discounts.SaveDiscount(vm.Discount);
                if (validationResult.HasValidationMessageType<ValidationErrorMessage>())
                {
                    foreach (var validationMessage in validationResult.Messages)
                    {
                        foreach (var message in validationMessage.Value)
                        {
                            ModelState.AddModelError(validationMessage.Key, message.Message);
                        }
                    }

                    FillDropdowns(vm);

                    return View(vm);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "System error. Try again later.");
            }
            FillDropdowns(vm);
            return View(vm);
        }

        // GET: Discount/Edit/5
        public ActionResult Edit(int id)
        {
            var discount = _uow.Discounts.GetDiscount(id);
            var vm = new DiscountCreateEditViewModel() { Discount = discount };
            FillDropdowns(vm);
            return View(vm);
        }

        // POST: Discount/Edit/5
        [HttpPost]
        public ActionResult Edit(DiscountCreateEditViewModel vm)
        {
            try
            {
                var validationResult = _uow.Discounts.SaveDiscount(vm.Discount);
                if (validationResult.HasValidationMessageType<ValidationErrorMessage>())
                {
                    foreach (var validationMessage in validationResult.Messages)
                    {
                        foreach (var message in validationMessage.Value)
                        {
                            ModelState.AddModelError(validationMessage.Key, message.Message);
                        }
                    }

                    FillDropdowns(vm);
                    return View(vm);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "System error. Try again later.");
            }
            FillDropdowns(vm);
            return View(vm);
        }

        private void FillDropdowns(DiscountCreateEditViewModel vm)
        {
            var discountTypes = _uow.DiscountTypes.GetAllDiscountTypes();
            vm.DiscountTypeSelector = new SelectList(discountTypes, "Id", "Name.Value");
            var products = _uow.Products.GetAllProducts();
            vm.ProductsSelector = new SelectList(products, "Id", "Name.Value");
        }
    }
}
