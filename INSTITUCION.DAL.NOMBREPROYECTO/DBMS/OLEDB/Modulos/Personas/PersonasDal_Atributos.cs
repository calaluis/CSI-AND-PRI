using HELPER.NET.DAL.OLEDB;

namespace INSTITUCION.DAL.NOMBREPROYECTO.DBMS.OLEDB.Modulos.Personas
{
    /// <summary>
    /// Clase que define el acceso a datos a la base de datos del sistema, con fines docentes.
    /// </summary>
    public partial class PersonasDal
    {
        /// <summary>
        /// Atributo que guarda o establece al ADO.NET de acceso a datos.
        /// </summary>
        public OleDbComun Comun { get; set; }

        /// <summary>
        /// Método constructor inicializador del objeto.
        /// </summary>
        public PersonasDal()
        {
            this.Comun = new OleDbComun("CSI_AND_PRI", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\ProyectosVisualStudio\\CSI-AND-PRI\\INSTITUCION.DAL.NOMBREPROYECTO\\DBMS\\OLEDB\\CSI_AND_PRI.mdb;Persist Security Info=True", 300);
        }
    }
}
