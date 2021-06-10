using INSTITUCION.ENTVAL.NOMBREPROYECTO.Dto.Modulos.Capitales;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace INSTITUCION.ENTVAL.NOMBREPROYECTO.Validaciones.Modulos.Capitales
{
    /// <summary>
    /// Clase de anotación de datos que permite validar el objeto completo, 
    /// correspondiente a la clase de entidad CuestionarioDto.
    /// </summary>
    public class CuestionarioValidacionAttribute : ValidationAttribute
    {
        /// <summary>
        /// Metodo que permite validar el objeto de la clase CuestionarioDto.
        /// </summary>
        /// <param name="value">El objeto de la clase CuestionarioDto, previamente llenado.</param>
        /// <param name="validationContext">El contexto de la validacion interna.</param>
        /// <returns>TRUE = Cumple; FALSE = No cumple.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<string> ListaErrores = new List<string>();

            #region Flujo de Validación.

            CuestionarioDto Datos = (CuestionarioDto)value;

            if (string.IsNullOrEmpty(Datos.RespuestaJugador)) 
            {
                ListaErrores.Add("Su respuesta, es requerida.");
            }

            #endregion

            if (ListaErrores.Any())
            {
                return new ValidationResult("Errores en el formulario", ListaErrores.AsEnumerable());
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
