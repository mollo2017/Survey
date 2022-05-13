USE surveyDb
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_PerfilesInsertar')
DROP PROCEDURE SPR_PerfilesInsertar
GO

CREATE PROCEDURE SPR_PerfilesInsertar 
    @IdUsuario INT,
    @Nombre NVARCHAR(50)
AS
BEGIN
SET NOCOUNT ON;

DECLARE @Hoy DATETIME = GETDATE()

INSERT INTO Perfiles(
    Nombre,
    IdAgrego,
    FechaAgrego,
    IdModifico,
    FechaModifico
)
VALUES(
    @Nombre,
    @IdUsuario,
    @Hoy,
    @IdUsuario,
    @Hoy
)

SELECT SCOPE_IDENTITY() AS [IdPerfil]

END
GO