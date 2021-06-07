use master
go

if DB_ID('BD_CIBERVET') is not null
drop database BD_CIBERVET
create database BD_CIBERVET
go

use BD_CIBERVET
go

/*-----------------------------Tablas y Registros-----------------------------*/
create table tb_distrito
(
 id_dis			int identity(1,1) primary key not null,
 nombre_dis		varchar(50) not null
);
go

insert into tb_distrito values('Los Olivos')
insert into tb_distrito values('Independencia')
insert into tb_distrito values('Comas')
insert into tb_distrito values('Puente Piedra')
go

create table Administrador
(
 idAdm			int identity(1,1) primary key not null,
 nombreAdm		varchar(25) NOT NULL,
 apellidoAdm	varchar(25) NOT NULL,
 iddistrito		int NULL,
 dniAdm			int NOT NULL,
 emailAdm		varchar(50) NULL,
 pwdAdm			varchar(50) NULL,
 constraint fk_admindis foreign key(iddistrito)
 references tb_distrito(id_dis)
);
go

insert into Administrador values('Jeanpier','Araujo',2,75234281,'Admin2021@hotmail.com','123')
insert into Administrador values('Yhon','Alama',4,72643455,'yhon@gmail.com','1234')
go

create table TIPOUSUARIO
(
 Id_TipoUsuario		int identity(1,1) primary key not null,
 descripcion		varchar(45) NOT NULL
);
go

insert into TIPOUSUARIO values('Administrador')
insert into TIPOUSUARIO values('Veterinario')
insert into TIPOUSUARIO values('Personal de Ventas')
insert into TIPOUSUARIO values('Cliente')
go

create table usuario
(
 idusuario			int identity(1,1) primary key not null,
 dni				varchar(45) NULL,
 nombre				varchar(45) NULL,
 apellido			varchar(45) NULL,
 login				varchar(45) NULL,
 password			varchar(45) NULL,
 celular			varchar(45) NULL,
 correo				varchar(45) NULL,
 direccion			varchar(45) NULL,
 IdDistritos		int NULL,
 IdTipoUsuarios		int NULL,
 constraint fk_usudis foreign key(IdDistritos)
 references tb_distrito(id_dis),
 constraint fk_usutipo foreign key(IdTipoUsuarios)
 references TIPOUSUARIO(Id_TipoUsuario)
);
go

insert into usuario values('12345678','Mario','Bros','marbro','1234','123456789','marbro@hotmail.com','Calle setas 123',4,4)
go

create table especie_mascota
(
 idespecie		int identity(1,1) primary key,
 especie		varchar(100) not null
);
go

insert into especie_mascota values('Canino')
insert into especie_mascota values('Felino')
insert into especie_mascota values('Ave')
insert into especie_mascota values('Pez')
insert into especie_mascota values('Roedor')
go

create table raza_mascota
(
 idraza			int identity(1,1) primary key,
 raza			varchar(100) not null,
 idespecie		int not null,
 constraint fk_razaespe foreign key(idespecie)
 references especie_mascota(idespecie)
);
go

insert into raza_mascota values('Barbet',1)
insert into raza_mascota values('Dogo Canario',1)
insert into raza_mascota values('mastiff',1)
insert into raza_mascota values('Pug',1)
insert into raza_mascota values('Chihuahua',1)
insert into raza_mascota values('Otro',1)
insert into raza_mascota values('Canario',3)
insert into raza_mascota values('Catas',3)
insert into raza_mascota values('Loros',3)
insert into raza_mascota values('Cacatúas',3)
insert into raza_mascota values('Otro',3)
insert into raza_mascota values('Bengala',2)
insert into raza_mascota values('Birmano',2)
insert into raza_mascota values('Persa',2)
insert into raza_mascota values('Otro',2)
insert into raza_mascota values('Ramirezi',4)
insert into raza_mascota values('Tetras',4)
insert into raza_mascota values('Guppysa',4)
insert into raza_mascota values('Otro',4)
insert into raza_mascota values('Hamster',5)
insert into raza_mascota values('Cuy',5)
insert into raza_mascota values('Ardilla',5)
insert into raza_mascota values('Otro',5)
go

create table MASCOTA
(
 idmascota		int identity(1,1) primary key not null,
 nombre			varchar(45) not null,
 idespecie		int not null,
 sexo			varchar(30) not null,
 idraza         int not null,
 foto           varchar(100) not null,
 idusuario		int not null,
 constraint fk_masusu foreign key(idusuario)
 references usuario(idusuario),
 constraint fk_masraza foreign key(idraza)
 references raza_mascota(idraza),
 constraint fk_masespe foreign key(idespecie)
 references especie_mascota(idespecie)
);
go

