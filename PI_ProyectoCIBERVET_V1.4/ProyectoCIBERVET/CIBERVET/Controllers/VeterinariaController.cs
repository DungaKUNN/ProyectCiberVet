using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIBERVET.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using CIBERVET.Filters;

namespace CIBERVET.Controllers
{
    public class VeterinariaController : Controller
    {
        BD_CIBERVETEntities bd = new BD_CIBERVETEntities();
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public ActionResult LoginVeterinaria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginVeterinaria(string usu, string contra)
        {
            try
            {
                using (bd)
                {
                    var oUsuario = (from u in bd.tb_usuario
                                    where u.email_usuario == usu.Trim() && u.password_usuario == contra.Trim()
                                    select u).FirstOrDefault();
                    if (oUsuario == null)
                    {
                        ViewBag.Error = "Usuario o contraseña incorrectos.";
                        return View();
                    }
                    // Si el usuario existe
                    Session["UsuarioVeterinaria"] = oUsuario;
                    Session["UsuarioVeterinariaNombre"] = oUsuario.nombre_usuario.ToString();
                    Session["UsuarioVeterinariaApellido"] = oUsuario.apellido_usuario.ToString();
                }

                return RedirectToAction("HomeVeterinaria", "Veterinaria");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        public ActionResult CerrarSesionVeterinaria()
        {
            if (Session["UsuarioVeterinaria"] != null)
            {
                Session["UsuarioVeterinaria"] = null;
            }
            return RedirectToAction("Home", "PagPrin");/*POSIBLE CAMBIOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO*/
        }

        public ActionResult HomeVeterinaria()
        {
            if (Session["UsuarioVeterinaria"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginVeterinaria", "Veterinaria");
            }
        }

        /*---------------------Mantenimiento Producto---------------------*/
        public List<CategoriaForCRUD> ListarCategorias()
        {
            List<CategoriaForCRUD> lista = new List<CategoriaForCRUD>();
            SqlCommand cmd = new SqlCommand("sp_ListarCategorias", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new CategoriaForCRUD()
                {
                    idCate = dr.GetInt32(0),
                    descripcion = dr.GetString(1)
                });
            }
            dr.Close(); cn.Close();
            return lista;
        }

        public List<ProveedorForCRUD> ListarProveedores()
        {
            List<ProveedorForCRUD> lista = new List<ProveedorForCRUD>();
            SqlCommand cmd = new SqlCommand("sp_ListarProveedores", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new ProveedorForCRUD()
                {
                    idProve = dr.GetInt32(0),
                    razonSocial = dr.GetString(1)
                });
            }
            dr.Close(); cn.Close();
            return lista;
        }

        public List<ProductoForCRUD> ListarProductos()
        {
            List<ProductoForCRUD> lista = new List<ProductoForCRUD>();
            SqlCommand cmd = new SqlCommand("sp_ListarProductos", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new ProductoForCRUD()
                {
                    IdProducto = dr.GetInt32(0),
                    desSimple = dr.GetString(1),
                    precio = dr.GetDecimal(2),
                    stock = dr.GetInt32(3),
                    serie = dr.GetString(4),
                    marca = dr.GetString(5),
                    categoria = dr.GetString(6),
                    proveedor = dr.GetString(7),
                    desHTML = dr.GetString(8),
                    foto1 = dr.GetString(9),
                    foto2 = dr.GetString(10),
                    foto3 = dr.GetString(11)
                });
            }
            dr.Close(); cn.Close();
            return lista;
        }

