using Microsoft.EntityFrameworkCore.Migrations;

namespace Rental_Services.Migrations
{
    public partial class Seven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BikeCompany",
                table: "Vehicletable",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BikeCompany",
                table: "Vehicletable");
        }
    }
}
