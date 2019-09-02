using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Web.Migrations
{
    public partial class UpdateData_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Distance", "ImageUrl", "Name", "Timestamp" },
                values: new object[] { "Deals & Promotions", 236.0, "https://cdn0.tnwcdn.com/wp-content/blogs.dir/1/files/2018/01/Amazon-Go-796x419.jpg", "Amazon Store", new DateTime(2019, 9, 2, 9, 13, 38, 819, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Distance", "ImageUrl", "Name", "Timestamp" },
                values: new object[] { "Clothes & Apparel.", 708.0, "https://cdn.cnn.com/cnnnext/dam/assets/180517180219-jcpenney-store-front-exlarge-169.jpg", "JC Penny's", new DateTime(2019, 9, 2, 9, 13, 38, 820, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Description", "Distance", "ImageUrl", "MetricUnit", "Name", "Timestamp" },
                values: new object[,]
                {
                    { 3, "Chinese Multinational", 21.0, "https://amp.businessinsider.com/images/5d361e6b100a242406627ce5-750-562.jpg", "Km", "Alibaba", new DateTime(2019, 9, 2, 9, 13, 38, 820, DateTimeKind.Local) },
                    { 4, "Domestic retail store", 613.0, "http://giftcardsgiveaway.net/wp-content/uploads/2016/01/bed-bath-and-beyond-img2.jpg", "Km", "BedBath & Beyond", new DateTime(2019, 9, 2, 9, 13, 38, 820, DateTimeKind.Local) },
                    { 5, "Kenyan Supermarket", 715.0, "https://businesstoday.co.ke/wp-content/uploads/2018/02/nakumatt-supermarket.jpg", "Km", "Nakumatt", new DateTime(2019, 9, 2, 9, 13, 38, 820, DateTimeKind.Local) },
                    { 6, "Electrical appliances", 294.0, "https://t1.hespress.com/files/aswakassalam_789587962.jpg", "Km", "Aswak Assalam", new DateTime(2019, 9, 2, 9, 13, 38, 820, DateTimeKind.Local) },
                    { 7, "BIG on life", 411.0, "http://www.fkservis.cz/uploads/references/66/oczm1481v8.jpg", "Km", "Makro", new DateTime(2019, 9, 2, 9, 13, 38, 820, DateTimeKind.Local) },
                    { 8, "Chain store in SouthAfrica", 237.0, "http://www.sabcnews.com/sabcnews/wp-content/uploads/2018/03/pick-n-pay-1.jpg", "Km", "Pick n Pay", new DateTime(2019, 9, 2, 9, 13, 38, 820, DateTimeKind.Local) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Distance", "ImageUrl", "Name", "Timestamp" },
                values: new object[] { "Electronics", 25.0, "", "Amazon", new DateTime(2019, 9, 2, 5, 47, 27, 26, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Distance", "ImageUrl", "Name", "Timestamp" },
                values: new object[] { "Clothes & Apparel", 48.0, "", "Macy's", new DateTime(2019, 9, 2, 5, 47, 27, 28, DateTimeKind.Local) });
        }
    }
}
