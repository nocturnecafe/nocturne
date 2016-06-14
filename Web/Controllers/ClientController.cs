using System.Linq;
using System.Web.Mvc;
using Nocturne.Common.Models;
using Nocturne.Web.ServiceReference;

namespace Nocturne.Web.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            using (var service = new NocturneServiceClient())
            {
                var clients = service.GetAllClients().OrderBy(c => c.IdCode);
                return View(clients);
            }
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            using (var service = new NocturneServiceClient())
            {
                var client = service.GetClient(id);
                return View(client);
            }
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            var client = new Client();
            return View(client);
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(Client client)
        {
            try
            {
                using (var service = new NocturneServiceClient())
                {
                    var validationResult = service.SaveClient(client);
                    if (validationResult.HasValidationMessageType<ValidationErrorMessage>())
                    {
                        foreach (var validationMessage in validationResult.Messages)
                        {
                            foreach (var message in validationMessage.Value)
                            {
                                ModelState.AddModelError(validationMessage.Key, message.Message);
                            }
                        }
                        return View(client);
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "System error. Try again later.");
            }
            return View(client);
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            using (var service = new NocturneServiceClient())
            {
                var client = service.GetClient(id);
                return View(client);
            }
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(Client client)
        {
            try
            {
                using (var service = new NocturneServiceClient())
                {
                    var validationResult = service.SaveClient(client);
                    if (validationResult.HasValidationMessageType<ValidationErrorMessage>())
                    {
                        foreach (var validationMessage in validationResult.Messages)
                        {
                            foreach (var message in validationMessage.Value)
                            {
                                ModelState.AddModelError(validationMessage.Key, message.Message);
                            }
                        }
                        return View(client);
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "System error. Try again later.");
            }
            return View(client);
        }
    }
}
