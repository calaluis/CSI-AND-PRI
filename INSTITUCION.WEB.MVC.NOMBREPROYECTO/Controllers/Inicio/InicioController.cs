using System.Web.Mvc;

namespace INSTITUCION.WEB.MVC.NOMBREPROYECTO.Controllers
{
    public class InicioController : ControllerBaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Luis Rodrigo Carrasco Lagos (calaluis).";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Para contactarme, puede utilizar correo electrónico o la red social LinkedIn.";

            return View();
        }
    }
}