USE surveyDb
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_RespuestasSeleccionar')
DROP PROCEDURE SPR_RespuestasSeleccionar
GO

CREATE PROCEDURE SPR_RespuestasSeleccionar
    @IdRespuesta INT,
    @IdPregunta INT
AS
BEGIN
SET NOCOUNT ON;

SELECT DISTINCT
    r.IdRespuesta AS [IdRespuesta],
    r.Respuesta AS [Respuesta],
    r.IdAgrego AS [IdAgrego],
    r.FechaAgrego AS [FechaAgrego],
    r.IdModifico AS [IdModifico],
    r.FechaModifico AS [FechaModifico],
    ctrlpr.IsRespuesta AS [IsRespuesta],
    ctrlpr.Orden AS [Orden]
FROM Respuestas r
INNER JOIN CtrlPreguntaRespuesta ctrlpr ON r.IdRespuesta = ctrlpr.IdRespuesta
WHERE (ISNULL(@IdRespuesta, 0) = 0 OR r.IdRespuesta = @IdRespuesta)
AND (ISNULL(@IdPregunta, '') = '' OR ctrlpr.IdPregunta = @IdPregunta)
ORDER BY ctrlpr.Orden DESC

END
GO