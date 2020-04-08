using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AlgoLogistics.Infrastructure.Persistence.Migrations
{
	public partial class InitialCreation : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Packages",
				columns: table => new
				{
					package_id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					created_by = table.Column<string>(nullable: true),
					created = table.Column<DateTime>(nullable: false),
					last_modified_by = table.Column<string>(nullable: true),
					last_modified = table.Column<DateTime>(nullable: true),
					description = table.Column<string>(nullable: false),
					price = table.Column<decimal>(nullable: false),
					delivery_price = table.Column<decimal>(nullable: false),
					weight_category = table.Column<string>(nullable: false),
					size_category = table.Column<string>(nullable: false),
					width = table.Column<double>(nullable: true),
					height = table.Column<double>(nullable: true),
					length = table.Column<double>(nullable: true),
					weight = table.Column<double>(nullable: true),
					sender = table.Column<string>(nullable: true),
					receiver = table.Column<string>(nullable: true),
					from_city = table.Column<string>(nullable: true),
					to_city = table.Column<string>(nullable: true),
					status = table.Column<string>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Packages", x => x.package_id);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Packages");
		}
	}
}
