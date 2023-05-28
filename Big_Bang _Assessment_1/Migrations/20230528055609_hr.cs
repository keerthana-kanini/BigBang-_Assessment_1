using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Big_Bang__Assessment_1.Migrations
{
    /// <inheritdoc />
    public partial class hr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    Customer_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Hotel_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hotel_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hotel_Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hotel_Price = table.Column<int>(type: "int", nullable: true),
                    Room_Availability = table.Column<int>(type: "int", nullable: false),
                    Hotel_Amenities = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Hotel_Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Reservation_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "200, 1"),
                    Check_in_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Check_out_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    CustomersCustomer_Id = table.Column<int>(type: "int", nullable: false),
                    Hotel_Id = table.Column<int>(type: "int", nullable: false),
                    hotelsHotel_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Reservation_Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Customers_CustomersCustomer_Id",
                        column: x => x.CustomersCustomer_Id,
                        principalTable: "Customers",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Hotels_hotelsHotel_Id",
                        column: x => x.hotelsHotel_Id,
                        principalTable: "Hotels",
                        principalColumn: "Hotel_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Room_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "300, 1"),
                    Room_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Room_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Room_Capacity = table.Column<int>(type: "int", nullable: true),
                    Room_Availability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hotel_Id = table.Column<int>(type: "int", nullable: false),
                    HotelsHotel_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Room_Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelsHotel_Id",
                        column: x => x.HotelsHotel_Id,
                        principalTable: "Hotels",
                        principalColumn: "Hotel_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "400, 1"),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manage_Room_Availability = table.Column<bool>(type: "bit", nullable: false),
                    Hotel_Id = table.Column<int>(type: "int", nullable: false),
                    HotelsHotel_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staffs_Hotels_HotelsHotel_Id",
                        column: x => x.HotelsHotel_Id,
                        principalTable: "Hotels",
                        principalColumn: "Hotel_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CustomersCustomer_Id",
                table: "Reservation",
                column: "CustomersCustomer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_hotelsHotel_Id",
                table: "Reservation",
                column: "hotelsHotel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelsHotel_Id",
                table: "Rooms",
                column: "HotelsHotel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_HotelsHotel_Id",
                table: "Staffs",
                column: "HotelsHotel_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
