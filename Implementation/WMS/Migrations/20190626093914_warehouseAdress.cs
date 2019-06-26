using Microsoft.EntityFrameworkCore.Migrations;

namespace WMS.Migrations
{
    public partial class warehouseAdress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Warehouses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Warehouses");
        }
    }
}
