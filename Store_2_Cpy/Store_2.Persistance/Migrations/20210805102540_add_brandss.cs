using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store_2.Persistance.Migrations
{
    public partial class add_brandss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 5, 14, 55, 38, 927, DateTimeKind.Local).AddTicks(9385),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 3, 22, 18, 59, 476, DateTimeKind.Local).AddTicks(1442));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 5, 14, 55, 38, 927, DateTimeKind.Local).AddTicks(6612),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 3, 22, 18, 59, 459, DateTimeKind.Local).AddTicks(4378));

            migrationBuilder.CreateTable(
                name: "CataLogItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CatalogTypeId = table.Column<int>(type: "int", nullable: false),
                    CatalogBrandId = table.Column<int>(type: "int", nullable: true),
                    AvailableStock = table.Column<int>(type: "int", nullable: false),
                    RestockThershold = table.Column<int>(type: "int", nullable: false),
                    MaxStockThresjold = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 8, 5, 14, 55, 38, 909, DateTimeKind.Local).AddTicks(1770)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemovedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CataLogItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CataLogItems_CatalogBrand_CatalogBrandId",
                        column: x => x.CatalogBrandId,
                        principalTable: "CatalogBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CataLogItems_CatalogType_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalTable: "CatalogType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CataLogItemFeature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CataLogItemId = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 8, 5, 14, 55, 38, 927, DateTimeKind.Local).AddTicks(3960)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemovedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CataLogItemFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CataLogItemFeature_CataLogItems_CataLogItemId",
                        column: x => x.CataLogItemId,
                        principalTable: "CataLogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItemImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CataLogItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItemImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogItemImage_CataLogItems_CataLogItemId",
                        column: x => x.CataLogItemId,
                        principalTable: "CataLogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CatalogBrand",
                columns: new[] { "Id", "Brand", "RemovedTime", "UpdateTime" },
                values: new object[,]
                {
                    { 44, "Samsung", null, null },
                    { 45, "Xiaomi", null, null },
                    { 46, "Apple", null, null },
                    { 47, "Huawei", null, null },
                    { 48, "Nokia", null, null }
                });

            migrationBuilder.InsertData(
                table: "CatalogType",
                columns: new[] { "Id", "ParentCatalogTypeId", "RemovedTime", "Type", "UpdateTime" },
                values: new object[] { 10067, 10003, null, "Phone", null });

            migrationBuilder.CreateIndex(
                name: "IX_CataLogItemFeature_CataLogItemId",
                table: "CataLogItemFeature",
                column: "CataLogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItemImage_CataLogItemId",
                table: "CatalogItemImage",
                column: "CataLogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CataLogItems_CatalogBrandId",
                table: "CataLogItems",
                column: "CatalogBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CataLogItems_CatalogTypeId",
                table: "CataLogItems",
                column: "CatalogTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CataLogItemFeature");

            migrationBuilder.DropTable(
                name: "CatalogItemImage");

            migrationBuilder.DropTable(
                name: "CataLogItems");

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 10067);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 22, 18, 59, 476, DateTimeKind.Local).AddTicks(1442),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 5, 14, 55, 38, 927, DateTimeKind.Local).AddTicks(9385));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 22, 18, 59, 459, DateTimeKind.Local).AddTicks(4378),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 5, 14, 55, 38, 927, DateTimeKind.Local).AddTicks(6612));

            migrationBuilder.InsertData(
                table: "CatalogBrand",
                columns: new[] { "Id", "Brand", "RemovedTime", "UpdateTime" },
                values: new object[,]
                {
                    { 1, "Samsung", null, null },
                    { 2, "Xiaomi", null, null },
                    { 3, "Apple", null, null },
                    { 4, "Huawei", null, null },
                    { 5, "Nokia", null, null }
                });
        }
    }
}
