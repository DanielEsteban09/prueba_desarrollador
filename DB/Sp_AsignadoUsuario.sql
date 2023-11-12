SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_AsignadoUsuario]
	
	@opc Char(10),
	@Id int = 0,
	@Id_usuario int = null,
	@Id_ticket int = null,
	--@Fecha datetime,
	@Id_Estado int = null

AS
BEGIN
declare
@mensaje nvarchar(max),
@estado nvarchar(max),
@identificador   nvarchar(max)

	IF @opc = 'LISTAR'
	BEGIN
		SELECT Id, Id_usuario, Id_ticket, Fecha, Id_Estado FROM AsignadoUsuario;
	END

	IF @opc = 'CREAR'
	BEGIN
		INSERT INTO AsignadoUsuario(Id_usuario, Id_ticket, Fecha, Id_Estado) VALUES(@Id_usuario, @Id_ticket,GETDATE(), @Id_Estado);
		set @mensaje = 'Registro Exitoso';
		set @estado = 'ok';
		set @identificador = SCOPE_IDENTITY()
		select @mensaje as mensaje, @estado as estado, CAST(SCOPE_IDENTITY() AS decimal(10, 2)) as identificador
	END

	IF @opc = 'ACTUALIZAR'
	BEGIN
		UPDATE AsignadoUsuario SET Id_usuario = @Id_usuario, Id_ticket = @Id_ticket, Fecha = GETDATE(), Id_Estado = @Id_Estado WHERE Id = @Id;
		set @mensaje = 'Actualizacion Exitosa';
		set @estado = 'ok';
		set @identificador = SCOPE_IDENTITY()
		select @mensaje as mensaje, @estado as estado,CAST(@Id AS decimal(10, 2))  as identificador
	END

	IF @opc = 'ELIMINAR'
	BEGIN
		DELETE FROM AsignadoUsuario WHERE Id = @Id;
		set @mensaje = 'Eliminacion Exitosa';
		set @estado = 'ok';
		set @identificador = SCOPE_IDENTITY()
		select @mensaje as mensaje, @estado as estado,CAST(0 AS decimal(10, 2))  as identificador
	END

END
GO
