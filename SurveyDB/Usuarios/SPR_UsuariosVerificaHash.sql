USE surveyDb
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_UsuariosVerificaHash')
DROP PROCEDURE SPR_UsuariosVerificaHash
GO

CREATE PROCEDURE SPR_UsuariosVerificaHash
    @Correo NVARCHAR(50),
    @Contrasenia NVARCHAR(50)

AS
BEGIN
SET NOCOUNT ON;

DECLARE @Llave NVARCHAR(MAX) = NULL

SELECT @Llave = us.Llave
FROM UsuariosSeguridad us
INNER JOIN Usuarios u ON u.IdUsuario = us.IdUsuario
WHERE u.Correo = @Correo
AND u.Contrasenia = @Contrasenia

SELECT 
@Llave AS [Llave]

END
GO