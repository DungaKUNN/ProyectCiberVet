using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CIBERVET.Models.Entidades
{
    public class Usuario
    {
        
        public int idusuario { get; set; }

        public string dni { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string login { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        public string password { get; set; }

        public string celular { get; set; }
        [Required]
        [Display(Name = "correo")]
        public string correo { get; set; }

        public string direccion { get; set; }



        public tb_distrito IdDistritos { get; set; }
        public int? IdDistrito { get; set; }
        public TIPOUSUARIO IdTipoUsuarios { get; set; }
        


    }
}