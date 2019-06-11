using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class fixShoperinosadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_GameObjects_GameObjectId",
                table: "Shops");

            migrationBuilder.DropIndex(
                name: "IX_Shops_GameObjectId",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "GameObjectId",
                table: "Shops");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "GameObjectId",
                table: "Shops",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shops_GameObjectId",
                table: "Shops",
                column: "GameObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_GameObjects_GameObjectId",
                table: "Shops",
                column: "GameObjectId",
                principalTable: "GameObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
