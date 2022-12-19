using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testmvc.Migrations
{
    public partial class fixod4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrdersDetails_ProductID",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDetails_ProductID",
                table: "OrdersDetails",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersDetails_Products_ProductID",
                table: "OrdersDetails",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersDetails_Products_ProductID",
                table: "OrdersDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrdersDetails_ProductID",
                table: "OrdersDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrdersDetails_ProductID",
                table: "Products",
                column: "ProductID",
                principalTable: "OrdersDetails",
                principalColumn: "OrderDetailID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
