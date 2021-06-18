using HELPER.NET.ENTIDADES.Criptografia;
using HELPER.NET.ENTIDADES.Dto.Generico;
using HELPER.NET.ENTIDADES.Utilidades;
using INSTITUCION.ENTVAL.NOMBREPROYECTO.Dto.Modulos.Personas;
using INSTITUCION.ENTVAL.NOMBREPROYECTO.Enumeraciones.Modulos.Personas;
using INSTITUCION.WEB.MVC.NOMBREPROYECTO.Models.Modulos.Personas;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace INSTITUCION.WEB.MVC.NOMBREPROYECTO.Controllers.Modulos.Personas
{
    public partial class PersonasController : ControllerBaseController
    {
        public ActionResult Index() 
        {
            PersonasVm Datos = new PersonasVm();
            SubRespuesta Respuesta = new SubRespuesta();
            if (TempData["Mensaje"] != null)
            {
                Respuesta = (SubRespuesta)TempData["Mensaje"];
            }

            var ObtSexo = Negocio.ConsultarSexo();
            if (!ObtSexo.decision) 
            { return RetornarVista(ObtSexo.CapturarDatos(), Datos); }

            var ObtDatos = Negocio.ConsultarPersonasInicial(2);
            if (!ObtDatos.decision) 
            { return RetornarVista(ObtDatos.CapturarDatos(), Datos); }

            Datos.ModeloVistaNegocio = ObtDatos.estructuraDatos;
            Datos.ModeloVistaNegocio.PersonaSeleccionada.Sexo = ObtSexo.estructuraDatos;

            return RetornarVista(Respuesta, Datos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PersonasVm Datos, FormCollection Collection) 
        {
            SubRespuesta Respuesta = new SubRespuesta();
            string VistaParcial = "_IndexContenido";

            #region Eventos.
            if (Collection["Control"].ToString() == "ModeloVistaNegocio.PersonaSeleccionada.Sexo.SelectedValue" && Collection["Evento"].ToString() == "change") 
            {
                string Valor = Collection["ValorControlEvento"].ToString();
                Datos.ModeloVistaNegocio.PersonaSeleccionada.Sexo = DatoComboBox.SeleccionarElemento(Datos.ModeloVistaNegocio.PersonaSeleccionada.Sexo, Valor);
            }
            if (Collection["Control"].ToString() == "Insertar" && Collection["Evento"].ToString() == "click") 
            {
                var ValForm = Validacion.ValidadorMaestro(Datos.ModeloVistaNegocio.PersonaSeleccionada);
                if (!ValForm.decision)
                {
                    string Errores = string.Join("<br />", ValForm.estructuraDatos);
                    Respuesta = ValForm.CapturarDatos();
                    Respuesta.mensajeDetalle = Errores;
                }
                else 
                {
                    var InsPersona = Negocio.IngresarPersona(Datos.ModeloVistaNegocio);
                    if (InsPersona.decision) 
                    {
                        Datos.ModeloVistaNegocio = InsPersona.estructuraDatos;

                        Datos.ModeloVistaNegocio.PersonaSeleccionada = new PersonaDto();

                        var ObtSexo = Negocio.ConsultarSexo();
                        if (!ObtSexo.decision)
                        { return RetornarVistaParcial(ObtSexo.CapturarDatos(), VistaParcial, Datos); }

                        Datos.ModeloVistaNegocio.PersonaSeleccionada.Sexo = ObtSexo.estructuraDatos;
                    }
                    Respuesta = InsPersona.CapturarDatos();
                }
            }
            if (Collection["Control"].ToString() == "Editar" && Collection["Evento"].ToString() == "click")
            {
                PersonaDto Valor = JsonConvert.DeserializeObject<PersonaDto>(EncriptacionRijndael.Desencriptar(Collection["ValorControlEvento"].ToString()));
                Datos.ModeloVistaNegocio.PersonaSeleccionada = Valor;
            }
            if (Collection["Control"].ToString() == "Actualizar" && Collection["Evento"].ToString() == "click")
            {
                var ValForm = Validacion.ValidadorMaestro(Datos.ModeloVistaNegocio.PersonaSeleccionada);
                if (!ValForm.decision)
                {
                    string Errores = string.Join("<br />", ValForm.estructuraDatos);
                    Respuesta = ValForm.CapturarDatos();
                    Respuesta.mensajeDetalle = Errores;
                }
                else
                {
                    var InsPersona = Negocio.ActualizarPersona(Datos.ModeloVistaNegocio);
                    if (InsPersona.decision)
                    {
                        Datos.ModeloVistaNegocio = InsPersona.estructuraDatos;

                        Datos.ModeloVistaNegocio.PersonaSeleccionada = new PersonaDto();

                        var ObtSexo = Negocio.ConsultarSexo();
                        if (!ObtSexo.decision)
                        { return RetornarVistaParcial(ObtSexo.CapturarDatos(), VistaParcial, Datos); }

                        Datos.ModeloVistaNegocio.PersonaSeleccionada.Sexo = ObtSexo.estructuraDatos;
                    }
                    Respuesta = InsPersona.CapturarDatos();
                }
            }
            if (Collection["Control"].ToString() == "Cancelar" && Collection["Evento"].ToString() == "click")
            {
                Datos.ModeloVistaNegocio.PersonaSeleccionada = new PersonaDto();

                var ObtSexo = Negocio.ConsultarSexo();
                if (!ObtSexo.decision)
                { return RetornarVistaParcial(ObtSexo.CapturarDatos(), VistaParcial, Datos); }

                Datos.ModeloVistaNegocio.PersonaSeleccionada.Sexo = ObtSexo.estructuraDatos;
            }
            if (Collection["Control"].ToString() == "Eliminar" && Collection["Evento"].ToString() == "click")
            {
                PersonaDto Valor = JsonConvert.DeserializeObject<PersonaDto>(EncriptacionRijndael.Desencriptar(Collection["ValorControlEvento"].ToString()));
                Datos.ModeloVistaNegocio.PersonaSeleccionada = Valor;

                var ValForm = Validacion.ValidadorMaestro(Datos.ModeloVistaNegocio.PersonaSeleccionada);
                if (!ValForm.decision)
                {
                    string Errores = string.Join("<br />", ValForm.estructuraDatos);
                    Respuesta = ValForm.CapturarDatos();
                    Respuesta.mensajeDetalle = Errores;
                }
                else
                {
                    var InsPersona = Negocio.EliminarPersona(Datos.ModeloVistaNegocio);
                    if (InsPersona.decision)
                    {
                        Datos.ModeloVistaNegocio = InsPersona.estructuraDatos;

                        Datos.ModeloVistaNegocio.PersonaSeleccionada = new PersonaDto();

                        var ObtSexo = Negocio.ConsultarSexo();
                        if (!ObtSexo.decision)
                        { return RetornarVistaParcial(ObtSexo.CapturarDatos(), VistaParcial, Datos); }

                        Datos.ModeloVistaNegocio.PersonaSeleccionada.Sexo = ObtSexo.estructuraDatos;
                    }
                    Respuesta = InsPersona.CapturarDatos();
                }
            }
            if (Collection["Control"].ToString() == "PrimeraPagina" && Collection["Evento"].ToString() == "click")
            {
                Datos.ModeloVistaNegocio.Funcionalidad = TiposDePagina.PrimeraPagina;
                var ObtPag = Negocio.IrAPagina(Datos.ModeloVistaNegocio);
                if (!ObtPag.decision) 
                { return RetornarVistaParcial(ObtPag.CapturarDatos(), VistaParcial, Datos); }

                Datos.ModeloVistaNegocio = ObtPag.estructuraDatos;
            }
            if (Collection["Control"].ToString() == "PaginaAnterior" && Collection["Evento"].ToString() == "click")
            {
                Datos.ModeloVistaNegocio.Funcionalidad = TiposDePagina.PaginaAnterior;
                var ObtPag = Negocio.IrAPagina(Datos.ModeloVistaNegocio);
                if (!ObtPag.decision)
                { return RetornarVistaParcial(ObtPag.CapturarDatos(), VistaParcial, Datos); }

                Datos.ModeloVistaNegocio = ObtPag.estructuraDatos;
            }
            if (Collection["Control"].ToString() == "NumeroDePagina" && Collection["Evento"].ToString() == "keypress")
            {
                Datos.ModeloVistaNegocio.Funcionalidad = TiposDePagina.NumeroDePagina;
                Datos.ModeloVistaNegocio.DatosPaginacion.Numero_De_Pagina = Conversion.ConvierteStringAEntero32(Collection["ValorControlEvento"].ToString());
                var ObtPag = Negocio.IrAPagina(Datos.ModeloVistaNegocio);
                if (!ObtPag.decision)
                { return RetornarVistaParcial(ObtPag.CapturarDatos(), VistaParcial, Datos); }

                Datos.ModeloVistaNegocio = ObtPag.estructuraDatos;
            }
            if (Collection["Control"].ToString() == "PaginaSiguiente" && Collection["Evento"].ToString() == "click")
            {
                Datos.ModeloVistaNegocio.Funcionalidad = TiposDePagina.PaginaSiguiente;
                var ObtPag = Negocio.IrAPagina(Datos.ModeloVistaNegocio);
                if (!ObtPag.decision)
                { return RetornarVistaParcial(ObtPag.CapturarDatos(), VistaParcial, Datos); }

                Datos.ModeloVistaNegocio = ObtPag.estructuraDatos;
            }
            if (Collection["Control"].ToString() == "UltimaPagina" && Collection["Evento"].ToString() == "click")
            {
                Datos.ModeloVistaNegocio.Funcionalidad = TiposDePagina.UltimaPagina;
                var ObtPag = Negocio.IrAPagina(Datos.ModeloVistaNegocio);
                if (!ObtPag.decision)
                { return RetornarVistaParcial(ObtPag.CapturarDatos(), VistaParcial, Datos); }

                Datos.ModeloVistaNegocio = ObtPag.estructuraDatos;
            }

            #endregion

            return RetornarVistaParcial(Respuesta, VistaParcial, Datos);
        }
    }
}