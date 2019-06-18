using Microsoft.EntityFrameworkCore.Migrations;

namespace WMS.Migrations
{
    public partial class updatedStorageSpaceModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageSpaces_Warehouses_Name",
                table: "StorageSpaces");

            migrationBuilder.DropIndex(
                name: "IX_StorageSpaces_Name",
                table: "StorageSpaces");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StorageSpaces",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StorageSpaces",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StorageSpaces_Name",
                table: "StorageSpaces",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageSpaces_Warehouses_Name",
                table: "StorageSpaces",
                column: "Name",
                principalTable: "Warehouses",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
