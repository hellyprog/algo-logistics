using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgoLogistics.Infrastructure.Persistence.Migrations
{
	public partial class EnumColumnsRemove : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "size_category",
				table: "Packages");

			migrationBuilder.DropColumn(
				name: "weight_category",
				table: "Packages");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "size_category",
				table: "Packages",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddColumn<string>(
				name: "weight_category",
				table: "Packages",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");
		}
	}
}
