using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store_2.Persistance.Migrations
{
    public partial class edited_catalogtypeeee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 19, 31, 44, 601, DateTimeKind.Local).AddTicks(4767),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 15, 19, 27, 10, 460, DateTimeKind.Local).AddTicks(5679));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Catalogbran",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 19, 31, 44, 552, DateTimeKind.Local).AddTicks(7270),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 15, 19, 27, 10, 413, DateTimeKind.Local).AddTicks(7255));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 19, 27, 10, 460, DateTimeKind.Local).AddTicks(5679),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 15, 19, 31, 44, 601, DateTimeKind.Local).AddTicks(4767));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Catalogbran",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 19, 27, 10, 413, DateTimeKind.Local).AddTicks(7255),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 15, 19, 31, 44, 552, DateTimeKind.Local).AddTicks(7270));
        }
    }
}
