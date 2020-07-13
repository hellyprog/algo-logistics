using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgoLogistics.Infrastructure.Persistence.Migrations
{
    public partial class ExplicitFK3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Shipments_transport_id",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Transports_TransportId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_TransportId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "TransportId",
                table: "Packages");

            migrationBuilder.AddColumn<int>(
                name: "shipment_id",
                table: "Packages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_shipment_id",
                table: "Packages",
                column: "shipment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Shipments_shipment_id",
                table: "Packages",
                column: "shipment_id",
                principalTable: "Shipments",
                principalColumn: "shipment_id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Transports_transport_id",
                table: "Packages",
                column: "transport_id",
                principalTable: "Transports",
                principalColumn: "transport_id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Shipments_shipment_id",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Transports_transport_id",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_shipment_id",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "shipment_id",
                table: "Packages");

            migrationBuilder.AddColumn<int>(
                name: "TransportId",
                table: "Packages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_TransportId",
                table: "Packages",
                column: "TransportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Shipments_transport_id",
                table: "Packages",
                column: "transport_id",
                principalTable: "Shipments",
                principalColumn: "shipment_id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Transports_TransportId",
                table: "Packages",
                column: "TransportId",
                principalTable: "Transports",
                principalColumn: "transport_id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
