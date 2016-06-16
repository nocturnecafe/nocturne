using System.Web.Mvc;
using Web.Models;

namespace Nocturne.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View(new HomeIndexViewModel());
        }
    }
}