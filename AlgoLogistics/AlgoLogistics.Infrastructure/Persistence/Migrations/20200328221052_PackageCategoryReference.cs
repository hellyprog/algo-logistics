using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgoLogistics.Infrastructure.Persistence.Migrations
{
	public partial class PackageCategoryReference : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "package_category_id",
				table: "Packages",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.CreateIndex(
				name: "IX_Packages_package_category_id",
				table: "Packages",
				column: "package_category_id");

			migrationBuilder.AddForeignKey(
				name: "FK_Packages_PackageCategories_package_category_id",
				table: "Packages",
				column: "package_category_id",
				principalTable: "PackageCategories",
				principalColumn: "package_category_id",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Packages_PackageCategories_package_category_id",
				table: "Packages");

			migrationBuilder.DropIndex(
				name: "IX_Packages_package_category_id",
				table: "Packages");

			migrationBuilder.DropColumn(
				name: "package_category_id",
				table: "Packages");
		}
	}
}
