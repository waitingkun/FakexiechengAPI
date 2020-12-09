using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FakexiechengAPI.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "touristRoutes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1500, nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPresent = table.Column<double>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    DeparttureTime = table.Column<DateTime>(nullable: true),
                    Features = table.Column<string>(nullable: true),
                    Fees = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_touristRoutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "touristRoutePictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(maxLength: 100, nullable: true),
                    TouristRouteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_touristRoutePictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_touristRoutePictures_touristRoutes_TouristRouteId",
                        column: x => x.TouristRouteId,
                        principalTable: "touristRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "touristRoutes",
                columns: new[] { "Id", "CreateTime", "DeparttureTime", "Description", "DiscountPresent", "Features", "Fees", "Notes", "OriginalPrice", "Title", "UpdateTime" },
                values: new object[] { new Guid("80faa3c0-eb77-4c0e-9c09-06e8f3b6d534"), new DateTime(2020, 12, 3, 14, 2, 37, 530, DateTimeKind.Utc).AddTicks(1348), null, "shuoming", null, null, null, null, 0m, "xiechengTitle", null });

            migrationBuilder.CreateIndex(
                name: "IX_touristRoutePictures_TouristRouteId",
                table: "touristRoutePictures",
                column: "TouristRouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "touristRoutePictures");

            migrationBuilder.DropTable(
                name: "touristRoutes");
        }
    }
}
