CREATE DATABASE OXXO 

CREATE TABLE OXXO.dbo.Usuarios(
UsuarioId int IDENTITY(1,1) PRIMARY KEY,
Usuario varchar(20) NOT NULL,
contrasenia varchar (20) NOT NULL,
IdPuesto int )

CREATE TABLE OXXO.dbo.ctPuestos(
PuestoId int IDENTITY(1,1) PRIMARY KEY,
Puesto varchar(40))

--DROP TABLE OXXO.dbo.PROVEEDORES
CREATE TABLE OXXO.dbo.Proveedores(
ProveedorId int IDENTITY(1,1) PRIMARY KEY,
Proveed_nombre varchar(40) NOT NULL,
Proveed_LogoUrl varchar(50))


CREATE TABLE OXXO.dbo.Productos(
ProductoId int IDENTITY(1,1) PRIMARY KEY,
productoDescr varchar(100) NOT NULL,
ProveedorId int NOT NULL,
existencia int NOT NULL DEFAULT 0)


CREATE TABLE OXXO.dbo.Inventarios(
InventarioId int IDENTITY(1,1) PRIMARY KEY,
InventarioNombre varchar (100),
Folio_Goma varchar (20),
Fecha_Creacion DATE NOT NULL DEFAULT GETDATE(),
Fecha_Finalizacion DATE)


CREATE TABLE Oxxo.dbo.ProductosInventario(
ProductoId int,
InventarioId int,
Fisico int,
Faltante int, 
Sobrante int)


