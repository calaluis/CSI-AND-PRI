using HELPER.NET.ENTIDADES.Dto.Generico;
using INSTITUCION.ENTVAL.NOMBREPROYECTO.Dto.Modulos.Capitales;
using System.Collections.Generic;

namespace INSTITUCION.ENTVAL.NOMBREPROYECTO.Interfaces.Modulos.Capitales
{
    /// <summary>
    /// interfaz que define los comportamientos que serán presentados, con fines docentes.
    /// </summary>
    public interface ICapitalesApl
    {
        /// <summary>
        /// Método que permite consultar la lista de preguntas para ser respondidas.
        /// </summary>
        /// <returns>TRUE = Datos consultados sin problemas; FALSE = Problemas al consultar las preguntas.</returns>
        Respuesta<CuestionarioDto> ConsultarPreguntas();
        /// <summary>
        /// Método que permite evaluar la respuests del jugador.
        /// </summary>
        /// <param name="Datos">Los datos del cuestionario, previamente llenados.</param>
        /// <returns>TRUE = C O R R E C T O !!!; FALSE = ¡Incorrecto!, la respuesta era XXXXXXXX.</returns>
        Respuesta<CuestionarioDto> EvaluacionPregunta(CuestionarioDto Datos);
    }
}
