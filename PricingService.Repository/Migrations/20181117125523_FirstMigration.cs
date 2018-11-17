using Microsoft.EntityFrameworkCore.Migrations;

namespace PricingService.Repository.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceDetails",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceDetails", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "PriceDetails",
                columns: new[] { "ProductId", "Price" },
                values: new object[] { 1, 500.0 });

            migrationBuilder.InsertData(
                table: "PriceDetails",
                columns: new[] { "ProductId", "Price" },
                values: new object[] { 2, 1500.0 });

            migrationBuilder.InsertData(
                table: "PriceDetails",
                columns: new[] { "ProductId", "Price" },
                values: new object[] { 3, 700.0 });

            migrationBuilder.InsertData(
                table: "PriceDetails",
                columns: new[] { "ProductId", "Price" },
                values: new object[] { 4, 1700.0 });

            migrationBuilder.InsertData(
                table: "PriceDetails",
                columns: new[] { "ProductId", "Price" },
                values: new object[] { 5, 2700.0 });

            migrationBuilder.InsertData(
                table: "PriceDetails",
                columns: new[] { "ProductId", "Price" },
                values: new object[] { 6, 1000.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceDetails");
        }
    }
}
