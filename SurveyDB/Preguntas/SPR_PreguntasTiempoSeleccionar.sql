USE surveyDb
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_PreguntasTiempoSeleccionar')
DROP PROCEDURE SPR_PreguntasTiempoSeleccionar
GO

CREATE PROCEDURE SPR_PreguntasTiempoSeleccionar
    @IdEncuesta INT,
    @IdUsuario INT
AS
BEGIN
SET NOCOUNT ON;

;WITH ps AS
(
    SELECT DISTINCT
    p.IdPregunta AS [IdPregunta],
    p.Pregunta AS [Pregunta],
    (SELECT TiempoRegistro 
    FROM RegistroEncuestaPregunta rep
    INNER JOIN RegistroUsuarioEncuesta rue ON rep.IdRegistroUsuarioEncuesta = rue.IdRegistroUsuarioEncuesta 
    WHERE rep.IdPregunta = p.IdPregunta
    AND rep.RegistoEvento = 'inicio'
    AND rue.IdUsuario = @IdUsuario
    AND rue.IdEncuesta = @IdEncuesta) AS [TiempoInicio],
    (SELECT TiempoRegistro 
    FROM RegistroEncuestaPregunta rep
    INNER JOIN RegistroUsuarioEncuesta rue ON rep.IdRegistroUsuarioEncuesta = rue.IdRegistroUsuarioEncuesta 
    WHERE rep.IdPregunta = p.IdPregunta
    AND rep.RegistoEvento = 'fin'
    AND rue.IdUsuario = @IdUsuario
    AND rue.IdEncuesta = @IdEncuesta) AS [TiempoFin]
    FROM Preguntas p
    INNER JOIN CtrlEncuestaPregunta ctrlep ON p.IdPregunta = ctrlep.IdPregunta
    WHERE ctrlep.IdEncuesta = @IdEncuesta
)
SELECT DISTINCT
    ps.IdPregunta AS [IdPregunta],
    ps.Pregunta AS [Pregunta],
    DATEDIFF(minute, TiempoInicio, TiempoFin) AS [TiempoRespuesta]
FROM ps 

END
GO