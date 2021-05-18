﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CIBERVET.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BD_CIBERVETEntities : DbContext
    {
        public BD_CIBERVETEntities()
            : base("name=BD_CIBERVETEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<especie_mascota> especie_mascota { get; set; }
        public virtual DbSet<MASCOTA> MASCOTA { get; set; }
        public virtual DbSet<raza_mascota> raza_mascota { get; set; }
        public virtual DbSet<tb_categoria> tb_categoria { get; set; }
        public virtual DbSet<tb_distrito> tb_distrito { get; set; }
        public virtual DbSet<tb_estado> tb_estado { get; set; }
        public virtual DbSet<tb_pedidoCabe> tb_pedidoCabe { get; set; }
        public virtual DbSet<tb_pedidoDeta> tb_pedidoDeta { get; set; }
        public virtual DbSet<tb_producto> tb_producto { get; set; }
        public virtual DbSet<tb_proveedor> tb_proveedor { get; set; }
        public virtual DbSet<tb_servicio> tb_servicio { get; set; }
        public virtual DbSet<TIPOUSUARIO> TIPOUSUARIO { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<Carrito> Carrito { get; set; }
    
        public virtual int sp_ActualizarProducto(Nullable<int> id, string desSimple, Nullable<decimal> pre, Nullable<int> stk, string serie, string marca, Nullable<int> idCat, Nullable<int> idProve, string desHTML, string foto1, string foto2, string foto3)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var desSimpleParameter = desSimple != null ?
                new ObjectParameter("desSimple", desSimple) :
                new ObjectParameter("desSimple", typeof(string));
    
            var preParameter = pre.HasValue ?
                new ObjectParameter("pre", pre) :
                new ObjectParameter("pre", typeof(decimal));
    
            var stkParameter = stk.HasValue ?
                new ObjectParameter("stk", stk) :
                new ObjectParameter("stk", typeof(int));
    
            var serieParameter = serie != null ?
                new ObjectParameter("serie", serie) :
                new ObjectParameter("serie", typeof(string));
    
            var marcaParameter = marca != null ?
                new ObjectParameter("marca", marca) :
                new ObjectParameter("marca", typeof(string));
    
            var idCatParameter = idCat.HasValue ?
                new ObjectParameter("idCat", idCat) :
                new ObjectParameter("idCat", typeof(int));
    
            var idProveParameter = idProve.HasValue ?
                new ObjectParameter("idProve", idProve) :
                new ObjectParameter("idProve", typeof(int));
    
            var desHTMLParameter = desHTML != null ?
                new ObjectParameter("desHTML", desHTML) :
                new ObjectParameter("desHTML", typeof(string));
    
            var foto1Parameter = foto1 != null ?
                new ObjectParameter("foto1", foto1) :
                new ObjectParameter("foto1", typeof(string));
    
            var foto2Parameter = foto2 != null ?
                new ObjectParameter("foto2", foto2) :
                new ObjectParameter("foto2", typeof(string));
    
            var foto3Parameter = foto3 != null ?
                new ObjectParameter("foto3", foto3) :
                new ObjectParameter("foto3", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ActualizarProducto", idParameter, desSimpleParameter, preParameter, stkParameter, serieParameter, marcaParameter, idCatParameter, idProveParameter, desHTMLParameter, foto1Parameter, foto2Parameter, foto3Parameter);
        }
    
        public virtual int sp_ActualizarServicio(Nullable<int> id, string nom, Nullable<decimal> pre, string des, string horario, Nullable<System.DateTime> fecha)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nomParameter = nom != null ?
                new ObjectParameter("nom", nom) :
                new ObjectParameter("nom", typeof(string));
    
            var preParameter = pre.HasValue ?
                new ObjectParameter("pre", pre) :
                new ObjectParameter("pre", typeof(decimal));
    
            var desParameter = des != null ?
                new ObjectParameter("des", des) :
                new ObjectParameter("des", typeof(string));
    
            var horarioParameter = horario != null ?
                new ObjectParameter("horario", horario) :
                new ObjectParameter("horario", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ActualizarServicio", idParameter, nomParameter, preParameter, desParameter, horarioParameter, fechaParameter);
        }
    
        public virtual int sp_EditarUsuario(Nullable<int> idusu, string dniusu, string nomusu, string apeusu, string logusu, string passusu, string celusu, string corusu, string dirusu, Nullable<int> iddis)
        {
            var idusuParameter = idusu.HasValue ?
                new ObjectParameter("idusu", idusu) :
                new ObjectParameter("idusu", typeof(int));
    
            var dniusuParameter = dniusu != null ?
                new ObjectParameter("dniusu", dniusu) :
                new ObjectParameter("dniusu", typeof(string));
    
            var nomusuParameter = nomusu != null ?
                new ObjectParameter("nomusu", nomusu) :
                new ObjectParameter("nomusu", typeof(string));
    
            var apeusuParameter = apeusu != null ?
                new ObjectParameter("apeusu", apeusu) :
                new ObjectParameter("apeusu", typeof(string));
    
            var logusuParameter = logusu != null ?
                new ObjectParameter("logusu", logusu) :
                new ObjectParameter("logusu", typeof(string));
    
            var passusuParameter = passusu != null ?
                new ObjectParameter("passusu", passusu) :
                new ObjectParameter("passusu", typeof(string));
    
            var celusuParameter = celusu != null ?
                new ObjectParameter("celusu", celusu) :
                new ObjectParameter("celusu", typeof(string));
    
            var corusuParameter = corusu != null ?
                new ObjectParameter("corusu", corusu) :
                new ObjectParameter("corusu", typeof(string));
    
            var dirusuParameter = dirusu != null ?
                new ObjectParameter("dirusu", dirusu) :
                new ObjectParameter("dirusu", typeof(string));
    
            var iddisParameter = iddis.HasValue ?
                new ObjectParameter("iddis", iddis) :
                new ObjectParameter("iddis", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EditarUsuario", idusuParameter, dniusuParameter, nomusuParameter, apeusuParameter, logusuParameter, passusuParameter, celusuParameter, corusuParameter, dirusuParameter, iddisParameter);
        }
    
        public virtual int sp_Insertar_Mascotas(string nombre, Nullable<int> idespecie, string sexo, Nullable<int> idraza, string foto, Nullable<int> idusuario)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var idespecieParameter = idespecie.HasValue ?
                new ObjectParameter("idespecie", idespecie) :
                new ObjectParameter("idespecie", typeof(int));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("sexo", sexo) :
                new ObjectParameter("sexo", typeof(string));
    
            var idrazaParameter = idraza.HasValue ?
                new ObjectParameter("idraza", idraza) :
                new ObjectParameter("idraza", typeof(int));
    
            var fotoParameter = foto != null ?
                new ObjectParameter("foto", foto) :
                new ObjectParameter("foto", typeof(string));
    
            var idusuarioParameter = idusuario.HasValue ?
                new ObjectParameter("idusuario", idusuario) :
                new ObjectParameter("idusuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Insertar_Mascotas", nombreParameter, idespecieParameter, sexoParameter, idrazaParameter, fotoParameter, idusuarioParameter);
        }
    
        public virtual int sp_InsertarProducto(string desSimple, Nullable<decimal> pre, Nullable<int> stk, string serie, string marca, Nullable<int> idCat, Nullable<int> idProve, string desHTML, string foto1, string foto2, string foto3)
        {
            var desSimpleParameter = desSimple != null ?
                new ObjectParameter("desSimple", desSimple) :
                new ObjectParameter("desSimple", typeof(string));
    
            var preParameter = pre.HasValue ?
                new ObjectParameter("pre", pre) :
                new ObjectParameter("pre", typeof(decimal));
    
            var stkParameter = stk.HasValue ?
                new ObjectParameter("stk", stk) :
                new ObjectParameter("stk", typeof(int));
    
            var serieParameter = serie != null ?
                new ObjectParameter("serie", serie) :
                new ObjectParameter("serie", typeof(string));
    
            var marcaParameter = marca != null ?
                new ObjectParameter("marca", marca) :
                new ObjectParameter("marca", typeof(string));
    
            var idCatParameter = idCat.HasValue ?
                new ObjectParameter("idCat", idCat) :
                new ObjectParameter("idCat", typeof(int));
    
            var idProveParameter = idProve.HasValue ?
                new ObjectParameter("idProve", idProve) :
                new ObjectParameter("idProve", typeof(int));
    
            var desHTMLParameter = desHTML != null ?
                new ObjectParameter("desHTML", desHTML) :
                new ObjectParameter("desHTML", typeof(string));
    
            var foto1Parameter = foto1 != null ?
                new ObjectParameter("foto1", foto1) :
                new ObjectParameter("foto1", typeof(string));
    
            var foto2Parameter = foto2 != null ?
                new ObjectParameter("foto2", foto2) :
                new ObjectParameter("foto2", typeof(string));
    
            var foto3Parameter = foto3 != null ?
                new ObjectParameter("foto3", foto3) :
                new ObjectParameter("foto3", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertarProducto", desSimpleParameter, preParameter, stkParameter, serieParameter, marcaParameter, idCatParameter, idProveParameter, desHTMLParameter, foto1Parameter, foto2Parameter, foto3Parameter);
        }
    
        public virtual int sp_InsertarServicio(string nom, Nullable<decimal> pre, string des, string horario, Nullable<System.DateTime> fecha)
        {
            var nomParameter = nom != null ?
                new ObjectParameter("nom", nom) :
                new ObjectParameter("nom", typeof(string));
    
            var preParameter = pre.HasValue ?
                new ObjectParameter("pre", pre) :
                new ObjectParameter("pre", typeof(decimal));
    
            var desParameter = des != null ?
                new ObjectParameter("des", des) :
                new ObjectParameter("des", typeof(string));
    
            var horarioParameter = horario != null ?
                new ObjectParameter("horario", horario) :
                new ObjectParameter("horario", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertarServicio", nomParameter, preParameter, desParameter, horarioParameter, fechaParameter);
        }
    
        public virtual ObjectResult<sp_Listado_Mascotas_Result> sp_Listado_Mascotas(Nullable<int> idusuario)
        {
            var idusuarioParameter = idusuario.HasValue ?
                new ObjectParameter("idusuario", idusuario) :
                new ObjectParameter("idusuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Listado_Mascotas_Result>("sp_Listado_Mascotas", idusuarioParameter);
        }
    
        public virtual ObjectResult<sp_ListarCategorias_Result> sp_ListarCategorias()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ListarCategorias_Result>("sp_ListarCategorias");
        }
    
        public virtual ObjectResult<sp_ListarProductos_Result> sp_ListarProductos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ListarProductos_Result>("sp_ListarProductos");
        }
    
        public virtual ObjectResult<sp_ListarProveedores_Result> sp_ListarProveedores()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ListarProveedores_Result>("sp_ListarProveedores");
        }
    
        public virtual ObjectResult<sp_ListarServicios_Result> sp_ListarServicios()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ListarServicios_Result>("sp_ListarServicios");
        }

        public System.Data.Entity.DbSet<CIBERVET.Models.ProductoForCRUD> ProductoForCRUDs { get; set; }
    }
}
