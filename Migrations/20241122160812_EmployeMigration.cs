using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportData.Migrations
{
    /// <inheritdoc />
    public partial class EmployeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employe",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adressecourriel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    motdepasse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    validation = table.Column<bool>(type: "bit", nullable: false),
                    idorganisation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employe", x => x.id);
                    table.ForeignKey(
                        name: "FK_employe_organisation_idorganisation",
                        column: x => x.idorganisation,
                        principalTable: "organisation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employe_idorganisation",
                table: "employe",
                column: "idorganisation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employe");
        }
    }
}