create table tb_categoria
(
 id_cate			int identity(1,1) primary key not null,
 descripcion_cate	varchar(80) not null
);
go

insert into tb_categoria values('Alimentos y Snacks')
insert into tb_categoria values('Comederos y Bebederos')
insert into tb_categoria values('Collares y Correas')
insert into tb_categoria values('Juguetes')
insert into tb_categoria values('Ropa y Disfraces')
insert into tb_categoria values('Limpieza')
go

create table tb_proveedor
(
 id_prove			int identity(1,1) primary key not null,
 nombres_prove		varchar(40) not null,
 apellidos_prove	varchar(40) not null,
 razonSocial_prove	varchar(80) not null,
 direccion_prove	varchar(80) not null,
 celular_prove		varchar(15) not null,
 email_prove		varchar(40),
 id_dis				int,
 constraint fk_provedis foreign key(id_dis)
 references tb_distrito(id_dis)
);
go

insert into tb_proveedor values('Juan Carlos','Salazar Mendoza','Mimaskot','Urb. Amelia Beltrán #1','974631584','jcsalazar@gmail.com',3)
insert into tb_proveedor values('Luis Armando','Paredes Salas','Ricocan','Av. Salomé Rincón #096','915478634','lparedes@gmail.com',4)
insert into tb_proveedor values('Juan','Tello Garcia','CanFood SAC','Av. La Unión #02','954784756','juantg@gmail.com',2)
insert into tb_proveedor values('Pedro','Paulet','Dog Chow','Av. Proceres #014','945631478','pedropau@gmail.com',1)
go

create table tb_producto
(
 id_prod					int identity(1,1) primary key not null,
 descripcionSimple_prod		varchar(100) not null,
 precio_prod				decimal(10,2) not null,
 stock_prod					int not null,
 serie_prod					varchar(40),
 marca_prod					varchar(40) not null,
 id_cate					int,
 id_prove					int,
 descripcionHTML_prod		text not null,
 foto1_prod					varchar(255),
 foto2_prod					varchar(255),
 foto3_prod					varchar(255),
 constraint fk_prodcate foreign key(id_cate)
 references tb_categoria(id_cate),
 constraint fk_prodprove foreign key(id_prove)
 references tb_proveedor(id_prove)
);
go

create table tb_servicio
(
 id_servicio			int identity(1,1) primary key not null,
 nombre_servicio		varchar(100) not null,
 precio_servicio		decimal(10,2) not null,
 descripcion_servicio	text not null,
 horario_servicio		varchar(40) not null,
 fecha_servicio			date not null
);
go

create table Carrito
(
 CarritoID			int identity(1,1) primary key not null,
 Identificador		varchar(50) not null,
 idusuario			int null,
 id_prod			int not null,
 Cantidad			int not null,
 Fecha				datetime not null,
 constraint FK_Carrito_tb_producto foreign key(id_prod)
 references tb_producto(id_prod),
 constraint FK_Carrito_usuario foreign key(idusuario)
 references usuario(idusuario)
);
go

create table tb_estado
(
 id_estado				int identity(1,1) primary key not null,
 descripcion_estado		varchar(50) not null
);
go

insert into tb_estado values('Preparado')
insert into tb_estado values('Enviado')
insert into tb_estado values('Entregado')
insert into tb_estado values('Cancelado')
go

create table tb_pedidoCabe
(
 id_pedido			int identity(1,1) primary key not null,
 id_usuario			int,
 fecha_pedido		datetime not null,
 total_pedido		decimal not null,
 id_estado			int,
 constraint fk_pedusu foreign key(id_usuario)
 references usuario(idusuario),
 constraint fk_pedest foreign key(id_estado)
 references tb_estado(id_estado)
);
go

create table tb_pedidoDeta
(
 id_pedido			int,
 id_prod			int,
 precioPorUnidad	decimal not null,
 cantidad_pedido	int not null,
 constraint fk_detacabe foreign key(id_pedido)
 references tb_pedidoCabe(id_pedido),
 constraint fk_pedprod foreign key(id_prod)
 references tb_producto(id_prod),
 primary key(id_pedido,id_prod)
);
go
/*----------------------------------------------------------------------------*/

/*-----------Procedimientos Almacenados para Mantenimiento Producto-----------*/
create procedure sp_ListarCategorias
as
select c.id_cate,c.descripcion_cate
from tb_categoria c
go

create procedure sp_ListarProveedores
as
select p.id_prove,p.razonSocial_prove
from tb_proveedor p
go

