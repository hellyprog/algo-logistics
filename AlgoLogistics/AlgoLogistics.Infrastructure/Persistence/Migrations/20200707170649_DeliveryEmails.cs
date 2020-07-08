using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgoLogistics.Infrastructure.Persistence.Migrations
{
    public partial class DeliveryEmails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "receiver_email",
                table: "Packages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sender_email",
                table: "Packages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "receiver_email",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "sender_email",
                table: "Packages");
        }
    }
}
