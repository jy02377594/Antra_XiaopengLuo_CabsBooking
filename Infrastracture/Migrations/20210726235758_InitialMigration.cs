using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastracture.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CabTypes",
                columns: table => new
                {
                    CabTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabTypeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabTypes", x => x.CabTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    PlaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.PlaceId);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingTime = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    FromPlace = table.Column<int>(type: "int", nullable: false),
                    ToPlace = table.Column<int>(type: "int", nullable: false),
                    PickupAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Landmark = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickupTime = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CabTypeId = table.Column<int>(type: "int", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PlacesPlaceId = table.Column<int>(type: "int", nullable: true),
                    CabTypesCabTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bookings_CabTypes_CabTypesCabTypeId",
                        column: x => x.CabTypesCabTypeId,
                        principalTable: "CabTypes",
                        principalColumn: "CabTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Places_PlacesPlaceId",
                        column: x => x.PlacesPlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookingsHistory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingTime = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    FromPlace = table.Column<int>(type: "int", nullable: false),
                    ToPlace = table.Column<int>(type: "int", nullable: false),
                    PickupAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Landmark = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PickupTime = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CabTypeId = table.Column<int>(type: "int", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Comp_time = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Charge = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PlacesPlaceId = table.Column<int>(type: "int", nullable: true),
                    CabTypesCabTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingsHistory", x => x.id);
                    table.ForeignKey(
                        name: "FK_BookingsHistory_CabTypes_CabTypesCabTypeId",
                        column: x => x.CabTypesCabTypeId,
                        principalTable: "CabTypes",
                        principalColumn: "CabTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingsHistory_Places_PlacesPlaceId",
                        column: x => x.PlacesPlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CabTypesCabTypeId",
                table: "Bookings",
                column: "CabTypesCabTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PlacesPlaceId",
                table: "Bookings",
                column: "PlacesPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingsHistory_CabTypesCabTypeId",
                table: "BookingsHistory",
                column: "CabTypesCabTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingsHistory_PlacesPlaceId",
                table: "BookingsHistory",
                column: "PlacesPlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "BookingsHistory");

            migrationBuilder.DropTable(
                name: "CabTypes");

            migrationBuilder.DropTable(
                name: "Places");
        }
    }
}
