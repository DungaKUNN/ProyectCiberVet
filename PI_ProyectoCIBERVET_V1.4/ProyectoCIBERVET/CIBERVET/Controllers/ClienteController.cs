using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CIBERVET.Models;
using CIBERVET.Models.Entidades;
using CIBERVET.ViewModel;

namespace CIBERVET.Controllers
{
    public class ClienteController : Controller
    {
        private BD_CIBERVETEntities db = new BD_CIBERVETEntities();
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public ActionResult Login2()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login2(usuario user)
        {
            if (ModelState.IsValid)
            {
                using (BD_CIBERVETEntities db = new BD_CIBERVETEntities())
                {
                    var obj = db.usuario.Where(a => a.correo.Equals(user.correo) && a.password.Equals(user.password)).FirstOrDefault();
                    
                    if (obj != null)
                    {
                        Session["usuario"] = obj;
                        Session["UserID"] = obj.idusuario.ToString();
                        Session["UserName"] = obj.nombre.ToString();
                        Session["UserLastName"] = obj.apellido.ToString();
                        //return RedirectToAction("RegistrarTarjeta", "PagPrin");
                        System.Web.HttpContext.Current.Session["IndMascotaUsu"] = "N";
                        int indUsuario = obj.idusuario;
                        var mascota =( from m in db.MASCOTA
                                       where m.idusuario==indUsuario select m).Count();
                        
                        if (mascota > 0)
                        {
                            System.Web.HttpContext.Current.Session["IndMascotaUsu"] = "S";
                            
                        }
                        
                        return RedirectToAction("HomeCliente", "Cliente");
                    }
                }
            }
            return View(user);
        }

        public ActionResult NosotrosCliente()
        {
            return View();
        }

        public ActionResult ContactanosCliente()
        {
            return View();
        }

