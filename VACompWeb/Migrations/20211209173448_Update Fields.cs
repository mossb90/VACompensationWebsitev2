using Microsoft.EntityFrameworkCore.Migrations;

namespace VACompWeb.Migrations
{
    public partial class UpdateFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyComp",
                table: "AspNetUsers",
                type: "decimal(38,17)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthlyComp",
                table: "AspNetUsers");
        }
    }
}
