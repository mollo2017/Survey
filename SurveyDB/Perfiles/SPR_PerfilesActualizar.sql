USE surveyDb
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_PerfilesActualizar')
DROP PROCEDURE SPR_PerfilesActualizar
GO

CREATE PROCEDURE SPR_PerfilesActualizar
    @IdUsuario INT,
    @Nombre NVARCHAR(50),
    @IdPerfil INT
AS
BEGIN
SET NOCOUNT ON;

DECLARE @Hoy DATETIME = GETDATE()

UPDATE Perfiles SET 
    Nombre = @Nombre,
    IdAgrego = @IdUsuario,
    FechaAgrego = @Hoy,
    IdAgrego = @IdUsuario,
    FechaAgrego = @Hoy
WHERE IdPerfil = @IdPerfil

SELECT @IdPerfil AS [IdPerfil]

END
GO