--CREAR BASE DE DATOS AND USE
create database AndNuts
use AndNuts

--////////////////////////////////////////////////////////////////////////////////////////////////////////

--TABLA DE USUARIOS
Create table Usuarios(
Id_User int identity(1,1) primary key,
Nombre_User nvarchar(100) not null,
Apellido_User nvarchar(100) not null,
Email_User nvarchar(150),
Telefono_User Nvarchar(30),
Foto_User image,
UserName nvarchar(100) not null,
Contraseña_User nvarchar(100) not null,
--foreing key
Id_Rol_User int not  null,
--Referenciar 
Constraint Relacionar_Rol foreign key (Id_Rol_User) references Roles(Id_Rol)
)
--Insertar Valores
Insert into Usuarios values ('admin','admin','admin@gmail.com','3518562143')
insert into Usuarios values ('Facundo','Lenardon','facundonl99@gmail.com','3513642134')

select * from Usuarios
--////////////////////////////////////////////////////////////////////////////////////////////////////////

--TABLA DE ROLES
Create table Roles(
Id_Rol int identity(1,1) primary key,
Permiso nvarchar(100) not null,
Descripcion_Permiso nvarchar(150) not null
)

--Insertar Valores
insert into Roles values('Administrador', 'Control General')
insert into Roles values('Director', 'Control total')
insert into Roles values('Vendedor','permisos de area ventas')
insert into Roles values('Fraccionador','Fraccionadores de productos')
insert into Roles values('Distribuidor','Repartidores')
--////////////////////////////////////////////////////////////////////////////////////////////////////////

--COMANDO PARA LOGIN USER
select
Usuarios.Nombre_User,
Usuarios.Apellido_User,
Usuarios.Email_User,
Usuarios.Foto_User,
Usuarios.UserName,
Usuarios.Contraseña_User,
Roles.Permiso,
Usuarios.Telefono_User
from Usuarios
inner join Roles on Usuarios.Id_Rol_User = Roles.Id_Rol 
where UserName = 'facu' AND Contraseña_User = 'facundonl99'

--PROCEDIMIENTO LSITAR USUARIOS
create proc SP_ListUser
as select top 100
Usuarios.Id_User,
Usuarios.Nombre_User,
Usuarios.Apellido_User,
Usuarios.Email_User,
Usuarios.Telefono_User,
Usuarios.Foto_User,
Usuarios.UserName,
Usuarios.Contraseña_User,
Roles.Permiso
from Usuarios
inner join Roles on Usuarios.Id_Rol_User = Roles.Id_Rol 
order by Id_User asc

--PROCEDIMIENTO INSERTAR USUARIO
create proc SP_InsertarUsuario
@Nombre_User nvarchar(100),
@Apellido_User nvarchar(100),
@Email_User nvarchar(150),
@Telefono_User Nvarchar(30),
@Foto_User image,
@UserName nvarchar(100),
@Contraseña_User nvarchar(100),
@Id_Rol_User int
as
insert into Usuarios values (@Nombre_User, @Apellido_User, @Email_User, @Telefono_User, @Foto_User, @UserName, @Contraseña_User, @Id_Rol_User)

--PROCEDIMIENTO EDITAR USUARIO
create proc SP_EditarUsuario
@Id_User int,
@Nombre_User nvarchar(100),
@Apellido_User nvarchar(100),
@Email_User nvarchar(150),
@Telefono_User Nvarchar(30),
@Foto_User image,
@UserName nvarchar(100),
@Contraseña_User nvarchar(100),
@Id_Rol_User int
as
Update Usuarios set Nombre_User = @Nombre_User, Apellido_User = @Apellido_User, Email_User = @Email_User, Telefono_User = @Telefono_User,
					Foto_User = @Foto_User, UserName = @UserName, Contraseña_User = @Contraseña_User, Id_Rol_User = @Id_Rol_User
where Id_User = @Id_User
go


--////////////////////////////////////////////////////////////////////////////////////////////////////////

