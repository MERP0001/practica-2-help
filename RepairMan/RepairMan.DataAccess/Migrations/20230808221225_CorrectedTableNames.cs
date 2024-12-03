using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairMan.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CorrectedTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandSpecialization_Brands_BrandId",
                table: "BrandSpecialization");

            migrationBuilder.DropForeignKey(
                name: "FK_BrandSpecialization_Workshops_WorkshopId",
                table: "BrandSpecialization");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelSpecialization_Models_ModelId",
                table: "ModelSpecialization");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelSpecialization_Workshops_WorkshopId",
                table: "ModelSpecialization");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkshopCategorization_WorkshopCategories_WorkshopCategoryId",
                table: "WorkshopCategorization");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkshopCategorization_Workshops_WorkshopId",
                table: "WorkshopCategorization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkshopCategorization",
                table: "WorkshopCategorization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModelSpecialization",
                table: "ModelSpecialization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BrandSpecialization",
                table: "BrandSpecialization");

            migrationBuilder.RenameTable(
                name: "WorkshopCategorization",
                newName: "WorkshopCategorizations");

            migrationBuilder.RenameTable(
                name: "ModelSpecialization",
                newName: "ModelSpecializations");

            migrationBuilder.RenameTable(
                name: "BrandSpecialization",
                newName: "BrandSpecializations");

            migrationBuilder.RenameIndex(
                name: "IX_WorkshopCategorization_WorkshopId",
                table: "WorkshopCategorizations",
                newName: "IX_WorkshopCategorizations_WorkshopId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkshopCategorization_WorkshopCategoryId",
                table: "WorkshopCategorizations",
                newName: "IX_WorkshopCategorizations_WorkshopCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ModelSpecialization_WorkshopId",
                table: "ModelSpecializations",
                newName: "IX_ModelSpecializations_WorkshopId");

            migrationBuilder.RenameIndex(
                name: "IX_ModelSpecialization_ModelId",
                table: "ModelSpecializations",
                newName: "IX_ModelSpecializations_ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_BrandSpecialization_WorkshopId",
                table: "BrandSpecializations",
                newName: "IX_BrandSpecializations_WorkshopId");

            migrationBuilder.RenameIndex(
                name: "IX_BrandSpecialization_BrandId",
                table: "BrandSpecializations",
                newName: "IX_BrandSpecializations_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkshopCategorizations",
                table: "WorkshopCategorizations",
                column: "WorkshopCategorizationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModelSpecializations",
                table: "ModelSpecializations",
                column: "ModelSpecializationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BrandSpecializations",
                table: "BrandSpecializations",
                column: "BrandSpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandSpecializations_Brands_BrandId",
                table: "BrandSpecializations",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BrandSpecializations_Workshops_WorkshopId",
                table: "BrandSpecializations",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "WorkshopId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelSpecializations_Models_ModelId",
                table: "ModelSpecializations",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "ModelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelSpecializations_Workshops_WorkshopId",
                table: "ModelSpecializations",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "WorkshopId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkshopCategorizations_WorkshopCategories_WorkshopCategoryId",
                table: "WorkshopCategorizations",
                column: "WorkshopCategoryId",
                principalTable: "WorkshopCategories",
                principalColumn: "WorkshopCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkshopCategorizations_Workshops_WorkshopId",
                table: "WorkshopCategorizations",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "WorkshopId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandSpecializations_Brands_BrandId",
                table: "BrandSpecializations");

            migrationBuilder.DropForeignKey(
                name: "FK_BrandSpecializations_Workshops_WorkshopId",
                table: "BrandSpecializations");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelSpecializations_Models_ModelId",
                table: "ModelSpecializations");

            migrationBuilder.DropForeignKey(
                name: "FK_ModelSpecializations_Workshops_WorkshopId",
                table: "ModelSpecializations");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkshopCategorizations_WorkshopCategories_WorkshopCategoryId",
                table: "WorkshopCategorizations");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkshopCategorizations_Workshops_WorkshopId",
                table: "WorkshopCategorizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkshopCategorizations",
                table: "WorkshopCategorizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModelSpecializations",
                table: "ModelSpecializations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BrandSpecializations",
                table: "BrandSpecializations");

            migrationBuilder.RenameTable(
                name: "WorkshopCategorizations",
                newName: "WorkshopCategorization");

            migrationBuilder.RenameTable(
                name: "ModelSpecializations",
                newName: "ModelSpecialization");

            migrationBuilder.RenameTable(
                name: "BrandSpecializations",
                newName: "BrandSpecialization");

            migrationBuilder.RenameIndex(
                name: "IX_WorkshopCategorizations_WorkshopId",
                table: "WorkshopCategorization",
                newName: "IX_WorkshopCategorization_WorkshopId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkshopCategorizations_WorkshopCategoryId",
                table: "WorkshopCategorization",
                newName: "IX_WorkshopCategorization_WorkshopCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ModelSpecializations_WorkshopId",
                table: "ModelSpecialization",
                newName: "IX_ModelSpecialization_WorkshopId");

            migrationBuilder.RenameIndex(
                name: "IX_ModelSpecializations_ModelId",
                table: "ModelSpecialization",
                newName: "IX_ModelSpecialization_ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_BrandSpecializations_WorkshopId",
                table: "BrandSpecialization",
                newName: "IX_BrandSpecialization_WorkshopId");

            migrationBuilder.RenameIndex(
                name: "IX_BrandSpecializations_BrandId",
                table: "BrandSpecialization",
                newName: "IX_BrandSpecialization_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkshopCategorization",
                table: "WorkshopCategorization",
                column: "WorkshopCategorizationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModelSpecialization",
                table: "ModelSpecialization",
                column: "ModelSpecializationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BrandSpecialization",
                table: "BrandSpecialization",
                column: "BrandSpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandSpecialization_Brands_BrandId",
                table: "BrandSpecialization",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BrandSpecialization_Workshops_WorkshopId",
                table: "BrandSpecialization",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "WorkshopId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelSpecialization_Models_ModelId",
                table: "ModelSpecialization",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "ModelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelSpecialization_Workshops_WorkshopId",
                table: "ModelSpecialization",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "WorkshopId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkshopCategorization_WorkshopCategories_WorkshopCategoryId",
                table: "WorkshopCategorization",
                column: "WorkshopCategoryId",
                principalTable: "WorkshopCategories",
                principalColumn: "WorkshopCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkshopCategorization_Workshops_WorkshopId",
                table: "WorkshopCategorization",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "WorkshopId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
