USE surveyDb
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_UsuariosLogin')
DROP PROCEDURE SPR_UsuariosLogin
GO

CREATE PROCEDURE SPR_UsuariosLogin
    @Correo NVARCHAR(50),
    @Contrasenia NVARCHAR(50),
    @Llave NVARCHAR(MAX),
    @ContraseniaHash NVARCHAR(MAX)

AS
BEGIN
SET NOCOUNT ON;

DECLARE @Acceso BIT = 0 
DECLARE @Nombre NVARCHAR(200) = '*'

SELECT 
    @Acceso = 1,
    @Nombre = u.Nombre
FROM UsuariosSeguridad us
INNER JOIN Usuarios u ON u.IdUsuario = us.IdUsuario
WHERE u.Correo = @Correo
AND u.Contrasenia = @Contrasenia
and us.ContraseniaHash = @ContraseniaHash

SELECT 
@Acceso AS [Acceso],
@Nombre AS [Nombre],
DATEADD(day, 1, GETDATE()) AS [FechaExpira]
--IIF(@Acceso=1,DATEADD(day, 1, GETDATE()), NULL) AS [FechaExpira]

END
GO