--TABLA CATEGORIA
Create table Categoria(
Id_Categoria int identity(1,1) primary key not null,
Nombre_Cat Nvarchar(30) not null,
Descripcion nvarchar(250) null,
)
--Insertar Valores
insert into Categoria values ('Cereales', 'Cereales Granix,inflados')
insert into Categoria values ('Semillas', '')

--procedimiento almacenado buscar categoria
CREATE PROC SP_BuscarCategoria
@Buscar nvarchar(20)
as
select * from Categoria
where Nombre_Cat like @Buscar + '%'

--procedimiento almacenado insertar categoria
CREATE PROC SP_InsertarCategoria
@Nombre_Cat nvarchar(30),
@Descripcion nvarchar(250)
as
insert into Categoria values (@Nombre_Cat, @Descripcion)

--procedimiento almacenado editar categoria
CREATE PROC SP_EditarCategoria
@ID_Categoria int,
@Nombre_Cat nvarchar(30),
@Descripcion nvarchar(250)
as
update Categoria set Nombre_Cat = @Nombre_Cat, Descripcion = @Descripcion
Where ID_Categoria = @ID_Categoria

--LLenar combobox categoria
create proc SP_ListNameCat
as
select Id_Categoria, Nombre_Cat from Categoria order by Id_Categoria asc
go  

--////////////////////////////////////////////////////////////////////////////////////////////////////////

--TABLA PROVEEDORES
create table Proveedores(
Id_Prov int identity(1,1) primary key not null,
Razon_Social Nvarchar(30) not null,
Nombre_Prov Nvarchar(150) not null,
Email_Prov nvarchar(150) null,
Telefono_Prov Nvarchar(30) null,
Calle_Prov nvarchar(150) NULL,
Numero_Prov int NULL,
Departamento_Prov nvarchar(5) NULL,
Piso_Prov nvarchar (5) NULL,
Codigo_Postal_Prov int NULL,
Provincia_Prov Nvarchar(30) NULL,
Ciudad_Prov Nvarchar(30)NULL,
CUIT_Prov Nvarchar(30)NULL,
)

--Insertar Valores
Insert into Proveedores values ('SYTARI SRL','SYTARI','@',3516731234,'VENEZUELA',3854,'X','X',5000,'Cordoba','Cordoba','30679864374')
Insert into Proveedores values ('GENERAL CEREALS S.A.','GENERAL CEREALS','@',3516739876,'LAS HERAS',695,'X','X',5000,'Cordoba','RIO SEGUNDO','30658034800')

--procedimiento almacenado buscar Proveedor
CREATE PROC SP_BuscarProveedor
@Buscar nvarchar(20)
as
select * from Proveedores
where Nombre_Prov like @Buscar + '%'

--procedimiento almacenado Listar Proveedores
Create proc SP_ListarProveedor
As Select *
from Proveedores
order by Id_Prov ASC

exec SP_ListarProveedor

--procedimiento almacenado insertar Proveedor
CREATE PROC SP_InsertarProveedor
@Razon_Social Nvarchar(30),
@Nombre_Prov Nvarchar(150),
@Email_Prov nvarchar(150),
@Telefono_Prov Nvarchar(30),
@Calle_Prov nvarchar(150),
@Numero_Prov int,
@Departamento_Prov nvarchar(5),
@Piso_Prov nvarchar (5),
@Codigo_Postal_Prov int,
@Provincia_Prov Nvarchar(30),
@Ciudad_Prov Nvarchar(30),
@CUIT_Prov Nvarchar(30)
as
insert into Proveedores values (@Razon_Social,@Nombre_Prov,@Email_Prov,@Telefono_Prov,@Calle_Prov,@Numero_Prov,@Departamento_Prov,@Piso_Prov,@Codigo_Postal_Prov,
@Provincia_Prov,@Ciudad_Prov,@CUIT_Prov )

