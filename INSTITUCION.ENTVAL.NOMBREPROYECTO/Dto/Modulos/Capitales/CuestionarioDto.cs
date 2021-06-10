using INSTITUCION.ENTVAL.NOMBREPROYECTO.Validaciones.Modulos.Capitales;
using System.Collections.Generic;

namespace INSTITUCION.ENTVAL.NOMBREPROYECTO.Dto.Modulos.Capitales
{
    /// <summary>
    /// Clase que define la estructura de datos del cuestionario de preguntas.
    /// </summary>
    [CuestionarioValidacion()]
    public class CuestionarioDto
    {
        /// <summary>
        /// Atributo que guarda o establece la lista de países y sius capitales asociados.
        /// </summary>
        public List<CapitalesDto> ListaPaisesCapitales { get; set; }
        /// <summary>
        /// Atributo que guarda o establece el número de pregunta que va el jugador.
        /// </summary>
        public int NumeroPregunta { get; set; }
        /// <summary>
        /// Atributo que guarda o establece la cantidad de respuestas correctas que lleva el jugador.
        /// </summary>
        public int CantidadRespuestasCorrectas { get; set; }
        /// <summary>
        /// Atributo que guarda o establece la cantidad de respuestas incorrectas que lleva el jugador.
        /// </summary>
        public int CantidadRespuestasIncorrectas { get; set; }
        /// <summary>
        /// Atributo que guarda o establece la respuesta que ingresa el jugador.
        /// </summary>
        public string RespuestaJugador { get; set; }

        /// <summary>
        /// Método constructor inicializador del objeto.
        /// </summary>
        public CuestionarioDto()
        {
            foreach (var item in this.GetType().GetProperties())
            {
                if (item.PropertyType == typeof(string))
                {
                    item.SetValue(this, string.Empty);
                }
            }
            this.ListaPaisesCapitales = new List<CapitalesDto>();
        }
    }
}
