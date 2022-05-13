USE surveyDb
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_EncuestasSeleccionar')
DROP PROCEDURE SPR_EncuestasSeleccionar
GO

CREATE PROCEDURE SPR_EncuestasSeleccionar
    @Nombre NVARCHAR(50),
    @IdEncuesta INT,
    @Estatus BIT,
    @IdCategoria INT,
    @IdUsuario INT
AS
BEGIN
SET NOCOUNT ON;

SELECT DISTINCT
    e.IdEncuesta [IdEncuesta],
    e.Nombre [Nombre],
    e.Estatus [Estatus],
    e.IdCategoria [IdCategoria],
    c.Nombre [Categoria],
    e.IdAgrego [IdAgrego],
    e.FechaAgrego [FechaAgrego],
    e.IdModifico [IdModifico],
    e.FechaModifico [FechaModifico]
FROM Encuestas e
INNER JOIN Categorias c ON e.IdCategoria = c.IdCategoria
WHERE ISNULL(@IdEncuesta, 0) = 0 OR e.IdEncuesta = @IdEncuesta
AND ISNULL(@Nombre, '') = '' OR e.Nombre = @Nombre
AND ISNULL(@Estatus, 0) = 0 OR e.Estatus = @Estatus
AND ISNULL(@IdCategoria, '') = '' OR e.IdCategoria = @IdCategoria
AND ISNULL(@IdUsuario, '') = '' OR e.IdEncuesta IN (SELECT rue.IdEncuesta 
                                                    FROM RegistroUsuarioEncuesta rue 
                                                    WHERE rue.IdUsuario = @IdUsuario)

END
GO