using Microsoft.EntityFrameworkCore.Migrations;

namespace PropertyViewer.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    YearBuilt = table.Column<int>(nullable: true),
                    ListPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MonthlyRent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrossYield = table.Column<decimal>(type: "decimal(18,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
