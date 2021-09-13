using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store_2.Persistance.Migrations
{
    public partial class create_database_again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CataLogItemFeature_CataLogItems_CataLogItemId",
                table: "CataLogItemFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_CatalogItemImage_CataLogItems_CataLogItemId",
                table: "CatalogItemImage");

            migrationBuilder.DropForeignKey(
                name: "FK_CataLogItems_CatalogBrand_CatalogBrandId",
                table: "CataLogItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CataLogItems_CatalogType_CatalogTypeId",
                table: "CataLogItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CatalogType_CatalogType_ParentCatalogTypeId",
                table: "CatalogType");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatalogType",
                table: "CatalogType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatalogItemImage",
                table: "CatalogItemImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CataLogItemFeature",
                table: "CataLogItemFeature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatalogBrand",
                table: "CatalogBrand");

            migrationBuilder.RenameTable(
                name: "CatalogType",
                newName: "CatalogTypes");

            migrationBuilder.RenameTable(
                name: "CatalogItemImage",
                newName: "CatalogItemImages");

            migrationBuilder.RenameTable(
                name: "CataLogItemFeature",
                newName: "CataLogItemFeatures");

            migrationBuilder.RenameTable(
                name: "CatalogBrand",
                newName: "CatalogBrands");

            migrationBuilder.RenameIndex(
                name: "IX_CatalogType_ParentCatalogTypeId",
                table: "CatalogTypes",
                newName: "IX_CatalogTypes_ParentCatalogTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CatalogItemImage_CataLogItemId",
                table: "CatalogItemImages",
                newName: "IX_CatalogItemImages_CataLogItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CataLogItemFeature_CataLogItemId",
                table: "CataLogItemFeatures",
                newName: "IX_CataLogItemFeatures_CataLogItemId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 133, DateTimeKind.Local).AddTicks(4917),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 909, DateTimeKind.Local).AddTicks(7192));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 133, DateTimeKind.Local).AddTicks(2561),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 909, DateTimeKind.Local).AddTicks(5021));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 132, DateTimeKind.Local).AddTicks(5193),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 908, DateTimeKind.Local).AddTicks(8279));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 132, DateTimeKind.Local).AddTicks(9738),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 909, DateTimeKind.Local).AddTicks(2527));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 132, DateTimeKind.Local).AddTicks(531),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 908, DateTimeKind.Local).AddTicks(3861));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 130, DateTimeKind.Local).AddTicks(6025),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 907, DateTimeKind.Local).AddTicks(199));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 131, DateTimeKind.Local).AddTicks(4824),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 907, DateTimeKind.Local).AddTicks(8572));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 120, DateTimeKind.Local).AddTicks(5215),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 897, DateTimeKind.Local).AddTicks(5084));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 130, DateTimeKind.Local).AddTicks(2229),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 906, DateTimeKind.Local).AddTicks(6539));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 131, DateTimeKind.Local).AddTicks(7168),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 908, DateTimeKind.Local).AddTicks(721));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItemFeatures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 131, DateTimeKind.Local).AddTicks(579),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 907, DateTimeKind.Local).AddTicks(4195));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 131, DateTimeKind.Local).AddTicks(2804),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 907, DateTimeKind.Local).AddTicks(6285));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatalogTypes",
                table: "CatalogTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatalogItemImages",
                table: "CatalogItemImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CataLogItemFeatures",
                table: "CataLogItemFeatures",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatalogBrands",
                table: "CatalogBrands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CataLogItemFeatures_CataLogItems_CataLogItemId",
                table: "CataLogItemFeatures",
                column: "CataLogItemId",
                principalTable: "CataLogItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogItemImages_CataLogItems_CataLogItemId",
                table: "CatalogItemImages",
                column: "CataLogItemId",
                principalTable: "CataLogItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CataLogItems_CatalogBrands_CatalogBrandId",
                table: "CataLogItems",
                column: "CatalogBrandId",
                principalTable: "CatalogBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CataLogItems_CatalogTypes_CatalogTypeId",
                table: "CataLogItems",
                column: "CatalogTypeId",
                principalTable: "CatalogTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogTypes_CatalogTypes_ParentCatalogTypeId",
                table: "CatalogTypes",
                column: "ParentCatalogTypeId",
                principalTable: "CatalogTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CataLogItemFeatures_CataLogItems_CataLogItemId",
                table: "CataLogItemFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_CatalogItemImages_CataLogItems_CataLogItemId",
                table: "CatalogItemImages");

            migrationBuilder.DropForeignKey(
                name: "FK_CataLogItems_CatalogBrands_CatalogBrandId",
                table: "CataLogItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CataLogItems_CatalogTypes_CatalogTypeId",
                table: "CataLogItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CatalogTypes_CatalogTypes_ParentCatalogTypeId",
                table: "CatalogTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatalogTypes",
                table: "CatalogTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatalogItemImages",
                table: "CatalogItemImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CataLogItemFeatures",
                table: "CataLogItemFeatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatalogBrands",
                table: "CatalogBrands");

            migrationBuilder.RenameTable(
                name: "CatalogTypes",
                newName: "CatalogType");

            migrationBuilder.RenameTable(
                name: "CatalogItemImages",
                newName: "CatalogItemImage");

            migrationBuilder.RenameTable(
                name: "CataLogItemFeatures",
                newName: "CataLogItemFeature");

            migrationBuilder.RenameTable(
                name: "CatalogBrands",
                newName: "CatalogBrand");

            migrationBuilder.RenameIndex(
                name: "IX_CatalogTypes_ParentCatalogTypeId",
                table: "CatalogType",
                newName: "IX_CatalogType_ParentCatalogTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CatalogItemImages_CataLogItemId",
                table: "CatalogItemImage",
                newName: "IX_CatalogItemImage_CataLogItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CataLogItemFeatures_CataLogItemId",
                table: "CataLogItemFeature",
                newName: "IX_CataLogItemFeature_CataLogItemId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 909, DateTimeKind.Local).AddTicks(7192),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 133, DateTimeKind.Local).AddTicks(4917));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 909, DateTimeKind.Local).AddTicks(5021),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 133, DateTimeKind.Local).AddTicks(2561));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 908, DateTimeKind.Local).AddTicks(8279),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 132, DateTimeKind.Local).AddTicks(5193));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 909, DateTimeKind.Local).AddTicks(2527),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 132, DateTimeKind.Local).AddTicks(9738));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 908, DateTimeKind.Local).AddTicks(3861),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 132, DateTimeKind.Local).AddTicks(531));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 907, DateTimeKind.Local).AddTicks(199),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 130, DateTimeKind.Local).AddTicks(6025));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogItemFavorites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 907, DateTimeKind.Local).AddTicks(8572),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 131, DateTimeKind.Local).AddTicks(4824));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 897, DateTimeKind.Local).AddTicks(5084),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 120, DateTimeKind.Local).AddTicks(5215));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 906, DateTimeKind.Local).AddTicks(6539),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 130, DateTimeKind.Local).AddTicks(2229));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 908, DateTimeKind.Local).AddTicks(721),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 131, DateTimeKind.Local).AddTicks(7168));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 907, DateTimeKind.Local).AddTicks(4195),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 131, DateTimeKind.Local).AddTicks(579));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 11, 56, 39, 907, DateTimeKind.Local).AddTicks(6285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 23, 20, 37, 52, 131, DateTimeKind.Local).AddTicks(2804));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatalogType",
                table: "CatalogType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatalogItemImage",
                table: "CatalogItemImage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CataLogItemFeature",
                table: "CataLogItemFeature",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatalogBrand",
                table: "CatalogBrand",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CataLogItemFeature_CataLogItems_CataLogItemId",
                table: "CataLogItemFeature",
                column: "CataLogItemId",
                principalTable: "CataLogItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogItemImage_CataLogItems_CataLogItemId",
                table: "CatalogItemImage",
                column: "CataLogItemId",
                principalTable: "CataLogItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CataLogItems_CatalogBrand_CatalogBrandId",
                table: "CataLogItems",
                column: "CatalogBrandId",
                principalTable: "CatalogBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CataLogItems_CatalogType_CatalogTypeId",
                table: "CataLogItems",
                column: "CatalogTypeId",
                principalTable: "CatalogType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogType_CatalogType_ParentCatalogTypeId",
                table: "CatalogType",
                column: "ParentCatalogTypeId",
                principalTable: "CatalogType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
