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
DECLARE @IsCorreo BIT = 0
--DECLARE @IsContrasenia BIT = 0

SELECT @IsCorreo = 1
FROM Usuarios u
WHERE u.Correo = @Correo

/*SELECT @IsContrasenia = 1
FROM Usuarios u
WHERE u.Correo = @Correo
AND u.Contrasenia = @Contrasenia*/

SELECT @Llave = us.Llave
FROM UsuariosSeguridad us
INNER JOIN Usuarios u ON u.IdUsuario = us.IdUsuario
WHERE u.Correo = @Correo
AND u.Contrasenia = @Contrasenia

SELECT 
CAST((IIF(@Llave IS NULL, 0, 1)) AS BIT) AS [Acceso],
IIF(@Llave IS NULL, '--', @Llave) AS [Llave],
CASE 
    WHEN @IsCorreo = 0 THEN 'No se ha encontrado el usuario'
    --WHEN  @IsCorreo = 1 AND @IsContrasenia = 0 THEN 'Contraseña incorrecta'
    WHEN  @IsCorreo = 1 /*AND @IsContrasenia = 1*/ THEN '--'
END AS [Mensaje],
CASE 
    WHEN @IsCorreo = 0 THEN 1
    --WHEN  @IsCorreo = 1 AND @IsContrasenia = 0 THEN 2
    WHEN  @IsCorreo = 1 /*AND @IsContrasenia = 1*/ THEN 0
END AS [Codigo]

END
GO