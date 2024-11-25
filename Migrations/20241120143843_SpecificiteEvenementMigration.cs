using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportData.Migrations
{
    /// <inheritdoc />
    public partial class SpecificiteEvenementMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "nombreplace",
                table: "specificiteevenement",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nombreplace",
                table: "specificiteevenement");
        }
    }
}
