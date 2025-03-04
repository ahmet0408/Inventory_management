using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory_management.dal.Migrations
{
    public partial class Produc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mark",
                table: "Rent",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "Product",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Product",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mark",
                table: "Rent");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Product");
        }
    }
}
