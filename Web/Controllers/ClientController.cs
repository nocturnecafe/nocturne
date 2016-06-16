using System.Linq;
using System.Web.Mvc;
using Nocturne.Common.Interfaces;
using Nocturne.Common.Models;
using Web.Models;

namespace Nocturne.Web.Controllers
{
    [Authorize]
    public class ClientController : BaseController
    {
        private readonly IUOW _uow;

        public ClientController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Client
        public ActionResult Index()
        {
            var clients = _uow.Clients.GetAllClients().OrderBy(c => c.IdCode).ToArray();
            return View(new ClientIndexViewModel() { Clients = clients});
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            var client = _uow.Clients.GetClient(id);
            return View(new ClientCreateEditDetailsViewModel() { Client = client});
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            var client = new Client();
            return View(new ClientCreateEditDetailsViewModel() { Client = client});
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(ClientCreateEditDetailsViewModel vm)
        {
            try
            {
                var validationResult = _uow.Clients.SaveClient(vm.Client);
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

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            var client = _uow.Clients.GetClient(id);
            return View(new ClientCreateEditDetailsViewModel() {Client = client});
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(ClientCreateEditDetailsViewModel vm)
        {
            try
            {
                var validationResult = _uow.Clients.SaveClient(vm.Client);
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
