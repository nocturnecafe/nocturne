using Nocturne.Common.Models;
using Nocturne.Web.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nocturne.Common.Interfaces;

namespace Nocturne.Web.Controllers
{
    [Authorize]
    public class DiscountTypeController : Controller
    {
        private readonly IUOW _uow;

        public DiscountTypeController(IUOW uow)
        {
            _uow = uow;
        }


        // GET: DiscountType
        public ActionResult Index()
        {

            var discountTypes = _uow.DiscountTypes.GetAllDiscountTypes().OrderBy(c => c.Name.Value);
            return View(discountTypes);
        }

        // GET: DiscountType/Details/5
        public ActionResult Details(int id)
        {

            var discountType = _uow.DiscountTypes.GetDiscountType(id);
            return View(discountType);
        }

        // GET: DiscountType/Create
        public ActionResult Create()
        {
            var discountType = new DiscountType();
            return View(discountType);
        }

        // POST: DiscountType/Create
        [HttpPost]
        public ActionResult Create(DiscountType discountType)
        {
            try
            {
                var validationResult = _uow.DiscountTypes.SaveDiscountType(discountType);
                if (validationResult.HasValidationMessageType<ValidationErrorMessage>())
                {
                    foreach (var validationMessage in validationResult.Messages)
                    {
                        foreach (var message in validationMessage.Value)
                        {
                            ModelState.AddModelError(validationMessage.Key, message.Message);
                        }
                    }
                    return View(discountType);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "System error. Try again later.");
            }
            return View(discountType);
        }

        // GET: DiscountType/Edit/5
        public ActionResult Edit(int id)
        {
            var discountType = _uow.DiscountTypes.GetDiscountType(id);
            return View(discountType);
        }

        // POST: DiscountType/Edit/5
        [HttpPost]
        public ActionResult Edit(DiscountType discountType)
        {
            try
            {
                var validationResult = _uow.DiscountTypes.SaveDiscountType(discountType);
                if (validationResult.HasValidationMessageType<ValidationErrorMessage>())
                {
                    foreach (var validationMessage in validationResult.Messages)
                    {
                        foreach (var message in validationMessage.Value)
                        {
                            ModelState.AddModelError(validationMessage.Key, message.Message);
                        }
                    }
                    return View(discountType);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "System error. Try again later.");
            }
            return View(discountType);
        }
    }
}
