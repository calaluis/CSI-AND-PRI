using HELPER.NET.ENTIDADES.Dto.Generico;
using HELPER.NET.ENTIDADES.Enumeradores.Generico;
using System.Web.Mvc;

namespace INSTITUCION.WEB.MVC.NOMBREPROYECTO.Controllers
{
    public class ControllerBaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewData["Loading"] = Url.Content("~/Content/Img/ajax-loader.gif");
            base.OnActionExecuting(filterContext);
        }
        public ActionResult RetornarVista(SubRespuesta Respuesta, object Datos)
        {
            ViewData["Mensaje"] = Respuesta;
            return View(Datos);
        }
        public ActionResult RetornarVistaParcial(SubRespuesta Respuesta, string NombreVistaParcial, object Datos)
        {
            ViewData["Mensaje"] = Respuesta;
            return PartialView(NombreVistaParcial, Datos);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception == null) return;

            string Controlador = filterContext.RouteData.GetRequiredString("controller");
            string Vista = filterContext.RouteData.GetRequiredString("action");

            filterContext.ExceptionHandled = true;

            SubRespuesta Respuesta = new SubRespuesta() 
            {
                decision = false,
                mensaje = "Error en procesar la solicitud para la vista " + Vista + ", controlador " + Controlador + ".",
                mensajeDetalle = filterContext.Exception.Message + " Traza: " + filterContext.Exception.StackTrace,
                TipoRespuesta = TipoRespuesta.ErrorTecnico
            };

            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/Error.cshtml",
                    ViewData = new ViewDataDictionary(Respuesta)
                };
            }
            else
            {
                filterContext.Controller.TempData["Falla"] = Respuesta;
                filterContext.Result = Json(new { url = Url.Action("Error") });
            }
        }

        public ActionResult Error()
        {
            return View((SubRespuesta)TempData["Falla"]);
        }
    }
}