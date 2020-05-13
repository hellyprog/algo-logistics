using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgoLogistics.Infrastructure.Persistence.Migrations
{
    public partial class ApplicationConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationConfig",
                columns: table => new
                {
                    application_config_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    config_name = table.Column<string>(nullable: true),
                    config_value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationConfig", x => x.application_config_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationConfig");
        }
    }
}
