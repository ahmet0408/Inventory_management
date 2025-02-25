using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory_management.dal.Migrations
{
    public partial class Rent1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rent_Employee_EmployeeId",
                table: "Rent");

            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "RentDetail");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Rent",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Rent_Employee_EmployeeId",
                table: "Rent",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rent_Employee_EmployeeId",
                table: "Rent");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "RentDetail",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Rent",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rent_Employee_EmployeeId",
                table: "Rent",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
