using HELPER.NET.ENTIDADES.Criptografia;
using HELPER.NET.ENTIDADES.Dto.Generico;
using HELPER.NET.ENTIDADES.Enumeradores.Generico;
using HELPER.NET.MVC;
using INSTITUCION.ENTVAL.NOMBREPROYECTO.Dto.Modulos.Capitales;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace INSTITUCION.WEB.MVC.NOMBREPROYECTO.Models.Modulos.Capitales
{
    public class CapitalesVm : IModelBinder
    {
        public CuestionarioDto ModeloVistaNegocio { get; set; }
        public Boton Responder { get; set; }
        public CapitalesVm() 
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
            this.ModeloVistaNegocio = new CuestionarioDto();
            this.Responder.Texto = "Responder Pregunta";
            this.Responder.Tipo = TipoBoton.Primario;
        }
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            CapitalesVm VM = new CapitalesVm();

            VM = VM.EnlazarModeloToClase(bindingContext, "INSTITUCION.ENTVAL.NOMBREPROYECTO", "INSTITUCION.WEB.MVC.NOMBREPROYECTO");

            VM.ModeloVistaNegocio.ListaPaisesCapitales = JsonConvert.DeserializeObject<List<CapitalesDto>>(EncriptacionRijndael
                .Desencriptar(Helper.ConsultarValorEnlazadorModelo(bindingContext.ValueProvider.GetValue("ModeloVistaNegocio.ListaPaisesCapitales"))));

            return VM;
        }
    }
}