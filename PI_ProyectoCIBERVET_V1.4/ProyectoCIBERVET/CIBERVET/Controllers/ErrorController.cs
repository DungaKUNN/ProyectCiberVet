using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIBERVET.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public ActionResult UnauthorizedOperation(String operacion, String modulo, String msjeErrorExcepcion)
        {
            ViewBag.operacion = operacion;
            ViewBag.modulo = modulo;
            ViewBag.msjeErrorExcepcion = msjeErrorExcepcion;
            return View();
        }
    }
}