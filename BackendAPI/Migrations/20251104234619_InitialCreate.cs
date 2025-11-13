using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Annee_Scolaires",
                columns: table => new
                {
                    AnneeScolaire = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annee_Scolaires", x => x.AnneeScolaire);
                });

            migrationBuilder.CreateTable(
                name: "Ecoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricule_Secope = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitreEcole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresseEcole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoEcole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoriqueEcole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Arrete_Agreement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatitudeEcole = table.Column<double>(type: "float", nullable: false),
                    LongitudeEcole = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eleves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomEleve = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostNomEleve = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SexeEleve = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoEleve = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LieuNaisEleve = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateNaisEleve = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eleves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EleveId = table.Column<int>(type: "int", nullable: false),
                    EcoleId = table.Column<int>(type: "int", nullable: false),
                    AnneScolaireId = table.Column<int>(type: "int", nullable: false),
                    AnneeScolaire1 = table.Column<int>(type: "int", nullable: true),
                    DateInscription = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Annee_Scolaires_AnneeScolaire1",
                        column: x => x.AnneeScolaire1,
                        principalTable: "Annee_Scolaires",
                        principalColumn: "AnneeScolaire",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Ecoles_EcoleId",
                        column: x => x.EcoleId,
                        principalTable: "Ecoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Eleves_EleveId",
                        column: x => x.EleveId,
                        principalTable: "Eleves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_AnneeScolaire1",
                table: "Inscriptions",
                column: "AnneeScolaire1");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_EcoleId",
                table: "Inscriptions",
                column: "EcoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_EleveId",
                table: "Inscriptions",
                column: "EleveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscriptions");

            migrationBuilder.DropTable(
                name: "Annee_Scolaires");

            migrationBuilder.DropTable(
                name: "Ecoles");

            migrationBuilder.DropTable(
                name: "Eleves");
        }
    }
}
