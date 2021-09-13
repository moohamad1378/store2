using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store_2.Persistance.Migrations
{
    public partial class some_error : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 12, 4, 32, 6, 414, DateTimeKind.Local).AddTicks(130),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 11, 19, 13, 26, 733, DateTimeKind.Local).AddTicks(2395));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 12, 4, 32, 6, 413, DateTimeKind.Local).AddTicks(4920),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 11, 19, 13, 26, 732, DateTimeKind.Local).AddTicks(9505));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 12, 4, 32, 6, 413, DateTimeKind.Local).AddTicks(1194),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 11, 19, 13, 26, 732, DateTimeKind.Local).AddTicks(6160));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 12, 4, 32, 6, 412, DateTimeKind.Local).AddTicks(3808),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 11, 19, 13, 26, 731, DateTimeKind.Local).AddTicks(5455));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 12, 4, 32, 6, 412, DateTimeKind.Local).AddTicks(6870),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 11, 19, 13, 26, 731, DateTimeKind.Local).AddTicks(9143));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 12, 4, 32, 6, 412, DateTimeKind.Local).AddTicks(9058),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 11, 19, 13, 26, 732, DateTimeKind.Local).AddTicks(2030));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 12, 4, 32, 6, 395, DateTimeKind.Local).AddTicks(4402),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 11, 19, 13, 26, 709, DateTimeKind.Local).AddTicks(5830));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 12, 4, 32, 6, 411, DateTimeKind.Local).AddTicks(8987),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 11, 19, 13, 26, 731, DateTimeKind.Local).AddTicks(479));

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ammount = table.Column<int>(type: "int", nullable: false),
                    IsPay = table.Column<bool>(type: "bit", nullable: false),
                    DatePay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Authority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefId = table.Column<long>(type: "bigint", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 8, 12, 4, 32, 6, 413, DateTimeKind.Local).AddTicks(8062)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemovedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 11, 19, 13, 26, 733, DateTimeKind.Local).AddTicks(2395),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 12, 4, 32, 6, 414, DateTimeKind.Local).AddTicks(130));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 11, 19, 13, 26, 732, DateTimeKind.Local).AddTicks(9505),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 12, 4, 32, 6, 413, DateTimeKind.Local).AddTicks(4920));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 11, 19, 13, 26, 732, DateTimeKind.Local).AddTicks(6160),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 12, 4, 32, 6, 413, DateTimeKind.Local).AddTicks(1194));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 11, 19, 13, 26, 731, DateTimeKind.Local).AddTicks(5455),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 12, 4, 32, 6, 412, DateTimeKind.Local).AddTicks(3808));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CataLogItemFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 11, 19, 13, 26, 731, DateTimeKind.Local).AddTicks(9143),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 12, 4, 32, 6, 412, DateTimeKind.Local).AddTicks(6870));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "CatalogBrand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 11, 19, 13, 26, 732, DateTimeKind.Local).AddTicks(2030),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 12, 4, 32, 6, 412, DateTimeKind.Local).AddTicks(9058));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 11, 19, 13, 26, 709, DateTimeKind.Local).AddTicks(5830),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 12, 4, 32, 6, 395, DateTimeKind.Local).AddTicks(4402));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 11, 19, 13, 26, 731, DateTimeKind.Local).AddTicks(479),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 12, 4, 32, 6, 411, DateTimeKind.Local).AddTicks(8987));
        }
    }
}
