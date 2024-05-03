using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DUEGsm.Data.Migrations
{
    public partial class PicProdModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Mobiles_MobilesId",
                table: "OrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_OrderProduct_MobilesId",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "MobilesId",
                table: "OrderProduct");

            migrationBuilder.CreateTable(
                name: "ProductPicture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    MobileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPicture_Mobiles_MobileId",
                        column: x => x.MobileId,
                        principalTable: "Mobiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductID",
                table: "OrderProduct",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPicture_MobileId",
                table: "ProductPicture",
                column: "MobileId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Mobiles_ProductID",
                table: "OrderProduct",
                column: "ProductID",
                principalTable: "Mobiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Mobiles_ProductID",
                table: "OrderProduct");

            migrationBuilder.DropTable(
                name: "ProductPicture");

            migrationBuilder.DropIndex(
                name: "IX_OrderProduct_ProductID",
                table: "OrderProduct");

            migrationBuilder.AddColumn<int>(
                name: "MobilesId",
                table: "OrderProduct",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_MobilesId",
                table: "OrderProduct",
                column: "MobilesId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Mobiles_MobilesId",
                table: "OrderProduct",
                column: "MobilesId",
                principalTable: "Mobiles",
                principalColumn: "Id");
        }
    }
}
