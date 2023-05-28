using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Big_Bang__Assessment_1.Migrations
{
    /// <inheritdoc />
    public partial class bb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Customers_CustomersCustomer_Id",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Hotels_hotelsHotel_Id",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_hotelsHotel_Id",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "hotelsHotel_Id",
                table: "Reservation");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "Reservations");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_CustomersCustomer_Id",
                table: "Reservations",
                newName: "IX_Reservations_CustomersCustomer_Id");

            migrationBuilder.AlterColumn<int>(
                name: "CustomersCustomer_Id",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Customer_Id",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Hotel_Id",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Reservation_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Hotel_Id",
                table: "Reservations",
                column: "Hotel_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_CustomersCustomer_Id",
                table: "Reservations",
                column: "CustomersCustomer_Id",
                principalTable: "Customers",
                principalColumn: "Customer_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Hotels_Hotel_Id",
                table: "Reservations",
                column: "Hotel_Id",
                principalTable: "Hotels",
                principalColumn: "Hotel_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_CustomersCustomer_Id",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Hotels_Hotel_Id",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_Hotel_Id",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Customer_Id",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Hotel_Id",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservation");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_CustomersCustomer_Id",
                table: "Reservation",
                newName: "IX_Reservation_CustomersCustomer_Id");

            migrationBuilder.AlterColumn<int>(
                name: "CustomersCustomer_Id",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "hotelsHotel_Id",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "Reservation_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_hotelsHotel_Id",
                table: "Reservation",
                column: "hotelsHotel_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Customers_CustomersCustomer_Id",
                table: "Reservation",
                column: "CustomersCustomer_Id",
                principalTable: "Customers",
                principalColumn: "Customer_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Hotels_hotelsHotel_Id",
                table: "Reservation",
                column: "hotelsHotel_Id",
                principalTable: "Hotels",
                principalColumn: "Hotel_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
