using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PregledPlus.Migrations
{
    public partial class izmena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Termins_AspNetUsers_ApplicationUserId",
                table: "Termins");

            migrationBuilder.DropIndex(
                name: "IX_Termins_ApplicationUserId",
                table: "Termins");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Termins");

            migrationBuilder.AddColumn<string>(
                name: "brojTelefona",
                table: "Termins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Termins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ime",
                table: "Termins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "prezime",
                table: "Termins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "brojTelefona",
                table: "Termins");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Termins");

            migrationBuilder.DropColumn(
                name: "ime",
                table: "Termins");

            migrationBuilder.DropColumn(
                name: "prezime",
                table: "Termins");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Termins",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Termins_ApplicationUserId",
                table: "Termins",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Termins_AspNetUsers_ApplicationUserId",
                table: "Termins",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
