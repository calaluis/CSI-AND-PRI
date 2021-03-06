using INSTITUCION.WEB.MVC.NOMBREPROYECTO.Models.Modulos.Capitales;
using INSTITUCION.WEB.MVC.NOMBREPROYECTO.Models.Modulos.Personas;
using System.Web.Mvc;

namespace INSTITUCION.WEB.MVC.NOMBREPROYECTO
{
    public class ModelBinderConfig
    {
        public static void RegistrarModelos() 
        {
            #region Módulos.

            #region Capitales.

            ModelBinders.Binders.Add(typeof(CapitalesVm), new CapitalesVm());

            #endregion

            #region Personas.

            ModelBinders.Binders.Add(typeof(PersonasVm), new PersonasVm());

            #endregion

            #endregion
        }
    }
}