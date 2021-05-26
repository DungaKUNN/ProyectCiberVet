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
        [Required(ErrorMessage = "Ingrese el Nombre")]
        [StringLength(100, ErrorMessage = "Maximo 100  caracteres")]
        [RegularExpression("^[A-Za-z]+$")]
        public string nombre { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Ingrese el Precio ")]
        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "Ingrese precio con formato 0.00")]
        public decimal precio { get; set; }

        [Display(Name = "Descripción")]
        [AllowHtml]
        [Required(ErrorMessage = "Ingrese la Descripción")]
        public string descripcion { get; set; }

        [Display(Name = "Horario")]
        [Required(ErrorMessage = "Ingrese el Horario")]
        public string horario { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ingrese la Fecha")]
        public DateTime fecha { get; set; }
    }
}