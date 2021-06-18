using HELPER.NET.ENTIDADES.Dto.Generico;
using INSTITUCION.ENTVAL.NOMBREPROYECTO.Dto.Modulos.Personas;
using System.Collections.Generic;

namespace INSTITUCION.ENTVAL.NOMBREPROYECTO.Interfaces.Modulos.Personas
{
    /// <summary>
    /// interfaz que define los comportamientos que serán presentados, con fines docentes.
    /// </summary>
    public interface IPersonasApl
    {
        /// <summary>
        /// Método que permite consultar los sexos registrados en el sistema.
        /// </summary>
        /// <returns>TRUE = Datos consultados correctamente; FALSE = Problemas al consultar los datos.</returns>
        Respuesta<List<DatoComboBox>> ConsultarSexo();
        /// <summary>
        /// Método que permite el ingreso de nuevas personas al sistema.
        /// </summary>
        /// <param name="Datos">Los datos de la persona, previamente llenados y validados.</param>
        /// <returns>TRUE = Ingreso realizado correctamente; FALSE = Problemas al ingresar a la persona.</returns>
        Respuesta<MantenedorPersonasDto> IngresarPersona(MantenedorPersonasDto Datos);
        /// <summary>
        /// Método que premite consultar los datos de forma paginada. Por defecto está seteado en mostrar la primera página.
        /// </summary>
        /// <param name="NumeroFilasPorPagina">La cantidad de filas por página a mostrar.</param>
        /// <returns>TRUE = Datos consultados correctamente; FALSE = Problemas al consultar los datos.</returns>
        Respuesta<MantenedorPersonasDto> ConsultarPersonasInicial(int NumeroFilasPorPagina);
        /// <summary>
        /// Método que permite ir a la página deseada, según funcionalidad especificada.
        /// </summary>
        /// <param name="Datos">Los datos previamente proporcionados.</param>
        /// <returns>TRUE = Datos consultados correctamente; FALSE = Problemas al consultar los datos.</returns>
        Respuesta<MantenedorPersonasDto> IrAPagina(MantenedorPersonasDto Datos);
        /// <summary>
        /// Método que permite actualizar los datos de una persona seleccionada.
        /// </summary>
        /// <param name="Datos">Los datos previamente proporcionados.</param>
        /// <returns>TRUE = Persona actualizada correctamente; FALSE = Problemas al actualizar los datos.</returns>
        Respuesta<MantenedorPersonasDto> ActualizarPersona(MantenedorPersonasDto Datos);
        /// <summary>
        /// Método que permite eliminar los datos de una persona seleccionada.
        /// </summary>
        /// <param name="Datos">Los datos previamente proporcionados.</param>
        /// <returns>TRUE = Persona eliminada correctamente; FALSE = Problemas al eliminar los datos.</returns>
        Respuesta<MantenedorPersonasDto> EliminarPersona(MantenedorPersonasDto Datos);
    }
}
