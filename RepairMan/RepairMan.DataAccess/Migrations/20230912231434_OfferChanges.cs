using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairMan.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OfferChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Offers",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Offers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CategoryId",
                table: "Offers",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_WorkshopCategories_CategoryId",
                table: "Offers",
                column: "CategoryId",
                principalTable: "WorkshopCategories",
                principalColumn: "WorkshopCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_WorkshopCategories_CategoryId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_CategoryId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Offers");
        }
    }
}
