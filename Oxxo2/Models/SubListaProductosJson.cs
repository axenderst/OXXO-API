namespace Oxxo2.Models
{
    public class SubListaProductosJson
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int proveedorId { get; set; }
        public int existencia { get; set; }
        public bool selected { get; set; }
    }
}
