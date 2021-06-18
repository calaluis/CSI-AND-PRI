namespace INSTITUCION.ENTVAL.NOMBREPROYECTO.Enumeraciones.Modulos.Personas
{
    /// <summary>
    /// Enumeración que permite clasificar las funcionalidades de navegación de la clase MantenedorPersonasDto.
    /// </summary>
    public enum TiposDePagina
    {
        /// <summary>
        /// Desconocido.
        /// </summary>
        Desconocido = -1,
        /// <summary>
        /// Primera página.
        /// </summary>
        PrimeraPagina = 1,
        /// <summary>
        /// Página anterior.
        /// </summary>
        PaginaAnterior,
        /// <summary>
        /// Número de página.
        /// </summary>
        NumeroDePagina,
        /// <summary>
        /// Página siguiente.
        /// </summary>
        PaginaSiguiente,
        /// <summary>
        /// Última página.
        /// </summary>
        UltimaPagina
    }
}
