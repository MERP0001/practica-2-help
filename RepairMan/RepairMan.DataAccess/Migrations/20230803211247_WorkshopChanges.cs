using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairMan.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class WorkshopChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workshops_Geoposition_GeopositionId",
                table: "Workshops");

            migrationBuilder.AlterColumn<Guid>(
                name: "GeopositionId",
                table: "Workshops",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "WorkshopProducts",
                columns: table => new
                {
                    WorkshopProductId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkshopId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ProductType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopProducts", x => x.WorkshopProductId);
                    table.ForeignKey(
                        name: "FK_WorkshopProducts_Workshops_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Workshops",
                        principalColumn: "WorkshopId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopProducts_WorkshopId",
                table: "WorkshopProducts",
                column: "WorkshopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workshops_Geoposition_GeopositionId",
                table: "Workshops",
                column: "GeopositionId",
                principalTable: "Geoposition",
                principalColumn: "GeopositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workshops_Geoposition_GeopositionId",
                table: "Workshops");

            migrationBuilder.DropTable(
                name: "WorkshopProducts");

            migrationBuilder.AlterColumn<Guid>(
                name: "GeopositionId",
                table: "Workshops",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Workshops_Geoposition_GeopositionId",
                table: "Workshops",
                column: "GeopositionId",
                principalTable: "Geoposition",
                principalColumn: "GeopositionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
