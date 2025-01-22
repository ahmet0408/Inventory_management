using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory_management.dal.Migrations
{
    public partial class Depart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LanguageCulture",
                table: "DepartmentTranslate",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageCulture",
                table: "DepartmentTranslate");
        }
    }
}
