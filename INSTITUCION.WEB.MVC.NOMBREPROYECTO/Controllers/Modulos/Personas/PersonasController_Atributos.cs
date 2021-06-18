using INSTITUCION.APL.NOMBREPROYECTO.Procesos.Modulos.Personas;
using INSTITUCION.ENTVAL.NOMBREPROYECTO.Interfaces.Modulos.Personas;

namespace INSTITUCION.WEB.MVC.NOMBREPROYECTO.Controllers.Modulos.Personas
{
    public partial class PersonasController : ControllerBaseController
    {
        private IPersonasApl Negocio { get; set; }

        public PersonasController()
        {
            Negocio = new PersonasApl();
        }
    }
}