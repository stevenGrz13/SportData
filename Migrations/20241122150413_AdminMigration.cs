using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportData.Migrations
{
    /// <inheritdoc />
    public partial class AdminMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "administrateur",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adressecourriel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    motdepasse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    identifiant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idorganisation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrateur", x => x.id);
                    table.ForeignKey(
                        name: "FK_administrateur_organisation_idorganisation",
                        column: x => x.idorganisation,
                        principalTable: "organisation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_administrateur_idorganisation",
                table: "administrateur",
                column: "idorganisation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrateur");
        }
    }
}
