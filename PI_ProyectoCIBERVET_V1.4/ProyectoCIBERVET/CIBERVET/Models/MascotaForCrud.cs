using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CIBERVET.Models
{
    public class MascotaForCrud
    {
        [Key]
        public int idmascota { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public int idespecie { get; set; }

        public string especie { get; set; }
        [Required]
        public string sexo { get; set; }
        [Required]
        public int idraza { get; set; }

        public string raza { get; set; }
        [Required]
        public string foto { get; set; }
        public int idusuario { get; set; }
         
	}

}