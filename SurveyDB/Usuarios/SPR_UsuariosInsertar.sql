USE surveyDb
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_UsuariosInsertar')
DROP PROCEDURE SPR_UsuariosInsertar
GO

CREATE PROCEDURE SPR_UsuariosInsertar 
@IdUsuario INT,
@Nombre NVARCHAR(50),
@Apaterno NVARCHAR(50),
@Amaterno NVARCHAR(50),
@Correo NVARCHAR(100),
@Contrasenia NVARCHAR(20),
@Estatus bit,
@IdPerfil INT,
@Llave NVARCHAR(MAX),
@ContraseniaHash NVARCHAR(MAX)

AS
BEGIN
SET NOCOUNT ON;

DECLARE @Hoy DATETIME = GETDATE()
DECLARE @IdUsuarioInsert INT = NULL

INSERT INTO Usuarios(
    Nombre,
    Apaterno,
    Amaterno,
    Correo,
    Contrasenia,
    Estatus,
    IdPerfil,
    IdAgrego,
    FechaAgrego,
    IdModifico,
    FechaModifico
)
VALUES(
    @Nombre,
    @Apaterno,
    @Amaterno,
    @Correo,
    @Contrasenia,
    @Estatus,
    @IdPerfil,
    @IdUsuario,
    @Hoy,
    @IdUsuario,
    @Hoy
)

SET @IdUsuarioInsert = SCOPE_IDENTITY()

INSERT INTO UsuariosSeguridad(
    Llave,
    ContraseniaHash,
    IdUsuario,
    IdAgrego,
    FechaAgrego,
    IdModifico,
    FechaModifico
)
VALUES(
    @Llave,
    @ContraseniaHash,
    @IdUsuarioInsert,
    @IdUsuario,
    @Hoy,
    @IdUsuario,
    @Hoy
)

EXEC SPR_UsuariosSeleccionar @Nombre = NULL, @IdUsuario = @IdUsuarioInsert

END
GO