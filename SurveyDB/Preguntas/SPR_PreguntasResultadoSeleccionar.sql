USE surveyDb
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_PreguntasResultadoSeleccionar')
DROP PROCEDURE SPR_PreguntasResultadoSeleccionar
GO

CREATE PROCEDURE SPR_PreguntasResultadoSeleccionar
    @IdEncuesta INT,
    @IdUsuario INT
AS
BEGIN
SET NOCOUNT ON;

;WITH Respondidas AS
(SELECT --DISTINCT
        rpr.IdPregunta AS [IdPregunta], 
        COUNT(rpr.IdRespuesta) [RCorrectas]
    FROM RegistroPreguntaRespuesta rpr
    INNER JOIN RegistroUsuarioEncuesta rue ON rue.IdRegistroUsuarioEncuesta = rpr.IdRegistroUsuarioEncuesta
    INNER JOIN Respuestas rs ON rs.IdRespuesta = rpr.IdRespuesta
    INNER JOIN CtrlPreguntaRespuesta cpr ON cpr.IdRespuesta = rs.IdRespuesta
    WHERE cpr.IsRespuesta = 1
    AND rue.IdUsuario = @IdUsuario
    AND rue.IdEncuesta = @IdEncuesta
    GROUP BY rpr.IdPregunta, rpr.IdRespuesta
), Correctas AS 
(
    SELECT --DISTINCT
        rpr.IdPregunta AS [IdPregunta], 
        COUNT(rpr.IdRespuesta) [RCorrectas]
    FROM RegistroPreguntaRespuesta rpr
    INNER JOIN Respuestas rs ON rs.IdRespuesta = rpr.IdRespuesta
    INNER JOIN CtrlPreguntaRespuesta cpr ON cpr.IdRespuesta = rs.IdRespuesta
    WHERE cpr.IsRespuesta = 1
    GROUP BY rpr.IdPregunta, rpr.IdRespuesta
)

SELECT DISTINCT
    p.IdPregunta,
    P.Pregunta,
    CASE 
        WHEN r.RCorrectas = c.RCorrectas THEN 'Correcta'
        ELSE 'Incorrecta'
    END AS [Resultado]
FROM Respondidas r
INNER JOIN Correctas c ON r.IdPregunta = c.IdPregunta
INNER JOIN Preguntas p ON p.IdPregunta = r.IdPregunta

END
GO