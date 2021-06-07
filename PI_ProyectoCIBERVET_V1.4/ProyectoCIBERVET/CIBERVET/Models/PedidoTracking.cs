using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CIBERVET.Models
{
    public class PedidoTracking
    {
        [Key]
        public int idPedido { get; set; }
        public string NomApeCliente { get; set; }
        public DateTime fechaPedido { get; set; }
        public string descripcionEstado { get; set; }
        public string descripcionProducto { get; set; }
        public decimal precioProducto { get; set; }
        public int cantidad { get; set; }
        public decimal importeTotal { get; set; }
        public int idEstado { get; set; }
    }
}