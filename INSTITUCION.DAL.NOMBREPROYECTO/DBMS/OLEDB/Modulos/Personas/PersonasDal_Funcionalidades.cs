using HELPER.NET.DAL.OLEDB;
using HELPER.NET.ENTIDADES.Dto.Dal;
using HELPER.NET.ENTIDADES.Dto.Generico;
using HELPER.NET.ENTIDADES.Enumeradores.Generico;
using HELPER.NET.ENTIDADES.Utilidades;
using INSTITUCION.ENTVAL.NOMBREPROYECTO.Dto.Modulos.Personas;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace INSTITUCION.DAL.NOMBREPROYECTO.DBMS.OLEDB.Modulos.Personas
{
    public partial class PersonasDal
    {
        /// <summary>
        /// Método que permite ingresar una nueva persona a la base de datos.
        /// </summary>
        /// <param name="Datos">Los datos de la persona, previamente llenados.</param>
        /// <returns>TRUE = Operación realizada correctamente; FALSE = Problemas al ejecutar la operación.</returns>
        public Respuesta<string> IngresarPersona(PersonaDto Datos) 
        {
            Respuesta<string> Resp = new Respuesta<string>();

            var ObtQuery = Ensamblado.LeerArchivoTextoDesdeEnsamblado("InsertarPersona.sql", "INSTITUCION.DAL.NOMBREPROYECTO");
            if (!ObtQuery.decision) 
            { return Resp.MensajeGenerico(ObtQuery.CapturarDatos()); }

            string Query = ObtQuery.estructuraDatos;

            Query = Query.Replace("[NOMBRE]", Datos.Nombre);
            Query = Query.Replace("[APP]", Datos.ApellidoPaterno);
            Query = Query.Replace("[APM]", Datos.ApellidoMaterno);
            Query = Query.Replace("[SEXO]", Datos.Sexo.Where(o => o.esSeleccionado).Select(o => o.numeroOpcion).FirstOrDefault());

            Resp = Comun.ProcesarQueryEnDuroTipoTransaccional(Query);

            return Resp;
        }
        /// <summary>
        /// Método que permite obtener la lista de sexo definidos en el sistema.
        /// </summary>
        /// <returns>TRUE = Datos obtenidos correctamente; FALSE = Problemas al obtener los datos.</returns>
        public Respuesta<List<DatoComboBox>> ObtenerSexo() 
        {
            Respuesta<List<DatoComboBox>> Resp = new Respuesta<List<DatoComboBox>>() 
            {
                mensaje = "Consultar Sexo.",
                estructuraDatos = new List<DatoComboBox>()
            };

            var ObtQuery = Ensamblado.LeerArchivoTextoDesdeEnsamblado("ConsultarSexo.sql", "INSTITUCION.DAL.NOMBREPROYECTO");
            if (!ObtQuery.decision) 
            { return Resp.MensajeGenerico(ObtQuery.CapturarDatos()); }

            string Query = ObtQuery.estructuraDatos;

            List<MapeoColumnas> Map = new List<MapeoColumnas>();
            Map.Add(new MapeoColumnas("numeroOpcion", "Id"));
            Map.Add(new MapeoColumnas("nombreOpcion", "Descripcion"));
            Map.Add(new MapeoColumnas("esSeleccionado", "", false));

            OleDbComunExtension<DatoComboBox> Ext = new OleDbComunExtension<DatoComboBox>(this.Comun, this.GetType().Namespace);
            Resp = Ext.ProcesarQueryTipoSelectDTO(Query, Map);

            return Resp;
        }
        /// <summary>
        /// Método que permite obtener la cantidad de personas registradas en el sistema.
        /// </summary>
        /// <returns>TRUE = Datos obtenidos correctamente; FALSE = Problemas al obtener los datos.</returns>
        public Respuesta<int> ObtenerCantidadPersonas() 
        {
            Respuesta<int> Resp = new Respuesta<int>() 
            {
                mensaje = "Obtener Cantidad Personas."
            };

            var ObtQuery = Ensamblado.LeerArchivoTextoDesdeEnsamblado("ConsultarCantidadPersonas.sql", "INSTITUCION.DAL.NOMBREPROYECTO");
            if (!ObtQuery.decision)
            { return Resp.MensajeGenerico(ObtQuery.CapturarDatos()); }

            string Query = ObtQuery.estructuraDatos;

            var RespQuery = Comun.ProcesarQueryEnDuroTipoSelect(Query);
            if (!RespQuery.decision) 
            { return Resp.MensajeGenerico(RespQuery.CapturarDatos()); }

            Resp.estructuraDatos = Conversion.ConvierteStringAEntero32(RespQuery.estructuraDatos.Select(null, null, DataViewRowState.CurrentRows)[0].ItemArray[0].ToString());

            Resp.decision = true;
            Resp.mensajeDetalle = "Datos obtenidos correctamente.";
            Resp.TipoRespuesta = TipoRespuesta.CorrectoTecnico;

            return Resp;
        }
        /// <summary>
        /// Método que permite obtener la lista de personas registradas en el sistema.
        /// </summary>
        /// <returns>TRUE = Datos obtenidos correctamente; FALSE = Problemas al obtener los datos.</returns>
        public Respuesta<List<PersonaDto>> ObtenerPersonas(PaginacionMuestreoOptimizado Datos) 
        {
            Respuesta<List<PersonaDto>> Resp = new Respuesta<List<PersonaDto>>();

            var ObtSexo = ObtenerSexo();
            if (!ObtSexo.decision) 
            { return Resp.MensajeGenerico(ObtSexo.CapturarDatos()); }

            var ObtQuery = Ensamblado.LeerArchivoTextoDesdeEnsamblado("ConsultarPersonas.sql", "INSTITUCION.DAL.NOMBREPROYECTO");
            if (!ObtQuery.decision)
            { return Resp.MensajeGenerico(ObtQuery.CapturarDatos()); }

            string Query = ObtQuery.estructuraDatos;

            Query = Query.Replace("[FilaInicial]", Datos.Pag_Ini.ToString());
            Query = Query.Replace("[FilaFinal]", Datos.Pag_Fin.ToString());

            List<MapeoColumnas> Map = new List<MapeoColumnas>();
            Map.Add(new MapeoColumnas("NumeroFila", "NumeroFila"));
            Map.Add(new MapeoColumnas("Id", "Id"));
            Map.Add(new MapeoColumnas("Nombre", "Nombre"));
            Map.Add(new MapeoColumnas("ApellidoPaterno", "ApellidoPaterno"));
            Map.Add(new MapeoColumnas("ApellidoMaterno", "ApellidoMaterno"));
            Map.Add(new MapeoColumnas("Sexo", "Sexo", ObtSexo.estructuraDatos));

            OleDbComunExtension<PersonaDto> Ext = new OleDbComunExtension<PersonaDto>(this.Comun, this.GetType().Namespace);
            Resp = Ext.ProcesarQueryTipoSelectDTO(Query, Map);

            return Resp;
        }
        /// <summary>
        /// Método que permite actualizar los datos de una persona.
        /// </summary>
        /// <param name="Datos">Los datos de la persona, previamente llenados y validados.</param>
        /// <returns>TRUE = Datos actualizados correctamente; FALSE = Problemas al actualizar los datos.</returns>
        public Respuesta<string> ActualizarPersona(PersonaDto Datos) 
        {
            Respuesta<string> Resp = new Respuesta<string>() 
            {
                mensaje = "Actualizar Persona."
            };

            var ObtQuery = Ensamblado.LeerArchivoTextoDesdeEnsamblado("ActualizarPersona.sql", "INSTITUCION.DAL.NOMBREPROYECTO");
            if (!ObtQuery.decision)
            { return Resp.MensajeGenerico(ObtQuery.CapturarDatos()); }

            string Query = ObtQuery.estructuraDatos;

            Query = Query.Replace("[NOMBRE]", Datos.Nombre);
            Query = Query.Replace("[APP]", Datos.ApellidoPaterno);
            Query = Query.Replace("[APM]", Datos.ApellidoMaterno);
            Query = Query.Replace("[SEXO]", Datos.Sexo.Where(o => o.esSeleccionado).Select(o => o.numeroOpcion).FirstOrDefault());
            Query = Query.Replace("[ID]", Datos.Id.ToString());

            var ActPersona = this.Comun.ProcesarQueryEnDuroTipoTransaccional(Query);
            if (!ActPersona.decision) 
            { return Resp.MensajeGenerico(ActPersona.CapturarDatos()); }

            Resp.decision = true;
            Resp.mensajeDetalle = "Datos actualizados correctamente.";

            return Resp;
        }
        /// <summary>
        /// Método que permite eliminar una persona del sistema.
        /// </summary>
        /// <param name="Datos">Los datos de la persona, previamente llenados y validados.</param>
        /// <returns>TRUE = Datos actualizados correctamente; FALSE = Problemas al actualizar los datos.</returns>
        public Respuesta<string> EliminarPersona(PersonaDto Datos)
        {
            Respuesta<string> Resp = new Respuesta<string>()
            {
                mensaje = "Actualizar Persona."
            };

            var ObtQuery = Ensamblado.LeerArchivoTextoDesdeEnsamblado("EliminarPersona.sql", "INSTITUCION.DAL.NOMBREPROYECTO");
            if (!ObtQuery.decision)
            { return Resp.MensajeGenerico(ObtQuery.CapturarDatos()); }

            string Query = ObtQuery.estructuraDatos;

            Query = Query.Replace("[ID]", Datos.Id.ToString());

            var ActPersona = this.Comun.ProcesarQueryEnDuroTipoTransaccional(Query);
            if (!ActPersona.decision)
            { return Resp.MensajeGenerico(ActPersona.CapturarDatos()); }

            Resp.decision = true;
            Resp.mensajeDetalle = "Datos actualizados correctamente.";

            return Resp;
        }
    }
}
