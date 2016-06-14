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
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            using (var service = new NocturneServiceClient())
            {
                var products = service.GetAllProducts().OrderBy(c => c.Name);
                return View(products);
            }
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            using (var service = new NocturneServiceClient())
            {
                var product = service.GetProduct(id);
                return View(product);
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            var product = new Product();
            return View(product);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                using (var service = new NocturneServiceClient())
                {
                    var validationResult = service.SaveProduct(product);
                    if (validationResult.HasValidationMessageType<ValidationErrorMessage>())
                    {
                        foreach (var validationMessage in validationResult.Messages)
                        {
                            foreach (var message in validationMessage.Value)
                            {
                                ModelState.AddModelError(validationMessage.Key, message.Message);
                            }
                        }
                        return View(product);
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "System error. Try again later.");
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            using (var service = new NocturneServiceClient())
            {
                var product = service.GetProduct(id);
                return View(product);
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                using (var service = new NocturneServiceClient())
                {
                    var validationResult = service.SaveProduct(product);
                    if (validationResult.HasValidationMessageType<ValidationErrorMessage>())
                    {
                        foreach (var validationMessage in validationResult.Messages)
                        {
                            foreach (var message in validationMessage.Value)
                            {
                                ModelState.AddModelError(validationMessage.Key, message.Message);
                            }
                        }
                        return View(product);
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "System error. Try again later.");
            }
            return View(product);
        }

    }
}
