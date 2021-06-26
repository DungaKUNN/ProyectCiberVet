using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIBERVET.Models;

namespace CIBERVET.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AutorizarUsuario : AuthorizeAttribute
    {
        private tb_usuario oUsuario;
        private BD_CIBERVETEntities bd = new BD_CIBERVETEntities();
        private int idOperacion;

        public AutorizarUsuario(int idOperacion = 0)
        {
            this.idOperacion = idOperacion;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            String nombreOperacion = "";
            String nombreModulo = "";
            try
            {
                oUsuario = (tb_usuario)HttpContext.Current.Session["UsuarioVeterinaria"];
                var lstMisOperaciones = from ro in bd.tb_rol_operacion
                                        where ro.id_rol == oUsuario.id_rol
                                        && ro.id_operacion == idOperacion
                                        select ro;

                if (lstMisOperaciones.ToList().Count() == 0)
                {
                    var oOperacion = bd.tb_operacion.Find(idOperacion);
                    int? idModulo = oOperacion.id_modulo;
                    nombreOperacion = getNombreDeOperacion(idOperacion);
                    nombreModulo = getNombreDeModulo(idModulo);
                    filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=" + nombreOperacion + "&modulo=" + nombreModulo + "&msjeErrorExcepcion=");
                }
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=" + nombreOperacion + "&modulo=" + nombreModulo + "&msjeErrorExcepcion=" + ex.Message);
            }
        }

        public string getNombreDeOperacion(int idOperacion)
        {
            var ope = from o in bd.tb_operacion
                      where o.id_operacion == idOperacion
                      select o.nombre_operacion;
            String nombreOperacion;
            try
            {
                nombreOperacion = ope.First();
            }
            catch (Exception)
            {
                nombreOperacion = "";
            }
            return nombreOperacion;
        }

        public string getNombreDeModulo(int? idModulo)
        {
            var modulo = from m in bd.tb_modulo
                         where m.id_modulo == idModulo
                         select m.nombre_modulo;
            String nombreModulo;
            try
            {
                nombreModulo = modulo.First();
            }
            catch (Exception)
            {
                nombreModulo = "";
            }
            return nombreModulo;
        }
    }
}