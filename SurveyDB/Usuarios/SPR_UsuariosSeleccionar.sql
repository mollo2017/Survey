USE surveyDb
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_UsuariosSeleccionar')
DROP PROCEDURE SPR_UsuariosSeleccionar
GO

CREATE PROCEDURE SPR_UsuariosSeleccionar
    @Nombre NVARCHAR(50),
    @IdUsuario INT
AS
BEGIN
SET NOCOUNT ON;

SELECT 
    IdUsuario AS [IdUsuario],
    p.Nombre AS [Nombre],
    p.Apaterno AS [Apaterno],
    p.Amaterno AS [Amaterno],
    p.Correo AS [Correo],
    p.Contrasenia AS [Contrasenia],
    p.Estatus AS [Estatus],
    p.IdPerfil AS [IdPerfil],
    ps.Nombre AS [Perfil]
FROM Usuarios p
INNER JOIN Perfiles ps ON p.IdPerfil = ps.IdPerfil
WHERE ISNULL(@IdUsuario, 0) = 0 OR p.IdUsuario = @IdUsuario
AND ISNULL(@Nombre, '') = '' OR p.Nombre = @Nombre

SELECT @IdUsuario AS [IdUsuario]

END
GO