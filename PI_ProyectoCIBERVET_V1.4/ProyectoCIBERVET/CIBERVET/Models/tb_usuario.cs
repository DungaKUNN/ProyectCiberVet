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
    
    public partial class tb_usuario
    {
        public int id_usuario { get; set; }
        public string dni_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string apellido_usuario { get; set; }
        public string direccion_usuario { get; set; }
        public string celular_usuario { get; set; }
        public string email_usuario { get; set; }
        public string password_usuario { get; set; }
        public Nullable<int> id_dis { get; set; }
        public Nullable<int> id_rol { get; set; }
    
        public virtual tb_distrito tb_distrito { get; set; }
        public virtual tb_rol tb_rol { get; set; }
    }
}
