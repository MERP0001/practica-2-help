using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairMan.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IconCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "WorkshopCategories",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Keywords",
                table: "WorkshopCategories",
                type: "json",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "WorkshopCategories");

            migrationBuilder.DropColumn(
                name: "Keywords",
                table: "WorkshopCategories");
        }
    }
}
