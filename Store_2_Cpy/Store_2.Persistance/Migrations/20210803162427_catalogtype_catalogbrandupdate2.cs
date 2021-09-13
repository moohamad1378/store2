using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store_2.Persistance.Migrations
{
    public partial class catalogtype_catalogbrandupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 20, 54, 26, 440, DateTimeKind.Local).AddTicks(7596),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 15, 19, 33, 13, 848, DateTimeKind.Local).AddTicks(5468));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Catalogbran",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 20, 54, 26, 422, DateTimeKind.Local).AddTicks(4623),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 15, 19, 33, 13, 825, DateTimeKind.Local).AddTicks(32));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 19, 33, 13, 848, DateTimeKind.Local).AddTicks(5468),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 3, 20, 54, 26, 440, DateTimeKind.Local).AddTicks(7596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Catalogbran",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 19, 33, 13, 825, DateTimeKind.Local).AddTicks(32),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 3, 20, 54, 26, 422, DateTimeKind.Local).AddTicks(4623));
        }
    }
}
