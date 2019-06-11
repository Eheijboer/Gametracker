using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class fixShoperino : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameObjects_Shops_ShopId",
                table: "GameObjects");

            migrationBuilder.DropIndex(
                name: "IX_GameObjects_ShopId",
                table: "GameObjects");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "GameObjects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "GameObjects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameObjects_ShopId",
                table: "GameObjects",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameObjects_Shops_ShopId",
                table: "GameObjects",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
