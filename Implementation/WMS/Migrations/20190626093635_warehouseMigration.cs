using Microsoft.EntityFrameworkCore.Migrations;

namespace WMS.Migrations
{
    public partial class warehouseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Warehouses",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "WarehouseId",
                table: "Warehouses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "UsedUp",
                table: "Warehouses",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "UsedUp",
                table: "Warehouses");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Warehouses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses",
                column: "Name");
        }
    }
}
