namespace INSTITUCION.ENTVAL.NOMBREPROYECTO.Dto.Modulos.Capitales
{
    /// <summary>
    /// Clase que define la estructura de datos de la tabla Capitales albergada en Access, con fines docentes.
    /// </summary>
    public class CapitalesDto
    {
        /// <summary>
        /// Atributo que guarda o establece el identificador del registro.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Atributo que guarda o establece el nombre del país.
        /// </summary>
        public string Pais { get; set; }
        /// <summary>
        /// Atributo que guarda o establece el nombre de la capital, asociada al país.
        /// </summary>
        public string Capital { get; set; }

        /// <summary>
        /// Método constructor inicializador del objeto.
        /// </summary>
        public CapitalesDto()
        {
            foreach (var item in this.GetType().GetProperties()) 
            {
                if(item.PropertyType == typeof(string)) 
                {
                    item.SetValue(this, string.Empty);
                }
            }
        }
    }
}
