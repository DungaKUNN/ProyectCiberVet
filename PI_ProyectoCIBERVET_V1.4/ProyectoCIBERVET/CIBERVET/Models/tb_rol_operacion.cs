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
    
    public partial class tb_rol_operacion
    {
        public int id_rol_operacion { get; set; }
        public Nullable<int> id_rol { get; set; }
        public Nullable<int> id_operacion { get; set; }
    
        public virtual tb_operacion tb_operacion { get; set; }
        public virtual tb_rol tb_rol { get; set; }
    }
}