        public int InsertarProducto(ProductoForCRUD p)
        {
            int resultado = -1;
            SqlCommand cmd = new SqlCommand("sp_InsertarProducto", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@desSimple", p.desSimple);
            cmd.Parameters.AddWithValue("@pre", p.precio);
            cmd.Parameters.AddWithValue("@stk", p.stock);
            cmd.Parameters.AddWithValue("@serie", p.serie);
            cmd.Parameters.AddWithValue("@marca", p.marca);
            cmd.Parameters.AddWithValue("@idCat", p.Idcategoria);
            cmd.Parameters.AddWithValue("@idProve", p.Idproveedor);
            cmd.Parameters.AddWithValue("@desHTML", p.desHTML);
            cmd.Parameters.AddWithValue("@foto1", p.foto1);
            cmd.Parameters.AddWithValue("@foto2", p.foto2);
            cmd.Parameters.AddWithValue("@foto3", p.foto3);
            cn.Open();
            resultado = cmd.ExecuteNonQuery();
            cn.Close();
            return resultado;
        }

        public int ActualizarProducto(ProductoForCRUD p)
        {
            int resultado = -1;
            SqlCommand cmd = new SqlCommand("sp_ActualizarProducto", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@desSimple", p.desSimple);
            cmd.Parameters.AddWithValue("@pre", p.precio);
            cmd.Parameters.AddWithValue("@stk", p.stock);
            cmd.Parameters.AddWithValue("@serie", p.serie);
            cmd.Parameters.AddWithValue("@marca", p.marca);
            cmd.Parameters.AddWithValue("@idCat", p.Idcategoria);
            cmd.Parameters.AddWithValue("@idProve", p.Idproveedor);
            cmd.Parameters.AddWithValue("@desHTML", p.desHTML);
            cmd.Parameters.AddWithValue("@foto1", p.foto1);
            cmd.Parameters.AddWithValue("@foto2", p.foto2);
            cmd.Parameters.AddWithValue("@foto3", p.foto3);
            cmd.Parameters.AddWithValue("@id", p.IdProducto);
            cn.Open();
            resultado = cmd.ExecuteNonQuery();
            cn.Close();
            return resultado;
        }

        [AutorizarUsuario(idOperacion: 1)]
        public ActionResult MantenimientoProductos()
        {
            return View(ListarProductos());
        }

        // GET: Producto/Create
        public ActionResult RegistrarProducto()
        {
            // Almacenar listas en ViewBag
            ViewBag.categorias = ListarCategorias();
            ViewBag.proveedores = ListarProveedores();
            return View(new ProductoForCRUD());
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult RegistrarProducto(ProductoForCRUD p, HttpPostedFileBase archivo1, HttpPostedFileBase archivo2, HttpPostedFileBase archivo3)
        {
            if (archivo1 == null || archivo2 == null || archivo3 == null)
            {
                ViewBag.Mensaje = "Seleccione una foto";
                ViewBag.categorias = ListarCategorias();
                ViewBag.proveedores = ListarProveedores();
                return View(p);
            }

            if (Path.GetExtension(archivo1.FileName) != ".jpg" || Path.GetExtension(archivo2.FileName) != ".jpg" || Path.GetExtension(archivo3.FileName) != ".jpg")
            {
                ViewBag.Mensaje = "Formato permitido: .jpg";
                ViewBag.categorias = ListarCategorias();
                ViewBag.proveedores = ListarProveedores();
                return View(p);
            }
            p.foto1 = archivo1.FileName;
            p.foto2 = archivo2.FileName;
            p.foto3 = archivo3.FileName;
            InsertarProducto(p);
            archivo1.SaveAs(Path.Combine(Server.MapPath("~/images/"),
                            Path.GetFileName(archivo1.FileName)));
            archivo2.SaveAs(Path.Combine(Server.MapPath("~/images/"),
                            Path.GetFileName(archivo2.FileName)));
            archivo3.SaveAs(Path.Combine(Server.MapPath("~/images/"),
                            Path.GetFileName(archivo3.FileName)));

            return RedirectToAction("MantenimientoProductos");
        }

        public ActionResult ModificarProducto(int id)
        {
            ProductoForCRUD reg = ListarProductos().Where(pl => pl.IdProducto == id).FirstOrDefault();
            ViewBag.categorias = ListarCategorias();
            ViewBag.proveedores = ListarProveedores();
            return View(reg);
        }

        [HttpPost]
        public ActionResult ModificarProducto(HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, ProductoForCRUD p)
        {
            /*if (file1 == null && p.foto1 == null)
            {
                ViewBag.Mensaje = "Seleccione una foto";
                ViewBag.categorias = ListarCategorias();
                ViewBag.proveedores = ListarProveedores();
                return View(p);
            }

            if (file2 == null && p.foto2 == null)
            {
                ViewBag.Mensaje = "Seleccione una foto";
                ViewBag.categorias = ListarCategorias();
                ViewBag.proveedores = ListarProveedores();
                return View(p);
            }

            if (file3 == null && p.foto3 == null)
            {
                ViewBag.Mensaje = "Seleccione una foto";
                ViewBag.categorias = ListarCategorias();
                ViewBag.proveedores = ListarProveedores();
                return View(p);
            }

            if (file1 != null && Path.GetExtension(file1.FileName) != ".jpg")
            {
                ViewBag.Mensaje = "Formato permitido: .jpg";
                ViewBag.categorias = ListarCategorias();
                ViewBag.proveedores = ListarProveedores();
                return View(p);
            }

            if (file2 != null && Path.GetExtension(file2.FileName) != ".jpg")
            {
                ViewBag.Mensaje = "Formato permitido: .jpg";
                ViewBag.categorias = ListarCategorias();
                ViewBag.proveedores = ListarProveedores();
                return View(p);
            }

            if (file3 != null && Path.GetExtension(file3.FileName) != ".jpg")
            {
                ViewBag.Mensaje = "Formato permitido: .jpg";
                ViewBag.categorias = ListarCategorias();
                ViewBag.proveedores = ListarProveedores();
                return View(p);
            }*/

            if (file1 != null)
            {
                p.foto1 = file1.FileName;
                file1.SaveAs(Path.Combine(Server.MapPath("~/images/"),
                            Path.GetFileName(file1.FileName)));
            }

            if (file2 != null)
            {
                p.foto2 = file2.FileName;
                file2.SaveAs(Path.Combine(Server.MapPath("~/images/"),
                            Path.GetFileName(file2.FileName)));
            }

            if (file3 != null)
            {
                p.foto3 = file3.FileName;
                file3.SaveAs(Path.Combine(Server.MapPath("~/images/"),
                            Path.GetFileName(file3.FileName)));
            }
            ActualizarProducto(p);
            return RedirectToAction("MantenimientoProductos");
        }

        public ActionResult DetalleProducto(int id)
        {
            ProductoForCRUD reg = ListarProductos().Where(e => e.IdProducto == id).FirstOrDefault();
            return View(reg);
        }

        public ActionResult EliminarProducto(int id)
        {
            tb_producto producto = bd.tb_producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        [HttpPost, ActionName("EliminarProducto")]
        public ActionResult EliminarProductoPost(int id)
        {
            tb_producto producto = bd.tb_producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            bd.tb_producto.Remove(producto);
            bd.SaveChanges();
            return RedirectToAction("MantenimientoProductos");
        }
        /*----------------------------------------------------------------*/

        /*---------------------Mantenimiento Servicio---------------------*/
        public List<ServicioForCRUD> ListarServicios()
        {
            List<ServicioForCRUD> lista = new List<ServicioForCRUD>();
            SqlCommand cmd = new SqlCommand("sp_ListarServicios", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new ServicioForCRUD()
                {
                    idServicio = dr.GetInt32(0),
                    nombre = dr.GetString(1),
                    precio = dr.GetDecimal(2),
                    descripcion = dr.GetString(3),
                    horario = dr.GetString(4),
                    fecha = dr.GetDateTime(5)
                });
            }
            dr.Close(); cn.Close();
            return lista;
        }

        public int InsertarServicio(ServicioForCRUD s)
        {
            int resultado = -1;
            SqlCommand cmd = new SqlCommand("sp_InsertarServicio", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nom", s.nombre);
            cmd.Parameters.AddWithValue("@pre", s.precio);
            cmd.Parameters.AddWithValue("@des", s.descripcion);
            cmd.Parameters.AddWithValue("@horario", s.horario);
            cmd.Parameters.AddWithValue("@fecha", s.fecha);
            cn.Open();
            resultado = cmd.ExecuteNonQuery();
            cn.Close();
            return resultado;
        }
        public int ActualizarServicio(ServicioForCRUD s)
        {
            int resultado = -1;
            SqlCommand cmd = new SqlCommand("sp_ActualizarServicio", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nom", s.nombre);
            cmd.Parameters.AddWithValue("@pre", s.precio);
            cmd.Parameters.AddWithValue("@des", s.descripcion);
            cmd.Parameters.AddWithValue("@horario", s.horario);
            cmd.Parameters.AddWithValue("@fecha", s.fecha);
            cmd.Parameters.AddWithValue("@id", s.idServicio);
            cn.Open();
            resultado = cmd.ExecuteNonQuery();
            cn.Close();
            return resultado;
        }

        [AutorizarUsuario(idOperacion: 2)]
        public ActionResult MantenimientoServicios()
        {
            return View(ListarServicios());
        }

        public ActionResult RegistrarServicio()
        {
            return View(new ServicioForCRUD());
        }

        [HttpPost]
        public ActionResult RegistrarServicio(ServicioForCRUD s)
        {
            InsertarServicio(s);
            return RedirectToAction("MantenimientoServicios");
        }

        public ActionResult ModificarServicio(int id)
        {
            ServicioForCRUD reg = ListarServicios().Where(s => s.idServicio == id).FirstOrDefault();
            return View(reg);
        }

        [HttpPost]
        public ActionResult ModificarServicio(ServicioForCRUD s)
        {
            ActualizarServicio(s);
            return RedirectToAction("MantenimientoServicios");
        }

        public ActionResult DetalleServicio(int id)
        {
            ServicioForCRUD reg = ListarServicios().Where(servi => servi.idServicio == id).FirstOrDefault();
            return View(reg);
        }

        public ActionResult EliminarServicio(int id)
        {
            tb_servicio servicio = bd.tb_servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        [HttpPost, ActionName("EliminarServicio")]
        public ActionResult EliminarServicioPost(int id)
        {
            tb_servicio servicio = bd.tb_servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            bd.tb_servicio.Remove(servicio);
            bd.SaveChanges();
            return RedirectToAction("MantenimientoServicios");
        }
        /*----------------------------------------------------------------*/

        /*------------------Metodos para cambiar el estadoPedido desde Administrador------------------*/
        public List<PedidoTracking> ListarPedidosPorApellido(string ape)
        {
            List<PedidoTracking> lista = new List<PedidoTracking>();
            SqlCommand cmd = new SqlCommand("sp_FiltroPedidoPorApellido", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@apeUsu", ape);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new PedidoTracking()
                {
                    idPedido = dr.GetInt32(0),
                    NomApeCliente = dr.GetString(1),
                    fechaPedido = dr.GetDateTime(2),
                    descripcionEstado = dr.GetString(3)
                });
            }
            dr.Close(); cn.Close();
            return lista;
        }

        public List<tb_estado> ListarEstados()
        {
            List<tb_estado> lista = new List<tb_estado>();
            SqlCommand cmd = new SqlCommand("sp_ListarEstados", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new tb_estado()
                {
                    id_estado = dr.GetInt32(0),
                    descripcion_estado = dr.GetString(1)
                });
            }
            dr.Close(); cn.Close();
            return lista;
        }

        public int ActualizarEstadoPedido(PedidoTracking p)
        {
            int resultado = -1;
            SqlCommand cmd = new SqlCommand("sp_EditarEstadoPedido", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idEstado", p.idEstado);
            cmd.Parameters.AddWithValue("@idPedCabe", p.idPedido);
            cn.Open();
            resultado = cmd.ExecuteNonQuery();
            cn.Close();
            return resultado;
        }

        [AutorizarUsuario(idOperacion: 3)]
        public ActionResult TrackingPersonalVentas(string apellido)
        {
            if (string.IsNullOrEmpty(apellido))
            {
                apellido = string.Empty;
            }

            List<PedidoTracking> lista = ListarPedidosPorApellido(apellido);
            ViewBag.apellidos = apellido;

            return View(lista);
        }

        public ActionResult ModificarEstadoPedido(int id)
        {
            PedidoTracking pedido = new PedidoTracking();
            pedido.idPedido = id;
            ViewBag.estados = ListarEstados();
            return View(pedido);
        }

        [HttpPost]
        public ActionResult ModificarEstadoPedido(PedidoTracking p)
        {
            ActualizarEstadoPedido(p);
            return RedirectToAction("TrackingPersonalVentas");
        }
        /*---------------------------------------------------------------------------------------------*/

        /*------------------------------Metodos para Incidente de Mascota------------------------------*/
        public List<IncidenteMascota> ListarMascotaPorApellidoCliente(string ape)
        {
            List<IncidenteMascota> lista = new List<IncidenteMascota>();
            SqlCommand cmd = new SqlCommand("sp_FiltroMascotasPorApellidoCliente", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@apeUsu", ape);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new IncidenteMascota()
                {
                    NomApeCliente = dr.GetString(0),
                    nombreMascota = dr.GetString(1),
                    especie = dr.GetString(2),
                    sexo = dr.GetString(3),
                    raza = dr.GetString(4)
                });
            }
            dr.Close(); cn.Close();
            return lista;
        }

        [AutorizarUsuario(idOperacion: 5)]
        public ActionResult IncidenteMascota(string apellido)
        {
            if (string.IsNullOrEmpty(apellido))
            {
                apellido = string.Empty;
            }

            List<IncidenteMascota> lista = ListarMascotaPorApellidoCliente(apellido);
            ViewBag.apellidos = apellido;

            return View(lista);
        }
        /*--------------------------------------------------------------------------------------------*/
    }
}