USE surveyDb
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_UsuariosActualizar')
DROP PROCEDURE SPR_UsuariosActualizar
GO

CREATE PROCEDURE SPR_UsuariosActualizar
    @IdUsuario INT,
    @Nombre NVARCHAR(50),
    @Apaterno NVARCHAR(50),
    @Amaterno NVARCHAR(50),
    @Correo NVARCHAR(100),
    @Contrasenia NVARCHAR(20),
    @Estatus bit,
    @IdPerfil INT

AS
BEGIN
SET NOCOUNT ON;

DECLARE @Hoy DATETIME = GETDATE()

UPDATE Usuarios SET 
    Nombre = @Nombre,
    Apaterno = @Apaterno,
    Amaterno = @Amaterno,
    Correo = @Correo,
    Contrasenia = @Contrasenia,
    Estatus = @Estatus,
    IdPerfil = @IdPerfil,
    IdAgrego = @IdUsuarioModificador,
    FechaAgrego = @Hoy,
    IdAgrego = @IdUsuarioModificador,
    FechaAgrego = @Hoy
WHERE IdUsuario = @IdUsuario

SELECT @IdUsuario AS [IdUsuario]

END
GO