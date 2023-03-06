using Microsoft.EntityFrameworkCore.Migrations;

namespace Rental_Services.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Source",
                table: "Bookingtable",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Destination",
                table: "Bookingtable",
                newName: "Hub");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Bookingtable",
                newName: "EmailID");

            migrationBuilder.AddColumn<string>(
                name: "BookingDate",
                table: "Bookingtable",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "Bookingtable");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Bookingtable",
                newName: "Source");

            migrationBuilder.RenameColumn(
                name: "Hub",
                table: "Bookingtable",
                newName: "Destination");

            migrationBuilder.RenameColumn(
                name: "EmailID",
                table: "Bookingtable",
                newName: "CustomerName");
        }
    }
}
