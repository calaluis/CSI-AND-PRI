using HELPER.NET.ENTIDADES.Utilidades;
using INSTITUCION.ENTVAL.NOMBREPROYECTO.Enumeraciones.Modulos.Personas;
using System.Collections.Generic;

namespace INSTITUCION.ENTVAL.NOMBREPROYECTO.Dto.Modulos.Personas
{
    /// <summary>
    /// Clase que define la estructura de daros del Mantenedor Personas.
    /// </summary>
    public class MantenedorPersonasDto
    {
        /// <summary>
        /// Atributo que guarda o establece los datos paginados.
        /// </summary>
        public List<PersonaDto> Tupla { get; set; }
        /// <summary>
        /// Atributo que guarda o establece los datos de la paginación.
        /// </summary>
        public PaginacionMuestreoOptimizado DatosPaginacion { get; set; }
        /// <summary>
        /// Atributo que guarda o establece las funcionalidades del paginador.
        /// </summary>
        public TiposDePagina Funcionalidad { get; set; }
        /// <summary>
        /// Atributo que guarda o establece la persona seleccionada, que se utiliza para ingresar, actualizar o eliminar un registro del sistema.
        /// </summary>
        public PersonaDto PersonaSeleccionada { get; set; }

        /// <summary>
        /// Método constructor inicializador del objeto.
        /// </summary>
        public MantenedorPersonasDto()
        {
            Tupla = new List<PersonaDto>();
            DatosPaginacion = new PaginacionMuestreoOptimizado();
            this.Funcionalidad = TiposDePagina.PrimeraPagina;
            this.PersonaSeleccionada = new PersonaDto();
        }
    }
}
