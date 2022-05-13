using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapaDatos.Migrations
{
    public partial class ProcedimientosAlmacenados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acciones",
                columns: table => new
                {
                    IdAccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdAgrego = table.Column<int>(type: "int", nullable: false),
                    FechaAgrego = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModifico = table.Column<int>(type: "int", nullable: false),
                    FechaModifico = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acciones", x => x.IdAccion);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdAgrego = table.Column<int>(type: "int", nullable: false),
                    FechaAgrego = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModifico = table.Column<int>(type: "int", nullable: false),
                    FechaModifico = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Perfiles",
                columns: table => new
                {
                    IdPerfil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdAgrego = table.Column<int>(type: "int", nullable: false),
                    FechaAgrego = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModifico = table.Column<int>(type: "int", nullable: false),
                    FechaModifico = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfiles", x => x.IdPerfil);
                });

            migrationBuilder.CreateTable(
                name: "Preguntas",
                columns: table => new
                {
                    IdPregunta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pregunta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdAgrego = table.Column<int>(type: "int", nullable: false),
                    FechaAgrego = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModifico = table.Column<int>(type: "int", nullable: false),
                    FechaModifico = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preguntas", x => x.IdPregunta);
                });

            migrationBuilder.CreateTable(
                name: "Respuestas",
                columns: table => new
                {
                    IdRespuesta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Respuesta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdAgrego = table.Column<int>(type: "int", nullable: false),
                    FechaAgrego = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModifico = table.Column<int>(type: "int", nullable: false),
                    FechaModifico = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuestas", x => x.IdRespuesta);
                });

            migrationBuilder.CreateTable(
                name: "Encuestas",
                columns: table => new
                {
                    IdEncuesta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    CategoriasIdCategoria = table.Column<int>(type: "int", nullable: true),
                    IdAgrego = table.Column<int>(type: "int", nullable: false),
                    FechaAgrego = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModifico = table.Column<int>(type: "int", nullable: false),
                    FechaModifico = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encuestas", x => x.IdEncuesta);
                    table.ForeignKey(
                        name: "FK_Encuestas_Categorias_CategoriasIdCategoria",
                        column: x => x.CategoriasIdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria");
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    IdPermiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerfil = table.Column<int>(type: "int", nullable: false),
                    PerfilesIdPerfil = table.Column<int>(type: "int", nullable: true),
                    IdAccion = table.Column<int>(type: "int", nullable: false),
                    AccionesIdAccion = table.Column<int>(type: "int", nullable: true),
                    IdAgrego = table.Column<int>(type: "int", nullable: false),
                    FechaAgrego = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModifico = table.Column<int>(type: "int", nullable: false),
                    FechaModifico = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.IdPermiso);
                    table.ForeignKey(
                        name: "FK_Permisos_Acciones_AccionesIdAccion",
                        column: x => x.AccionesIdAccion,
                        principalTable: "Acciones",
                        principalColumn: "IdAccion");
                    table.ForeignKey(
                        name: "FK_Permisos_Perfiles_PerfilesIdPerfil",
                        column: x => x.PerfilesIdPerfil,
                        principalTable: "Perfiles",
                        principalColumn: "IdPerfil");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Aparterno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amaterno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    IdPerfil = table.Column<int>(type: "int", nullable: false),
                    PerfilesIdPerfil = table.Column<int>(type: "int", nullable: true),
                    IdAgrego = table.Column<int>(type: "int", nullable: false),
                    FechaAgrego = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModifico = table.Column<int>(type: "int", nullable: false),
                    FechaModifico = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Perfiles_PerfilesIdPerfil",
                        column: x => x.PerfilesIdPerfil,
                        principalTable: "Perfiles",
                        principalColumn: "IdPerfil");
                });

            migrationBuilder.CreateTable(
                name: "CtrlPreguntaRespuesta",
                columns: table => new
                {
                    IdCtrlPreguntaRespuesta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPregunta = table.Column<int>(type: "int", nullable: false),
                    PreguntasIdPregunta = table.Column<int>(type: "int", nullable: true),
                    IdRespuesta = table.Column<int>(type: "int", nullable: false),
                    RespuestasIdRespuesta = table.Column<int>(type: "int", nullable: true),
                    IsRespuesta = table.Column<bool>(type: "bit", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    IdAgrego = table.Column<int>(type: "int", nullable: false),
                    FechaAgrego = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModifico = table.Column<int>(type: "int", nullable: false),
                    FechaModifico = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CtrlPreguntaRespuesta", x => x.IdCtrlPreguntaRespuesta);
                    table.ForeignKey(
                        name: "FK_CtrlPreguntaRespuesta_Preguntas_PreguntasIdPregunta",
                        column: x => x.PreguntasIdPregunta,
                        principalTable: "Preguntas",
                        principalColumn: "IdPregunta");
                    table.ForeignKey(
                        name: "FK_CtrlPreguntaRespuesta_Respuestas_RespuestasIdRespuesta",
                        column: x => x.RespuestasIdRespuesta,
                        principalTable: "Respuestas",
                        principalColumn: "IdRespuesta");
                });

            migrationBuilder.CreateTable(
                name: "CtrlEncuestaPregunta",
                columns: table => new
                {
                    IdCtrlEncuestaPregunta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEncuesta = table.Column<int>(type: "int", nullable: false),
                    EncuestasIdEncuesta = table.Column<int>(type: "int", nullable: true),
                    IdPregunta = table.Column<int>(type: "int", nullable: false),
                    PreguntasIdPregunta = table.Column<int>(type: "int", nullable: true),
                    IdAgrego = table.Column<int>(type: "int", nullable: false),
                    FechaAgrego = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModifico = table.Column<int>(type: "int", nullable: false),
                    FechaModifico = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CtrlEncuestaPregunta", x => x.IdCtrlEncuestaPregunta);
                    table.ForeignKey(
                        name: "FK_CtrlEncuestaPregunta_Encuestas_EncuestasIdEncuesta",
                        column: x => x.EncuestasIdEncuesta,
                        principalTable: "Encuestas",
                        principalColumn: "IdEncuesta");
                    table.ForeignKey(
                        name: "FK_CtrlEncuestaPregunta_Preguntas_PreguntasIdPregunta",
                        column: x => x.PreguntasIdPregunta,
                        principalTable: "Preguntas",
                        principalColumn: "IdPregunta");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CtrlEncuestaPregunta_EncuestasIdEncuesta",
                table: "CtrlEncuestaPregunta",
                column: "EncuestasIdEncuesta");

            migrationBuilder.CreateIndex(
                name: "IX_CtrlEncuestaPregunta_PreguntasIdPregunta",
                table: "CtrlEncuestaPregunta",
                column: "PreguntasIdPregunta");

            migrationBuilder.CreateIndex(
                name: "IX_CtrlPreguntaRespuesta_PreguntasIdPregunta",
                table: "CtrlPreguntaRespuesta",
                column: "PreguntasIdPregunta");

            migrationBuilder.CreateIndex(
                name: "IX_CtrlPreguntaRespuesta_RespuestasIdRespuesta",
                table: "CtrlPreguntaRespuesta",
                column: "RespuestasIdRespuesta");

            migrationBuilder.CreateIndex(
                name: "IX_Encuestas_CategoriasIdCategoria",
                table: "Encuestas",
                column: "CategoriasIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_AccionesIdAccion",
                table: "Permisos",
                column: "AccionesIdAccion");

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_PerfilesIdPerfil",
                table: "Permisos",
                column: "PerfilesIdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Correo",
                table: "Usuarios",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PerfilesIdPerfil",
                table: "Usuarios",
                column: "PerfilesIdPerfil");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CtrlEncuestaPregunta");

            migrationBuilder.DropTable(
                name: "CtrlPreguntaRespuesta");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Encuestas");

            migrationBuilder.DropTable(
                name: "Preguntas");

            migrationBuilder.DropTable(
                name: "Respuestas");

            migrationBuilder.DropTable(
                name: "Acciones");

            migrationBuilder.DropTable(
                name: "Perfiles");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
