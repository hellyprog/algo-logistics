using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgoLogistics.Infrastructure.Persistence.Migrations
{
    public partial class ExplicitFK2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Shipments_ShipmentId",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "ShipmentId",
                table: "Packages",
                newName: "transport_id");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_ShipmentId",
                table: "Packages",
                newName: "IX_Packages_transport_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Shipments_transport_id",
                table: "Packages",
                column: "transport_id",
                principalTable: "Shipments",
                principalColumn: "shipment_id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Shipments_transport_id",
                table: "Packages");

            migrationBuilder.RenameColumn(
                name: "transport_id",
                table: "Packages",
                newName: "ShipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Packages_transport_id",
                table: "Packages",
                newName: "IX_Packages_ShipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Shipments_ShipmentId",
                table: "Packages",
                column: "ShipmentId",
                principalTable: "Shipments",
                principalColumn: "shipment_id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
