using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WMS.Migrations
{
    public partial class ItemCountModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCounts_Requests_RequestId",
                table: "ItemCounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemCounts",
                table: "ItemCounts");

            migrationBuilder.DropIndex(
                name: "IX_ItemCounts_RequestId",
                table: "ItemCounts");

            migrationBuilder.AlterColumn<string>(
                name: "RequestId",
                table: "ItemCounts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "ItemCounts",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "RequestId1",
                table: "ItemCounts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemCounts",
                table: "ItemCounts",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCounts_RequestId1",
                table: "ItemCounts",
                column: "RequestId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCounts_Requests_RequestId1",
                table: "ItemCounts",
                column: "RequestId1",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCounts_Requests_RequestId1",
                table: "ItemCounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemCounts",
                table: "ItemCounts");

            migrationBuilder.DropIndex(
                name: "IX_ItemCounts_RequestId1",
                table: "ItemCounts");

            migrationBuilder.DropColumn(
                name: "RequestId1",
                table: "ItemCounts");

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "ItemCounts",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "RequestId",
                table: "ItemCounts",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemCounts",
                table: "ItemCounts",
                column: "Count");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCounts_RequestId",
                table: "ItemCounts",
                column: "RequestId");

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
