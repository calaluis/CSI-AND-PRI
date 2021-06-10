using HELPER.NET.MVC;
using System.Web.Mvc;

namespace INSTITUCION.WEB.MVC.NOMBREPROYECTO
{
    /// <summary>
    /// Clase que define la estrucrtura de datos 
    /// del motor de busqueda personalizado de NOMBREPROYECTO.
    /// </summary>
    public class NOMBREPROYECTOViewEngine : RazorViewEngine
    {
        /// <summary>
        /// Método constructor inicializador del objeto.
        /// </summary>
        public NOMBREPROYECTOViewEngine() : base() 
        {
            #region Paramteros de busqueda por defecto.

            base.AreaViewLocationFormats = new string[] {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };

            base.AreaMasterLocationFormats = new string[] {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };

            base.AreaPartialViewLocationFormats = new string[] {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };

            base.ViewLocationFormats = new string[] {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };

            base.PartialViewLocationFormats = new string[] {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };

            base.MasterLocationFormats = new string[] {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };

            base.FileExtensions = new string[] {
                "cshtml"
            };

            #endregion

            #region Parametros personalizados.

            #region Modulos.

            #region Capitales.

            base.ViewLocationFormats = Helper.AddItem(base.ViewLocationFormats, "~/Views/Modulos/{1}/{0}.cshtml");
            base.PartialViewLocationFormats = Helper.AddItem(base.PartialViewLocationFormats, "~/Views/Modulos/{1}/{0}.cshtml");
            base.MasterLocationFormats = Helper.AddItem(base.MasterLocationFormats, "~/Views/Modulos/{1}/{0}.cshtml");

            #endregion

            #endregion

            #endregion
        }
    }
}