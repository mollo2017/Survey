using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuerveyAPI.Migrations
{
    public partial class jwtProcedimientos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            /*SPR_EncuestasSeleccionar*/
            migrationBuilder.Sql(
                @"ALTER PROCEDURE SPR_EncuestasSeleccionar
                    @Nombre NVARCHAR(50) = NULL,
                    @IdEncuesta INT = NULL,
                    @Estatus BIT = NULL,
                    @IdCategoria INT = NULL,
                    @IdUsuario INT = NULL
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
                WHERE (ISNULL(@IdEncuesta, 0) = 0 OR e.IdEncuesta = @IdEncuesta)
                AND (ISNULL(@Nombre, '') = '' OR e.Nombre = @Nombre)
                AND (ISNULL(@Estatus, 0) = 0 OR e.Estatus = @Estatus)
                AND (ISNULL(@IdCategoria, '') = '' OR e.IdCategoria = @IdCategoria)
                AND (ISNULL(@IdUsuario, '') = '' OR e.IdEncuesta IN (SELECT rue.IdEncuesta 
                                                                    FROM RegistroUsuarioEncuesta rue 
                                                                    WHERE rue.IdUsuario = @IdUsuario))

                END");
            /*SPR_PreguntasSeleccionar*/
            migrationBuilder.Sql(
                @"ALTER PROCEDURE SPR_PreguntasSeleccionar
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
                WHERE (ISNULL(@IdPregunta, 0) = 0 OR p.IdPregunta = @IdPregunta)
                AND (ISNULL(@IdEncuesta, '') = '' OR ctrlep.IdEncuesta = @IdEncuesta)

                END");
            /*SPR_UsuariosSeleccionar*/
            migrationBuilder.Sql(
                @"ALTER PROCEDURE SPR_UsuariosSeleccionar
                    @Nombre NVARCHAR(50),
                    @IdUsuario INT
                AS
                BEGIN
                SET NOCOUNT ON;

                            SELECT
                                IdUsuario AS[IdUsuario],
                    p.Nombre AS[Nombre],
                    p.Apaterno AS[Apaterno],
                    p.Amaterno AS[Amaterno],
                    p.Correo AS[Correo],
                    p.Contrasenia AS[Contrasenia],
                    p.Estatus AS[Estatus],
                    p.IdPerfil AS[IdPerfil],
                    NULL AS[PerfilesIdPerfil],
                    p.IdAgrego AS[IdAgrego],
                    p.FechaAgrego AS[FechaAgrego],
                    p.IdModifico AS[IdModifico],
                    p.FechaModifico AS[FechaModifico]
                FROM Usuarios p
                INNER JOIN Perfiles ps ON p.IdPerfil = ps.IdPerfil
                WHERE(ISNULL(@IdUsuario, 0) = 0 OR p.IdUsuario = @IdUsuario)
                AND(ISNULL(@Nombre, '') = '' OR p.Nombre = @Nombre)
                END");
            /*SPR_UsuariosInsertar*/
            migrationBuilder.Sql(
                @"CREATE PROCEDURE SPR_UsuariosInsertar 
                    @IdUsuario INT,
                    @Nombre NVARCHAR(50),
                    @Apaterno NVARCHAR(50),
                    @Amaterno NVARCHAR(50),
                    @Correo NVARCHAR(100),
                    @Contrasenia NVARCHAR(20),
                    @Estatus bit,
                    @IdPerfil INT,
                    @Llave NVARCHAR(MAX),
                    @ContraseniaHash NVARCHAR(MAX)

                AS
                BEGIN
                SET NOCOUNT ON;

                DECLARE @Hoy DATETIME = GETDATE()
                DECLARE @IdUsuarioInsert INT = NULL

                    INSERT INTO Usuarios(
                        Nombre,
                        Apaterno,
                        Amaterno,
                        Correo,
                        Contrasenia,
                        Estatus,
                        IdPerfil,
                        IdAgrego,
                        FechaAgrego,
                        IdModifico,
                        FechaModifico)
                    VALUES(
                        @Nombre,
                        @Apaterno,
                        @Amaterno,
                        @Correo,
                        @Contrasenia,
                        @Estatus,
                        @IdPerfil,
                        @IdUsuario,
                        @Hoy,
                        @IdUsuario,
                        @Hoy)

                    SET @IdUsuarioInsert = SCOPE_IDENTITY()

                    INSERT INTO UsuariosSeguridad(
                        Llave,
                        ContraseniaHash,
                        IdUsuario,
                        IdAgrego,
                        FechaAgrego,
                        IdModifico,
                        FechaModifico)
                    VALUES(
                        @Llave,
                        @ContraseniaHash,
                        @IdUsuarioInsert,
                        @IdUsuario,
                        @Hoy,
                        @IdUsuario,
                        @Hoy)

                    EXEC SPR_UsuariosSeleccionar @Nombre = NULL, @IdUsuario = @IdUsuarioInsert
                END");
            /*SPR_UsuariosLogin*/
            migrationBuilder.Sql(
                @"CREATE PROCEDURE SPR_UsuariosLogin
                    @Correo NVARCHAR(MAX),
                    @Contrasenia INT,
                    @Llave NVARCHAR(MAX),
                    @ContraseniaHash NVARCHAR(MAX)
                AS
                BEGIN
                SET NOCOUNT ON;

                            DECLARE @Acceso BIT = 0

                SELECT @Acceso = 1
                FROM UsuariosSeguridad us
                INNER JOIN Usuarios u ON u.IdUsuario = us.IdUsuario
                WHERE u.Correo = @Correo
                AND u.Contrasenia = @Contrasenia
                and us.ContraseniaHash = @ContraseniaHash

                SELECT
                @Acceso AS[Acceso],
                DATEADD(day, 1, GETDATE()) AS[FechaExpira]
                END");
            /*SPR_UsuariosVerificaHash*/
            migrationBuilder.Sql(
                @"CREATE PROCEDURE SPR_UsuariosVerificaHash
                    @Correo NVARCHAR(50),
                    @Contrasenia NVARCHAR(50)

                AS
                BEGIN
                SET NOCOUNT ON;

                            DECLARE @Llave NVARCHAR(MAX) = NULL

                SELECT @Llave = us.Llave
                FROM UsuariosSeguridad us
                INNER JOIN Usuarios u ON u.IdUsuario = us.IdUsuario
                WHERE u.Correo = @Correo
                AND u.Contrasenia = @Contrasenia

                SELECT
                @Llave AS[Llave]

                END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_EncuestasSeleccionar')
                    DROP PROCEDURE SPR_EncuestasSeleccionar");
            migrationBuilder.Sql(
                @"IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_PreguntasSeleccionar')
                    DROP PROCEDURE SPR_PreguntasSeleccionar");
            migrationBuilder.Sql(
                @"IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_UsuariosSeleccionar')
                    DROP PROCEDURE SPR_UsuariosSeleccionar");
            migrationBuilder.Sql(
                @"IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_UsuariosInsertar')
                    DROP PROCEDURE SPR_UsuariosInsertar");
            migrationBuilder.Sql(
                @"IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_UsuariosLogin')
                    DROP PROCEDURE SPR_UsuariosLogin");
            migrationBuilder.Sql(
                @"IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'SPR_UsuariosVerificaHash')
                    DROP PROCEDURE SPR_UsuariosVerificaHash");
        }
    }
}
