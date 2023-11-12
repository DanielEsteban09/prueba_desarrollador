SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_Tickets]
	
	@opc Char(10),
	@Id int = 0,
	@Descripcion varchar(500) = null,
	@Numero int = null,
	@Prioridad varchar(100) = null

AS
BEGIN
declare
@mensaje nvarchar(max),
@estado nvarchar(max),
@identificador   nvarchar(max)

    
	IF @opc = 'LISTAR'
	BEGIN
		SELECT Id, Descripcion, Numero, Prioridad FROM Tickets;
	END

	IF @opc = 'CREAR'
	BEGIN
		INSERT INTO Tickets(Descripcion, Numero, Prioridad) VALUES (@Descripcion, @Numero, @Prioridad);
		set @mensaje = 'Registro Exitoso';
		set @estado = 'ok';
		set @identificador = SCOPE_IDENTITY()
		select @mensaje as mensaje, @estado as estado, CAST(SCOPE_IDENTITY() AS decimal(10, 2)) as identificador
	END

	IF @opc = 'ACTUALIZAR'
	BEGIN
		UPDATE Tickets SET Descripcion = @Descripcion, Numero = @Numero, Prioridad = @Prioridad WHERE Id = @Id;
		set @mensaje = 'Actualizacion Exitosa';
		set @estado = 'ok';
		set @identificador = SCOPE_IDENTITY()
		select @mensaje as mensaje, @estado as estado,CAST(@Id AS decimal(10, 2))  as identificador
	END

	IF @opc = 'ELIMINAR'
	BEGIN
		DELETE FROM Tickets WHERE Id = @Id;
		set @mensaje = 'Eliminacion Exitosa';
		set @estado = 'ok';
		set @identificador = SCOPE_IDENTITY()
		select @mensaje as mensaje, @estado as estado,CAST(0 AS decimal(10, 2))  as identificador
	END

END
GO