--procedimiento almacenado editar Proveedor
CREATE PROC SP_EditarProveedor
@Id_Prov int,
@Razon_Social Nvarchar(30),
@Nombre_Prov Nvarchar(150),
@Email_Prov nvarchar(150),
@Telefono_Prov Nvarchar(30),
@Calle_Prov nvarchar(150),
@Numero_Prov int,
@Departamento_Prov nvarchar(5),
@Piso_Prov nvarchar (5),
@Codigo_Postal_Prov int,
@Provincia_Prov Nvarchar(30),
@Ciudad_Prov Nvarchar(30),
@CUIT_Prov Nvarchar(30)
as
update Proveedores set @Id_Prov = Id_Prov, Razon_Social = @Razon_Social, Nombre_Prov = @Nombre_Prov, Email_Prov = @Email_Prov, Telefono_Prov = @Telefono_Prov,
                       Calle_Prov = @Calle_Prov, Numero_Prov = @Numero_Prov, Departamento_Prov = @Departamento_Prov, Piso_Prov = @Piso_Prov,
					   Codigo_Postal_Prov = @Codigo_Postal_Prov, Provincia_Prov = @Provincia_Prov, Ciudad_Prov = @Ciudad_Prov, CUIT_Prov = @CUIT_Prov
					   Where Id_Prov = @Id_Prov

--llenar combobox Proveedores
create proc SP_ListNameProv
as
select Id_Prov, Nombre_Prov from Proveedores order by Id_Prov asc
go  
--////////////////////////////////////////////////////////////////////////////////////////////////////////

--TABLA PRODUCTOS
CREATE TABLE Productos(
Id_Producto int identity(1,1) Primary key not null,
Cod_Producto as ('PR' + RIGHT('00' + CONVERT(VARCHAR, Id_Producto), (2))),
Nombre_Producto nvarchar (50) not null,
Precio_Mayorista decimal(18,2)not null,
Precio_Minorista decimal (18,2)not null,
Stock int null,
--foreing key
Id_Categoria_Producto int not null,
Id_Prov_Producto int not null,
--Referenciar
Constraint Relacionar_Categoria foreign key (Id_Categoria_Producto) references Categoria(Id_Categoria),
Constraint Relacionar_Proveedores foreign key (Id_Prov_Producto) references Proveedores(Id_Prov),
)

--Insertar Valores
Insert into Productos values ('Copoz de maiz 4kg', 80, 100, 4, 5,2)
Insert into Productos values ('Bocaditos de avena 4kg', 100, 80, 6, 5,2)
Insert into Productos values ('Aritos frutales 2,5kg', 50, 40, 20, 5,2)
Insert into Productos values ('Semilla Alpise x Kg', 40, 20, 22, 2,1)
Insert into Productos values ('Semilla Amaranto x Kg', 40, 20, 32,2,1)
Insert into Productos values ('Semilla Amapola x kg', 40, 20, 100, 2,1)

--procedimiento almacenado Listar Productos
Create proc SP_ListarProductos
As Select top 100
Productos.Id_Producto,
Productos.Cod_Producto as Codigo,
Productos.Nombre_Producto as Nombre,
Productos.Precio_Mayorista,
Productos.Precio_Minorista,
Productos.Stock,
Categoria.Id_Categoria,
Categoria.Nombre_Cat as Categoria,
Proveedores.Id_Prov,
Proveedores.Nombre_Prov
FROM Productos
INNER JOIN Categoria on Productos.Id_Categoria_Producto = Categoria.Id_Categoria
INNER JOIN Proveedores on Productos.Id_Prov_Producto = Proveedores.id_Prov
order by Id_Producto ASC

exec SP_ListarCompras

--buscar por prov
Create proc SP_BuscarProductosxProv
@Proveedor nvarchar(20)
as Select 
Productos.Id_Producto,
Productos.Nombre_Producto,
Productos.Stock,
Categoria.Nombre_Cat,
Proveedores.Nombre_Prov
FROM Productos
INNER JOIN Categoria on Productos.Id_Categoria_Producto = Categoria.Id_Categoria
INNER JOIN Proveedores on Productos.Id_Prov_Producto = Proveedores.id_Prov
where Nombre_Prov like @Proveedor
order by Id_Producto ASC

Create proc SP_IdProductoCorrecta
@Nombre nvarchar(50)
as Select 
Productos.Id_Producto,
Productos.Nombre_Producto
FROM Productos
where Nombre_Producto like @Nombre
order by Id_Producto ASC

