USE surveyDb
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_PerfilesSeleccionar')
DROP PROCEDURE SPR_PerfilesSeleccionar
GO

CREATE PROCEDURE SPR_PerfilesSeleccionar
    @Nombre NVARCHAR(50),
    @IdPerfil INT
AS
BEGIN
SET NOCOUNT ON;

SELECT 
    IdPerfil AS [IdPerfil],
    Nombre AS [Nombre],
    IdAgrego AS [IdAgrego],
    FechaAgrego AS [FechaAgrego],
    IdModifico AS [IdModifico],
    FechaAgrego AS [FechaModifico]
FROM Perfiles p
WHERE ISNULL(@IdPerfil, 0) = 0 OR p.IdPerfil = @IdPerfil
AND ISNULL(@Nombre, '') = '' OR p.Nombre = @Nombre

END
GO