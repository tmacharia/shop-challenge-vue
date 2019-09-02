using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Web.Migrations
{
    public partial class Update_Shop_List : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Distance", "Timestamp" },
                values: new object[] { 180.0, new DateTime(2019, 9, 3, 0, 27, 23, 617, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Distance", "Timestamp" },
                values: new object[] { 957.0, new DateTime(2019, 9, 3, 0, 27, 23, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Distance", "Timestamp" },
                values: new object[] { 203.0, new DateTime(2019, 9, 3, 0, 27, 23, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Distance", "Timestamp" },
                values: new object[] { 715.0, new DateTime(2019, 9, 3, 0, 27, 23, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Distance", "Timestamp" },
                values: new object[] { 386.0, new DateTime(2019, 9, 3, 0, 27, 23, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Distance", "Timestamp" },
                values: new object[] { 94.0, new DateTime(2019, 9, 3, 0, 27, 23, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Distance", "Timestamp" },
                values: new object[] { 873.0, new DateTime(2019, 9, 3, 0, 27, 23, 636, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Distance", "ImageUrl", "Timestamp" },
                values: new object[] { 209.0, "https://www.moneyweb.co.za/wp-content/uploads/2014/07/Pick-n-pay-3-2-Large1-500x333.jpg", new DateTime(2019, 9, 3, 0, 27, 23, 636, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Description", "Distance", "ImageUrl", "MetricUnit", "Name", "Timestamp" },
                values: new object[,]
                {
                    { 9, "Large retail store", 534.0, "https://media.bizj.us/view/img/425831/target*750xx600-338-0-19.jpg", "Km", "Target", new DateTime(2019, 9, 3, 0, 27, 23, 636, DateTimeKind.Local) },
                    { 10, "Chain of hypermarkets", 357.0, "https://n4f9d4s8.stackpathcdn.com/wp-content/uploads/2019/08/Walmart.jpg", "Km", "Walmart", new DateTime(2019, 9, 3, 0, 27, 23, 636, DateTimeKind.Local) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Distance", "Timestamp" },
                values: new object[] { 236.0, new DateTime(2019, 9, 2, 9, 13, 38, 819, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Distance", "Timestamp" },
                values: new object[] { 708.0, new DateTime(2019, 9, 2, 9, 13, 38, 820, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Distance", "Timestamp" },
                values: new object[] { 21.0, new DateTime(2019, 9, 2, 9, 13, 38, 820, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Distance", "Timestamp" },
                values: new object[] { 613.0, new DateTime(2019, 9, 2, 9, 13, 38, 820, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Distance", "Timestamp" },
                values: new object[] { 715.0, new DateTime(2019, 9, 2, 9, 13, 38, 820, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Distance", "Timestamp" },
                values: new object[] { 294.0, new DateTime(2019, 9, 2, 9, 13, 38, 820, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Distance", "Timestamp" },
                values: new object[] { 411.0, new DateTime(2019, 9, 2, 9, 13, 38, 820, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Distance", "ImageUrl", "Timestamp" },
                values: new object[] { 237.0, "http://www.sabcnews.com/sabcnews/wp-content/uploads/2018/03/pick-n-pay-1.jpg", new DateTime(2019, 9, 2, 9, 13, 38, 820, DateTimeKind.Local) });
        }
    }
}
