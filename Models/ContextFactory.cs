using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Shop.Web.Models
{
    /// <summary>
    /// Represents a design time implementation used by EntityFramework to create database tables(schemas)
    /// when you run migrations using the following commands:
    /// 
    /// dotnet ef migrations add Initial
    /// dotnet ef database update
    /// 
    /// Readmore:
    /// <see cref="https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/"/>
    /// </summary>
    public class ContextFactory : IDesignTimeDbContextFactory<ShopDbContext>
    {
        private readonly IConfiguration configuration;
        public ContextFactory()
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            configuration = builder.Build();
        }
        public ShopDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ShopDbContext> builder = new DbContextOptionsBuilder<ShopDbContext>();
            builder.UseSqlServer(configuration["ConnectionString"]);
            return new ShopDbContext(builder.Options);
        }
    }
}