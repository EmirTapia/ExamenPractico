using System;

namespace WEBAPI.Models
{
    public partial class Producto
    {
        public int ProductoId { get; set; }
        public string Sku { get; set; }
        public string Fert { get; set; }
        public string Modelo { get; set; }
        public short Tipo { get; set; }
        public string Serie { get; set; }
        public DateTime Fecha { get; set; }
    }
}
