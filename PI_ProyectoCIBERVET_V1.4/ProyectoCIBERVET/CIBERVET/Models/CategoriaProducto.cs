using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CIBERVET.Models
{
    public class CategoriaProducto
    {

        [Key]
        public int IdCategoria { get; set; }

        public string NomCategoria { get; set; }
    }
}