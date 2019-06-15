using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WMS.Migrations
{
    public partial class addedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firms",
                columns: table => new
                {
                    FirmName = table.Column<string>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firms", x => x.FirmName);
                    table.ForeignKey(
                        name: "FK_Firms_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemDetails",
                columns: table => new
                {
                    UPC = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Volume = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImageURI = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDetails", x => x.UPC);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Capacity = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    FirmName = table.Column<string>(nullable: true),
                    Processed = table.Column<bool>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Firms_FirmName",
                        column: x => x.FirmName,
                        principalTable: "Firms",
                        principalColumn: "FirmName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StorageSpaces",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Capacity = table.Column<double>(nullable: false),
                    Firm = table.Column<string>(nullable: true),
                    FirmName = table.Column<string>(nullable: true),
                    WarehouseName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageSpaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageSpaces_AspNetUsers_Firm",
                        column: x => x.Firm,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StorageSpaces_Firms_FirmName",
                        column: x => x.FirmName,
                        principalTable: "Firms",
                        principalColumn: "FirmName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StorageSpaces_Warehouses_WarehouseName",
                        column: x => x.WarehouseName,
                        principalTable: "Warehouses",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemCounts",
                columns: table => new
                {
                    Count = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemUPC = table.Column<string>(nullable: true),
                    RequestId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCounts", x => x.Count);
                    table.ForeignKey(
                        name: "FK_ItemCounts_ItemDetails_ItemUPC",
                        column: x => x.ItemUPC,
                        principalTable: "ItemDetails",
                        principalColumn: "UPC",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemCounts_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ItemDetailsUPC = table.Column<string>(nullable: true),
                    StorageSpaceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemDetails_ItemDetailsUPC",
                        column: x => x.ItemDetailsUPC,
                        principalTable: "ItemDetails",
                        principalColumn: "UPC",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_StorageSpaces_StorageSpaceId",
                        column: x => x.StorageSpaceId,
                        principalTable: "StorageSpaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Firms_IdentityUserId",
                table: "Firms",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCounts_ItemUPC",
                table: "ItemCounts",
                column: "ItemUPC");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCounts_RequestId",
                table: "ItemCounts",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemDetailsUPC",
                table: "Items",
                column: "ItemDetailsUPC");

            migrationBuilder.CreateIndex(
                name: "IX_Items_StorageSpaceId",
                table: "Items",
                column: "StorageSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_FirmName",
                table: "Requests",
                column: "FirmName");

            migrationBuilder.CreateIndex(
                name: "IX_StorageSpaces_Firm",
                table: "StorageSpaces",
                column: "Firm");

            migrationBuilder.CreateIndex(
                name: "IX_StorageSpaces_FirmName",
                table: "StorageSpaces",
                column: "FirmName");

            migrationBuilder.CreateIndex(
                name: "IX_StorageSpaces_WarehouseName",
                table: "StorageSpaces",
                column: "WarehouseName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCounts");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "ItemDetails");

            migrationBuilder.DropTable(
                name: "StorageSpaces");

            migrationBuilder.DropTable(
                name: "Firms");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
