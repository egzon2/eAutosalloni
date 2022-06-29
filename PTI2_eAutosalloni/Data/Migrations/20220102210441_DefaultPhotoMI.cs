using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PTI2_eAutosalloni.Data.Migrations
{
    public partial class DefaultPhotoMI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "DefaultImage",
                table: "Vehicles",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "DefaultImage",
                table: "Vehicles");
        }
    }
}
