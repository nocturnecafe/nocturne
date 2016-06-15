using System.Linq;
using System.Web.Mvc;
using Nocturne.Common.Interfaces;
using Nocturne.Common.Models;
using Nocturne.Web.ServiceReference;

namespace Nocturne.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUOW _uow;

        public UserController(IUOW uow)
        {
            _uow = uow;
        }


        // GET: User
        public ActionResult Index()
        {
            var users = _uow.Users.GetAllUsers().OrderBy(c => c.Name);
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = _uow.Users.GetUser(id);
            return View(user);
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
                var validationResult = _uow.Users.SaveUser(user);
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

            var user = _uow.Users.GetUser(id);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                var validationResult = _uow.Users.SaveUser(user);
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
