using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgoLogistics.Infrastructure.Persistence.Migrations
{
    public partial class Transport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransportId",
                table: "Packages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    transport_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transport_no = table.Column<string>(nullable: false),
                    transport_model = table.Column<string>(nullable: false),
                    transport_type = table.Column<string>(nullable: false),
                    length = table.Column<double>(nullable: true),
                    width = table.Column<double>(nullable: true),
                    height = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.transport_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_TransportId",
                table: "Packages",
                column: "TransportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Transports_TransportId",
                table: "Packages",
                column: "TransportId",
                principalTable: "Transports",
                principalColumn: "transport_id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Transports_TransportId",
                table: "Packages");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropIndex(
                name: "IX_Packages_TransportId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "TransportId",
                table: "Packages");
        }
    }
}