--procedimiento almacenado Buscar Productos
Create proc SP_BuscarProductos
@Buscar nvarchar(20)
as Select top 100
Productos.Id_Producto,
Productos.Cod_Producto as Codigo,
Productos.Nombre_Producto as Nombre,
Productos.Precio_Mayorista,
Productos.Precio_Minorista,
Productos.Stock,
Categoria.Id_Categoria,
Categoria.Nombre_Cat as Categoria,
Proveedores.Id_Prov,
Proveedores.Nombre_Prov
FROM Productos
INNER JOIN Categoria on Productos.Id_Categoria_Producto = Categoria.Id_Categoria
INNER JOIN Proveedores on Productos.Id_Prov_Producto = Proveedores.id_Prov
where Nombre_Producto like @Buscar + '%'
order by Id_Producto ASC

--procedimiento almacenado Insertar Producto
CREATE PROC SP_InsertarProducto
@Nombre_Producto nvarchar(30),
@Precio_Mayorista decimal(18,2),
@Precio_Minorista decimal(18,2),
@Stock int,
@Id_Categoria_Producto int,
@Id_Prov_Producto int
as
insert into Productos values (@Nombre_Producto,@Precio_Mayorista,@Precio_Minorista,@Stock,@Id_Categoria_Producto,@Id_Prov_Producto)

--procedimiento almacenado Editar Producto
Create proc SP_EditarProducto
@Id_Producto int,
@Cod_Producto nvarchar(5),
@Nombre_Producto nvarchar(30),
@Precio_Mayorista decimal(18,2),
@Precio_Minorista decimal(18,2),
@Stock int,
@Id_Categoria_Producto int,
@Id_Prov_Producto int
as
Update Productos set Nombre_Producto = @Nombre_Producto, Id_Categoria_Producto = @Id_Categoria_Producto, Precio_Mayorista = @Precio_Mayorista,
Precio_Minorista = @Precio_Minorista, Stock = @Stock, Id_Prov_Producto = @Id_Prov_Producto
where Id_Producto = @Id_Producto
go

--procedimiento almacenado count products
Create proc SP_CountProducts
@TotalCategoria int output,
--@TotalProv int output,
@TotalProductos int output,
@SumStock int output
as
set @TotalCategoria = (select count(Id_Categoria) as Categorias from Categoria)
set @TotalProv = (select count(Id_Prov) as Proveedores from Proveedores)
set @TotalProductos = (select count(Id_Producto) as Productos from Productos)
set @SumStock = (select sum(Stock) as Total_Productos from Productos)
go

--////////////////////////////////////////////////////////////////////////////////////////////////////////

--TABLA COMPRAS
Create table Compras(
Id_Compra int identity(1,1) primary key not null,
No_Ingreso varchar(15) not null,
Nro_Remito int null,
Fecha_Compra date not null,
Estado_Compras varchar(7) null,
Monto_Total decimal(12,2) not null,
--foreing key
Id_User_Compras int not null,
Id_Prov_Compras int not null,
--Referenciar
constraint Relacionar_User foreign key(Id_User_Compras) references Usuarios(Id_User),
Constraint Relacionar_Proveedores1 foreign key (Id_Prov_Compras) references Proveedores(Id_Prov),
)

--Procedimiento insertar compras
alter proc SP_InsertarCompra
@No_Ingreso varchar(15),
@Nro_Remito int,
@Fecha_Compra date,
@Estado_Compras varchar(7),
@Monto_Total decimal(12,2),
@Id_User_Compras int,
@Id_Prov_Compras int
as
insert into Compras values(@No_Ingreso,@Nro_Remito, @Fecha_Compra, @Estado_Compras,@Monto_Total, @Id_User_Compras, @Id_Prov_Compras)
go

--procedimiento anular compras
Create proc SP_AnularCompra
@Id_Compra int,
@No_Ingreso varchar(15),
@Nro_Remito int,
@Fecha_Compra date,
@Estado_Compras varchar(7),
@Monto_Total decimal(12,2),
@Id_User_Compras int,
@Id_Prov_Compras int
as
update Compras set No_Ingreso = @No_Ingreso, Nro_Remito = @Nro_Remito,Fecha_Compra = @Fecha_Compra,Estado_Compras = @Estado_Compras,Monto_Total = @Monto_Total, Id_User_Compras = @Id_User_Compras, Id_Prov_Compras = @Id_Prov_Compras 
Where Id_Compra = @Id_Compra
go

