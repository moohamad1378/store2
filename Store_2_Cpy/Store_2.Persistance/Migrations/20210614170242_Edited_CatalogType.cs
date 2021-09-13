using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store_2.Persistance.Migrations
{
    public partial class Edited_CatalogType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogType_CatalogType_ParentCatalogTpeId",
                table: "CatalogType");

            migrationBuilder.RenameColumn(
                name: "ParentCatalogTpeId",
                table: "CatalogType",
                newName: "ParentCatalogTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CatalogType_ParentCatalogTpeId",
                table: "CatalogType",
                newName: "IX_CatalogType_ParentCatalogTypeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 32, 41, 513, DateTimeKind.Local).AddTicks(6840),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 14, 12, 0, 57, 656, DateTimeKind.Local).AddTicks(8454));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Catalogbran",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 21, 32, 41, 489, DateTimeKind.Local).AddTicks(6634),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 14, 12, 0, 57, 638, DateTimeKind.Local).AddTicks(3064));

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogType_CatalogType_ParentCatalogTypeId",
                table: "CatalogType",
                column: "ParentCatalogTypeId",
                principalTable: "CatalogType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogType_CatalogType_ParentCatalogTypeId",
                table: "CatalogType");

            migrationBuilder.RenameColumn(
                name: "ParentCatalogTypeId",
                table: "CatalogType",
                newName: "ParentCatalogTpeId");

            migrationBuilder.RenameIndex(
                name: "IX_CatalogType_ParentCatalogTypeId",
                table: "CatalogType",
                newName: "IX_CatalogType_ParentCatalogTpeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 12, 0, 57, 656, DateTimeKind.Local).AddTicks(8454),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 32, 41, 513, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Catalogbran",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 14, 12, 0, 57, 638, DateTimeKind.Local).AddTicks(3064),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 14, 21, 32, 41, 489, DateTimeKind.Local).AddTicks(6634));

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogType_CatalogType_ParentCatalogTpeId",
                table: "CatalogType",
                column: "ParentCatalogTpeId",
                principalTable: "CatalogType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
