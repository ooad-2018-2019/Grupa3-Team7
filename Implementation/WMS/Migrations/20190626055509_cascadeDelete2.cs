using Microsoft.EntityFrameworkCore.Migrations;

namespace WMS.Migrations
{
    public partial class cascadeDelete2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCounts_Requests_RequestId",
                table: "ItemCounts");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCounts_Requests_RequestId",
                table: "ItemCounts",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCounts_Requests_RequestId",
                table: "ItemCounts");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCounts_Requests_RequestId",
                table: "ItemCounts",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
