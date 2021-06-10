using HELPER.NET.ENTIDADES.Dto.Generico;
using HELPER.NET.ENTIDADES.Utilidades;
using INSTITUCION.WEB.MVC.NOMBREPROYECTO.Models.Modulos.Capitales;
using System.Web.Mvc;

namespace INSTITUCION.WEB.MVC.NOMBREPROYECTO.Controllers.Modulos.Capitales
{
    public partial class CapitalesController : ControllerBaseController
    {
        public ActionResult Index() 
        {
            CapitalesVm Datos = new CapitalesVm();
            SubRespuesta Respuesta = new SubRespuesta();
            if (TempData["Mensaje"] != null)
            {
                Respuesta = (SubRespuesta)TempData["Mensaje"];
            }

            var ObtPreguntas = Negocio.ConsultarPreguntas();
            if (!ObtPreguntas.decision) 
            { return RetornarVista(ObtPreguntas.CapturarDatos(), Datos); }

            Datos.ModeloVistaNegocio = ObtPreguntas.estructuraDatos;

            return RetornarVista(Respuesta, Datos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CapitalesVm Datos, FormCollection Collection) 
        {
            SubRespuesta Respuesta = new SubRespuesta();
            string VistaParcial = "_IndexContenido";

            #region Eventos.

            if (Collection["Control"].ToString() == "Responder" && Collection["Evento"].ToString() == "click") 
            {
                var ValForm = Validacion.ValidadorMaestro(Datos.ModeloVistaNegocio);
                if (!ValForm.decision)
                {
                    string Errores = string.Join("<br />", ValForm.estructuraDatos);
                    Respuesta = ValForm.CapturarDatos();
                    Respuesta.mensajeDetalle = Errores;
                }
                else 
                {
                    var EvalPregunta = Negocio.EvaluacionPregunta(Datos.ModeloVistaNegocio);
                    Datos.ModeloVistaNegocio = EvalPregunta.estructuraDatos;
                    Respuesta = EvalPregunta.CapturarDatos();
                }
            }

            #endregion

            return RetornarVistaParcial(Respuesta, VistaParcial, Datos);
        }
    }
}