using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIBERVET.Models.Entidades
{
    public class Mascota
    {
        public int idmascota { get; set; }

        public string nombre { get; set; }
        public int idespecie { get; set; }

        public string especie { get; set; }

        public string sexo { get; set; }

        public int idraza { get; set; }

        public string raza { get; set; }

        public string foto { get; set; }
        public int idusuario { get; set; }
    }
}