using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store_2.Persistance.Migrations
{
    public partial class change_Names_Brand_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalogbran",
                table: "Catalogbran");

            migrationBuilder.RenameTable(
                name: "Catalogbran",
                newName: "Catalogbrand");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 21, 21, 1, 939, DateTimeKind.Local).AddTicks(3140),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 3, 20, 54, 26, 440, DateTimeKind.Local).AddTicks(7596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Catalogbrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 21, 21, 1, 922, DateTimeKind.Local).AddTicks(2392),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 3, 20, 54, 26, 422, DateTimeKind.Local).AddTicks(4623));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalogbrand",
                table: "Catalogbrand",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalogbrand",
                table: "Catalogbrand");

            migrationBuilder.RenameTable(
                name: "Catalogbrand",
                newName: "Catalogbran");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 20, 54, 26, 440, DateTimeKind.Local).AddTicks(7596),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 3, 21, 21, 1, 939, DateTimeKind.Local).AddTicks(3140));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Catalogbran",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 3, 20, 54, 26, 422, DateTimeKind.Local).AddTicks(4623),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 3, 21, 21, 1, 922, DateTimeKind.Local).AddTicks(2392));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalogbran",
                table: "Catalogbran",
                column: "Id");
        }
    }
}
