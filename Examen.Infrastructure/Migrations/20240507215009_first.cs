using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banques",
                columns: table => new
                {
                    code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banques", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "DAB",
                columns: table => new
                {
                    DABid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Localisation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DAB", x => x.DABid);
                });

            migrationBuilder.CreateTable(
                name: "Comptes",
                columns: table => new
                {
                    NumeroCompte = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Proprietaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Solde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    BanqueFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comptes", x => x.NumeroCompte);
                    table.ForeignKey(
                        name: "FK_Comptes_Banques_BanqueFK",
                        column: x => x.BanqueFK,
                        principalTable: "Banques",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DABFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompteFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Montant = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    AutreAgence = table.Column<bool>(type: "bit", nullable: true),
                    NumeroCompte = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => new { x.Date, x.CompteFk, x.DABFk });
                    table.ForeignKey(
                        name: "FK_Transactions_Comptes_CompteFk",
                        column: x => x.CompteFk,
                        principalTable: "Comptes",
                        principalColumn: "NumeroCompte",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_DAB_DABFk",
                        column: x => x.DABFk,
                        principalTable: "DAB",
                        principalColumn: "DABid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comptes_BanqueFK",
                table: "Comptes",
                column: "BanqueFK");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CompteFk",
                table: "Transactions",
                column: "CompteFk");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DABFk",
                table: "Transactions",
                column: "DABFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Comptes");

            migrationBuilder.DropTable(
                name: "DAB");

            migrationBuilder.DropTable(
                name: "Banques");
        }
    }
}
