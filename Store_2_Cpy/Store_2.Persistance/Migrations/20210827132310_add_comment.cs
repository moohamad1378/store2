using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store_2.Persistance.Migrations
{
    public partial class add_comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CatalogBrands",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "CatalogBrands",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "CatalogBrands",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "CatalogBrands",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "CatalogBrands",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "CatalogTypes",
                keyColumn: "Id",
                keyValue: 10005);

            migrationBuilder.DeleteData(
                table: "CatalogTypes",
                keyColumn: "Id",
                keyValue: 10006);

            migrationBuilder.DeleteData(
                table: "CatalogTypes",
                keyColumn: "Id",
                keyValue: 10007);

            migrationBuilder.DeleteData(
                table: "CatalogTypes",
                keyColumn: "Id",
                keyValue: 10067);

            migrationBuilder.DeleteData(
                table: "CatalogTypes",
                keyColumn: "Id",
                keyValue: 10004);

            migrationBuilder.DeleteData(
                table: "CatalogTypes",
                keyColumn: "Id",
                keyValue: 10003);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 549, DateTimeKind.Local).AddTicks(4086),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 723, DateTimeKind.Local).AddTicks(729));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 549, DateTimeKind.Local).AddTicks(2044),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 722, DateTimeKind.Local).AddTicks(7676));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 548, DateTimeKind.Local).AddTicks(5515),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 721, DateTimeKind.Local).AddTicks(9985));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 548, DateTimeKind.Local).AddTicks(9614),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 722, DateTimeKind.Local).AddTicks(4801));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 548, DateTimeKind.Local).AddTicks(917),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 721, DateTimeKind.Local).AddTicks(1169));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 547, DateTimeKind.Local).AddTicks(7799),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 720, DateTimeKind.Local).AddTicks(5352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 546, DateTimeKind.Local).AddTicks(1895),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 719, DateTimeKind.Local).AddTicks(3168));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItemFeatures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 546, DateTimeKind.Local).AddTicks(8352),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 719, DateTimeKind.Local).AddTicks(8232));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 547, DateTimeKind.Local).AddTicks(5436),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 720, DateTimeKind.Local).AddTicks(2976));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 547, DateTimeKind.Local).AddTicks(533),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 720, DateTimeKind.Local).AddTicks(889));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 534, DateTimeKind.Local).AddTicks(6873),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 704, DateTimeKind.Local).AddTicks(313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 545, DateTimeKind.Local).AddTicks(8475),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 718, DateTimeKind.Local).AddTicks(8679));

            migrationBuilder.CreateTable(
                name: "CatalogItemComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cataLogItemId = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 547, DateTimeKind.Local).AddTicks(2701)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemovedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItemComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogItemComments_CataLogItems_cataLogItemId",
                        column: x => x.cataLogItemId,
                        principalTable: "CataLogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItemComments_cataLogItemId",
                table: "CatalogItemComments",
                column: "cataLogItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogItemComments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 723, DateTimeKind.Local).AddTicks(729),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 549, DateTimeKind.Local).AddTicks(4086));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 722, DateTimeKind.Local).AddTicks(7676),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 549, DateTimeKind.Local).AddTicks(2044));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 721, DateTimeKind.Local).AddTicks(9985),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 548, DateTimeKind.Local).AddTicks(5515));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 722, DateTimeKind.Local).AddTicks(4801),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 548, DateTimeKind.Local).AddTicks(9614));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 721, DateTimeKind.Local).AddTicks(1169),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 548, DateTimeKind.Local).AddTicks(917));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 720, DateTimeKind.Local).AddTicks(5352),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 547, DateTimeKind.Local).AddTicks(7799));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 719, DateTimeKind.Local).AddTicks(3168),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 546, DateTimeKind.Local).AddTicks(1895));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItemFeatures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 719, DateTimeKind.Local).AddTicks(8232),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 546, DateTimeKind.Local).AddTicks(8352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 720, DateTimeKind.Local).AddTicks(2976),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 547, DateTimeKind.Local).AddTicks(5436));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 720, DateTimeKind.Local).AddTicks(889),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 547, DateTimeKind.Local).AddTicks(533));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 704, DateTimeKind.Local).AddTicks(313),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 534, DateTimeKind.Local).AddTicks(6873));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 25, 18, 19, 10, 718, DateTimeKind.Local).AddTicks(8679),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 27, 17, 53, 7, 545, DateTimeKind.Local).AddTicks(8475));

            migrationBuilder.InsertData(
                table: "CatalogBrands",
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
                table: "CatalogTypes",
                columns: new[] { "Id", "ParentCatalogTypeId", "RemovedTime", "Type", "UpdateTime" },
                values: new object[] { 10003, null, null, "Digital goods", null });

            migrationBuilder.InsertData(
                table: "CatalogTypes",
                columns: new[] { "Id", "ParentCatalogTypeId", "RemovedTime", "Type", "UpdateTime" },
                values: new object[] { 10004, 10003, null, "Phone accessories", null });

            migrationBuilder.InsertData(
                table: "CatalogTypes",
                columns: new[] { "Id", "ParentCatalogTypeId", "RemovedTime", "Type", "UpdateTime" },
                values: new object[] { 10067, 10003, null, "Phone", null });

            migrationBuilder.InsertData(
                table: "CatalogTypes",
                columns: new[] { "Id", "ParentCatalogTypeId", "RemovedTime", "Type", "UpdateTime" },
                values: new object[] { 10005, 10004, null, "Phone holder base", null });

            migrationBuilder.InsertData(
                table: "CatalogTypes",
                columns: new[] { "Id", "ParentCatalogTypeId", "RemovedTime", "Type", "UpdateTime" },
                values: new object[] { 10006, 10004, null, "Mobile charger power bank", null });

            migrationBuilder.InsertData(
                table: "CatalogTypes",
                columns: new[] { "Id", "ParentCatalogTypeId", "RemovedTime", "Type", "UpdateTime" },
                values: new object[] { 10007, 10004, null, "Phone case and cover", null });
        }
    }
}
