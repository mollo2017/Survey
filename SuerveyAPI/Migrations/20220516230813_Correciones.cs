using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuerveyAPI.Migrations
{
    public partial class Correciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Aparterno",
                table: "Usuarios",
                newName: "Apaterno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Apaterno",
                table: "Usuarios",
                newName: "Aparterno");
        }
    }
}
