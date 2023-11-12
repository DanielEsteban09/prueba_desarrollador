SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_Usuario]
	
	@opc Char(10),
	@Id int = 0,
	@Nombre varchar(100) = null,
	@Cedula varchar(100) = null

AS
BEGIN
declare
@mensaje nvarchar(max),
@estado nvarchar(max),
@identificador   nvarchar(max)

	IF @opc = 'LISTAR'
	BEGIN
		SELECT Id, Nombre, Cedula FROM Usuario;
	END

	IF @opc = 'CREAR'
	BEGIN
		INSERT INTO Usuario(Nombre, Cedula) VALUES (@Nombre, @Cedula);
		set @mensaje = 'Registro Exitoso';
		set @estado = 'ok';
		set @identificador = SCOPE_IDENTITY()
		select @mensaje as mensaje, @estado as estado, CAST(SCOPE_IDENTITY() AS decimal(10, 2)) as identificador
	END

	IF @opc = 'ACTUALIZAR'
	BEGIN
		UPDATE Usuario SET Nombre = @Nombre, Cedula = @Cedula WHERE Id = @Id;
		set @mensaje = 'Actualizacion Exitosa';
		set @estado = 'ok';
		set @identificador = SCOPE_IDENTITY()
		select @mensaje as mensaje, @estado as estado,CAST(@Id AS decimal(10, 2))  as identificador
	END

	IF @opc = 'ELIMINAR'
	BEGIN
		DELETE FROM Usuario WHERE Id = @Id;
		set @mensaje = 'Eliminacion Exitosa';
		set @estado = 'ok';
		set @identificador = SCOPE_IDENTITY()
		select @mensaje as mensaje, @estado as estado,CAST(0 AS decimal(10, 2))  as identificador
	END

END
GO
