using Microsoft.EntityFrameworkCore.Migrations;

namespace WMS.Migrations
{
    public partial class cascadeDeleteItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_StorageSpaces_StorageSpaceId",
                table: "Items");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_StorageSpaces_StorageSpaceId",
                table: "Items",
                column: "StorageSpaceId",
                principalTable: "StorageSpaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_StorageSpaces_StorageSpaceId",
                table: "Items");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_StorageSpaces_StorageSpaceId",
                table: "Items",
                column: "StorageSpaceId",
                principalTable: "StorageSpaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
