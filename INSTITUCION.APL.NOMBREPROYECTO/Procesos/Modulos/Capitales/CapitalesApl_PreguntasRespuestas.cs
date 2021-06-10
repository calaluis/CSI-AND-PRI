using HELPER.NET.ENTIDADES.Dto.Generico;
using HELPER.NET.ENTIDADES.Enumeradores.Generico;
using INSTITUCION.ENTVAL.NOMBREPROYECTO.Dto.Modulos.Capitales;
using INSTITUCION.ENTVAL.NOMBREPROYECTO.Interfaces.Modulos.Capitales;
using System.Collections.Generic;
using System.Linq;

namespace INSTITUCION.APL.NOMBREPROYECTO.Procesos.Modulos.Capitales
{
    public partial class CapitalesApl : ICapitalesApl
    {
        /// <summary>
        /// Método que permite consultar la lista de preguntas para ser respondidas.
        /// </summary>
        /// <returns>TRUE = Datos consultados sin problemas; FALSE = Problemas al consultar las preguntas.</returns>
        public Respuesta<CuestionarioDto> ConsultarPreguntas() 
        {
            Respuesta<CuestionarioDto> Resp = new Respuesta<CuestionarioDto>() 
            {
                mensaje = "Consultar Preguntas.",
                estructuraDatos = new CuestionarioDto()
            }; // La clase Respuesta, es el Dto estándar para retornar Response.

            var ObtDatos = DAL.ObtenerPreguntas(); // llamada a la capa de datos e infraestructura.
            if (!ObtDatos.decision) 
            { return Resp.MensajeGenerico(ObtDatos.CapturarDatos()); } // Cuando vienen errores, se tratan de esta forma. En este caso, se captura el mensaje de error que viene desde la capa de datos.

            Resp.estructuraDatos.ListaPaisesCapitales = ObtDatos.estructuraDatos;
            Resp.estructuraDatos.NumeroPregunta = 1;

            // Formalización de una respuesta exitosa, de este método ya ejecutado.
            Resp.decision = true;
            Resp.mensajeDetalle = "Datos consultados correctamente.";
            Resp.TipoRespuesta = TipoRespuesta.CorrectoNegocio;

            return Resp;
        }
        /// <summary>
        /// Método que permite evaluar la respuests del jugador.
        /// </summary>
        /// <param name="Datos">Los datos del cuestionario, previamente llenados.</param>
        /// <returns>TRUE = C O R R E C T O !!!; FALSE = ¡Incorrecto!, la respuesta era XXXXXXXX.</returns>
        public Respuesta<CuestionarioDto> EvaluacionPregunta(CuestionarioDto Datos) 
        {
            Respuesta<CuestionarioDto> Resp = new Respuesta<CuestionarioDto>()
            {
                mensaje = "Evaluación Pregunta.",
                estructuraDatos = Datos
            };

            if (Datos.ListaPaisesCapitales.Select(o => o.Id).Max() < Datos.NumeroPregunta)
            {
                Resp.decision = true;
                Resp.mensaje = "¡Juego Terminado!";
                Resp.mensajeDetalle = "¡¡Gracias por jugar!!";
                Resp.TipoRespuesta = TipoRespuesta.Informacion;
            }
            else
            {
                if (Datos.ListaPaisesCapitales.Where(o => o.Id == Datos.NumeroPregunta).Select(o => o.Capital).FirstOrDefault() == Datos.RespuestaJugador)
                {
                    Resp.estructuraDatos.CantidadRespuestasCorrectas = Resp.estructuraDatos.CantidadRespuestasCorrectas + 1;

                    Resp.decision = true;
                    Resp.mensajeDetalle = "C O R R E C T O !!!";
                    Resp.TipoRespuesta = TipoRespuesta.CorrectoNegocio;
                }
                else
                {
                    Resp.estructuraDatos.CantidadRespuestasIncorrectas = Resp.estructuraDatos.CantidadRespuestasIncorrectas + 1;

                    Resp.decision = false;
                    Resp.mensajeDetalle = "¡Incorrecto!, la respuesta era " + Datos.ListaPaisesCapitales.Where(o => o.Id == Datos.NumeroPregunta).Select(o => o.Capital).FirstOrDefault() + ".";
                    Resp.TipoRespuesta = TipoRespuesta.ErrorReglaNegocio;
                }

                Resp.estructuraDatos.NumeroPregunta = Resp.estructuraDatos.NumeroPregunta + 1;
            }

            Resp.estructuraDatos.RespuestaJugador = string.Empty;

            return Resp;
        }
    }
}
