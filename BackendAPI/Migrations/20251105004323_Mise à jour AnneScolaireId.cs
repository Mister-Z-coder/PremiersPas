using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendAPI.Migrations
{
    public partial class MiseàjourAnneScolaireId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnneeScolaire",
                table: "Annee_Scolaires",
                newName: "AnneScolaireId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnneScolaireId",
                table: "Annee_Scolaires",
                newName: "AnneeScolaire");
        }
    }
}
