using Nocturne.Common.Models;
using System.Linq;
using System.Web.Mvc;
using Nocturne.Common.Interfaces;
using Web.Models;

namespace Nocturne.Web.Controllers
{
    [Authorize]
    public class DiscountTypeController : BaseController
    {
        private readonly IUOW _uow;

        public DiscountTypeController(IUOW uow)
        {
            _uow = uow;
        }


        // GET: DiscountType
        public ActionResult Index()
        {

            var discountTypes = _uow.DiscountTypes.GetAllDiscountTypes().OrderBy(c => c.Name.Value).ToArray();
            return View(new DiscountTypeIndexViewModel() { DiscountTypes = discountTypes });
        }

        // GET: DiscountType/Details/5
        public ActionResult Details(int id)
        {

            var discountType = _uow.DiscountTypes.GetDiscountType(id);
            return View(new DiscountTypeCreateEditDetailsViewModel() { DiscountType = discountType });
        }

        // GET: DiscountType/Create
        public ActionResult Create()
        {
            var discountType = new DiscountType();
            return View(new DiscountTypeCreateEditDetailsViewModel() { DiscountType = discountType });
        }

        // POST: DiscountType/Create
        [HttpPost]
        public ActionResult Create(DiscountTypeCreateEditDetailsViewModel vm)
        {
            try
            {
                var validationResult = _uow.DiscountTypes.SaveDiscountType(vm.DiscountType);
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

        // GET: DiscountType/Edit/5
        public ActionResult Edit(int id)
        {
            var discountType = _uow.DiscountTypes.GetDiscountType(id);
            return View(new DiscountTypeCreateEditDetailsViewModel() { DiscountType = discountType });
        }

        // POST: DiscountType/Edit/5
        [HttpPost]
        public ActionResult Edit(DiscountTypeCreateEditDetailsViewModel vm)
        {
            try
            {
                var validationResult = _uow.DiscountTypes.SaveDiscountType(vm.DiscountType);
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
