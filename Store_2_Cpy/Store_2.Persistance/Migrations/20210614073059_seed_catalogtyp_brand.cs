using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store_2.Persistance.Migrations
{
    public partial class seed_catalogtyp_brand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsRemoved",
                table: "CatalogType",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 12, 0, 57, 656, DateTimeKind.Local).AddTicks(8454),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "ParentCatalogTpeId",
                table: "CatalogType",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsRemoved",
                table: "Catalogbran",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Catalogbran",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 12, 0, 57, 638, DateTimeKind.Local).AddTicks(3064),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "CatalogType",
                columns: new[] { "Id", "ParentCatalogTpeId", "RemovedTime", "Type", "UpdateTime" },
                values: new object[] { 1, null, null, "Digital goods", null });

            migrationBuilder.InsertData(
                table: "Catalogbran",
                columns: new[] { "Id", "Brand", "RemovedTime", "UpdateTime" },
                values: new object[,]
                {
                    { 1, "Samsung", null, null },
                    { 2, "Xiaomi", null, null },
                    { 3, "Apple", null, null },
                    { 4, "Huawei", null, null },
                    { 5, "Nokia", null, null }
                });

            migrationBuilder.InsertData(
                table: "CatalogType",
                columns: new[] { "Id", "ParentCatalogTpeId", "RemovedTime", "Type", "UpdateTime" },
                values: new object[] { 2, 1, null, "Phone accessories", null });

            migrationBuilder.InsertData(
                table: "CatalogType",
                columns: new[] { "Id", "ParentCatalogTpeId", "RemovedTime", "Type", "UpdateTime" },
                values: new object[] { 3, 2, null, "Phone holder base", null });

            migrationBuilder.InsertData(
                table: "CatalogType",
                columns: new[] { "Id", "ParentCatalogTpeId", "RemovedTime", "Type", "UpdateTime" },
                values: new object[] { 4, 2, null, "Mobile charger power bank", null });

            migrationBuilder.InsertData(
                table: "CatalogType",
                columns: new[] { "Id", "ParentCatalogTpeId", "RemovedTime", "Type", "UpdateTime" },
                values: new object[] { 5, 2, null, "Phone case and cover", null });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogType_ParentCatalogTpeId",
                table: "CatalogType",
                column: "ParentCatalogTpeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogType_CatalogType_ParentCatalogTpeId",
                table: "CatalogType",
                column: "ParentCatalogTpeId",
                principalTable: "CatalogType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogType_CatalogType_ParentCatalogTpeId",
                table: "CatalogType");

            migrationBuilder.DropIndex(
                name: "IX_CatalogType_ParentCatalogTpeId",
                table: "CatalogType");

            migrationBuilder.DeleteData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Catalogbran",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Catalogbran",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Catalogbran",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Catalogbran",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Catalogbran",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CatalogType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ParentCatalogTpeId",
                table: "CatalogType");

            migrationBuilder.AlterColumn<bool>(
                name: "IsRemoved",
                table: "CatalogType",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 14, 12, 0, 57, 656, DateTimeKind.Local).AddTicks(8454));

            migrationBuilder.AlterColumn<bool>(
                name: "IsRemoved",
                table: "Catalogbran",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Catalogbran",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 14, 12, 0, 57, 638, DateTimeKind.Local).AddTicks(3064));
        }
    }
}
