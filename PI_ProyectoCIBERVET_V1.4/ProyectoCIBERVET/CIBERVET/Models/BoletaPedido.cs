using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIBERVET.Models
{
    public class BoletaPedido
    {
        public string nombreProducto { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public DateTime fechaPedido { get; set; }
        public decimal importeTotal { get; set; }
    }
}