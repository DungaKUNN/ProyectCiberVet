using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIBERVET.Models
{
    public class ProductoForCRUD
    {
        [Key]
        [Display(Name = "ID")]
        public int IdProducto { get; set; }

        [Display(Name = "Nombre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese el Nombre")]
        public string desSimple { get; set; }

        [Display(Name = "Precio")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese el Precio con Formato 10.00")]
        public decimal precio { get; set; }

        [Display(Name = "Stock")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese el Stock")]
        public int stock { get; set; }

        [Display(Name = "Serie")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese el Numero de Serie")]
        public string serie { get; set; }

        [Display(Name = "Marca")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese la Marca")]
        public string marca { get; set; }

        [Display(Name = "ID Categoria")]
        public int Idcategoria { get; set; }

        [Display(Name = "Categoria")]
        public string categoria { get; set; }

        [Display(Name = "ID Proveedor")]
        public int Idproveedor { get; set; }

        [Display(Name = "Proveedor")]
        public string proveedor { get; set; }

        [Display(Name = "Descripción")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese la Descripción")]
        public string desHTML { get; set; }

        [Display(Name = "Foto 1")]
        public string foto1 { get; set; }

        [Display(Name = "Foto 2")]
        public string foto2 { get; set; }

        [Display(Name = "Foto 3")]
        public string foto3 { get; set; }
    }
}