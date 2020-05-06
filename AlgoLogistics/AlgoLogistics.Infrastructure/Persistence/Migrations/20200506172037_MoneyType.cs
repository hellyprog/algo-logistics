using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgoLogistics.Infrastructure.Persistence.Migrations
{
    public partial class MoneyType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "Packages");

            migrationBuilder.AddColumn<decimal>(
                name: "amount",
                table: "Packages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "currency",
                table: "Packages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amount",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "currency",
                table: "Packages");

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "Packages",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
