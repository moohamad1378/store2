using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store_2.Persistance.Migrations
{
    public partial class add_imagesetings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 5, 17, 49, 35, 18, DateTimeKind.Local).AddTicks(5831),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 5, 14, 55, 38, 927, DateTimeKind.Local).AddTicks(9385));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 5, 17, 49, 34, 996, DateTimeKind.Local).AddTicks(2751),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 5, 14, 55, 38, 909, DateTimeKind.Local).AddTicks(1770));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 5, 17, 49, 35, 17, DateTimeKind.Local).AddTicks(397),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 5, 14, 55, 38, 927, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 5, 17, 49, 35, 17, DateTimeKind.Local).AddTicks(5755),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 5, 14, 55, 38, 927, DateTimeKind.Local).AddTicks(6612));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 5, 14, 55, 38, 927, DateTimeKind.Local).AddTicks(9385),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 5, 17, 49, 35, 18, DateTimeKind.Local).AddTicks(5831));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 5, 14, 55, 38, 909, DateTimeKind.Local).AddTicks(1770),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 5, 17, 49, 34, 996, DateTimeKind.Local).AddTicks(2751));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 5, 14, 55, 38, 927, DateTimeKind.Local).AddTicks(3960),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 5, 17, 49, 35, 17, DateTimeKind.Local).AddTicks(397));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 5, 14, 55, 38, 927, DateTimeKind.Local).AddTicks(6612),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 5, 17, 49, 35, 17, DateTimeKind.Local).AddTicks(5755));
        }
    }
}
