using Microsoft.EntityFrameworkCore.Migrations;

namespace WMS.Migrations
{
    public partial class BindStorageSpaceToRequest : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "StorageSpaceId",
                table: "Requests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StorageSpaceId",
                table: "Requests",
                column: "StorageSpaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_StorageSpaces_StorageSpaceId",
                table: "Requests",
                column: "StorageSpaceId",
                principalTable: "StorageSpaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Requests_StorageSpaces_StorageSpaceId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_StorageSpaces_Warehouses_Name",
                table: "StorageSpaces");

            migrationBuilder.DropIndex(
                name: "IX_Requests_StorageSpaceId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "StorageSpaceId",
                table: "Requests");

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
