using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgoLogistics.Infrastructure.Persistence.Migrations
{
	public partial class CititesSeed : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "Cities",
				columns: new[] { "city_id", "Name" },
				values: new object[,]
				{
					{ 1, "Lviv" },
					{ 2, "Uzgorod" },
					{ 3, "Lutsk" },
					{ 4, "Rivne" },
					{ 5, "Ternopil" },
					{ 6, "Ivano-Frankivsk" },
					{ 7, "Chernivtsi" },
					{ 8, "Zhytomyr" },
					{ 9, "Khmelnytskyi" },
					{ 10, "Vinnytsia" }
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "Cities",
				keyColumn: "city_id",
				keyValue: 1);

			migrationBuilder.DeleteData(
				table: "Cities",
				keyColumn: "city_id",
				keyValue: 2);

			migrationBuilder.DeleteData(
				table: "Cities",
				keyColumn: "city_id",
				keyValue: 3);

			migrationBuilder.DeleteData(
				table: "Cities",
				keyColumn: "city_id",
				keyValue: 4);

			migrationBuilder.DeleteData(
				table: "Cities",
				keyColumn: "city_id",
				keyValue: 5);

			migrationBuilder.DeleteData(
				table: "Cities",
				keyColumn: "city_id",
				keyValue: 6);

			migrationBuilder.DeleteData(
				table: "Cities",
				keyColumn: "city_id",
				keyValue: 7);

			migrationBuilder.DeleteData(
				table: "Cities",
				keyColumn: "city_id",
				keyValue: 8);

			migrationBuilder.DeleteData(
				table: "Cities",
				keyColumn: "city_id",
				keyValue: 9);

			migrationBuilder.DeleteData(
				table: "Cities",
				keyColumn: "city_id",
				keyValue: 10);
		}
	}
}
