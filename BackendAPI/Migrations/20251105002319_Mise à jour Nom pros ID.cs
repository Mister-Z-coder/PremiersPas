using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendAPI.Migrations
{
    public partial class MiseàjourNomprosID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Inscriptions",
                newName: "IdInscription");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Eleves",
                newName: "IdEleve");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ecoles",
                newName: "IdEcole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdInscription",
                table: "Inscriptions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdEleve",
                table: "Eleves",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdEcole",
                table: "Ecoles",
                newName: "Id");
        }
    }
}
