using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendAPI.Migrations
{
    public partial class MiseàjourAnneeScolaireId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscriptions_Annee_Scolaires_AnneeScolaire1",
                table: "Inscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Inscriptions_AnneeScolaire1",
                table: "Inscriptions");

            migrationBuilder.DropColumn(
                name: "AnneeScolaire1",
                table: "Inscriptions");

            migrationBuilder.RenameColumn(
                name: "AnneScolaireId",
                table: "Inscriptions",
                newName: "AnneeScolaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_AnneeScolaireId",
                table: "Inscriptions",
                column: "AnneeScolaireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscriptions_Annee_Scolaires_AnneeScolaireId",
                table: "Inscriptions",
                column: "AnneeScolaireId",
                principalTable: "Annee_Scolaires",
                principalColumn: "AnneScolaireId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscriptions_Annee_Scolaires_AnneeScolaireId",
                table: "Inscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Inscriptions_AnneeScolaireId",
                table: "Inscriptions");

            migrationBuilder.RenameColumn(
                name: "AnneeScolaireId",
                table: "Inscriptions",
                newName: "AnneScolaireId");

            migrationBuilder.AddColumn<int>(
                name: "AnneeScolaire1",
                table: "Inscriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_AnneeScolaire1",
                table: "Inscriptions",
                column: "AnneeScolaire1");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscriptions_Annee_Scolaires_AnneeScolaire1",
                table: "Inscriptions",
                column: "AnneeScolaire1",
                principalTable: "Annee_Scolaires",
                principalColumn: "AnneScolaireId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
