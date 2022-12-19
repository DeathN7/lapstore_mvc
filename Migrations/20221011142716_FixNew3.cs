using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testmvc.Migrations
{
    public partial class FixNew3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Accounts_AccountID",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_AccountID",
                table: "News");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "News");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "News",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_AccountID",
                table: "News",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Accounts_AccountID",
                table: "News",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID");
        }
    }
}
