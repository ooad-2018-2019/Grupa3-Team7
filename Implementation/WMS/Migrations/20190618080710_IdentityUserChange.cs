using Microsoft.EntityFrameworkCore.Migrations;

namespace WMS.Migrations
{
    public partial class IdentityUserChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Firms_AspNetUsers_IdentityUserId",
                table: "Firms");

            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "Firms",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Firms_IdentityUserId",
                table: "Firms",
                newName: "IX_Firms_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Firms_AspNetUsers_UserId",
                table: "Firms",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Firms_AspNetUsers_UserId",
                table: "Firms");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Firms",
                newName: "IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Firms_UserId",
                table: "Firms",
                newName: "IX_Firms_IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Firms_AspNetUsers_IdentityUserId",
                table: "Firms",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