--procedimiento listar compras
Create proc SP_ListarCompras
as select top 100
Compras.Id_Compra,
Compras.No_Ingreso,
Proveedores.Nombre_Prov as Proveedor,
Compras.Nro_Remito,
compras.Fecha_Compra,
Compras.Estado_Compras,
Compras.Monto_Total,
(Usuarios.Nombre_User+' '+Usuarios.Apellido_User) as Trabajador
from Compras
inner join Usuarios on Id_User_Compras = Usuarios.Id_User
inner join Proveedores on Id_Prov_Compras = Proveedores.Id_Prov
go

--Buscar compra por proveedor
Create proc SP_BuscarCompraProv
@Buscar nvarchar(100)
as select top 100
Compras.Id_Compra,
Compras.No_Ingreso,
Proveedores.Nombre_Prov as Proveedor,
Compras.Nro_Remito,
compras.Fecha_Compra,
Compras.Estado_Compras,
(Usuarios.Nombre_User+' '+Usuarios.Apellido_User) as Trabajador
from Compras
inner join Usuarios on Id_User_Compras = Usuarios.Id_User
inner join Proveedores on Id_Prov_Compras = Proveedores.Id_Prov
where Nombre_Prov like @Buscar + '%'
go

--Buscar compra por Remito
Create proc SP_BuscarCompraRemito
@Buscar nvarchar(100)
as select top 100
Compras.Id_Compra,
Compras.No_Ingreso,
Proveedores.Nombre_Prov as Proveedor,
Compras.Nro_Remito,
compras.Fecha_Compra,
Compras.Estado_Compras,
(Usuarios.Nombre_User+' '+Usuarios.Apellido_User) as Trabajador
from Compras
inner join Usuarios on Id_User_Compras = Usuarios.Id_User
inner join Proveedores on Id_Prov_Compras = Proveedores.Id_Prov
where Nro_Remito like @Buscar + '%'
go

--Buscar compras entre fechas 
Create proc SP_BuscarCompraFecha
@Buscar varchar(20),
@Buscar2 varchar(20)
as select
Compras.Id_Compra,
Compras.No_Ingreso,
Proveedores.Nombre_Prov as Proveedor,
Compras.Nro_Remito,
compras.Fecha_Compra,
Compras.Estado_Compras,
(Usuarios.Nombre_User+' '+Usuarios.Apellido_User) as Trabajador
from Compras
inner join Usuarios on Compras.Id_User_Compras = Usuarios.Id_User
inner join Proveedores on Id_Prov_Compras = Proveedores.Id_Prov
group by 
Compras.Id_Compra,
Compras.No_Ingreso,
Proveedores.Nombre_Prov,
Compras.Nro_Remito,
compras.Fecha_Compra,
Compras.Estado_Compras,
Usuarios.Nombre_User+' '+Usuarios.Apellido_User
Having Compras.Fecha_Compra >= @Buscar and Compras.Fecha_Compra <= @Buscar2
go


--////////////////////////////////////////////////////////////////////////////////////////////////////////

--TABLA DETALLE COMPRAS
Create table Detalle_Compra(
Id_DetalleCompra int identity(1,1) primary key not null,
Precio_Unitario decimal(12,2)not null,
Sub_Total decimal(12,2) not null,
Cantidad_Recibida int not null,
--foreing key
Id_Compra_Detalle int not null,
Id_Producto_Detalle int not null
--Referenciar
constraint Relacionar_Compra foreign key(Id_Compra_Detalle) references Compras(Id_Compra),
Constraint Relacionar_Productos foreign key(Id_Producto_Detalle) references Productos(Id_Producto)
)


