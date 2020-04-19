using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgoLogistics.Infrastructure.Persistence.Migrations
{
    public partial class ShipmentStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Shipments",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Shipments");
        }
    }
}
