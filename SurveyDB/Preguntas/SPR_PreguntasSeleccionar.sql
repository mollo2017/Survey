USE surveyDb
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_PreguntasSeleccionar')
DROP PROCEDURE SPR_PreguntasSeleccionar
GO

CREATE PROCEDURE SPR_PreguntasSeleccionar
    @IdPregunta INT,
    @IdEncuesta INT
AS
BEGIN
SET NOCOUNT ON;

SELECT DISTINCT
    p.IdPregunta AS [IdPregunta],
    p.Pregunta AS [Pregunta],
    p.IdAgrego AS [IdAgrego],
    p.FechaAgrego AS [FechaAgrego],
    p.IdModifico AS [IdModifico],
    p.FechaModifico AS [FechaModifico]
FROM Preguntas p
INNER JOIN CtrlEncuestaPregunta ctrlep ON p.IdPregunta = ctrlep.IdPregunta
WHERE ISNULL(@IdPregunta, 0) = 0 OR p.IdPregunta = @IdPregunta
AND ISNULL(@IdEncuesta, '') = '' OR ctrlep.IdEncuesta = @IdEncuesta

END
GO