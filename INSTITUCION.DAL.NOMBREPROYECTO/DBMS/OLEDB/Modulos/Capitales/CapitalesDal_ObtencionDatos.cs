using HELPER.NET.DAL.OLEDB;
using HELPER.NET.ENTIDADES.Dto.Dal;
using HELPER.NET.ENTIDADES.Dto.Generico;
using INSTITUCION.ENTVAL.NOMBREPROYECTO.Dto.Modulos.Capitales;
using System.Collections.Generic;

namespace INSTITUCION.DAL.NOMBREPROYECTO.DBMS.OLEDB.Modulos.Capitales
{
    public partial class CapitalesDal
    {
        /// <summary>
        /// Método que permite obtener la lista de preguntas.
        /// </summary>
        /// <returns>TRUE = Datos obtenidos correctamente; FALSE = Problemas al obtener los datos.</returns>
        public Respuesta<List<CapitalesDto>> ObtenerPreguntas() 
        {
            Respuesta<List<CapitalesDto>> Resp = new Respuesta<List<CapitalesDto>>()
            {
                estructuraDatos = new List<CapitalesDto>(),
                mensaje = "Obtener Preguntas."
            };

            string Query = "SELECT * FROM PaisesCapitales";

            List<MapeoColumnas> Map = new List<MapeoColumnas>();
            Map.Add(new MapeoColumnas("Id", "Id"));
            Map.Add(new MapeoColumnas("Pais", "Pais"));
            Map.Add(new MapeoColumnas("Capital", "Capital"));

            OleDbComunExtension<CapitalesDto> Ext = new OleDbComunExtension<CapitalesDto>(this.Comun, this.GetType().Namespace);
            Resp = Ext.ProcesarQueryTipoSelectDTO(Query, Map);

            return Resp;
        }
    }
}
