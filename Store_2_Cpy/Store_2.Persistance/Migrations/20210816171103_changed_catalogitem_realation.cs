using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store_2.Persistance.Migrations
{
    public partial class changed_catalogitem_realation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 38, DateTimeKind.Local).AddTicks(1447),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 883, DateTimeKind.Local).AddTicks(1974));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 37, DateTimeKind.Local).AddTicks(5918),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 882, DateTimeKind.Local).AddTicks(8249));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 36, DateTimeKind.Local).AddTicks(5921),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 881, DateTimeKind.Local).AddTicks(5749));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 37, DateTimeKind.Local).AddTicks(521),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 882, DateTimeKind.Local).AddTicks(4719));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 34, DateTimeKind.Local).AddTicks(3619),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 880, DateTimeKind.Local).AddTicks(6785));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 33, DateTimeKind.Local).AddTicks(8333),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 879, DateTimeKind.Local).AddTicks(9952));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 31, DateTimeKind.Local).AddTicks(4351),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 877, DateTimeKind.Local).AddTicks(6420));

            migrationBuilder.AddColumn<int>(
                name: "VisitCount",
                table: "CataLogItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 32, DateTimeKind.Local).AddTicks(3916),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 878, DateTimeKind.Local).AddTicks(3980));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 33, DateTimeKind.Local).AddTicks(1850),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 879, DateTimeKind.Local).AddTicks(5628));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 32, DateTimeKind.Local).AddTicks(8167),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 879, DateTimeKind.Local).AddTicks(2120));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 12, DateTimeKind.Local).AddTicks(8907),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 859, DateTimeKind.Local).AddTicks(7481));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 31, DateTimeKind.Local).AddTicks(378),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 876, DateTimeKind.Local).AddTicks(9849));

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_catalogItemId",
                table: "OrderItems",
                column: "catalogItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_CataLogItems_catalogItemId",
                table: "OrderItems",
                column: "catalogItemId",
                principalTable: "CataLogItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_CataLogItems_catalogItemId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_catalogItemId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "VisitCount",
                table: "CataLogItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 883, DateTimeKind.Local).AddTicks(1974),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 38, DateTimeKind.Local).AddTicks(1447));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 882, DateTimeKind.Local).AddTicks(8249),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 37, DateTimeKind.Local).AddTicks(5918));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 881, DateTimeKind.Local).AddTicks(5749),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 36, DateTimeKind.Local).AddTicks(5921));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 882, DateTimeKind.Local).AddTicks(4719),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 37, DateTimeKind.Local).AddTicks(521));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 880, DateTimeKind.Local).AddTicks(6785),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 34, DateTimeKind.Local).AddTicks(3619));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 879, DateTimeKind.Local).AddTicks(9952),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 33, DateTimeKind.Local).AddTicks(8333));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 877, DateTimeKind.Local).AddTicks(6420),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 31, DateTimeKind.Local).AddTicks(4351));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 878, DateTimeKind.Local).AddTicks(3980),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 32, DateTimeKind.Local).AddTicks(3916));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 879, DateTimeKind.Local).AddTicks(5628),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 33, DateTimeKind.Local).AddTicks(1850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 879, DateTimeKind.Local).AddTicks(2120),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 32, DateTimeKind.Local).AddTicks(8167));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 859, DateTimeKind.Local).AddTicks(7481),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 12, DateTimeKind.Local).AddTicks(8907));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 19, 42, 39, 876, DateTimeKind.Local).AddTicks(9849),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 21, 41, 1, 31, DateTimeKind.Local).AddTicks(378));
        }
    }
}
