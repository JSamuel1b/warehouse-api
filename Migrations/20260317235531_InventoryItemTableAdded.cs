using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace werehouse_api.Migrations
{
    /// <inheritdoc />
    public partial class InventoryItemTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKU = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastRestocked = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "InventoryItems",
                columns: new[] { "Id", "LastRestocked", "Location", "Name", "SKU", "Stock", "Unit" },
                values: new object[,]
                {
                    { 1, null, "A1-01D-01", "Disposable Coverall Medium /Each", "48678", 10, "Unit" },
                    { 2, null, "A1-01D-02", "Disposable Coverall Large /Each", "48679", 10, "Unit" },
                    { 3, null, "A1-01D-03", "Disposable Coverall XL /Each", "48680", 10, "Unit" },
                    { 4, null, "A1-01D-04A", "Vacuum Bag, For Super Coach Pro 6, GoFree Pro, and ProVac FS6 /Each Pack of 10", "CS485", 10, "Unit" },
                    { 5, null, "A1-01D-04B", "Vacuum Bag For Hip Hugger /Each Pack of 10", "CS420", 10, "Unit" },
                    { 6, null, "A1-01C-01", "Vacuum Bags Lavex /Each Pack of 9", "64789", 10, "Unit" },
                    { 7, null, "A1-01C-02", "Vacuum Bag For Versamatic VS14 /Each Pack of 10", "CS425", 10, "Unit" },
                    { 8, null, "A1-01C-02B", "Vacuum Bag Sanitaire SC9180, S9100, and C4900 /Each Pack of 5", "38784", 10, "Unit" },
                    { 9, null, "A1-01C-03", "Vacuum Bag, Windsor For Versamatic VSP14 /Each Pack of 10", "CS430", 10, "Unit" },
                    { 10, null, "A1-01C-04", "Vacuum Bag, ST Sanitaire/ 5/Pack", "62713", 10, "Unit" },
                    { 11, null, "A1-01C-05", "Vacuum Bag Lavex 12\" upright/ 9/Pack", "63393", 10, "Unit" },
                    { 12, null, "A1-01C-06", "Vacuum Bag Style LS/ 9/Pack", "64650", 10, "Unit" },
                    { 13, null, "A1-01B-01", "Trash Bags Clear, 43\" x 48\" (200/Box", "PP435", 10, "Unit" },
                    { 14, null, "A1-01B-02", "Trash Bags Clear, 24\" x 24\" (1000/Box", "PP415", 10, "Unit" },
                    { 15, null, "A1-01B-03", "Trash Bags Clear, 33\" x 39\" (250/Box", "PP425", 10, "Unit" },
                    { 16, null, "A1-01A-01", "Trash Bags Black, 44\" x 55\" (100/Box", "PP450", 10, "Unit" },
                    { 17, null, "A1-01A-02", "Trash Bags Black, 43\" x 47\" (100/Box", "PP455", 10, "Unit" },
                    { 18, null, "A1-02C-01", "Trash Bags, Sanitary Napkin Liners, 12\" x 6\" (500/Box", "FP120", 10, "Unit" },
                    { 19, null, "A1-02C-02", "Deli Paper 10\" x 10.75\" (500/Box", "PP335", 10, "Unit" },
                    { 20, null, "A1-02C-03", "Tampon Procter and Gamble (Each", "FP105", 10, "Unit" },
                    { 21, null, "A1-02C-04", "Maxi Pad Gards, Hospitality Specialty Co. (Each", "FP115", 10, "Unit" },
                    { 22, null, "A1-02B-01", "Trash Bags Black, 49\" x 53\" (75/Box", "PP460", 10, "Unit" },
                    { 23, null, "A1-02B-02", "Trash Bags Black 58\" x 38\" (100 Box", "60707", 10, "Unit" },
                    { 24, null, "A1-02A-01", "Trash Bags Clear, 27\" x 35\" (500/Box", "PP400", 10, "Unit" },
                    { 25, null, "A1-02A-02", "Trash Bags Clear, 24\" x 33\" (1000/Box", "PP420", 10, "Unit" },
                    { 26, null, "A1-03C-01", "8 oz Disposable Beverage Cups For Hot or Cold Drinks (Each Box", "49618", 10, "Unit" },
                    { 27, null, "A1-03C-02", "5 oz Disposable Beverage Cups For Cold Drinks Each Box 5 0z Disposable Beverage Cups For Cold Drinks (Each Box", "PP205", 10, "Unit" },
                    { 28, null, "A1-03C-03", "9 oz Disposable Beverage Cups For Cold Drinks (Each Box", "PP211", 10, "Unit" },
                    { 29, null, "A1-03C-04", "Facial Tissue, Victoria Bay Rectangular Box (Each Tissue Box", "PP131", 10, "Unit" },
                    { 30, null, "A1-03B-01", "Baby Wipe Huggies, Unscented Tubs", "63747", 10, "Unit" },
                    { 31, null, "A1-03B-02", "Facial Tissue, Kleenex Cardboard Cube (Each", "PP101", 10, "Unit" },
                    { 32, null, "A1-03B-03", "Napkin, Luncheon White Paper 12PK/CS Napkin, Luncheon White Paper 12PK/CS Napkin, Luncheon White Paper 12PK/CS", "PP328", 10, "Unit" },
                    { 33, null, "A1-03A-01", "WypAll, All-Purpose Wipes, White (Each Pack", "PP320", 10, "Unit" },
                    { 34, null, "A1-03A-02", "WypAll, Wipes Kimberly-Clark (Each Box", "PP315", 10, "Unit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryItems");
        }
    }
}
