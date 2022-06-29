using Microsoft.EntityFrameworkCore.Migrations;

namespace PTI2_eAutosalloni.Data.Migrations
{
    public partial class VehicleMi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Brands_BrandID",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "BrandID",
                table: "Vehicles",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_BrandID",
                table: "Vehicles",
                newName: "IX_Vehicles_BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Brands_BrandId",
                table: "Vehicles",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Brands_BrandId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Vehicles",
                newName: "BrandID");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_BrandId",
                table: "Vehicles",
                newName: "IX_Vehicles_BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Brands_BrandID",
                table: "Vehicles",
                column: "BrandID",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
