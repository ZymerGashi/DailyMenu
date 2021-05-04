using Microsoft.EntityFrameworkCore.Migrations;

namespace DailyMenu.DataAccess.Migrations
{
    public partial class AddBusiness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true),
                    MapPositionCoordinates = table.Column<string>(nullable: true),
                    MenuId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Business_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Business_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Business_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Business_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Business_CategoryId",
                table: "Business",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_CityId",
                table: "Business",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_MenuId",
                table: "Business",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_OwnerId",
                table: "Business",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Business");
        }
    }
}
