USE [OXXO]
GO

INSERT INTO [dbo].[Usuarios]
           ([Usuario]
           ,[contrasenia]
           ,[IdPuesto])
     VALUES
           ('admin', 'pass', 1)
GO




INSERT INTO OXXO.[dbo].Productos
           (productoDescr,
           ProveedorId,
		   existencia)
     VALUES
           ('Pepsi Kick 500ml', 1, 50)
GO

SELECT * FROM OXXO.dbo.Proveedores
SELECT * FROM OXXO.dbo.Usuarios
SELECT * FROM OXXO.dbo.Productos