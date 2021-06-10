using INSTITUCION.DAL.NOMBREPROYECTO.DBMS.OLEDB.Modulos.Capitales;
using INSTITUCION.ENTVAL.NOMBREPROYECTO.Interfaces.Modulos.Capitales;

namespace INSTITUCION.APL.NOMBREPROYECTO.Procesos.Modulos.Capitales
{
    /// <summary>
    /// Clase que define los flujos de ejecución de los procesos especificados, con fines docentes.
    /// </summary>
    public partial class CapitalesApl : ICapitalesApl
    {
        private CapitalesDal DAL { get; set; } // Declaración del objeto, que representa el enlace hacia los métodos de la capa de datos.

        /// <summary>
        /// Método constructor inicializador del objeto.
        /// </summary>
        public CapitalesApl()
        {
            DAL = new CapitalesDal(); // Construcción del objeto.
        }
    }
}
