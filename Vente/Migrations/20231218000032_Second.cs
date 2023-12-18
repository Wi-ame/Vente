using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vente.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proprietaires",
                columns: table => new
                {
                    IDUtilisateur = table.Column<int>(type: "int", nullable: false),
                    NomEntreprise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresseEntreprise = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietaires", x => x.IDUtilisateur);
                    table.ForeignKey(
                        name: "FK_Proprietaires_Utilisateurs_IDUtilisateur",
                        column: x => x.IDUtilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "ID");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proprietaires");
        }
    }
}
