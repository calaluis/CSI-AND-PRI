using INSTITUCION.DAL.NOMBREPROYECTO.DBMS.OLEDB.Modulos.Capitales;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INSTITUCION.DAL.NOMBREPROYECTO.TEST.Inicio.Modulos.Capitales
{
    [TestClass]
    public class CapitalesTest
    {
        [TestMethod]
        public void ObtenerPreguntas() 
        {
            CapitalesDal DAL = new CapitalesDal();
            var ObtDatos = DAL.ObtenerPreguntas();
            Assert.AreEqual(ObtDatos.decision, true);
        }
    }
}
