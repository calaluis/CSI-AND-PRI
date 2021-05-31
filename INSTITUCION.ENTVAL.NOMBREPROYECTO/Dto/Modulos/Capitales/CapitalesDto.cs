namespace INSTITUCION.ENTVAL.NOMBREPROYECTO.Dto.Modulos.Capitales
{
    public class CapitalesDto
    {
        public int Id { get; set; }
        public string Pais { get; set; }
        public string Capital { get; set; }

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
