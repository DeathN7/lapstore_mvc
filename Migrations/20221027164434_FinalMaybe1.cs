using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testmvc.Migrations
{
    public partial class FinalMaybe1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ammount",
                table: "OrdersDetails",
                newName: "TotalMoney");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "OrdersDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "OrdersDetails",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "OrdersDetails",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "OrdersDetails");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "OrdersDetails");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrdersDetails");

            migrationBuilder.RenameColumn(
                name: "TotalMoney",
                table: "OrdersDetails",
                newName: "Ammount");
        }
    }
}
