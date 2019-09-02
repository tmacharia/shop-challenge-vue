using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Shop.Web.Models
{
    public class ShopDbContext : IdentityDbContext
    {
        public ShopDbContext(DbContextOptionsBuilder<ShopDbContext> builder)
            :base(builder.Options)
        {

        }

        public virtual DbSet<ShopModel> Shops { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // seed database with initial shops
            List<ShopModel> shops = new List<ShopModel>()
            {
                new ShopModel(){Id =1,Name="Amazon",Description="Electronics",Distance=25,ImageUrl=""},
                new ShopModel(){Id =1,Name="Macy's",Description="Clothes & Apparel",Distance=48,ImageUrl=""}
            };

            builder.Entity<ShopModel>().HasData(shops);
        }
    }
}