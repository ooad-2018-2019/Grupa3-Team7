using Microsoft.EntityFrameworkCore.Migrations;

namespace WMS.Migrations
{
    public partial class storageSpaceMod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageSpaces_Warehouses_WarehouseName",
                table: "StorageSpaces");

            migrationBuilder.RenameColumn(
                name: "WarehouseName",
                table: "StorageSpaces",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_StorageSpaces_WarehouseName",
                table: "StorageSpaces",
                newName: "IX_StorageSpaces_Name");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageSpaces_Warehouses_Name",
                table: "StorageSpaces",
                column: "Name",
                principalTable: "Warehouses",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageSpaces_Warehouses_Name",
                table: "StorageSpaces");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "StorageSpaces",
                newName: "WarehouseName");

            migrationBuilder.RenameIndex(
                name: "IX_StorageSpaces_Name",
                table: "StorageSpaces",
                newName: "IX_StorageSpaces_WarehouseName");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageSpaces_Warehouses_WarehouseName",
                table: "StorageSpaces",
                column: "WarehouseName",
                principalTable: "Warehouses",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
