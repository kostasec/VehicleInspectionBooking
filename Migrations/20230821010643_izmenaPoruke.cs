using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PregledPlus.Migrations
{
    public partial class izmenaPoruke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ime",
                table: "Porukas");

            migrationBuilder.RenameColumn(
                name: "prezime",
                table: "Porukas",
                newName: "ime_prezime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ime_prezime",
                table: "Porukas",
                newName: "prezime");

            migrationBuilder.AddColumn<string>(
                name: "ime",
                table: "Porukas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
