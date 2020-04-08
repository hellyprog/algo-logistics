using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgoLogistics.Infrastructure.Persistence.Migrations
{
	public partial class WeightRemoval : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "weight",
				table: "Packages");

			migrationBuilder.DropColumn(
				name: "weight",
				table: "PackageCategories");

			migrationBuilder.DropColumn(
				name: "weight_category",
				table: "PackageCategories");

			migrationBuilder.InsertData(
				table: "PackageCategories",
				columns: new[] { "package_category_id", "height", "length", "size_category", "width" },
				values: new object[,]
				{
					{ 1, 0.050000000000000003, 0.20000000000000001, "ExtraSmall", 0.14999999999999999 },
					{ 2, 0.10000000000000001, 0.29999999999999999, "Small", 0.20000000000000001 },
					{ 3, 0.20000000000000001, 0.29999999999999999, "Medium", 0.29999999999999999 },
					{ 4, 0.29999999999999999, 0.40000000000000002, "Large", 0.29999999999999999 },
					{ 5, 0.29999999999999999, 0.45000000000000001, "ExtraLarge", 0.29999999999999999 }
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "PackageCategories",
				keyColumn: "package_category_id",
				keyValue: 1);

			migrationBuilder.DeleteData(
				table: "PackageCategories",
				keyColumn: "package_category_id",
				keyValue: 2);

			migrationBuilder.DeleteData(
				table: "PackageCategories",
				keyColumn: "package_category_id",
				keyValue: 3);

			migrationBuilder.DeleteData(
				table: "PackageCategories",
				keyColumn: "package_category_id",
				keyValue: 4);

			migrationBuilder.DeleteData(
				table: "PackageCategories",
				keyColumn: "package_category_id",
				keyValue: 5);

			migrationBuilder.AddColumn<double>(
				name: "weight",
				table: "Packages",
				type: "float",
				nullable: true);

			migrationBuilder.AddColumn<double>(
				name: "weight",
				table: "PackageCategories",
				type: "float",
				nullable: false,
				defaultValue: 0.0);

			migrationBuilder.AddColumn<string>(
				name: "weight_category",
				table: "PackageCategories",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");
		}
	}
}
