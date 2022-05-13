using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapaDatos.Migrations
{
    public partial class ProcedimientosAlmacenados2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*SPR_PreguntasResultadoSeleccionar*/
            migrationBuilder.Sql(
                @"CREATE PROCEDURE SPR_PreguntasResultadoSeleccionar
                    @IdEncuesta INT,
                    @IdUsuario INT
                AS
                BEGIN
                SET NOCOUNT ON;

                            ; WITH Respondidas AS
                            (SELECT DISTINCT
            
                                    rpr.IdPregunta AS[IdPregunta],
                                    COUNT(rpr.IdRespuesta)[RCorrectas]
            
                                FROM RegistroPreguntaRespuesta rpr
            
                                INNER JOIN RegistroUsuarioEncuesta rue ON rue.IdRegistroUsuarioEncuesta = rpr.IdRegistroUsuarioEncuesta
            
                                INNER JOIN Respuestas rs ON rs.IdRespuesta = rpr.IdRespuesta
            
                                INNER JOIN CtrlPreguntaRespuesta ON cpr.IdRespuesta = rs.IdRespuesta
            
                                WHERE cpr.IsRespuesta = 1
            
                                AND rue.IdUsuario = @IdUsuario
            
                                AND rue.IdEncuesta = @IdEncuesta
                            ), Correctas AS
                            (
                                SELECT DISTINCT
            
                                    rpr.IdPregunta AS [IdPregunta],
                                    COUNT(rpr.IdRespuesta)[RCorrectas]
                                FROM RegistroPreguntaRespuesta rpr
            
                                INNER JOIN Respuestas rs ON rs.IdRespuesta = rpr.IdRespuesta
            
                                INNER JOIN CtrlPreguntaRespuesta ON cpr.IdRespuesta = rs.IdRespuesta
            
                                WHERE cpr.IsRespuesta = 1
                            )

                SELECT
                    p.IdPregunta,
                    P.Pregunta,
                    CASE
                        WHEN r.RCorrectas = c.RCorrectas THEN 'Correcta'
                        ELSE 'Incorrecta'
                    END AS[Resultado]
                FROM Respondidas r
                INNER JOIN Correctas c ON r.IdPregunta = c.IdPregunta
                INNER JOIN Preguntas p ON p.IdPregunta = r.IdPregunta

                END");
            /*SPR_EncuestasSeleccionar*/
            migrationBuilder.Sql(
                @"CREATE PROCEDURE SPR_EncuestasSeleccionar
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

                END");
            /*SPR_EncuestasTiempoSeleccionar*/
            migrationBuilder.Sql(
                @"CREATE PROCEDURE SPR_EncuestasTiempoSeleccionar
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
                    e.Nombre AS [Encuesta],
                    DATEDIFF(minute, @Inicio, @Fin) AS [TiempoEncuesta],
                    CONCAT(u.Nombre, ' ', u.Apaterno, ' ', u.Amaterno) AS [Usuario]
                FROM RegistroUsuarioEncuesta rue 
                INNER JOIN Encuestas e ON e.IdEncuesta = rue.IdEncuesta
                INNER JOIN Usuarios u ON u.IdUsuario = rue.IdUsuario
                WHERE rue.IdUsuario = @IdUsuario
                AND rue.IdEncuesta = @IdEncuesta

                END");
            /*SPR_PreguntasSeleccionar*/
            migrationBuilder.Sql(
                @"CREATE PROCEDURE SPR_PreguntasSeleccionar
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

                END");
            /*SPR_PreguntasTiempoSeleccionar*/
            migrationBuilder.Sql(
                @"CREATE PROCEDURE SPR_PreguntasTiempoSeleccionar
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

                END");
            /*SPR_RespuestasSeleccionar*/
            migrationBuilder.Sql(
                @"CREATE PROCEDURE SPR_RespuestasSeleccionar
                    @IdRespuesta INT,
                    @IdPregunta INT
                AS
                BEGIN
                SET NOCOUNT ON;

                            SELECT DISTINCT
                    r.IdRespuesta AS[IdRespuesta],
                    r.Respuesta AS[Respuesta],
                    r.IdAgrego AS[IdAgrego],
                    r.FechaAgrego AS[FechaAgrego],
                    r.IdModifico AS[IdModifico],
                    r.FechaModifico AS[FechaModifico],
                    ctrlpr.IsRespuesta AS[IsRespuesta],
                    ctrlpr.Orden AS[Orden]
                FROM Respuestas r
                INNER JOIN CtrlPreguntaRespuesta ctrlpr ON r.IdRespuesta = ctrlpr.IdRespuesta
                WHERE ISNULL(@IdRespuesta, 0) = 0 OR r.IdRespuesta = @IdRespuesta
                AND ISNULL(@IdPregunta, '') = '' OR ctrlpr.IdPregunta = @IdPregunta
                ORDER BY ctrlpr.Orden DESC

                END");
            /*SPR_UsuariosSeleccionar*/
            migrationBuilder.Sql(
                @"CREATE PROCEDURE SPR_UsuariosSeleccionar
                    @Nombre NVARCHAR(50),
                    @IdUsuario INT
                AS
                BEGIN
                SET NOCOUNT ON;

                SELECT 
                    IdUsuario AS [IdUsuario],
                    p.Nombre AS [Nombre],
                    p.Aparterno AS [Aparterno],
                    p.Amaterno AS [Amaterno],
                    p.Correo AS [Correo],
                    p.Contrasenia AS [Contrasenia],
                    p.Estatus AS [Estatus],
                    p.IdPerfil AS [IdPerfil],
                    ps.Nombre AS [Perfil]
                FROM Usuarios p
                INNER JOIN Perfiles ps ON p.IdPerfil = ps.IdPerfil
                WHERE ISNULL(@IdUsuario, 0) = 0 OR p.IdUsuario = @IdUsuario
                AND ISNULL(@Nombre, '') = '' OR p.Nombre = @Nombre

                SELECT @IdUsuario AS [IdUsuario]

                END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_PreguntasResultadoSeleccionar')
                    DROP PROCEDURE SPR_PreguntasResultadoSeleccionar");
            migrationBuilder.Sql(
                @"IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_EncuestasSeleccionar')
                    DROP PROCEDURE SPR_EncuestasSeleccionar");
            migrationBuilder.Sql(
                @"IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_EncuestasTiempoSeleccionar')
                    DROP PROCEDURE SPR_EncuestasTiempoSeleccionar");
            migrationBuilder.Sql(
                @"IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_PreguntasSeleccionar')
                    DROP PROCEDURE SPR_PreguntasSeleccionar");
            migrationBuilder.Sql(
                @"IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_PreguntasTiempoSeleccionar')
                    DROP PROCEDURE SPR_PreguntasTiempoSeleccionar");
            migrationBuilder.Sql(
                @"IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_RespuestasSeleccionar')
                    DROP PROCEDURE SPR_RespuestasSeleccionar");
            migrationBuilder.Sql(
                @"IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_UsuariosSeleccionar')
                    DROP PROCEDURE SPR_UsuariosSeleccionar");

        }
    }
}
