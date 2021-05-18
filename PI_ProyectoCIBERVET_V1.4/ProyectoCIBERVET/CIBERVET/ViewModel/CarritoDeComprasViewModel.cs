using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CIBERVET.Models;

namespace CIBERVET.ViewModel
{
    public class CarritoDeComprasViewModel
    {
        public List<Carrito> CartItems { get; set; }

        public decimal CartTotal { get; set; }
    }
}