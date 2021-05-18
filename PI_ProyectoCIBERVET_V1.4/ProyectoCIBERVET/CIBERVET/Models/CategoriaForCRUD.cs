using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CIBERVET.Models
{
    public class CategoriaForCRUD
    {
        [Key]
        public int idCate { get; set; }

        public string descripcion { get; set; }
    }
}