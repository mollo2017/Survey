USE surveyDb
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_EncuestasTiempoSeleccionar')
DROP PROCEDURE SPR_EncuestasTiempoSeleccionar
GO

CREATE PROCEDURE SPR_EncuestasTiempoSeleccionar
    @IdEncuesta INT,
    @IdUsuario INT
AS
BEGIN
SET NOCOUNT ON;

DECLARE @Inicio DATETIME
DECLARE @Fin DATETIME

SELECT @Inicio = TiempoRegistro
FROM RegistroEncuesta re
INNER JOIN RegistroUsuarioEncuesta rue ON re.IdRegistroUsuarioEncuesta = rue.IdRegistroUsuarioEncuesta
WHERE re.RegistoEvento = 'inicio'
AND rue.IdUsuario = @IdUsuario
AND rue.IdEncuesta = @IdEncuesta

SELECT @Fin = TiempoRegistro
FROM RegistroEncuesta re
INNER JOIN RegistroUsuarioEncuesta rue ON re.IdRegistroUsuarioEncuesta = rue.IdRegistroUsuarioEncuesta
WHERE re.RegistoEvento = 'fin'
AND rue.IdUsuario = @IdUsuario
AND rue.IdEncuesta = @IdEncuesta

SELECT 
    e.IdEncuesta AS [IdEncuesta],
    e.Nombre AS [Encuesta],
    DATEDIFF(minute, @Inicio, @Fin) AS [TiempoEncuesta],
    u.IdUsuario AS [IdUsuario],
    CONCAT(u.Nombre, ' ', u.Apaterno, ' ', u.Amaterno) AS [Usuario]
FROM RegistroUsuarioEncuesta rue 
INNER JOIN Encuestas e ON e.IdEncuesta = rue.IdEncuesta
INNER JOIN Usuarios u ON u.IdUsuario = rue.IdUsuario
WHERE rue.IdUsuario = @IdUsuario
AND rue.IdEncuesta = @IdEncuesta

END
GO