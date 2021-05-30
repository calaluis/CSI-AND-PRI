using System.Web;
using System.Web.Mvc;

namespace INSTITUCION.WEB.MVC.NOMBREPROYECTO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
