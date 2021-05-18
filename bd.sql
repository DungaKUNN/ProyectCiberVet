USE [master]
GO
/****** Object:  Database [BD_CIBERVET]    Script Date: 17/05/2021 01:53:01:PM ******/
CREATE DATABASE [BD_CIBERVET]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD_CIBERVET', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BD_CIBERVET.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BD_CIBERVET_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BD_CIBERVET_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BD_CIBERVET] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD_CIBERVET].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD_CIBERVET] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BD_CIBERVET] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BD_CIBERVET] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BD_CIBERVET] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BD_CIBERVET] SET ARITHABORT OFF 
GO
ALTER DATABASE [BD_CIBERVET] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BD_CIBERVET] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BD_CIBERVET] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BD_CIBERVET] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BD_CIBERVET] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BD_CIBERVET] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BD_CIBERVET] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BD_CIBERVET] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BD_CIBERVET] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BD_CIBERVET] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BD_CIBERVET] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BD_CIBERVET] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BD_CIBERVET] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BD_CIBERVET] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BD_CIBERVET] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BD_CIBERVET] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BD_CIBERVET] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BD_CIBERVET] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BD_CIBERVET] SET  MULTI_USER 
GO
ALTER DATABASE [BD_CIBERVET] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BD_CIBERVET] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BD_CIBERVET] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BD_CIBERVET] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BD_CIBERVET] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BD_CIBERVET] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BD_CIBERVET] SET QUERY_STORE = OFF
GO
USE [BD_CIBERVET]
GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 17/05/2021 01:53:01:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrador](
	[idAdm] [int] IDENTITY(1,1) NOT NULL,
	[nombreAdm] [varchar](25) NOT NULL,
	[apellidoAdm] [varchar](25) NOT NULL,
	[iddistrito] [int] NULL,
	[dniAdm] [int] NOT NULL,
	[emailAdm] [varchar](50) NULL,
	[pwdAdm] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idAdm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carrito]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrito](
	[CarritoID] [int] IDENTITY(1,1) NOT NULL,
	[Identificador] [varchar](50) NOT NULL,
	[idusuario] [int] NULL,
	[id_prod] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CarritoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[especie_mascota]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[especie_mascota](
	[idespecie] [int] IDENTITY(1,1) NOT NULL,
	[especie] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idespecie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MASCOTA]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MASCOTA](
	[idmascota] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](45) NOT NULL,
	[idespecie] [int] NOT NULL,
	[sexo] [varchar](30) NOT NULL,
	[idraza] [int] NOT NULL,
	[foto] [varchar](100) NOT NULL,
	[idusuario] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idmascota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[raza_mascota]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[raza_mascota](
	[idraza] [int] IDENTITY(1,1) NOT NULL,
	[raza] [varchar](100) NOT NULL,
	[idespecie] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idraza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_categoria]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_categoria](
	[id_cate] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_cate] [varchar](80) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_distrito]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_distrito](
	[id_dis] [int] IDENTITY(1,1) NOT NULL,
	[nombre_dis] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_dis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_estado]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_estado](
	[id_estado] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_estado] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_pedidoCabe]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_pedidoCabe](
	[id_pedido] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario] [int] NULL,
	[fecha_pedido] [date] NOT NULL,
	[hora_pedido] [time](7) NOT NULL,
	[id_estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_pedidoDeta]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_pedidoDeta](
	[id_pedido] [int] NOT NULL,
	[id_prod] [int] NOT NULL,
	[id_servicio] [int] NOT NULL,
	[cantidad_pedido] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_pedido] ASC,
	[id_prod] ASC,
	[id_servicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_producto]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_producto](
	[id_prod] [int] IDENTITY(1,1) NOT NULL,
	[descripcionSimple_prod] [varchar](100) NOT NULL,
	[precio_prod] [decimal](10, 2) NOT NULL,
	[stock_prod] [int] NOT NULL,
	[serie_prod] [varchar](40) NULL,
	[marca_prod] [varchar](40) NOT NULL,
	[id_cate] [int] NULL,
	[id_prove] [int] NULL,
	[descripcionHTML_prod] [text] NOT NULL,
	[foto1_prod] [varchar](255) NULL,
	[foto2_prod] [varchar](255) NULL,
	[foto3_prod] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_prod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_proveedor]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_proveedor](
	[id_prove] [int] IDENTITY(1,1) NOT NULL,
	[nombres_prove] [varchar](40) NOT NULL,
	[apellidos_prove] [varchar](40) NOT NULL,
	[razonSocial_prove] [varchar](80) NOT NULL,
	[direccion_prove] [varchar](80) NOT NULL,
	[celular_prove] [varchar](15) NOT NULL,
	[email_prove] [varchar](40) NULL,
	[id_dis] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_prove] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_servicio]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_servicio](
	[id_servicio] [int] IDENTITY(1,1) NOT NULL,
	[nombre_servicio] [varchar](100) NOT NULL,
	[precio_servicio] [decimal](10, 2) NOT NULL,
	[descripcion_servicio] [text] NOT NULL,
	[horario_servicio] [varchar](40) NOT NULL,
	[fecha_servicio] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_servicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TIPOUSUARIO]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPOUSUARIO](
	[Id_TipoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_TipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[idusuario] [int] IDENTITY(1,1) NOT NULL,
	[dni] [varchar](45) NULL,
	[nombre] [varchar](45) NULL,
	[apellido] [varchar](45) NULL,
	[login] [varchar](45) NULL,
	[password] [varchar](45) NULL,
	[celular] [varchar](45) NULL,
	[correo] [varchar](45) NULL,
	[direccion] [varchar](45) NULL,
	[IdDistritos] [int] NULL,
	[IdTipoUsuarios] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Administrador]  WITH CHECK ADD  CONSTRAINT [fk_admindis] FOREIGN KEY([iddistrito])
REFERENCES [dbo].[tb_distrito] ([id_dis])
GO
ALTER TABLE [dbo].[Administrador] CHECK CONSTRAINT [fk_admindis]
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD  CONSTRAINT [FK_Carrito_tb_producto] FOREIGN KEY([id_prod])
REFERENCES [dbo].[tb_producto] ([id_prod])
GO
ALTER TABLE [dbo].[Carrito] CHECK CONSTRAINT [FK_Carrito_tb_producto]
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD  CONSTRAINT [FK_Carrito_usuario] FOREIGN KEY([idusuario])
REFERENCES [dbo].[usuario] ([idusuario])
GO
ALTER TABLE [dbo].[Carrito] CHECK CONSTRAINT [FK_Carrito_usuario]
GO
ALTER TABLE [dbo].[MASCOTA]  WITH CHECK ADD  CONSTRAINT [fk_masespe] FOREIGN KEY([idespecie])
REFERENCES [dbo].[especie_mascota] ([idespecie])
GO
ALTER TABLE [dbo].[MASCOTA] CHECK CONSTRAINT [fk_masespe]
GO
ALTER TABLE [dbo].[MASCOTA]  WITH CHECK ADD  CONSTRAINT [fk_masraza] FOREIGN KEY([idraza])
REFERENCES [dbo].[raza_mascota] ([idraza])
GO
ALTER TABLE [dbo].[MASCOTA] CHECK CONSTRAINT [fk_masraza]
GO
ALTER TABLE [dbo].[MASCOTA]  WITH CHECK ADD  CONSTRAINT [fk_masusu] FOREIGN KEY([idusuario])
REFERENCES [dbo].[usuario] ([idusuario])
GO
ALTER TABLE [dbo].[MASCOTA] CHECK CONSTRAINT [fk_masusu]
GO
ALTER TABLE [dbo].[raza_mascota]  WITH CHECK ADD  CONSTRAINT [fk_razaespe] FOREIGN KEY([idespecie])
REFERENCES [dbo].[especie_mascota] ([idespecie])
GO
ALTER TABLE [dbo].[raza_mascota] CHECK CONSTRAINT [fk_razaespe]
GO
ALTER TABLE [dbo].[tb_pedidoCabe]  WITH CHECK ADD  CONSTRAINT [fk_pedest] FOREIGN KEY([id_estado])
REFERENCES [dbo].[tb_estado] ([id_estado])
GO
ALTER TABLE [dbo].[tb_pedidoCabe] CHECK CONSTRAINT [fk_pedest]
GO
ALTER TABLE [dbo].[tb_pedidoCabe]  WITH CHECK ADD  CONSTRAINT [fk_pedusu] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([idusuario])
GO
ALTER TABLE [dbo].[tb_pedidoCabe] CHECK CONSTRAINT [fk_pedusu]
GO
ALTER TABLE [dbo].[tb_pedidoDeta]  WITH CHECK ADD  CONSTRAINT [fk_detacabe] FOREIGN KEY([id_pedido])
REFERENCES [dbo].[tb_pedidoCabe] ([id_pedido])
GO
ALTER TABLE [dbo].[tb_pedidoDeta] CHECK CONSTRAINT [fk_detacabe]
GO
ALTER TABLE [dbo].[tb_pedidoDeta]  WITH CHECK ADD  CONSTRAINT [fk_pedprod] FOREIGN KEY([id_prod])
REFERENCES [dbo].[tb_producto] ([id_prod])
GO
ALTER TABLE [dbo].[tb_pedidoDeta] CHECK CONSTRAINT [fk_pedprod]
GO
ALTER TABLE [dbo].[tb_pedidoDeta]  WITH CHECK ADD  CONSTRAINT [fk_pedservi] FOREIGN KEY([id_servicio])
REFERENCES [dbo].[tb_servicio] ([id_servicio])
GO
ALTER TABLE [dbo].[tb_pedidoDeta] CHECK CONSTRAINT [fk_pedservi]
GO
ALTER TABLE [dbo].[tb_producto]  WITH CHECK ADD  CONSTRAINT [fk_prodcate] FOREIGN KEY([id_cate])
REFERENCES [dbo].[tb_categoria] ([id_cate])
GO
ALTER TABLE [dbo].[tb_producto] CHECK CONSTRAINT [fk_prodcate]
GO
ALTER TABLE [dbo].[tb_producto]  WITH CHECK ADD  CONSTRAINT [fk_prodprove] FOREIGN KEY([id_prove])
REFERENCES [dbo].[tb_proveedor] ([id_prove])
GO
ALTER TABLE [dbo].[tb_producto] CHECK CONSTRAINT [fk_prodprove]
GO
ALTER TABLE [dbo].[tb_proveedor]  WITH CHECK ADD  CONSTRAINT [fk_provedis] FOREIGN KEY([id_dis])
REFERENCES [dbo].[tb_distrito] ([id_dis])
GO
ALTER TABLE [dbo].[tb_proveedor] CHECK CONSTRAINT [fk_provedis]
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [fk_usudis] FOREIGN KEY([IdDistritos])
REFERENCES [dbo].[tb_distrito] ([id_dis])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [fk_usudis]
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [fk_usutipo] FOREIGN KEY([IdTipoUsuarios])
REFERENCES [dbo].[TIPOUSUARIO] ([Id_TipoUsuario])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [fk_usutipo]
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarProducto]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_ActualizarProducto]
@id			int,
@desSimple	varchar(100),
@pre		decimal(10,2),
@stk		int,
@serie		varchar(40),
@marca		varchar(40),
@idCat		int,
@idProve	int,
@desHTML	text,
@foto1		varchar(255),
@foto2		varchar(255),
@foto3		varchar(255)
as
 begin
	UPDATE tb_producto set
	descripcionSimple_prod = @desSimple,
	precio_prod = @pre,
	stock_prod = @stk,
	serie_prod = @serie,
	marca_prod = @marca,
	id_cate = @idCat,
	id_prove = @idProve,
	descripcionHTML_prod = @desHTML,
	foto1_prod = @foto1,
	foto2_prod = @foto2,
	foto3_prod = @foto3
	where id_prod = @id
 end
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarServicio]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_ActualizarServicio]
@id			int,
@nom		varchar(100),
@pre		decimal(10,2),
@des		text,
@horario	varchar(40),
@fecha		date
as
 begin
	UPDATE tb_servicio set
	nombre_servicio = @nom,
	precio_servicio = @pre,
	descripcion_servicio = @des,
	horario_servicio = @horario,
	fecha_servicio = @fecha
	where id_servicio = @id
 end
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarUsuario]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_EditarUsuario]
	@idusu int,
	@dniusu varchar(50),
	@nomusu varchar(50),
	@apeusu	varchar(50),
	@logusu varchar(15),
	@passusu varchar(15),
	@celusu	varchar(30),
	@corusu	varchar(30),
	@dirusu	varchar(15),
	@iddis	int
