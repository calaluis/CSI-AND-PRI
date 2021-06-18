using INSTITUCION.ENTVAL.NOMBREPROYECTO.Dto.Modulos.Personas;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace INSTITUCION.ENTVAL.NOMBREPROYECTO.Validaciones.Modulos.Personas
{
    /// <summary>
    /// Clase de anotación de datos que permite validar el objeto completo, 
    /// correspondiente a la clase de entidad PersonaDto.
    /// </summary>
    public class PersonaValidacionAttribute : ValidationAttribute
    {
        /// <summary>
        /// Metodo que permite validar el objeto de la clase PersonaDto.
        /// </summary>
        /// <param name="value">El objeto de la clase PersonaDto, previamente llenado.</param>
        /// <param name="validationContext">El contexto de la validacion interna.</param>
        /// <returns>TRUE = Cumple; FALSE = No cumple.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<string> ListaErrores = new List<string>();

            #region Flujo de Validación.

            PersonaDto Datos = (PersonaDto)value;

            if (string.IsNullOrEmpty(Datos.Nombre))
            {
                ListaErrores.Add("El nombre es requerido.");
            }
            if (string.IsNullOrEmpty(Datos.ApellidoPaterno)) 
            {
                ListaErrores.Add("El Apellido Paterno es requerido.");
            }
            if (string.IsNullOrEmpty(Datos.ApellidoMaterno)) 
            {
                ListaErrores.Add("El Apellido Materno es requerido.");
            }
            if (!Datos.Sexo.Where(o => o.esSeleccionado && !string.IsNullOrEmpty(o.numeroOpcion)).Any()) 
            {
                ListaErrores.Add("El Sexo es requerido.");
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