create procedure sp_ListarProductos
as
select p.id_prod,p.descripcionSimple_prod,p.precio_prod,p.stock_prod,
	   p.serie_prod,p.marca_prod,c.descripcion_cate,prove.razonSocial_prove,
	   p.descripcionHTML_prod,ISNULL(p.foto1_prod,''),ISNULL(p.foto2_prod,''),ISNULL(p.foto3_prod,'')
from tb_producto p inner join tb_categoria c on p.id_cate = c.id_cate
				   inner join tb_proveedor prove on p.id_prove = prove.id_prove
go

create procedure sp_InsertarProducto
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
go

create procedure sp_ActualizarProducto
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
go
/*----------------------------------------------------------------------------*/

/*-----------Procedimientos Almacenados para Mantenimiento Servicio-----------*/
create procedure sp_ListarServicios
as
select s.id_servicio,s.nombre_servicio,s.precio_servicio,s.descripcion_servicio,
	   s.horario_servicio,s.fecha_servicio
from tb_servicio s
go

create procedure sp_InsertarServicio
@nom		varchar(100),
@pre		decimal(10,2),
@des		text,
@horario	varchar(40),
@fecha		date
as
 insert into tb_servicio(nombre_servicio,precio_servicio,descripcion_servicio,horario_servicio,fecha_servicio)
 values (@nom,@pre,@des,@horario,@fecha)
go

create procedure sp_ActualizarServicio
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
go
/*----------------------------------------------------------------------------*/

/*------------------Procedimientos Almacenados para Mascotas------------------*/
create procedure sp_Listado_Mascotas
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
go

create procedure sp_Insertar_Mascotas
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
go
/*----------------------------------------------------------------------------*/

/*-------------------Procedimientos Almacenados para Usuario------------------*/
create procedure sp_EditarUsuario
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
go
/*----------------------------------------------------------------------------*/

/*-------------------Procedimientos Almacenados para Carrito------------------*/
create procedure sp_boletaPedido
 @idUsu  int,
 @idPed  int
as
	begin
		select p.descripcionSimple_prod,p.precio_prod,pd.cantidad_pedido,pc.fecha_pedido,pc.total_pedido
		from tb_pedidoCabe pc
		inner join tb_pedidoDeta pd on pc.id_pedido = pd.id_pedido
		inner join tb_producto p on p.id_prod = pd.id_prod
		where pc.id_usuario = @idusu and pc.id_pedido = @idPed
	end
go
/*----------------------------------------------------------------------------*/

/*--------------Procedimientos Almacenados para Tracking Cliente--------------*/
create procedure sp_listaPedidos
 @idUsu int
as
	begin
		select pc.id_pedido,pc.fecha_pedido,e.descripcion_estado,pc.total_pedido
		from tb_pedidoCabe pc
		inner join tb_estado e on pc.id_estado = e.id_estado
		where pc.id_usuario = @idUsu
	end
go

create procedure sp_listaPedidosDetallado
 @idUsu  int,
 @idPed  int
as
	begin
		select pc.id_pedido,CONCAT(u.nombre,', ',u.apellido),pc.fecha_pedido,e.descripcion_estado,
			   p.descripcionSimple_prod,pd.precioPorUnidad,pd.cantidad_pedido,pc.total_pedido
		from tb_pedidoCabe pc
		inner join usuario u on pc.id_usuario = u.idusuario
		inner join tb_estado e on pc.id_estado = e.id_estado
		inner join tb_pedidoDeta pd on pc.id_pedido = pd.id_pedido
		inner join tb_producto p on pd.id_prod = p.id_prod
		where pc.id_usuario = @idusu and pc.id_pedido = @idPed
	end
go
/*----------------------------------------------------------------------------*/

/*---------------Procedimientos Almacenados para Tracking Admin---------------*/
/*Filtro por ? ApellidoUsuario,IdPedido,Fecha,Estado*/
create procedure sp_FiltroPedidoPorApellido
 @apeUsu varchar(45)
as
	begin
		select pc.id_pedido,CONCAT(u.nombre,', ',u.apellido),pc.fecha_pedido,e.descripcion_estado
		from tb_pedidoCabe pc
		inner join usuario u on pc.id_usuario = u.idusuario
		inner join tb_estado e on pc.id_estado = e.id_estado
		where u.apellido like '%' + @apeUsu + '%'
	end
go

create procedure sp_ListarEstados
as
	begin
		select e.id_estado,e.descripcion_estado
		from tb_estado e
	end
go

create procedure sp_EditarEstadoPedido
@idPedCabe	int,
@idEstado	int
as
 begin
	UPDATE tb_pedidoCabe set
	id_estado = @idEstado
	where id_pedido = @idPedCabe
 end
go
/*----------------------------------------------------------------------------*/