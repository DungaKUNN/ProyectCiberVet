using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CIBERVET.Models
{
    public class EstadoTracking
    {
        [Key]
        public int idEstado { get; set; }
        public string desEstado { get; set; }
    }
}