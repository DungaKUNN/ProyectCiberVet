//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CIBERVET.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MASCOTA
    {
        public int idmascota { get; set; }
        public string nombre { get; set; }
        public int idespecie { get; set; }
        public string sexo { get; set; }
        public int idraza { get; set; }
        public string foto { get; set; }
        public int idusuario { get; set; }
    
        public virtual especie_mascota especie_mascota { get; set; }
        public virtual raza_mascota raza_mascota { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
