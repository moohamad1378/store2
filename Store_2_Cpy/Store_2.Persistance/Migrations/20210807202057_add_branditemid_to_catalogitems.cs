using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store_2.Persistance.Migrations
{
    public partial class add_branditemid_to_catalogitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CataLogItems_CatalogBrand_CatalogBrandId",
                table: "CataLogItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 8, 0, 50, 56, 279, DateTimeKind.Local).AddTicks(5192),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 7, 18, 7, 50, 303, DateTimeKind.Local).AddTicks(141));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 8, 0, 50, 56, 278, DateTimeKind.Local).AddTicks(902),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 7, 18, 7, 50, 302, DateTimeKind.Local).AddTicks(1660));

            migrationBuilder.AlterColumn<int>(
                name: "CatalogBrandId",
                table: "CataLogItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 8, 0, 50, 56, 278, DateTimeKind.Local).AddTicks(7035),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 7, 18, 7, 50, 302, DateTimeKind.Local).AddTicks(5352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 8, 0, 50, 56, 279, DateTimeKind.Local).AddTicks(1120),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 7, 18, 7, 50, 302, DateTimeKind.Local).AddTicks(7618));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 8, 0, 50, 56, 250, DateTimeKind.Local).AddTicks(1637),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 7, 18, 7, 50, 284, DateTimeKind.Local).AddTicks(3463));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 8, 0, 50, 56, 275, DateTimeKind.Local).AddTicks(5287),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 7, 18, 7, 50, 301, DateTimeKind.Local).AddTicks(6704));

            migrationBuilder.AddForeignKey(
                name: "FK_CataLogItems_CatalogBrand_CatalogBrandId",
                table: "CataLogItems",
                column: "CatalogBrandId",
                principalTable: "CatalogBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CataLogItems_CatalogBrand_CatalogBrandId",
                table: "CataLogItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 7, 18, 7, 50, 303, DateTimeKind.Local).AddTicks(141),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 8, 0, 50, 56, 279, DateTimeKind.Local).AddTicks(5192));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 7, 18, 7, 50, 302, DateTimeKind.Local).AddTicks(1660),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 8, 0, 50, 56, 278, DateTimeKind.Local).AddTicks(902));

            migrationBuilder.AlterColumn<int>(
                name: "CatalogBrandId",
                table: "CataLogItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 7, 18, 7, 50, 302, DateTimeKind.Local).AddTicks(5352),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 8, 0, 50, 56, 278, DateTimeKind.Local).AddTicks(7035));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 7, 18, 7, 50, 302, DateTimeKind.Local).AddTicks(7618),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 8, 0, 50, 56, 279, DateTimeKind.Local).AddTicks(1120));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 7, 18, 7, 50, 284, DateTimeKind.Local).AddTicks(3463),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 8, 0, 50, 56, 250, DateTimeKind.Local).AddTicks(1637));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 7, 18, 7, 50, 301, DateTimeKind.Local).AddTicks(6704),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 8, 0, 50, 56, 275, DateTimeKind.Local).AddTicks(5287));

            migrationBuilder.AddForeignKey(
                name: "FK_CataLogItems_CatalogBrand_CatalogBrandId",
                table: "CataLogItems",
                column: "CatalogBrandId",
                principalTable: "CatalogBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
