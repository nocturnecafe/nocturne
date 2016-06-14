using Nocturne.Common.Models;
using Nocturne.Web.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nocturne.Web.Controllers
{
    [Authorize]
    public class DiscountTypeController : Controller
    {
        // GET: DiscountType
        public ActionResult Index()
        {
            using (var service = new NocturneServiceClient())
            {
                var discountTypes = service.GetAllDiscountTypes().OrderBy(c => c.Name);
                return View(discountTypes);
            }
        }

        // GET: DiscountType/Details/5
        public ActionResult Details(int id)
        {
            using (var service = new NocturneServiceClient())
            {
                var discountType = service.GetDiscountType(id);
                return View(discountType);
            }
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
                using (var service = new NocturneServiceClient())
                {
                    var validationResult = service.SaveDiscountType(discountType);
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
            using (var service = new NocturneServiceClient())
            {
                var discountType = service.GetDiscountType(id);
                return View(discountType);
            }
        }

        // POST: DiscountType/Edit/5
        [HttpPost]
        public ActionResult Edit(DiscountType discountType)
        {
            try
            {
                using (var service = new NocturneServiceClient())
                {
                    var validationResult = service.SaveDiscountType(discountType);
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
