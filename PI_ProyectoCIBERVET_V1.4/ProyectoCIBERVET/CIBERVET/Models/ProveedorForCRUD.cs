using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CIBERVET.Models
{
    public class ProveedorForCRUD
    {
        [Key]
        public int idProve { get; set; }

        public string razonSocial { get; set; }
    }
}