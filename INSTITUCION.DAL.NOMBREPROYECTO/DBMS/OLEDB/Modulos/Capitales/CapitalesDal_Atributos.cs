using HELPER.NET.DAL.OLEDB;

namespace INSTITUCION.DAL.NOMBREPROYECTO.DBMS.OLEDB.Modulos.Capitales
{
    public partial class CapitalesDal
    {
        public OleDbComun Comun { get; set; }

        public CapitalesDal() 
        {
            this.Comun = new OleDbComun("CSI_AND_PRI", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\\ProyectosVisualStudio\\CSI-AND-PRI\\INSTITUCION.DAL.NOMBREPROYECTO\\DBMS\\OLEDB\\CSI_AND_PRI.mdb;Persist Security Info=True", 300);
        }
    }
}
