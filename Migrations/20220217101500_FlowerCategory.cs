using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_MDP.Migrations
{
    public partial class FlowerCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SellerID",
                table: "Flower",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FlowerCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowerID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FlowerCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlowerCategory_Flower_FlowerID",
                        column: x => x.FlowerID,
                        principalTable: "Flower",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flower_SellerID",
                table: "Flower",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerCategory_CategoryID",
                table: "FlowerCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerCategory_FlowerID",
                table: "FlowerCategory",
                column: "FlowerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Flower_Seller_SellerID",
                table: "Flower",
                column: "SellerID",
                principalTable: "Seller",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flower_Seller_SellerID",
                table: "Flower");

            migrationBuilder.DropTable(
                name: "FlowerCategory");

            migrationBuilder.DropTable(
                name: "Seller");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Flower_SellerID",
                table: "Flower");

            migrationBuilder.DropColumn(
                name: "SellerID",
                table: "Flower");
        }
    }
}
