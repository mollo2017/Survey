using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuerveyAPI.Migrations
{
    public partial class Initial : Migration
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
                name: "RegistroUsuarioEncuesta",
                columns: table => new
                {
                    IdRegistroUsuarioEncuesta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEncuesta = table.Column<int>(type: "int", nullable: false),
                    EncuestasIdEncuesta = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuariosIdUsuario = table.Column<int>(type: "int", nullable: true),
                    IdAgrego = table.Column<int>(type: "int", nullable: false),
                    FechaAgrego = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModifico = table.Column<int>(type: "int", nullable: false),
                    FechaModifico = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroUsuarioEncuesta", x => x.IdRegistroUsuarioEncuesta);
                    table.ForeignKey(
                        name: "FK_RegistroUsuarioEncuesta_Encuestas_EncuestasIdEncuesta",
                        column: x => x.EncuestasIdEncuesta,
                        principalTable: "Encuestas",
                        principalColumn: "IdEncuesta");
                    table.ForeignKey(
                        name: "FK_RegistroUsuarioEncuesta_Usuarios_UsuariosIdUsuario",
                        column: x => x.UsuariosIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "RegistroEncuesta",
                columns: table => new
                {
                    IdRegistroEncuesta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistoEvento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRegistroUsuarioEncuesta = table.Column<int>(type: "int", nullable: false),
                    RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta = table.Column<int>(type: "int", nullable: true),
                    TiempoRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdAgrego = table.Column<int>(type: "int", nullable: false),
                    FechaAgrego = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModifico = table.Column<int>(type: "int", nullable: false),
                    FechaModifico = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroEncuesta", x => x.IdRegistroEncuesta);
                    table.ForeignKey(
                        name: "FK_RegistroEncuesta_RegistroUsuarioEncuesta_RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta",
                        column: x => x.RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta,
                        principalTable: "RegistroUsuarioEncuesta",
                        principalColumn: "IdRegistroUsuarioEncuesta");
                });

            migrationBuilder.CreateTable(
                name: "RegistroEncuestaPregunta",
                columns: table => new
                {
                    IdRegistroEncuestaPregunta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistoEvento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRegistroUsuarioEncuesta = table.Column<int>(type: "int", nullable: false),
                    RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta = table.Column<int>(type: "int", nullable: true),
                    TiempoRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPregunta = table.Column<int>(type: "int", nullable: false),
                    PreguntasIdPregunta = table.Column<int>(type: "int", nullable: false),
                    IdAgrego = table.Column<int>(type: "int", nullable: false),
                    FechaAgrego = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModifico = table.Column<int>(type: "int", nullable: false),
                    FechaModifico = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroEncuestaPregunta", x => x.IdRegistroEncuestaPregunta);
                    table.ForeignKey(
                        name: "FK_RegistroEncuestaPregunta_Preguntas_PreguntasIdPregunta",
                        column: x => x.PreguntasIdPregunta,
                        principalTable: "Preguntas",
                        principalColumn: "IdPregunta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroEncuestaPregunta_RegistroUsuarioEncuesta_RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta",
                        column: x => x.RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta,
                        principalTable: "RegistroUsuarioEncuesta",
                        principalColumn: "IdRegistroUsuarioEncuesta");
                });

            migrationBuilder.CreateTable(
                name: "RegistroPreguntaRespuesta",
                columns: table => new
                {
                    IdRegistroPreguntaRespuesta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRegistroUsuarioEncuesta = table.Column<int>(type: "int", nullable: false),
                    RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta = table.Column<int>(type: "int", nullable: true),
                    IdPregunta = table.Column<int>(type: "int", nullable: false),
                    PreguntasIdPregunta = table.Column<int>(type: "int", nullable: true),
                    IdRespuesta = table.Column<int>(type: "int", nullable: false),
                    RespuestasIdRespuesta = table.Column<int>(type: "int", nullable: true),
                    IdAgrego = table.Column<int>(type: "int", nullable: false),
                    FechaAgrego = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModifico = table.Column<int>(type: "int", nullable: false),
                    FechaModifico = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroPreguntaRespuesta", x => x.IdRegistroPreguntaRespuesta);
                    table.ForeignKey(
                        name: "FK_RegistroPreguntaRespuesta_Preguntas_PreguntasIdPregunta",
                        column: x => x.PreguntasIdPregunta,
                        principalTable: "Preguntas",
                        principalColumn: "IdPregunta");
                    table.ForeignKey(
                        name: "FK_RegistroPreguntaRespuesta_RegistroUsuarioEncuesta_RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta",
                        column: x => x.RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta,
                        principalTable: "RegistroUsuarioEncuesta",
                        principalColumn: "IdRegistroUsuarioEncuesta");
                    table.ForeignKey(
                        name: "FK_RegistroPreguntaRespuesta_Respuestas_RespuestasIdRespuesta",
                        column: x => x.RespuestasIdRespuesta,
                        principalTable: "Respuestas",
                        principalColumn: "IdRespuesta");
                });

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
                name: "IX_RegistroEncuesta_RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta",
                table: "RegistroEncuesta",
                column: "RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroEncuestaPregunta_PreguntasIdPregunta",
                table: "RegistroEncuestaPregunta",
                column: "PreguntasIdPregunta");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroEncuestaPregunta_RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta",
                table: "RegistroEncuestaPregunta",
                column: "RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPreguntaRespuesta_PreguntasIdPregunta",
                table: "RegistroPreguntaRespuesta",
                column: "PreguntasIdPregunta");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPreguntaRespuesta_RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta",
                table: "RegistroPreguntaRespuesta",
                column: "RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroPreguntaRespuesta_RespuestasIdRespuesta",
                table: "RegistroPreguntaRespuesta",
                column: "RespuestasIdRespuesta");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroUsuarioEncuesta_EncuestasIdEncuesta",
                table: "RegistroUsuarioEncuesta",
                column: "EncuestasIdEncuesta");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroUsuarioEncuesta_UsuariosIdUsuario",
                table: "RegistroUsuarioEncuesta",
                column: "UsuariosIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PerfilesIdPerfil",
                table: "Usuarios",
                column: "PerfilesIdPerfil");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "RegistroEncuesta");

            migrationBuilder.DropTable(
                name: "RegistroEncuestaPregunta");

            migrationBuilder.DropTable(
                name: "RegistroPreguntaRespuesta");

            migrationBuilder.DropTable(
                name: "Acciones");

            migrationBuilder.DropTable(
                name: "Preguntas");

            migrationBuilder.DropTable(
                name: "RegistroUsuarioEncuesta");

            migrationBuilder.DropTable(
                name: "Respuestas");

            migrationBuilder.DropTable(
                name: "Encuestas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Perfiles");
        }
    }
}
