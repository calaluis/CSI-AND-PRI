using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace INSTITUCION.WEB.MVC.NOMBREPROYECTO
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            EngineConfig.InicializarMotor();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinderConfig.RegistrarModelos();
        }
    }
}
