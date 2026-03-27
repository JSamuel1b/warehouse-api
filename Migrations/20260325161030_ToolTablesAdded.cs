using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace werehouse_api.Migrations
{
    /// <inheritdoc />
    public partial class ToolTablesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToolCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToolCategoryId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CurrentHolderUsername = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OwnerUsername = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CheckedOutAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LocationOfUse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedDuration = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tools_ToolCategories_ToolCategoryId",
                        column: x => x.ToolCategoryId,
                        principalTable: "ToolCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tools_Users_CurrentHolderUsername",
                        column: x => x.CurrentHolderUsername,
                        principalTable: "Users",
                        principalColumn: "Username");
                    table.ForeignKey(
                        name: "FK_Tools_Users_OwnerUsername",
                        column: x => x.OwnerUsername,
                        principalTable: "Users",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateTable(
                name: "ToolHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToolId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ByUserUsername = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LocationOfUse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clean = table.Column<bool>(type: "bit", nullable: true),
                    StaffUserUsername = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BorrowerUserUsername = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToolHistories_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ToolHistories_Users_BorrowerUserUsername",
                        column: x => x.BorrowerUserUsername,
                        principalTable: "Users",
                        principalColumn: "Username");
                    table.ForeignKey(
                        name: "FK_ToolHistories_Users_ByUserUsername",
                        column: x => x.ByUserUsername,
                        principalTable: "Users",
                        principalColumn: "Username");
                    table.ForeignKey(
                        name: "FK_ToolHistories_Users_StaffUserUsername",
                        column: x => x.StaffUserUsername,
                        principalTable: "Users",
                        principalColumn: "Username");
                });

            migrationBuilder.InsertData(
                table: "ToolCategories",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Hand Tools" },
                    { 2, true, "Power Tools" },
                    { 3, true, "Safety" },
                    { 4, true, "Ladders" }
                });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "Id", "CheckedOutAt", "CurrentHolderUsername", "DueAt", "ExpectedDuration", "LocationOfUse", "Name", "OwnerUsername", "Status", "ToolCategoryId" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, "Impact Drill (DeWalt)", null, "available", 2 },
                    { 2, null, null, null, null, null, "Angle Grinder", null, "available", 2 },
                    { 3, null, null, null, null, null, "Ladder 6ft", null, "available", 4 },
                    { 4, null, null, null, null, null, "Safety Harness", null, "available", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToolHistories_BorrowerUserUsername",
                table: "ToolHistories",
                column: "BorrowerUserUsername");

            migrationBuilder.CreateIndex(
                name: "IX_ToolHistories_ByUserUsername",
                table: "ToolHistories",
                column: "ByUserUsername");

            migrationBuilder.CreateIndex(
                name: "IX_ToolHistories_StaffUserUsername",
                table: "ToolHistories",
                column: "StaffUserUsername");

            migrationBuilder.CreateIndex(
                name: "IX_ToolHistories_ToolId",
                table: "ToolHistories",
                column: "ToolId");

            migrationBuilder.CreateIndex(
                name: "IX_Tools_CurrentHolderUsername",
                table: "Tools",
                column: "CurrentHolderUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Tools_OwnerUsername",
                table: "Tools",
                column: "OwnerUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Tools_ToolCategoryId",
                table: "Tools",
                column: "ToolCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToolHistories");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "ToolCategories");
        }
    }
}
