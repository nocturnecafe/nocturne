using Nocturne.Common.Models;
using System.Linq;
using System.Web.Mvc;
using Nocturne.Common.Interfaces;
using Web.Models;

namespace Nocturne.Web.Controllers
{
    [Authorize]
    public class ProductController : BaseController
    {
        private readonly IUOW _uow;

        public ProductController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Product
        public ActionResult Index()
        {
            var products = _uow.Products.GetAllProducts().OrderBy(c => c.Name.Value).ToArray();
            return View(new ProductIndexViewModel() {Products = products});
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = _uow.Products.GetProduct(id);
            return View(new ProductCreateEditDetailsViewModel() { Product = product });
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            var product = new Product();
            return View(new ProductCreateEditDetailsViewModel() { Product = product });
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductCreateEditDetailsViewModel vm)
        {
            try
            {
                var validationResult = _uow.Products.SaveProduct(vm.Product);
                if (validationResult.HasValidationMessageType<ValidationErrorMessage>())
                {
                    foreach (var validationMessage in validationResult.Messages)
                    {
                        foreach (var message in validationMessage.Value)
                        {
                            ModelState.AddModelError(validationMessage.Key, message.Message);
                        }
                    }
                    return View(vm);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "System error. Try again later.");
            }
            return View(vm);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _uow.Products.GetProduct(id);
            return View(new ProductCreateEditDetailsViewModel() {Product = product });
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductCreateEditDetailsViewModel vm)
        {
            try
            {
                var validationResult = _uow.Products.SaveProduct(vm.Product);
                if (validationResult.HasValidationMessageType<ValidationErrorMessage>())
                {
                    foreach (var validationMessage in validationResult.Messages)
                    {
                        foreach (var message in validationMessage.Value)
                        {
                            ModelState.AddModelError(validationMessage.Key, message.Message);
                        }
                    }
                    return View(vm);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "System error. Try again later.");
            }
            return View(vm);
        }

    }
}
