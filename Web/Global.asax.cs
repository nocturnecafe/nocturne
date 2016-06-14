using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Nocturne.Web.ServiceReference;
using Nocturne.Web;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            using (var service = new NocturneServiceClient())
            {
                service.InitializeDatabase();
            }
        }

        protected void Application_ResolveRequestCache()
        {
            WebUtils.SetUserLocale("et", "et,en");
        }
    }
}
