using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store_2.Persistance.Migrations
{
    public partial class change_Names_Brand_type3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalogbrand",
                table: "Catalogbrand");

            migrationBuilder.RenameTable(
                name: "Catalogbrand",
                newName: "CatalogBrand");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 21, 43, 2, 984, DateTimeKind.Local).AddTicks(8640),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 3, 21, 21, 1, 939, DateTimeKind.Local).AddTicks(3140));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 21, 43, 2, 967, DateTimeKind.Local).AddTicks(5264),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 3, 21, 21, 1, 922, DateTimeKind.Local).AddTicks(2392));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatalogBrand",
                table: "CatalogBrand",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CatalogBrand",
                table: "CatalogBrand");

            migrationBuilder.RenameTable(
                name: "CatalogBrand",
                newName: "Catalogbrand");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 21, 21, 1, 939, DateTimeKind.Local).AddTicks(3140),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 3, 21, 43, 2, 984, DateTimeKind.Local).AddTicks(8640));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Catalogbrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 21, 21, 1, 922, DateTimeKind.Local).AddTicks(2392),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 3, 21, 43, 2, 967, DateTimeKind.Local).AddTicks(5264));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalogbrand",
                table: "Catalogbrand",
                column: "Id");
        }
    }
}
