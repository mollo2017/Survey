using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuerveyAPI.Migrations
{
    public partial class Faltantes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CtrlEncuestaPregunta");

            migrationBuilder.DropTable(
                name: "CtrlPreguntaRespuesta");
        }
    }
}
