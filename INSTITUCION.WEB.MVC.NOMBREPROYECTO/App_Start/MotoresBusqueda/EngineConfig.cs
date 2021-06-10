using System.Web.Mvc;

namespace INSTITUCION.WEB.MVC.NOMBREPROYECTO
{
    /// <summary>
    /// Clase que define la estructura de datos del motor de busqueda 
    /// personalizado del Framework MVC.
    /// </summary>
    public class EngineConfig
    {
        /// <summary>
        /// Metodo que permite inicializar el motor de busqueda 
        /// de forma personalizada.
        /// </summary>
        public static void InicializarMotor()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new NOMBREPROYECTOViewEngine());
        }
    }
}