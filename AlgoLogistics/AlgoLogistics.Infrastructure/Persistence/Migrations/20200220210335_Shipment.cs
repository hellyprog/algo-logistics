using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgoLogistics.Infrastructure.Persistence.Migrations
{
    public partial class Shipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShipmentId",
                table: "Packages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Shipment",
                columns: table => new
                {
                    shipment_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    start_city = table.Column<string>(nullable: true),
                    destination_city = table.Column<string>(nullable: true),
                    Route_Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.shipment_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ShipmentId",
                table: "Packages",
                column: "ShipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Shipment_ShipmentId",
                table: "Packages",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "shipment_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Shipment_ShipmentId",
                table: "Packages");

            migrationBuilder.DropTable(
                name: "Shipment");

            migrationBuilder.DropIndex(
                name: "IX_Packages_ShipmentId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "ShipmentId",
                table: "Packages");
        }
    }
}
