using CIBERVET.Models;
using System.Linq;
using System.Web.Mvc;

namespace CIBERVET.Controllers
{
    public class GenericController : Controller
    {

        private BD_CIBERVETEntities db = new BD_CIBERVETEntities();
        // GET: Generic
        public JsonResult GetRaza(int idespecie)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var razas = db.raza_mascota.Where(r => r.idespecie == idespecie);
            return Json(razas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}