using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testmvc.Migrations
{
    public partial class FinalMaybe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrdersDetails",
                newName: "Ammount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ammount",
                table: "OrdersDetails",
                newName: "Quantity");
        }
    }
}
