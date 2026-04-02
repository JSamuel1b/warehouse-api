using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace werehouse_api.Migrations
{
    /// <inheritdoc />
    public partial class KioskAndPinCodeDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsKioskCheckout",
                table: "Tools",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KioskId",
                table: "Tools",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KioskName",
                table: "Tools",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsKioskCheckout",
                table: "ToolHistories",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KioskId",
                table: "ToolHistories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KioskName",
                table: "ToolHistories",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PinCode",
                table: "Departments",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "PinCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "PinCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                column: "PinCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsKioskCheckout", "KioskId", "KioskName" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsKioskCheckout", "KioskId", "KioskName" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsKioskCheckout", "KioskId", "KioskName" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IsKioskCheckout", "KioskId", "KioskName" },
                values: new object[] { null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsKioskCheckout",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "KioskId",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "KioskName",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "IsKioskCheckout",
                table: "ToolHistories");

            migrationBuilder.DropColumn(
                name: "KioskId",
                table: "ToolHistories");

            migrationBuilder.DropColumn(
                name: "KioskName",
                table: "ToolHistories");

            migrationBuilder.DropColumn(
                name: "PinCode",
                table: "Departments");
        }
    }
}
