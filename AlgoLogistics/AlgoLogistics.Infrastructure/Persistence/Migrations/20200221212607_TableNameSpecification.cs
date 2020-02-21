using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgoLogistics.Infrastructure.Persistence.Migrations
{
    public partial class TableNameSpecification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Shipment_ShipmentId",
                table: "Packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shipment",
                table: "Shipment");

            migrationBuilder.RenameTable(
                name: "Shipment",
                newName: "Shipments");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Shipments",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "LastModifiedBy",
                table: "Shipments",
                newName: "last_modified_by");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "Shipments",
                newName: "last_modified");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Shipments",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "Route_Path",
                table: "Shipments",
                newName: "path");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shipments",
                table: "Shipments",
                column: "shipment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Shipments_ShipmentId",
                table: "Packages",
                column: "ShipmentId",
                principalTable: "Shipments",
                principalColumn: "shipment_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Shipments_ShipmentId",
                table: "Packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shipments",
                table: "Shipments");

            migrationBuilder.RenameTable(
                name: "Shipments",
                newName: "Shipment");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "Shipment",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "last_modified_by",
                table: "Shipment",
                newName: "LastModifiedBy");

            migrationBuilder.RenameColumn(
                name: "last_modified",
                table: "Shipment",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "Shipment",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "path",
                table: "Shipment",
                newName: "Route_Path");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shipment",
                table: "Shipment",
                column: "shipment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Shipment_ShipmentId",
                table: "Packages",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "shipment_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
