using System.Web.Optimization;

namespace INSTITUCION.WEB.MVC.NOMBREPROYECTO
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts.

            BundleTable.EnableOptimizations = true;

            #region General.

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css"));

            #endregion

            #region Shared.

            bundles.Add(new ScriptBundle("~/bundles/Shared/_Cargando").Include(
                "~/Scripts/Shared/_Cargando.js"));
            bundles.Add(new ScriptBundle("~/bundles/Shared/_MensajeGenerico").Include(
                "~/Scripts/Shared/_MensajeGenerico.js"));

            #endregion

            #region Módulos.

            #region Capitales.

            bundles.Add(new ScriptBundle("~/bundles/Modulos/Capitales/_InicioContenido").Include(
                "~/Scripts/Modulos/Capitales/_InicioContenido.js"));

            #endregion

            #endregion

            #endregion
        }
    }
}
