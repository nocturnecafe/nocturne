using System.Linq;
using System.Web.Mvc;
using Nocturne.Common.Models;
using Nocturne.Web.ServiceReference;

namespace Nocturne.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            using (var service = new NocturneServiceClient())
            {
                var users = service.GetAllUsers().OrderBy(c => c.Name);
                return View(users);
            }
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            using (var service = new NocturneServiceClient())
            {
                var user = service.GetUser(id);
                return View(user);
            }
        }

        // GET: User/Create
        public ActionResult Create()
        {
            var user = new User();
            return View(user);
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                using (var service = new NocturneServiceClient())
                {
                    var validationResult = service.SaveUser(user);
                    if (validationResult.HasValidationMessageType<ValidationErrorMessage>())
                    {
                        foreach (var validationMessage in validationResult.Messages)
                        {
                            foreach (var message in validationMessage.Value)
                            {
                                ModelState.AddModelError(validationMessage.Key, message.Message);
                            }
                        }
                        return View(user);
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "System error. Try again later.");
            }
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            using (var service = new NocturneServiceClient())
            {
                var user = service.GetUser(id);
                return View(user);
            }
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                using (var service = new NocturneServiceClient())
                {
                    var validationResult = service.SaveUser(user);
                    if (validationResult.HasValidationMessageType<ValidationErrorMessage>())
                    {
                        foreach (var validationMessage in validationResult.Messages)
                        {
                            foreach (var message in validationMessage.Value)
                            {
                                ModelState.AddModelError(validationMessage.Key, message.Message);
                            }
                        }
                        return View(user);
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "System error. Try again later.");
            }
            return View(user);
        }
    }
}