as
	begin
		update usuario
		set dni = @dniusu, nombre = @nomusu, apellido = @apeusu, login = @logusu, password = @passusu, celular = @celusu,
		correo = @corusu,direccion = @dirusu,IdDistritos = @iddis,IdTipoUsuarios = 4
		where idusuario = @idusu
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_Insertar_Mascotas]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_Insertar_Mascotas]
 @nombre		varchar(45),
 @idespecie		int,
 @sexo			varchar(30),
 @idraza        int,
 @foto          varchar(100),
 @idusuario		int 
 as
 begin
	insert into MASCOTA(nombre,idespecie,sexo,idraza,foto,idusuario)
	values (@nombre,@idespecie,@sexo,@idraza,@foto,@idusuario)
 end
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarProducto]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_InsertarProducto]
@desSimple	varchar(100),
@pre		decimal(10,2),
@stk		int,
@serie		varchar(40),
@marca		varchar(40),
@idCat		int,
@idProve	int,
@desHTML	text,
@foto1		varchar(255),
@foto2		varchar(255),
@foto3		varchar(255)
as
 insert into tb_producto(descripcionSimple_prod,precio_prod,stock_prod,serie_prod,marca_prod,id_cate,id_prove,descripcionHTML_prod,foto1_prod,foto2_prod,foto3_prod)
 values (@desSimple,@pre,@stk,@serie,@marca,@idCat,@idProve,@desHTML,@foto1,@foto2,@foto3)
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarServicio]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_InsertarServicio]
@nom		varchar(100),
@pre		decimal(10,2),
@des		text,
@horario	varchar(40),
@fecha		date
as
 insert into tb_servicio(nombre_servicio,precio_servicio,descripcion_servicio,horario_servicio,fecha_servicio)
 values (@nom,@pre,@des,@horario,@fecha)
