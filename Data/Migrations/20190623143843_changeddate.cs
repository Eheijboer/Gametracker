using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class changeddate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoughtDate",
                table: "GameObjects");

            migrationBuilder.DropColumn(
                name: "BoughtFor",
                table: "GameObjects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoughtDate",
                table: "GameObjects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BoughtFor",
                table: "GameObjects",
                nullable: false,
                defaultValue: 0);
        }
    }
}
