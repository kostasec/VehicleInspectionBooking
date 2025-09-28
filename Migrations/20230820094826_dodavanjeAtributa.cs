using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PregledPlus.Migrations
{
    public partial class dodavanjeAtributa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vozilos");

            migrationBuilder.AddColumn<string>(
                name: "reg_oznaka",
                table: "Termins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "reg_oznaka",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reg_oznaka",
                table: "Termins");

            migrationBuilder.DropColumn(
                name: "reg_oznaka",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Vozilos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    broj_sasije = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    godiste = table.Column<DateTime>(type: "datetime2", nullable: false),
                    konjska_snaga = table.Column<int>(type: "int", nullable: false),
                    marka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reg_oznaka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozilos", x => x.id);
                });
        }
    }
}
