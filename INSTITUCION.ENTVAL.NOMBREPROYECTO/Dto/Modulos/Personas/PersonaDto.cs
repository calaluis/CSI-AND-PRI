using HELPER.NET.ENTIDADES.Dto.Generico;
using INSTITUCION.ENTVAL.NOMBREPROYECTO.Validaciones.Modulos.Personas;
using System.Collections.Generic;

namespace INSTITUCION.ENTVAL.NOMBREPROYECTO.Dto.Modulos.Personas
{
    /// <summary>
    /// Clase que define la estructura de datos de la tabla Personas albergada en Access, con fines docentes.
    /// </summary>
    [PersonaValidacion()]
    public class PersonaDto
    {
        /// <summary>
        /// Atributo que guarda o establece el número de fila desde la base de datos.
        /// </summary>
        public int NumeroFila { get; set; }
        /// <summary>
        /// Atributo que guarda o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Atributo que guarda o establece el nombre de la persona.
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Atributo que guarda o establece el apellido paterno de la persona.
        /// </summary>
        public string ApellidoPaterno { get; set; }
        /// <summary>
        /// Atributo que guarda o establece el apellido materno de la persona.
        /// </summary>
        public string ApellidoMaterno { get; set; }
        /// <summary>
        /// Atributo que guarda o establece elsexo de la persona.
        /// </summary>
        public List<DatoComboBox> Sexo { get; set; }

        /// <summary>
        /// Método constructor inicializador del objeto.
        /// </summary>
        public PersonaDto()
        {
            foreach (var item in this.GetType().GetProperties())
            {
                if (item.PropertyType == typeof(string))
                {
                    item.SetValue(this, string.Empty);
                }
            }
            this.Sexo = new List<DatoComboBox>();
        }
    }
}