GO
/****** Object:  StoredProcedure [dbo].[sp_Listado_Mascotas]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*----------------------------------------------------------------------*/

/*---------------Procedimientos Almacenados para Mascotas---------------*/
create procedure [dbo].[sp_Listado_Mascotas]
 @idusuario		int
 as
 begin
	select m.idmascota as 'Codigo de Mascota',
	m.nombre as 'Nombre',
	e.especie as 'Especie',
	m.sexo as 'Sexo',
	r.raza as 'Raza',
	m.foto as 'Foto'
	from MASCOTA m join especie_mascota e on m.idespecie=e.idespecie
	join raza_mascota r on r.idraza=m.idraza join usuario u on  m.idusuario=u.idusuario
	where m.idusuario=@idusuario
 end
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarCategorias]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*----------------------------------------------------------------------------*/

/*-----------Procedimientos Almacenados para Mantenimiento Producto-----------*/
create procedure [dbo].[sp_ListarCategorias]
as
select c.id_cate,c.descripcion_cate
from tb_categoria c
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarProductos]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_ListarProductos]
as
select p.id_prod,p.descripcionSimple_prod,p.precio_prod,p.stock_prod,
	   p.serie_prod,p.marca_prod,c.descripcion_cate,prove.razonSocial_prove,
	   p.descripcionHTML_prod,ISNULL(p.foto1_prod,''),ISNULL(p.foto2_prod,''),ISNULL(p.foto3_prod,'')
from tb_producto p inner join tb_categoria c on p.id_cate = c.id_cate
				   inner join tb_proveedor prove on p.id_prove = prove.id_prove
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarProveedores]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_ListarProveedores]
as
select p.id_prove,p.razonSocial_prove
from tb_proveedor p
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarServicios]    Script Date: 17/05/2021 01:53:02:PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*----------------------------------------------------------------------------*/

/*-----------Procedimientos Almacenados para Mantenimiento Servicio-----------*/
create procedure [dbo].[sp_ListarServicios]
as
select s.id_servicio,s.nombre_servicio,s.precio_servicio,s.descripcion_servicio,
	   s.horario_servicio,s.fecha_servicio
from tb_servicio s
GO
USE [master]
GO
ALTER DATABASE [BD_CIBERVET] SET  READ_WRITE 
GO
