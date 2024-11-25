using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportData.Migrations
{
    /// <inheritdoc />
    public partial class EntiteMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organisation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organisation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sport",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sport", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "evenement",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idorganisation = table.Column<int>(type: "int", nullable: false),
                    datedebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datefin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evenement", x => x.id);
                    table.ForeignKey(
                        name: "FK_evenement_organisation_idorganisation",
                        column: x => x.idorganisation,
                        principalTable: "organisation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "coach",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idsport = table.Column<int>(type: "int", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coach", x => x.id);
                    table.ForeignKey(
                        name: "FK_coach_sport_idsport",
                        column: x => x.idsport,
                        principalTable: "sport",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "specificiteevenement",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idevenement = table.Column<int>(type: "int", nullable: false),
                    idsport = table.Column<int>(type: "int", nullable: false),
                    datedebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datefin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specificiteevenement", x => x.id);
                    table.ForeignKey(
                        name: "FK_specificiteevenement_evenement_idevenement",
                        column: x => x.idevenement,
                        principalTable: "evenement",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_specificiteevenement_sport_idsport",
                        column: x => x.idsport,
                        principalTable: "sport",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_coach_idsport",
                table: "coach",
                column: "idsport");

            migrationBuilder.CreateIndex(
                name: "IX_evenement_idorganisation",
                table: "evenement",
                column: "idorganisation");

            migrationBuilder.CreateIndex(
                name: "IX_specificiteevenement_idevenement",
                table: "specificiteevenement",
                column: "idevenement");

            migrationBuilder.CreateIndex(
                name: "IX_specificiteevenement_idsport",
                table: "specificiteevenement",
                column: "idsport");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coach");

            migrationBuilder.DropTable(
                name: "specificiteevenement");

            migrationBuilder.DropTable(
                name: "evenement");

            migrationBuilder.DropTable(
                name: "sport");

            migrationBuilder.DropTable(
                name: "organisation");
        }
    }
}
