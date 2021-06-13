using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIBERVET.Models
{
    public class CarritoDeCompras
    {
        BD_CIBERVETEntities bd = new BD_CIBERVETEntities();
        string CarritoDeComprasId { get; set; }

        // Constante
        public const string idusu = "UserID";

        usuario obj = new usuario();

        //Obtener el Id del carrito 
        //claro como q en lugar q devuelva el nombre  
        //q devuelva el id
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[idusu] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[idusu] = context.User.Identity.Name;
                }
                else
                {
                    context.Session[idusu] = obj.idusuario.ToString();
                }
            }
            return context.Session[idusu].ToString();
        }

        // Obtener el carrito.  
        public static CarritoDeCompras GetCart(HttpContextBase context)
        {
            var cart = new CarritoDeCompras();
            cart.CarritoDeComprasId = cart.GetCartId(context);
            return cart;
        }

        // Método que puede ser invocado desde un controlador
        public static CarritoDeCompras GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        // Método que agrega un producto al carrito (en la BD)
        public void AddToCart(tb_producto p)
        {
            // Verifica si el producto ya se encuentra en el carrito de la bd
            var cartItem = bd.Carrito.SingleOrDefault(c =>
                        c.Identificador == CarritoDeComprasId && c.id_prod == p.id_prod);
            if (cartItem == null)
            {
                cartItem = new Carrito()
                {
                    id_prod = p.id_prod,
                    Identificador = CarritoDeComprasId,
                    Cantidad = 1,
                    Fecha = DateTime.Now
                };
                bd.Carrito.Add(cartItem);
            }
            else
            {
                cartItem.Cantidad++;
            }
            bd.SaveChanges();
        }

        public void DisToCart(tb_producto p)
        {
            // Verifica si el producto ya se encuentra en el carrito de la bd
            var cartItem = bd.Carrito.SingleOrDefault(c =>
                        c.Identificador == CarritoDeComprasId && c.id_prod == p.id_prod);
            if (cartItem == null)
            {
                cartItem = new Carrito()
                {
                    id_prod = p.id_prod,
                    Identificador = CarritoDeComprasId,
                    Cantidad = 1,
                    Fecha = DateTime.Now
                };
                bd.Carrito.Add(cartItem);
            }
            else if (cartItem != null)
            {
                
                bd.Carrito.Remove(cartItem);
            }
            else
            {
                cartItem.Cantidad--;
            }
            bd.SaveChanges();
        }

        // Método que remueve un producto del carrito (en la BD)
        public void RemoveToCart(tb_producto p)
        {
            // Verifica si el producto ya se encuentra en el carrito de la bd
            var cartItem = bd.Carrito.SingleOrDefault(c =>
                        c.Identificador == CarritoDeComprasId && c.id_prod == p.id_prod);
            if (cartItem != null)
            {
                //cartItem = new Carrito()
                //{
                //    IdProducto = p.IdProducto,
                //    Identificador = ShoppingCartId,
                //    Cantidad = 1,
                //    Fecha = DateTime.Now
                //};
                bd.Carrito.Remove(cartItem);
            }

            else
            {
                cartItem.Cantidad--;
            }
            bd.SaveChanges();
        }

        public List<Carrito> GetCartItems()
        {
            return bd.Carrito.Where(c => c.Identificador == CarritoDeComprasId).ToList();
        }

        public int GetCount()
        {
            // Suma todas las cantidades del carrito 
            int? count = (from cartItems in bd.Carrito
                          where cartItems.Identificador == CarritoDeComprasId
                          select (int?)cartItems.Cantidad).Sum();
            return count ?? 0;
        }
        public decimal GetTotal()
        {
            decimal? total = (from cartItems in bd.Carrito
                              where cartItems.Identificador == CarritoDeComprasId
                              select (int?)cartItems.Cantidad *
                                 cartItems.tb_producto.precio_prod).Sum();
            return total ?? decimal.Zero;
        }
      
    }
}