        public ActionResult HomeCliente()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login2", "Cliente");
            }
        }

        public JsonResult GetRaza(int idespecie)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var razas = db.raza_mascota.Where(r => r.idespecie == idespecie);
            return Json(razas);
        }

        public ActionResult RegistrarMascota()
        {
            ViewBag.idespecie = new SelectList(db.especie_mascota.ToList(), "idespecie", "especie");
            ViewBag.idraza = new SelectList(db.raza_mascota.Where(t => t.idespecie == db.especie_mascota.FirstOrDefault().idespecie).ToList(), "idraza", "raza");
            return View(new MascotaForCrud());
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult RegistrarMascota(MascotaForCrud m, HttpPostedFileBase foto3)
        {
            if (Session["UserID"] != null)
            {
                if (foto3 == null)
                {
                    ViewBag.Mensaje = "Seleccione una foto";
                    ViewBag.idespecie = new SelectList(db.especie_mascota.ToList(), "idespecie", "especie");
                    ViewBag.idraza = new SelectList(db.raza_mascota.Where(t => t.idespecie == db.especie_mascota.FirstOrDefault().idespecie).ToList(), "idraza", "raza");
                    
                    return View(m);

                }

                if (Path.GetExtension(foto3.FileName) != ".jpg")
                {
                    ViewBag.Mensaje = "Formato permitido: .jpg";
                    ViewBag.idespecie = new SelectList(db.especie_mascota.ToList(), "idespecie", "especie");
                    ViewBag.idraza = new SelectList(db.raza_mascota.Where(t => t.idespecie == db.especie_mascota.FirstOrDefault().idespecie).ToList(), "idraza", "raza");
                    return View(m);
                }
                m.foto = foto3.FileName;

                InsertarMascota(m);

                foto3.SaveAs(Path.Combine(Server.MapPath("~/images/"),
                             Path.GetFileName(foto3.FileName)));

                var id = Session["UserID"];
                return RedirectToAction("ListadoMascotas","Cliente", routeValues: new { id = id });
            }
            return RedirectToAction("Home", "PagPrin");
        }

        public int InsertarMascota(MascotaForCrud m)
        {
            int resultado = -1;
            var idusu = Convert.ToInt32(Session["UserID"]);
            SqlCommand cmd = new SqlCommand("sp_Insertar_Mascotas", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", m.nombre);
            cmd.Parameters.AddWithValue("@idespecie", m.idespecie);
            cmd.Parameters.AddWithValue("@sexo", m.sexo);
            cmd.Parameters.AddWithValue("@idraza", m.idraza);
            cmd.Parameters.AddWithValue("@foto", m.foto);
            cmd.Parameters.AddWithValue("@idusuario", idusu);
            cn.Open();
            resultado = cmd.ExecuteNonQuery();
            cn.Close();
            return resultado;
        }

        public ActionResult CerrarSession()
        {
            if (Session["UserID"] != null)
            {
                Session["UserID"] = null;
            }

            return RedirectToAction("Home", "PagPrin");

        }

        public ActionResult PerfilClient(int id)
        {
            List<usuario> lstusu = new List<usuario>();
            usuario usu = db.usuario.Find(id);
            usuario prueba = new usuario();
            prueba.idusuario = usu.idusuario;
            prueba.dni = usu.dni.ToString();
            prueba.nombre = usu.nombre.ToString();
            prueba.apellido = usu.apellido.ToString();
            prueba.login = usu.login.ToString();
            prueba.celular = usu.celular.ToString();
            prueba.direccion = usu.direccion.ToString();
            prueba.IdDistritos = usu.IdDistritos;
            lstusu.Add(prueba);
            if (Session["UserID"] != null)
            {
                string IndMascota;
                IndMascota=System.Web.HttpContext.Current.Session["IndMascotaUsu"].ToString();
                ViewBag.valor = IndMascota;

                ViewBag.ciudades = new SelectList(db.tb_distrito.ToList(), "Id_dis", "nombre_dis",usu.IdDistritos);
                ViewBag.tipoUsu = new SelectList(db.TIPOUSUARIO.ToList(), "Id_TipoUsuario", "descripcion", usu.IdTipoUsuarios);
                return View(lstusu);
            }
            return RedirectToAction("Home", "PagPrin");
        }
        public ActionResult EditarPerfil(int id)
        {
            usuario usu = db.usuario.Find(id);
            Usuario prueba = new Usuario();
            prueba.idusuario = usu.idusuario;
            prueba.dni = usu.dni.ToString();
            prueba.nombre = usu.nombre.ToString();
            prueba.apellido = usu.apellido.ToString();
            prueba.correo = usu.correo.ToString();
            prueba.password = usu.password.ToString();
            prueba.login = usu.login.ToString();
            prueba.celular = usu.celular.ToString();
            prueba.direccion = usu.direccion.ToString();
            prueba.IdDistrito = usu.IdDistritos;
            ViewBag.ciudades = new SelectList(db.tb_distrito.ToList(), "Id_dis", "nombre_dis", usu.IdDistritos);
            ViewBag.tipo = new SelectList(db.TIPOUSUARIO.ToList(), "Id_TipoUsuario", "descripcion", usu.IdTipoUsuarios);
            return View(prueba);
        }

        [HttpPost]
        public ActionResult EditarPerfil(Usuario usu)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ciudades = new SelectList(db.tb_distrito.ToList().OrderBy(x => x.nombre_dis), "Id_dis", "nombre_dis", usu.IdDistritos);
                
                TempData["prod"] = null;
                return View(usu);
            }

            db.sp_EditarUsuario(usu.idusuario,usu.dni, usu.nombre, usu.apellido, usu.login, usu.password, usu.celular, usu.correo, usu.direccion, usu.IdDistrito);

            Session["usuario"] = usu;

            return RedirectToAction("PerfilClient", "Cliente", routeValues: new { id = usu.idusuario });
        }

        // GET: Producto
        public ActionResult ListadoMascotas(int id)
        {
            return View(ListarMascotas(id));
        }

        public List<MascotaForCrud> ListarMascotas(int id)
        {
            List<MascotaForCrud> lista = new List<MascotaForCrud>();
            SqlCommand cmd = new SqlCommand("sp_Listado_Mascotas", cn);
            cmd.Parameters.AddWithValue("@idusuario",id);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new MascotaForCrud()
                {
                    idmascota = Convert.ToInt32(dr["Codigo de Mascota"]),
                    nombre = Convert.ToString(dr["Nombre"]),
                    especie = Convert.ToString(dr["Especie"]),
                    sexo = Convert.ToString(dr["Sexo"]),
                    raza = Convert.ToString(dr["Raza"]),
                    foto = Convert.ToString(dr["Foto"])

                });
            }
            dr.Close(); cn.Close();
            return lista;
        }

        public ActionResult EditarMascota(int id)
        {
            MASCOTA mas = db.MASCOTA.Find(id);
            Mascota prueba = new Mascota();
            prueba.idmascota = mas.idmascota;
            prueba.nombre = mas.nombre.ToString();
            prueba.idespecie = mas.idespecie;
            prueba.sexo = mas.sexo.ToString();
            prueba.idraza = mas.idraza;
            prueba.foto = mas.foto.ToString();
            prueba.idusuario = mas.idusuario;
            ViewBag.especie = new SelectList(db.especie_mascota.ToList(), "idespecie", "especie", mas.idespecie);
            ViewBag.idraza = new SelectList(db.raza_mascota.Where(t => t.idespecie == db.especie_mascota.FirstOrDefault().idespecie).ToList(), "idraza", "raza", mas.idraza);
            ViewBag.sexo = new SelectList(mas.sexo);
            return View(prueba);
        }

        [HttpPost]
        public ActionResult EditarMascota(Mascota mas, HttpPostedFileBase foto3)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.especie = new SelectList(db.especie_mascota.ToList(), "idespecie", "especie", mas.idespecie);
                ViewBag.idraza = new SelectList(db.raza_mascota.Where(t => t.idespecie == db.especie_mascota.FirstOrDefault().idespecie).ToList(), "idraza", "raza", mas.idraza);
                ViewBag.sexo = new SelectList(mas.sexo);

                return View(mas);
            }

            if (foto3 != null)
            {
                mas.foto = foto3.FileName;
                foto3.SaveAs(Path.Combine(Server.MapPath("~/images/"),
                             Path.GetFileName(foto3.FileName)));
            }

            db.sp_EditarMascota(mas.idmascota, mas.nombre, mas.idespecie, mas.sexo, mas.idraza, mas.foto);


            return RedirectToAction("ListadoMascotas", "Cliente", routeValues: new { id = Session["UserID"] });
        }

        [HttpGet]
        public ActionResult EliminarMascota(int id)
        {
            using (db)
            {
                var tabla = db.MASCOTA.Find(id);
                db.MASCOTA.Remove(tabla);
                db.SaveChanges();
            }

            return RedirectToAction("ListadoMascotas", "Cliente", routeValues: new { id = Session["UserID"] });
        }

        public ActionResult CatalogoProductos(int? id = 0)
        {
            List<tb_producto> ListarProductos;
            if (id.HasValue && id.Value != 0)
            {
                ListarProductos = db.tb_producto.Where(x => x.id_cate == id).ToList();
            }
            else
            {
                ListarProductos = db.tb_producto.ToList();
            }

            ViewBag.categorias = db.tb_categoria.ToList();
            return View(ListarProductos);
        }

        public ActionResult VerProductosDetallado(int id)
        {
            var p = db.tb_producto.Find(id);
            return View(p);
        }

        //CARRITO/AGREGARPRODUCTO
        public ActionResult AgregarProducto(int id)
        {
            //OBTENEMOS EL PRODUCTO
            var p = db.tb_producto.Single(o => o.id_prod == id);
            //AGREGAMOS EL CARRITO (SHOPPINGCART)
            var cart = CarritoDeCompras.GetCart(this.HttpContext);
            cart.AddToCart(p);

            //RETORNAR A LA VISTA DE CARRITO
            return RedirectToAction("VerCarrito");
        }

        // GET: Carrito/RemoverProducto/5
        public ActionResult RemoverProducto(int id)
        {
            // Obtener el producto
            var p = db.tb_producto.Single(o => o.id_prod == id);

            // Retiramos del carrito (CarritoDeCompras)
            var cart = CarritoDeCompras.GetCart(this.HttpContext);
            cart.RemoveToCart(p);

            // Retornar a la vista de Carrito
            return RedirectToAction("VerCarrito");
        }
        public ActionResult DisminuirProducto(int id)
        {
            //OBTENEMOS EL PRODUCTO
            var p = db.tb_producto.Single(o => o.id_prod == id);

            var cart = CarritoDeCompras.GetCart(this.HttpContext);
            cart.DisToCart(p);

            //RETORNAR A LA VISTA DE CARRITO
            return RedirectToAction("VerCarrito");

        }


        //GET CARRITO/VERCARRITO
        public ActionResult VerCarrito()
        {
            var cart = CarritoDeCompras.GetCart(this.HttpContext);

            //CONFIGURAMOS EL VIEWMODEL
            var vm = new CarritoDeComprasViewModel()
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return View(vm);
        }

        //Metodos para pagar carrito
        public void AddToPedido(Carrito c)
        {
            var cart = CarritoDeCompras.GetCart(this.HttpContext);
            tb_pedidoCabe pedCabe;
            usuario usu;

            usu = (usuario)Session["usuario"];

            pedCabe = new tb_pedidoCabe()
            {
                id_usuario = usu.idusuario,
                fecha_pedido = DateTime.Now,
                total_pedido = cart.GetTotal(),
                id_estado = 1//Se registra con estado "Preparado"
            };

            db.tb_pedidoCabe.Add(pedCabe);
            Session["Pedido"] = pedCabe;
            db.SaveChanges();
        }

        public void AddToPedidoDetalle()
        {
            tb_pedidoCabe pedCabe = (tb_pedidoCabe)Session["Pedido"];
            usuario usu = (usuario)Session["usuario"];
            var ped = db.tb_pedidoCabe.SingleOrDefault(p => p.id_usuario == usu.idusuario && p.id_pedido == pedCabe.id_pedido);
            var cart = CarritoDeCompras.GetCart(this.HttpContext);
            var item = cart.GetCartItems();
            tb_pedidoDeta pedDeta;

            foreach (var c in item)
            {
                pedDeta = new tb_pedidoDeta()
                {
                    id_pedido = ped.id_pedido,
                    id_prod = c.id_prod,
                    precioPorUnidad = c.tb_producto.precio_prod,
                    cantidad_pedido = c.Cantidad
                };
                db.tb_pedidoDeta.Add(pedDeta);
            };
            db.SaveChanges();
        }

        public List<BoletaPedido> ListaBoletaPedido(int idUsu, int idPedCabe)
        {
            List<BoletaPedido> lista = new List<BoletaPedido>();
            SqlCommand cmd = new SqlCommand("sp_boletaPedido", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsu", idUsu);
            cmd.Parameters.AddWithValue("@idPed", idPedCabe);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new BoletaPedido()
                {
                    nombreProducto = dr.GetString(0),
                    precio = dr.GetDecimal(1),
                    cantidad = dr.GetInt32(2),
                    fechaPedido = dr.GetDateTime(3),
                    importeTotal = dr.GetDecimal(4)
                });
            }
            dr.Close(); cn.Close();
            return lista;
        }

        public ActionResult PagarCarrito()
        {
            var cart = CarritoDeCompras.GetCart(this.HttpContext);
            var item = cart.GetCartItems();

            foreach (var c in item)
            {
                var carri = db.Carrito.Single(o => o.CarritoID == c.CarritoID);
                AddToPedido(carri);
                AddToPedidoDetalle();
                db.Carrito.RemoveRange(db.Carrito.Where(x => x.CarritoID == c.CarritoID));
                break;
            };

            //Luego de registrar el tb_pedidoCabe y tb_pedidoDeta mostrar la Boleta de Pedido
            usuario usu = (usuario)Session["usuario"];
            tb_pedidoCabe cabe = (tb_pedidoCabe)Session["Pedido"];

            List<BoletaPedido> lista;
            lista = ListaBoletaPedido(usu.idusuario, cabe.id_pedido);
            return View(lista);
        }

        //Metodos para listar todos los pedidos de un Cliente
        public List<PedidoTracking> ListaPedidosCliente(int idUsu)
        {
            List<PedidoTracking> lista = new List<PedidoTracking>();
            SqlCommand cmd = new SqlCommand("sp_listaPedidos", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsu", idUsu);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new PedidoTracking()
                {
                    idPedido = dr.GetInt32(0),
                    fechaPedido = dr.GetDateTime(1),
                    descripcionEstado = dr.GetString(2),
                    importeTotal = dr.GetDecimal(3)
                });
            }
            dr.Close(); cn.Close();
            return lista;
        }

        public ActionResult AllPedidos()
        {
            usuario usu = (usuario)Session["usuario"];
            List<PedidoTracking> lista;
            lista = ListaPedidosCliente(usu.idusuario);
            return View(lista);
        }

        //Metodos para el Tracking de Cliente
        public List<PedidoTracking> ListaPedidoTracking(int idUsu, int idPedCabe)
        {
            List<PedidoTracking> lista = new List<PedidoTracking>();
            SqlCommand cmd = new SqlCommand("sp_listaPedidosDetallado", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUsu", idUsu);
            cmd.Parameters.AddWithValue("@idPed", idPedCabe);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new PedidoTracking()
                {
                    idPedido = dr.GetInt32(0),
                    NomApeCliente = dr.GetString(1),
                    fechaPedido = dr.GetDateTime(2),
                    descripcionEstado = dr.GetString(3),
                    descripcionProducto = dr.GetString(4),
                    precioProducto = dr.GetDecimal(5),
                    cantidad = dr.GetInt32(6),
                    importeTotal = dr.GetDecimal(7)
                });
            }
            dr.Close(); cn.Close();
            return lista;
        }

        public ActionResult TrackingCliente(int idPed)
        {
            usuario usu = (usuario)Session["usuario"];
            List<PedidoTracking> lista;
            lista = ListaPedidoTracking(usu.idusuario, idPed);
            return View(lista);
        }


        public ActionResult ServicioCliente(int? id = 0)
        {
            List<tb_servicio> ListarServicio;
            if (id.HasValue && id.Value != 0)
            {
                ListarServicio = db.tb_servicio.Where(x => x.id_servicio == id).ToList();
            }
            else
            {
                ListarServicio = db.tb_servicio.ToList();
            }

            ViewBag.servicios = db.tb_servicio.ToList();
            return View(ListarServicio);
        }
        public ActionResult VerServiciosDetallado(int id)
        {
            var s = db.tb_servicio.Find(id);
            return View(s);
        }

        /*public ActionResult ReservarServicio(int id)
        {
            var s = db.tb_reservarservicio.Find(id);
            return View(s);
        }*/
    }
}