using Microsoft.EntityFrameworkCore.Migrations;

namespace WMS.Migrations
{
    public partial class ItemCountModelUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCounts_ItemDetails_ItemUPC",
                table: "ItemCounts");

            migrationBuilder.DropIndex(
                name: "IX_ItemCounts_ItemUPC",
                table: "ItemCounts");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "ItemCounts");

            migrationBuilder.DropColumn(
                name: "ItemUPC",
                table: "ItemCounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "ItemCounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ItemUPC",
                table: "ItemCounts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemCounts_ItemUPC",
                table: "ItemCounts",
                column: "ItemUPC");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCounts_ItemDetails_ItemUPC",
                table: "ItemCounts",
                column: "ItemUPC",
                principalTable: "ItemDetails",
                principalColumn: "UPC",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
