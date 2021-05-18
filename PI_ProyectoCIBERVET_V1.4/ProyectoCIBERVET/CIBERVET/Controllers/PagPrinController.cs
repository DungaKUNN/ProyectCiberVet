using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIBERVET.Models;

namespace CIBERVET.Controllers
{
    public class PagPrinController : Controller
    {
        private BD_CIBERVETEntities db = new BD_CIBERVETEntities();

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult RegistrarCliente()
        {
            ViewBag.IdDistritos = new SelectList(db.tb_distrito, "id_dis", "nombre_dis");
            ViewBag.IdTipoUsuarios = new SelectList(db.TIPOUSUARIO, "Id_TipoUsuario", "descripcion");
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarCliente([Bind(Include = "idusuario,dni,nombre,apellido,login,password,celular,correo,direccion,IdDistritos,IdTipoUsuarios")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Login2", "Cliente");
            }

            ViewBag.IdDistritos = new SelectList(db.tb_distrito, "id_dis", "nombre_dis", usuario.IdDistritos);
            ViewBag.IdTipoUsuarios = new SelectList(db.TIPOUSUARIO, "Id_TipoUsuario", "descripcion", usuario.IdTipoUsuarios);
            return View(usuario);
        }
        public ActionResult Contactanos()
        {
            return View();
        }

        public ActionResult Nosotros()
        {
            return View();
        }
    }
}