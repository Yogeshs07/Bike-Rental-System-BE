using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rental_Services.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authtable",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InsertionDate = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UserName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Password = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Role = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    FileName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    LicenceImageUrl = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    DateOfBirth = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    IsAccept = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authtable", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Bookingtable",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InsertionDate = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    VehicleName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    VehicleNumber = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    VehicleDescription = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PricePerKm = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CustomerName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    MobileNumber = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Source = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Destination = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    TotalDistance = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Status = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    IsActive = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookingtable", x => x.BookingID);
                });

            migrationBuilder.CreateTable(
                name: "Hubtable",
                columns: table => new
                {
                    HubID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InsertionDate = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    HubName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hubtable", x => x.HubID);
                });

            migrationBuilder.CreateTable(
                name: "Vehicletable",
                columns: table => new
                {
                    VehicleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InsertionDate = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    VehicleName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    VehicleNumber = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    VehicleDescription = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicletable", x => x.VehicleID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authtable");

            migrationBuilder.DropTable(
                name: "Bookingtable");

            migrationBuilder.DropTable(
                name: "Hubtable");

            migrationBuilder.DropTable(
                name: "Vehicletable");
        }
    }
}
