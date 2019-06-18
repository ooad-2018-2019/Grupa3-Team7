using Microsoft.EntityFrameworkCore.Migrations;

namespace WMS.Migrations
{
    public partial class StorageSpaceModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "StorageSpaces",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "StorageSpaces");
        }
    }
}
