using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testmvc.Migrations
{
    public partial class AddHomeFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HomeFlag",
                table: "Products",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeFlag",
                table: "Products");
        }
    }
}
