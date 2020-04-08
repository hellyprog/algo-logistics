using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgoLogistics.Infrastructure.Persistence.Migrations
{
	public partial class PackageCategories : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "invoice_no",
				table: "Packages",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Cities",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)",
				oldNullable: true);

			migrationBuilder.CreateTable(
				name: "PackageCategories",
				columns: table => new
				{
					package_category_id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					size_category = table.Column<string>(nullable: false),
					weight_category = table.Column<string>(nullable: false),
					length = table.Column<double>(nullable: false),
					width = table.Column<double>(nullable: false),
					height = table.Column<double>(nullable: false),
					weight = table.Column<double>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PackageCategories", x => x.package_category_id);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "PackageCategories");

			migrationBuilder.AlterColumn<string>(
				name: "invoice_no",
				table: "Packages",
				type: "nvarchar(max)",
				nullable: true,
				oldClrType: typeof(string));

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Cities",
				type: "nvarchar(max)",
				nullable: true,
				oldClrType: typeof(string));
		}
	}
}
