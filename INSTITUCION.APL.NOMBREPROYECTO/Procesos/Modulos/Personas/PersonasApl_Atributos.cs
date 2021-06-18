using INSTITUCION.DAL.NOMBREPROYECTO.DBMS.OLEDB.Modulos.Personas;
using INSTITUCION.ENTVAL.NOMBREPROYECTO.Interfaces.Modulos.Personas;

namespace INSTITUCION.APL.NOMBREPROYECTO.Procesos.Modulos.Personas
{
    /// <summary>
    /// Clase que define los flujos de ejecución de los procesos especificados, con fines docentes.
    /// </summary>
    public partial class PersonasApl : IPersonasApl
    {
        private PersonasDal DAL { get; set; } // Declaración del objeto, que representa el enlace hacia los métodos de la capa de datos.

        /// <summary>
        /// Método constructor inicializador del objeto.
        /// </summary>
        public PersonasApl()
        {
            DAL = new PersonasDal(); // Construcción del objeto.
        }
    }
}
