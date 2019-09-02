using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Shop.Web.Models
{
    public class ShopDbContext : IdentityDbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> builder)
            :base(builder)
        {

        }

        public virtual DbSet<ShopModel> Shops { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // seed database with initial shops
            List<ShopModel> shops = new List<ShopModel>()
            {
                new ShopModel(){Id =1,Name="Amazon Store",Description="Deals & Promotions",Distance=Globals.RandomNum(),ImageUrl="https://cdn0.tnwcdn.com/wp-content/blogs.dir/1/files/2018/01/Amazon-Go-796x419.jpg"},
                new ShopModel(){Id =2,Name="JC Penny's",Description="Clothes & Apparel.",Distance=Globals.RandomNum(),ImageUrl="https://cdn.cnn.com/cnnnext/dam/assets/180517180219-jcpenney-store-front-exlarge-169.jpg"},
                new ShopModel(){Id =3,Name="Alibaba",Description="Chinese Multinational",Distance=Globals.RandomNum(),ImageUrl="https://amp.businessinsider.com/images/5d361e6b100a242406627ce5-750-562.jpg"},
                new ShopModel(){Id =4,Name="BedBath & Beyond",Description="Domestic retail store",Distance=Globals.RandomNum(),ImageUrl="http://giftcardsgiveaway.net/wp-content/uploads/2016/01/bed-bath-and-beyond-img2.jpg"},

                new ShopModel(){Id =5,Name="Nakumatt",Description="Kenyan Supermarket",Distance=Globals.RandomNum(),ImageUrl="https://businesstoday.co.ke/wp-content/uploads/2018/02/nakumatt-supermarket.jpg"},
                new ShopModel(){Id =6,Name="Aswak Assalam",Description="Electrical appliances",Distance=Globals.RandomNum(),ImageUrl="https://t1.hespress.com/files/aswakassalam_789587962.jpg"},
                new ShopModel(){Id =7,Name="Makro",Description="BIG on life",Distance=Globals.RandomNum(),ImageUrl="http://www.fkservis.cz/uploads/references/66/oczm1481v8.jpg"},
                new ShopModel(){Id =8,Name="Pick n Pay",Description="Chain store in SouthAfrica",Distance=Globals.RandomNum(),ImageUrl="http://www.sabcnews.com/sabcnews/wp-content/uploads/2018/03/pick-n-pay-1.jpg"}
            };

            builder.Entity<ShopModel>().HasData(shops.ToArray());
        }
    }
}