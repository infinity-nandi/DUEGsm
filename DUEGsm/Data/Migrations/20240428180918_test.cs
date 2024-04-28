using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DUEGsm.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MobileId",
                table: "Mobiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_MobileId",
                table: "Mobiles",
                column: "MobileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mobiles_Mobiles_MobileId",
                table: "Mobiles",
                column: "MobileId",
                principalTable: "Mobiles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mobiles_Mobiles_MobileId",
                table: "Mobiles");

            migrationBuilder.DropIndex(
                name: "IX_Mobiles_MobileId",
                table: "Mobiles");

            migrationBuilder.DropColumn(
                name: "MobileId",
                table: "Mobiles");
        }
    }
}
