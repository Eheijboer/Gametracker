using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class shortname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Shortname",
                table: "Devices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shortname",
                table: "Devices");
        }
    }
}
