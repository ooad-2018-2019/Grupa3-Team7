using Microsoft.EntityFrameworkCore.Migrations;

namespace WMS.Migrations
{
    public partial class storageSpaceRequiredInRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_StorageSpaces_StorageSpaceId",
                table: "Requests");

            migrationBuilder.AlterColumn<string>(
                name: "StorageSpaceId",
                table: "Requests",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_StorageSpaces_StorageSpaceId",
                table: "Requests",
                column: "StorageSpaceId",
                principalTable: "StorageSpaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_StorageSpaces_StorageSpaceId",
                table: "Requests");

            migrationBuilder.AlterColumn<string>(
                name: "StorageSpaceId",
                table: "Requests",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_StorageSpaces_StorageSpaceId",
                table: "Requests",
                column: "StorageSpaceId",
                principalTable: "StorageSpaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
