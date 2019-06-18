using Microsoft.EntityFrameworkCore.Migrations;

namespace WMS.Migrations
{
    public partial class revokeprevious : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_StorageSpaces_StorageSpaceId1",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_StorageSpaceId1",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "StorageSpaceId1",
                table: "Requests");

            migrationBuilder.AlterColumn<string>(
                name: "StorageSpaceId",
                table: "Requests",
                nullable: true,
                oldClrType: typeof(int));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_StorageSpaces_StorageSpaceId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_StorageSpaceId",
                table: "Requests");

            migrationBuilder.AlterColumn<int>(
                name: "StorageSpaceId",
                table: "Requests",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StorageSpaceId1",
                table: "Requests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StorageSpaceId1",
                table: "Requests",
                column: "StorageSpaceId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_StorageSpaces_StorageSpaceId1",
                table: "Requests",
                column: "StorageSpaceId1",
                principalTable: "StorageSpaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