--Procedimiento insertar Detalle compra
Create proc SP_InsertarDetalleCompra
@Precio_Unitario decimal(18,2),
@Sub_Total decimal(12,2),
@Cantidad_Recibida int,
@Id_Compra_Detalle int,
@Id_Producto_Detalle int
as
insert into Detalle_Compra values(@Precio_Unitario,@Sub_Total,@Cantidad_Recibida,@Id_Compra_Detalle,@Id_Producto_Detalle)

--procedimiento anular Detalle de compras
Create proc SP_AnularDetalleCompra
@Id_DetalleCompra int,
@Precio_Unitario decimal(18,2),
@Sub_Total decimal(12,2),
@Cantidad_Recibida int,
@Id_Compra_Detalle int,
@Id_Producto_Detalle int
as
update Detalle_Compra set Precio_Unitario=@Precio_Unitario,Sub_Total=@Sub_Total,Cantidad_Recibida=@Cantidad_Recibida,Id_Compra_Detalle=@Id_Compra_Detalle,Id_Producto_Detalle=@Id_Producto_Detalle
Where Id_DetalleCompra = @Id_DetalleCompra
go

--trigger para agregar los productos ingresados al inventario
Create trigger Tr_BalancearProductos
on Detalle_Compra for insert as
begin
declare @Id_Producto int
declare @Cantidad_Recibida int
set @Id_Producto = (select Id_Producto_Detalle from inserted)
set @Cantidad_Recibida = (select Cantidad_Recibida from inserted)
update Productos 
set Stock = Stock + @Cantidad_Recibida
where Id_Producto = @Id_Producto
end

--trigger para restar los productos anulados al inventario
Create trigger Tr_ReducirProductos
on Detalle_Compra for update as
begin
declare @Id_Producto int
declare @Cantidad_Recibida int
set @Id_Producto = (select Id_Producto_Detalle from inserted)
set @Cantidad_Recibida = (select Cantidad_Recibida from inserted)
update Productos 
set Stock = Stock - @Cantidad_Recibida
where Id_Producto = @Id_Producto
end

--////////////////////////////////////////////////////////////////////////////////////////////////////////

--TABLA TIPO DE CLIENTE
Create table Tipo_Cliente(
Id_Tipo_Cliente int identity(1,1) primary key not null,
Tipo Nvarchar(30) not null,
)

Insert into Tipo_Cliente values ('Mayorista')
Insert into Tipo_Cliente values ('Minorista')

--////////////////////////////////////////////////////////////////////////////////////////////////////////

--TABLA CLIENTES
Create table Clientes(
Id_Cliente int identity(1,1) primary key not null,
Nombre_Cliente nvarchar(100) not null,
Apellido_Cliente nvarchar(100) not null,
Sexo_Cliente nvarchar(1) not null,
Dni_Cliente nvarchar(15) not null,
Email_Cliente nvarchar(150) null,
Telefono_Cliente Nvarchar(30)null,
--foreing key
Id_TipoCliente int not null
--Referenciar
Constraint Relacionar_TipoCliente Foreign key(Id_TipoCliente) references Tipo_Cliente(Id_Tipo_Cliente)
)

--procedimiento almacenado Listar Clientes
Create proc SP_ListarClientes
As Select top 100
Clientes.Id_Cliente,
Clientes.Nombre_Cliente,
Clientes.Apellido_Cliente,
Clientes.Sexo_Cliente,
Clientes.Dni_Cliente,
Clientes.Email_Cliente,
Clientes.Telefono_Cliente,
Clientes.Id_TipoCliente,
Tipo_Cliente.Tipo
FROM Clientes
INNER JOIN Tipo_Cliente on Clientes.Id_TipoCliente = Tipo_Cliente.Id_Tipo_Cliente
order by Id_Cliente ASC

--procedimiento almacenado Buscar Cliente
Create proc SP_BuscarCliente
@Buscar nvarchar(20)
As Select top 100
Clientes.Id_Cliente,
Clientes.Nombre_Cliente,
Clientes.Apellido_Cliente,
Clientes.Sexo_Cliente,
Clientes.Dni_Cliente,
Clientes.Email_Cliente,
Clientes.Telefono_Cliente,
Clientes.Id_TipoCliente,
Tipo_Cliente.Tipo
FROM Clientes
INNER JOIN Tipo_Cliente on Clientes.Id_TipoCliente = Tipo_Cliente.Id_Tipo_Cliente
where Nombre_Cliente like @Buscar + '%'
order by Id_Cliente ASC

