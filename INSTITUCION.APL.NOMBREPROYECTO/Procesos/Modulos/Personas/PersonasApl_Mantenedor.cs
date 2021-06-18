using HELPER.NET.ENTIDADES.Dto.Generico;
using HELPER.NET.ENTIDADES.Enumeradores.Generico;
using INSTITUCION.ENTVAL.NOMBREPROYECTO.Dto.Modulos.Personas;
using INSTITUCION.ENTVAL.NOMBREPROYECTO.Enumeraciones.Modulos.Personas;
using INSTITUCION.ENTVAL.NOMBREPROYECTO.Interfaces.Modulos.Personas;
using System.Collections.Generic;

namespace INSTITUCION.APL.NOMBREPROYECTO.Procesos.Modulos.Personas
{
    public partial class PersonasApl : IPersonasApl
    {
        /// <summary>
        /// Método que permite consultar los sexos registrados en el sistema.
        /// </summary>
        /// <returns>TRUE = Datos consultados correctamente; FALSE = Problemas al consultar los datos.</returns>
        public Respuesta<List<DatoComboBox>> ConsultarSexo() 
        {
            return DAL.ObtenerSexo();
        }
        /// <summary>
        /// Método que permite el ingreso de nuevas personas al sistema.
        /// </summary>
        /// <param name="Datos">Los datos de la persona, previamente llenados y validados.</param>
        /// <returns>TRUE = Ingreso realizado correctamente; FALSE = Problemas al ingresar a la persona.</returns>
        public Respuesta<MantenedorPersonasDto> IngresarPersona(MantenedorPersonasDto Datos) 
        {
            Respuesta<MantenedorPersonasDto> Resp = new Respuesta<MantenedorPersonasDto>() 
            {
                mensaje = "Ingresar Persona.",
                estructuraDatos = Datos
            };

            var IniTran = this.DAL.Comun.AbrirTransaccion();
            if (!IniTran.decision) 
            { return Resp.MensajeGenerico(IniTran.CapturarDatos()); }

            var InsPersona = this.DAL.IngresarPersona(Resp.estructuraDatos.PersonaSeleccionada);
            if (!InsPersona.decision) 
            { return Resp.MensajeGenerico(InsPersona.CapturarDatos()); }

            var EndTran = this.DAL.Comun.CerrarTransaccion();
            if (!EndTran.decision) 
            { return Resp.MensajeGenerico(EndTran.CapturarDatos()); }

            var ObtNroFilas = this.DAL.ObtenerCantidadPersonas();
            if (!ObtNroFilas.decision)
            { return Resp.MensajeGenerico(ObtNroFilas.CapturarDatos()); }

            Resp.estructuraDatos.DatosPaginacion.Nro_Filas = ObtNroFilas.estructuraDatos;

            Resp.estructuraDatos.DatosPaginacion = Resp.estructuraDatos.DatosPaginacion.ConsultaPaginacion(Resp.estructuraDatos.DatosPaginacion);

            var ObtDatos = this.DAL.ObtenerPersonas(Resp.estructuraDatos.DatosPaginacion);
            if (!ObtDatos.decision)
            { return Resp.MensajeGenerico(ObtDatos.CapturarDatos()); }

            Resp.estructuraDatos.Tupla = ObtDatos.estructuraDatos;

            Resp.decision = true;
            Resp.mensajeDetalle = "Ingreso realizado correctamente.";
            Resp.TipoRespuesta = TipoRespuesta.CorrectoNegocio;

            return Resp;
        }
        /// <summary>
        /// Método que premite consultar los datos de forma paginada. Por defecto está seteado en mostrar la primera página.
        /// </summary>
        /// <param name="NumeroFilasPorPagina">La cantidad de filas por página a mostrar.</param>
        /// <returns>TRUE = Datos consultados correctamente; FALSE = Problemas al consultar los datos.</returns>
        public Respuesta<MantenedorPersonasDto> ConsultarPersonasInicial(int NumeroFilasPorPagina) 
        {
            Respuesta<MantenedorPersonasDto> Resp = new Respuesta<MantenedorPersonasDto>() 
            {
                mensaje = "ConsultarPersonas",
                estructuraDatos = new MantenedorPersonasDto()
            };

            Resp.estructuraDatos.DatosPaginacion.Nro_Filas_Por_Pagina = NumeroFilasPorPagina;

            var ObtNroFilas = this.DAL.ObtenerCantidadPersonas();
            if (!ObtNroFilas.decision) 
            { return Resp.MensajeGenerico(ObtNroFilas.CapturarDatos()); }

            Resp.estructuraDatos.DatosPaginacion.Nro_Filas = ObtNroFilas.estructuraDatos;

            Resp.estructuraDatos.DatosPaginacion = Resp.estructuraDatos.DatosPaginacion.ConsultaPaginacion(Resp.estructuraDatos.DatosPaginacion);

            var ObtDatos = this.DAL.ObtenerPersonas(Resp.estructuraDatos.DatosPaginacion);
            if (!ObtDatos.decision) 
            { return Resp.MensajeGenerico(ObtDatos.CapturarDatos()); }

            Resp.estructuraDatos.Tupla = ObtDatos.estructuraDatos;

            Resp.decision = true;
            Resp.mensajeDetalle = "Datos consultados correctamente.";
            Resp.TipoRespuesta = TipoRespuesta.CorrectoNegocio;

            return Resp;
        }
        /// <summary>
        /// Método que permite ir a la página deseada, según funcionalidad especificada.
        /// </summary>
        /// <param name="Datos">Los datos previamente proporcionados.</param>
        /// <returns>TRUE = Datos consultados correctamente; FALSE = Problemas al consultar los datos.</returns>
        public Respuesta<MantenedorPersonasDto> IrAPagina(MantenedorPersonasDto Datos) 
        {
            Respuesta<MantenedorPersonasDto> Resp = new Respuesta<MantenedorPersonasDto>()
            {
                mensaje = "Ir A Página.",
                estructuraDatos = Datos
            };

            switch (Resp.estructuraDatos.Funcionalidad) 
            {
                case TiposDePagina.PrimeraPagina:
                    Resp.estructuraDatos.DatosPaginacion = Resp.estructuraDatos.DatosPaginacion.IndicePrimero(Resp.estructuraDatos.DatosPaginacion);
                    break;
                case TiposDePagina.PaginaAnterior:
                    Resp.estructuraDatos.DatosPaginacion = Resp.estructuraDatos.DatosPaginacion.IndiceAnterior(Resp.estructuraDatos.DatosPaginacion);
                    break;
                case TiposDePagina.NumeroDePagina:
                    Resp.estructuraDatos.DatosPaginacion = Resp.estructuraDatos.DatosPaginacion.NumeroPagina(Resp.estructuraDatos.DatosPaginacion);
                    break;
                case TiposDePagina.PaginaSiguiente:
                    Resp.estructuraDatos.DatosPaginacion = Resp.estructuraDatos.DatosPaginacion.IndicePosterior(Resp.estructuraDatos.DatosPaginacion);
                    break;
                case TiposDePagina.UltimaPagina:
                    Resp.estructuraDatos.DatosPaginacion = Resp.estructuraDatos.DatosPaginacion.IndiceUltimo(Resp.estructuraDatos.DatosPaginacion);
                    break;
                default:
                    Resp.estructuraDatos.DatosPaginacion = Resp.estructuraDatos.DatosPaginacion.ConsultaPaginacion(Resp.estructuraDatos.DatosPaginacion);
                    break;
            }

            var ObtDatos = this.DAL.ObtenerPersonas(Resp.estructuraDatos.DatosPaginacion);
            if (!ObtDatos.decision)
            { return Resp.MensajeGenerico(ObtDatos.CapturarDatos()); }

            Resp.estructuraDatos.Tupla = ObtDatos.estructuraDatos;

            Resp.decision = true;
            Resp.mensajeDetalle = "Datos consultados correctamente.";
            Resp.TipoRespuesta = TipoRespuesta.CorrectoNegocio;

            return Resp;
        }
        /// <summary>
        /// Método que permite actualizar los datos de una persona seleccionada.
        /// </summary>
        /// <param name="Datos">Los datos previamente proporcionados.</param>
        /// <returns>TRUE = Persona actualizada correctamente; FALSE = Problemas al actualizar los datos.</returns>
        public Respuesta<MantenedorPersonasDto> ActualizarPersona(MantenedorPersonasDto Datos) 
        {
            Respuesta<MantenedorPersonasDto> Resp = new Respuesta<MantenedorPersonasDto>() 
            {
                mensaje = "Actualizar Persona.",
                estructuraDatos = Datos
            };

            var IniTran = this.DAL.Comun.AbrirTransaccion();
            if (!IniTran.decision) 
            { return Resp.MensajeGenerico(IniTran.CapturarDatos()); }

            var ActPersona = this.DAL.ActualizarPersona(Resp.estructuraDatos.PersonaSeleccionada);
            if (!ActPersona.decision) 
            { return Resp.MensajeGenerico(ActPersona.CapturarDatos()); }

            var EndTran = this.DAL.Comun.CerrarTransaccion();
            if (!EndTran.decision) 
            { return Resp.MensajeGenerico(EndTran.CapturarDatos()); }

            var ObtDatos = this.DAL.ObtenerPersonas(Resp.estructuraDatos.DatosPaginacion);
            if (!ObtDatos.decision) 
            { return Resp.MensajeGenerico(ObtDatos.CapturarDatos()); }

            Resp.estructuraDatos.Tupla = ObtDatos.estructuraDatos;

            Resp.decision = true;
            Resp.mensajeDetalle = "Persona actualizada correctamente.";
            Resp.TipoRespuesta = TipoRespuesta.CorrectoNegocio;

            return Resp;
        }
        /// <summary>
        /// Método que permite eliminar los datos de una persona seleccionada.
        /// </summary>
        /// <param name="Datos">Los datos previamente proporcionados.</param>
        /// <returns>TRUE = Persona eliminada correctamente; FALSE = Problemas al eliminar los datos.</returns>
        public Respuesta<MantenedorPersonasDto> EliminarPersona(MantenedorPersonasDto Datos) 
        {
            Respuesta<MantenedorPersonasDto> Resp = new Respuesta<MantenedorPersonasDto>()
            {
                mensaje = "Eliminar Persona.",
                estructuraDatos = Datos
            };

            var IniTran = this.DAL.Comun.AbrirTransaccion();
            if (!IniTran.decision)
            { return Resp.MensajeGenerico(IniTran.CapturarDatos()); }

            var ActPersona = this.DAL.EliminarPersona(Resp.estructuraDatos.PersonaSeleccionada);
            if (!ActPersona.decision)
            { return Resp.MensajeGenerico(ActPersona.CapturarDatos()); }

            var EndTran = this.DAL.Comun.CerrarTransaccion();
            if (!EndTran.decision)
            { return Resp.MensajeGenerico(EndTran.CapturarDatos()); }

            var ObtNroFilas = this.DAL.ObtenerCantidadPersonas();
            if (!ObtNroFilas.decision)
            { return Resp.MensajeGenerico(ObtNroFilas.CapturarDatos()); }

            Resp.estructuraDatos.DatosPaginacion.Nro_Filas = ObtNroFilas.estructuraDatos;

            Resp.estructuraDatos.DatosPaginacion = Resp.estructuraDatos.DatosPaginacion.ConsultaPaginacion(Resp.estructuraDatos.DatosPaginacion);

            var ObtDatos = this.DAL.ObtenerPersonas(Resp.estructuraDatos.DatosPaginacion);
            if (!ObtDatos.decision)
            { return Resp.MensajeGenerico(ObtDatos.CapturarDatos()); }

            Resp.estructuraDatos.Tupla = ObtDatos.estructuraDatos;

            Resp.decision = true;
            Resp.mensajeDetalle = "Persona eliminada correctamente.";
            Resp.TipoRespuesta = TipoRespuesta.CorrectoNegocio;

            return Resp;
        }
    }
}