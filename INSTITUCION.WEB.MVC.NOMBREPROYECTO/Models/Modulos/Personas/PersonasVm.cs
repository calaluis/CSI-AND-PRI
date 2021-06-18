using HELPER.NET.ENTIDADES.Criptografia;
using HELPER.NET.ENTIDADES.Dto.Generico;
using HELPER.NET.ENTIDADES.Enumeradores.Generico;
using HELPER.NET.ENTIDADES.Utilidades;
using HELPER.NET.MVC;
using INSTITUCION.ENTVAL.NOMBREPROYECTO.Dto.Modulos.Personas;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace INSTITUCION.WEB.MVC.NOMBREPROYECTO.Models.Modulos.Personas
{
    public class PersonasVm : IModelBinder
    {
        public MantenedorPersonasDto ModeloVistaNegocio { get; set; }
        public Boton PrimeraPagina { get; set; }
        public Boton PaginaAnterior { get; set; }
        public Boton PaginaSiguiente { get; set; }
        public Boton UltimaPagina { get; set; }

        public PersonasVm()
        {
            foreach (var item in this.GetType().GetProperties())
            {
                if (item.PropertyType == typeof(string))
                {
                    item.SetValue(this, string.Empty);
                }
                if (item.PropertyType == typeof(Boton))
                {
                    item.SetValue(this, new Boton());
                }
            }
            this.ModeloVistaNegocio = new MantenedorPersonasDto();
            this.PrimeraPagina.Texto = "<<";
            this.PrimeraPagina.Tipo = TipoBoton.Link;
            this.PaginaAnterior.Texto = "<";
            this.PaginaAnterior.Tipo = TipoBoton.Link;
            this.PaginaSiguiente.Texto = ">";
            this.PaginaSiguiente.Tipo = TipoBoton.Link;
            this.UltimaPagina.Texto = ">>";
            this.UltimaPagina.Tipo = TipoBoton.Link;
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            PersonasVm VM = new PersonasVm();

            VM = VM.EnlazarModeloToClase(bindingContext, "INSTITUCION.ENTVAL.NOMBREPROYECTO", "INSTITUCION.WEB.MVC.NOMBREPROYECTO");

            VM.ModeloVistaNegocio.DatosPaginacion = JsonConvert.DeserializeObject<PaginacionMuestreoOptimizado>(EncriptacionRijndael
                .Desencriptar(Helper.ConsultarValorEnlazadorModelo(bindingContext.ValueProvider.GetValue("ModeloVistaNegocio.DatosPaginacion"))));
            VM.ModeloVistaNegocio.Tupla = JsonConvert.DeserializeObject<List<PersonaDto>>(EncriptacionRijndael
                .Desencriptar(Helper.ConsultarValorEnlazadorModelo(bindingContext.ValueProvider.GetValue("ModeloVistaNegocio.Tupla"))));

            return VM;
        }
    }
}