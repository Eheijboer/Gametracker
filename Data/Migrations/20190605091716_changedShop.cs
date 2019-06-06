using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class changedShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameObjectShops_GameObjects_GameObjectId",
                table: "GameObjectShops");

            migrationBuilder.AlterColumn<int>(
                name: "GameObjectId",
                table: "GameObjectShops",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GameObjectShops_GameObjects_GameObjectId",
                table: "GameObjectShops",
                column: "GameObjectId",
                principalTable: "GameObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameObjectShops_GameObjects_GameObjectId",
                table: "GameObjectShops");

            migrationBuilder.AlterColumn<int>(
                name: "GameObjectId",
                table: "GameObjectShops",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_GameObjectShops_GameObjects_GameObjectId",
                table: "GameObjectShops",
                column: "GameObjectId",
                principalTable: "GameObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
