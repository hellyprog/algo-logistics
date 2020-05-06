using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgoLogistics.Infrastructure.Persistence.Migrations
{
    public partial class CountryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "delivery_price",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "currency",
                table: "Packages",
                newName: "price_currency");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Packages",
                newName: "price_amount");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cities",
                newName: "name");

            migrationBuilder.AddColumn<decimal>(
                name: "delivery_price_amount",
                table: "Packages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "delivery_price_currency",
                table: "Packages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "Cities",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "city_id",
                keyValue: 1,
                column: "country",
                value: "Ukraine");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "city_id",
                keyValue: 2,
                column: "country",
                value: "Ukraine");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "city_id",
                keyValue: 3,
                column: "country",
                value: "Ukraine");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "city_id",
                keyValue: 4,
                column: "country",
                value: "Ukraine");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "city_id",
                keyValue: 5,
                column: "country",
                value: "Ukraine");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "city_id",
                keyValue: 6,
                column: "country",
                value: "Ukraine");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "city_id",
                keyValue: 7,
                column: "country",
                value: "Ukraine");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "city_id",
                keyValue: 8,
                column: "country",
                value: "Ukraine");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "city_id",
                keyValue: 9,
                column: "country",
                value: "Ukraine");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "city_id",
                keyValue: 10,
                column: "country",
                value: "Ukraine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "delivery_price_amount",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "delivery_price_currency",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "country",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "price_currency",
                table: "Packages",
                newName: "currency");

            migrationBuilder.RenameColumn(
                name: "price_amount",
                table: "Packages",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Cities",
                newName: "Name");

            migrationBuilder.AddColumn<decimal>(
                name: "delivery_price",
                table: "Packages",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
