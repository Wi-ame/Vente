using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vente.Migrations
{
    /// <inheritdoc />
    public partial class hi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    IdPr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prix = table.Column<double>(type: "float", nullable: false),
                    IDC = table.Column<int>(type: "int", nullable: false),
                    IDP = table.Column<int>(type: "int", nullable: false),
                    DateExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.IdPr);
                    table.ForeignKey(
                        name: "FK_Produits_Categories_IDC",
                        column: x => x.IDC,
                        principalTable: "Categories",
                        principalColumn: "CategorieID");
                    table.ForeignKey(
                        name: "FK_Produits_Proprietaires_IDP",
                        column: x => x.IDP,
                        principalTable: "Proprietaires",
                        principalColumn: "IDUtilisateur");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produits_IDC",
                table: "Produits",
                column: "IDC");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_IDP",
                table: "Produits",
                column: "IDP");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produits");
        }
    }
}
