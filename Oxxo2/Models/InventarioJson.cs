using System.Collections.Generic;

namespace Oxxo2.Models
{
    public class InventarioJson
    {
        public string InventarioNombre { get; set; }
        public string FolioGoma { get; set; }
        public bool Finalizado { get; set; }
        public int InvId { get; set; }
        public ICollection<SubListaProductosJson> ListaDeProductos { get; set; }
    }
}
    