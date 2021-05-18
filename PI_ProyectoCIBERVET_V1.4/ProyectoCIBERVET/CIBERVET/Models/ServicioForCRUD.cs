using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CIBERVET.Models
{
    public class ServicioForCRUD
    {
        [Key]
        [Display(Name = "ID")]
        public int idServicio { get; set; }

        [Display(Name = "Nombre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese el Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Precio")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese el Precio con Formato 10.00")]
        public decimal precio { get; set; }

        [Display(Name = "Descripción")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese la Descripción")]
        public string descripcion { get; set; }

        [Display(Name = "Horario")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese el Horario")]
        public string horario { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "Ingrese la Fecha")]
        public DateTime fecha { get; set; }
    }
}