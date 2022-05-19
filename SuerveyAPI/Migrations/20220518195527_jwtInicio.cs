using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuerveyAPI.Migrations
{
    public partial class jwtInicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuariosSeguridad",
                columns: table => new
                {
                    IdUsuariosSeguridad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Llave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContraseniaHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuariosIdUsuario = table.Column<int>(type: "int", nullable: true),
                    IdAgrego = table.Column<int>(type: "int", nullable: false),
                    FechaAgrego = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModifico = table.Column<int>(type: "int", nullable: false),
                    FechaModifico = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosSeguridad", x => x.IdUsuariosSeguridad);
                    table.ForeignKey(
                        name: "FK_UsuariosSeguridad_Usuarios_UsuariosIdUsuario",
                        column: x => x.UsuariosIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosSeguridad_UsuariosIdUsuario",
                table: "UsuariosSeguridad",
                column: "UsuariosIdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuariosSeguridad");
        }
    }
}