--procedimiento almacenado Insertar Cliente
CREATE PROC SP_InsertarCliente
@Nombre_Cliente nvarchar(100), 
@Apellido_Cliente nvarchar(100), 
@Sexo_Cliente nvarchar(1), 
@Dni_Cliente nvarchar(15), 
@Email_Cliente nvarchar(150),
@Telefono_Cliente Nvarchar(30),
@Id_TipoCliente int 
as
insert into Clientes values (@Nombre_Cliente, @Apellido_Cliente, @Sexo_Cliente, @Dni_Cliente, @Email_Cliente,@Telefono_Cliente, @Id_TipoCliente)

--procedimiento almacenado Editar Cliente
Create proc SP_EditarCliente
@Id_Cliente int,
@Nombre_Cliente nvarchar(100), 
@Apellido_Cliente nvarchar(100),
@Sexo_Cliente nvarchar(1), 
@Dni_Cliente nvarchar(15), 
@Email_Cliente nvarchar(150),
@Telefono_Cliente Nvarchar(30),
@Id_TipoCliente int 
as
update Clientes set Nombre_Cliente = @Nombre_Cliente, Apellido_Cliente = @Apellido_Cliente, Sexo_Cliente = @Sexo_Cliente,
					Dni_Cliente = @Dni_Cliente, Email_Cliente = @Email_Cliente, Telefono_Cliente = @Telefono_Cliente, Id_TipoCliente = @Id_TipoCliente
					Where Id_Cliente = @Id_Cliente

--procedimiento almacenado count Clientes
Create proc SP_CountClientes
@TotalCliente int output
as
set @TotalCliente = (select count(Id_Cliente) as Clientes from Clientes)
go

--////////////////////////////////////////////////////////////////////////////////////////////////////////

--TABLA INFO DE ENVIO
Create table Info_Envio(
Id_Info_Envio int identity(1,1) primary key not null,
Zona Nvarchar(150) null,
Calle_Cliente nvarchar(150) NULL,
Numero_Cliente int NULL,
Departamento_Cliente nvarchar(5) NULL,
Piso_Cliente nvarchar (5) NULL,
Codigo_Postal_Cliente int NULL,
Provincia_PCliente nvarchar(15) NULL,
--foreing key
Id_Cliente_Info int not null,
--Referenciar
Constraint Relacionar_Cliente Foreign key(Id_Cliente_Info) references Clientes(Id_Cliente)
)

--////////////////////////////////////////////////////////////////////////////////////////////////////////

--TABLA PEDIDOS
Create table Pedidos(
Id_Pedido int identity(1,1) primary key not null,
Fecha_Pedido_Cliente date null,
Fecha_entrega_Cliente date null,
--foreing key
Id_Usuario_pedidos int not null,
Id_Cliente_pedidos int not null,
Id_InfoEnvio_pedidos int not null,
--Referenciar
Constraint Relacionar_User1 Foreign key(Id_Usuario_pedidos) references Usuarios(Id_User),
Constraint Relacionar_Cliente1 Foreign key(Id_Cliente_pedidos) references Clientes(Id_Cliente),
Constraint Relacionar_InfoEnvio Foreign key(Id_InfoEnvio_pedidos) references Info_Envio(Id_Info_Envio)
)

--////////////////////////////////////////////////////////////////////////////////////////////////////////

--TABLA INFORMACION PEDIDOS
Create table Info_Pedidos(
Cantidad_Pedido int not null,
Forma_Pago nvarchar(30) not null,
Monto int not null,
Estado nvarchar(30) not null,
--foreing key
Id_Producto_Info int not null,
Id_Pedido_Info int not null,
--Referenciar
Constraint Relacionar_Productos1 foreign key(Id_Producto_Info) references Productos(Id_Producto),
Constraint Relacionar_Pedidos foreign key(Id_Pedido_Info) references Pedidos(Id_Pedido)
)

--////////////////////////////////////////////////////////////////////////////////////////////////////////