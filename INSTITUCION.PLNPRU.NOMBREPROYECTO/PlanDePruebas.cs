using INSTITUCION.DAL.NOMBREPROYECTO.DBMS.OLEDB.Modulos.Capitales;
using INSTITUCION.DAL.NOMBREPROYECTO.DBMS.OLEDB.Modulos.Personas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace INSTITUCION.PLNPRU.NOMBREPROYECTO
{
    [TestClass]
    public class PlanDePruebas
    {
        [TestInitialize]
        public void Arranque() 
        {

        }

        [TestMethod("1.- Obtener lista de preguntas."), TestCategory("DAL"), Owner("Calaluis")]
        public void ObtenerPreguntas()
        {
            CapitalesDal DAL = new CapitalesDal();
            var ObtDatos = DAL.ObtenerPreguntas();
            
            if (!ObtDatos.decision) 
            { Assert.Fail(ObtDatos.mensaje + " " + ObtDatos.mensajeDetalle); }
            
            if (!ObtDatos.estructuraDatos.Any()) 
            { Assert.Inconclusive("Debiera de dar una lista de preguntas, para lo cual no retorna nada."); }
        }

        [TestMethod("2.- Obtener lista de sexo."), TestCategory("DAL"), Owner("Calaluis")]
        public void ObtenerSexo() 
        {
            PersonasDal DAL = new PersonasDal();
            var ObtDatos = DAL.ObtenerSexo();

            if (!ObtDatos.decision) 
            { Assert.Fail(ObtDatos.mensaje + " " + ObtDatos.mensajeDetalle); }

            if (!ObtDatos.estructuraDatos.Any())
            { Assert.Inconclusive("Debiera de dar una lista de sexo, para lo cual no retorna nada."); }
        }

        [TestMethod("3.- Obtener el universo de personas."), TestCategory("DAL"), Owner("Calaluis")]
        public void ObtenerCantidadPersonas() 
        {
            PersonasDal DAL = new PersonasDal();
            var ObtDatos = DAL.ObtenerCantidadPersonas();

            if (!ObtDatos.decision)
            { Assert.Fail(ObtDatos.mensaje + " " + ObtDatos.mensajeDetalle); }

            if (ObtDatos.estructuraDatos < 1)
            { Assert.Inconclusive("Debiera de dar una lista de sexo, para lo cual no retorna nada."); }
        }
    }
}
