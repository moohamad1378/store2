using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store_2.Persistance.Migrations
{
    public partial class edited_catalogtypeee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 19, 27, 10, 460, DateTimeKind.Local).AddTicks(5679),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 15, 19, 19, 40, 833, DateTimeKind.Local).AddTicks(4433));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Catalogbran",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 19, 27, 10, 413, DateTimeKind.Local).AddTicks(7255),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 15, 19, 19, 40, 808, DateTimeKind.Local).AddTicks(3183));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 19, 19, 40, 833, DateTimeKind.Local).AddTicks(4433),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 15, 19, 27, 10, 460, DateTimeKind.Local).AddTicks(5679));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Catalogbran",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 15, 19, 19, 40, 808, DateTimeKind.Local).AddTicks(3183),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 15, 19, 27, 10, 413, DateTimeKind.Local).AddTicks(7255));
        }
    }
}
