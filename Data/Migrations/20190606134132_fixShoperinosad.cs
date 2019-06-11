using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class fixShoperinosad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
