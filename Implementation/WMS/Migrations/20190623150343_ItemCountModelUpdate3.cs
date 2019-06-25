using Microsoft.EntityFrameworkCore.Migrations;

namespace WMS.Migrations
{
    public partial class ItemCountModelUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCounts_Requests_RequestId1",
                table: "ItemCounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemCounts",
                table: "ItemCounts");

            migrationBuilder.RenameColumn(
                name: "RequestId1",
                table: "ItemCounts",
                newName: "ItemUPC");

            migrationBuilder.RenameIndex(
                name: "IX_ItemCounts_RequestId1",
                table: "ItemCounts",
                newName: "IX_ItemCounts_ItemUPC");

            migrationBuilder.AlterColumn<string>(
                name: "RequestId",
                table: "ItemCounts",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "ItemCounts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "ItemCounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemCounts",
                table: "ItemCounts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCounts_RequestId",
                table: "ItemCounts",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCounts_ItemDetails_ItemUPC",
                table: "ItemCounts",
                column: "ItemUPC",
                principalTable: "ItemDetails",
                principalColumn: "UPC",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCounts_Requests_RequestId",
                table: "ItemCounts",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCounts_ItemDetails_ItemUPC",
                table: "ItemCounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemCounts_Requests_RequestId",
                table: "ItemCounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemCounts",
                table: "ItemCounts");

            migrationBuilder.DropIndex(
                name: "IX_ItemCounts_RequestId",
                table: "ItemCounts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ItemCounts");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "ItemCounts");

            migrationBuilder.RenameColumn(
                name: "ItemUPC",
                table: "ItemCounts",
                newName: "RequestId1");

            migrationBuilder.RenameIndex(
                name: "IX_ItemCounts_ItemUPC",
                table: "ItemCounts",
                newName: "IX_ItemCounts_RequestId1");

            migrationBuilder.AlterColumn<string>(
                name: "RequestId",
                table: "ItemCounts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemCounts",
                table: "ItemCounts",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCounts_Requests_RequestId1",
                table: "ItemCounts",
                column: "RequestId1",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
