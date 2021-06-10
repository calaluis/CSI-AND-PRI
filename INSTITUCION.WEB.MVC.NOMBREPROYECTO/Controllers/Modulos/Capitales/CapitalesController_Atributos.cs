using INSTITUCION.APL.NOMBREPROYECTO.Procesos.Modulos.Capitales;
using INSTITUCION.ENTVAL.NOMBREPROYECTO.Interfaces.Modulos.Capitales;

namespace INSTITUCION.WEB.MVC.NOMBREPROYECTO.Controllers.Modulos.Capitales
{
    public partial class CapitalesController : ControllerBaseController
    {
        ICapitalesApl Negocio { get; set; }

        public CapitalesController()
        {
            this.Negocio = new CapitalesApl();
        }
    }
}