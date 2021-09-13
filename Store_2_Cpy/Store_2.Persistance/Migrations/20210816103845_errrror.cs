using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store_2.Persistance.Migrations
{
    public partial class errrror : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 644, DateTimeKind.Local).AddTicks(1461),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 896, DateTimeKind.Local).AddTicks(3503));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 643, DateTimeKind.Local).AddTicks(9157),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 896, DateTimeKind.Local).AddTicks(1295));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 643, DateTimeKind.Local).AddTicks(1901),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 895, DateTimeKind.Local).AddTicks(4836));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 643, DateTimeKind.Local).AddTicks(5704),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 895, DateTimeKind.Local).AddTicks(8829));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 642, DateTimeKind.Local).AddTicks(7576),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 895, DateTimeKind.Local).AddTicks(140));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 642, DateTimeKind.Local).AddTicks(4046),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 894, DateTimeKind.Local).AddTicks(3920));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 641, DateTimeKind.Local).AddTicks(3677),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 893, DateTimeKind.Local).AddTicks(2036));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 641, DateTimeKind.Local).AddTicks(7882),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 893, DateTimeKind.Local).AddTicks(5828));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 642, DateTimeKind.Local).AddTicks(1919),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 894, DateTimeKind.Local).AddTicks(119));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 642, DateTimeKind.Local).AddTicks(59),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 893, DateTimeKind.Local).AddTicks(7992));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 629, DateTimeKind.Local).AddTicks(2120),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 883, DateTimeKind.Local).AddTicks(652));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 641, DateTimeKind.Local).AddTicks(422),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 892, DateTimeKind.Local).AddTicks(8577));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 896, DateTimeKind.Local).AddTicks(3503),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 644, DateTimeKind.Local).AddTicks(1461));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 896, DateTimeKind.Local).AddTicks(1295),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 643, DateTimeKind.Local).AddTicks(9157));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 895, DateTimeKind.Local).AddTicks(4836),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 643, DateTimeKind.Local).AddTicks(1901));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 895, DateTimeKind.Local).AddTicks(8829),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 643, DateTimeKind.Local).AddTicks(5704));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 895, DateTimeKind.Local).AddTicks(140),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 642, DateTimeKind.Local).AddTicks(7576));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 894, DateTimeKind.Local).AddTicks(3920),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 642, DateTimeKind.Local).AddTicks(4046));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 893, DateTimeKind.Local).AddTicks(2036),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 641, DateTimeKind.Local).AddTicks(3677));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 893, DateTimeKind.Local).AddTicks(5828),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 641, DateTimeKind.Local).AddTicks(7882));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 894, DateTimeKind.Local).AddTicks(119),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 642, DateTimeKind.Local).AddTicks(1919));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 893, DateTimeKind.Local).AddTicks(7992),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 642, DateTimeKind.Local).AddTicks(59));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 883, DateTimeKind.Local).AddTicks(652),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 629, DateTimeKind.Local).AddTicks(2120));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 16, 3, 3, 56, 892, DateTimeKind.Local).AddTicks(8577),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 16, 15, 8, 44, 641, DateTimeKind.Local).AddTicks(422));
        }
    }
}
