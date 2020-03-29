using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgoLogistics.Infrastructure.Persistence.Migrations
{
    public partial class PackageCategoryReferenceImplicit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackageCategories_package_category_id",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "package_category_id",
                table: "Packages",
                newName: "PackageCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_package_category_id",
                table: "Packages",
                newName: "IX_Packages_PackageCategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "PackageCategoryId",
                table: "Packages",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackageCategories_PackageCategoryId",
                table: "Packages",
                column: "PackageCategoryId",
                principalTable: "PackageCategories",
                principalColumn: "package_category_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackageCategories_PackageCategoryId",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "PackageCategoryId",
                table: "Packages",
                newName: "package_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_PackageCategoryId",
                table: "Packages",
                newName: "IX_Packages_package_category_id");

            migrationBuilder.AlterColumn<int>(
                name: "package_category_id",
                table: "Packages",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackageCategories_package_category_id",
                table: "Packages",
                column: "package_category_id",
                principalTable: "PackageCategories",
                principalColumn: "package_category_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
