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
    
    public partial class tb_proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_proveedor()
        {
            this.tb_producto = new HashSet<tb_producto>();
        }
    
        public int id_prove { get; set; }
        public string nombres_prove { get; set; }
        public string apellidos_prove { get; set; }
        public string razonSocial_prove { get; set; }
        public string direccion_prove { get; set; }
        public string celular_prove { get; set; }
        public string email_prove { get; set; }
        public Nullable<int> id_dis { get; set; }
    
        public virtual tb_distrito tb_distrito { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_producto> tb_producto { get; set; }
    }
}
