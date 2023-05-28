using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Big_Bang__Assessment_1.Migrations
{
    /// <inheritdoc />
    public partial class bb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotels_HotelsHotel_Id",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Hotels_HotelsHotel_Id",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Hotel_Id",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Customer_Id",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Hotel_Id",
                table: "Reservation");

            migrationBuilder.AlterColumn<int>(
                name: "HotelsHotel_Id",
                table: "Staffs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HotelsHotel_Id",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hotels_HotelsHotel_Id",
                table: "Rooms",
                column: "HotelsHotel_Id",
                principalTable: "Hotels",
                principalColumn: "Hotel_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Hotels_HotelsHotel_Id",
                table: "Staffs",
                column: "HotelsHotel_Id",
                principalTable: "Hotels",
                principalColumn: "Hotel_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotels_HotelsHotel_Id",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Hotels_HotelsHotel_Id",
                table: "Staffs");

            migrationBuilder.AlterColumn<int>(
                name: "HotelsHotel_Id",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Hotel_Id",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "HotelsHotel_Id",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Customer_Id",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Hotel_Id",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hotels_HotelsHotel_Id",
                table: "Rooms",
                column: "HotelsHotel_Id",
                principalTable: "Hotels",
                principalColumn: "Hotel_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Hotels_HotelsHotel_Id",
                table: "Staffs",
                column: "HotelsHotel_Id",
                principalTable: "Hotels",
                principalColumn: "Hotel_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
