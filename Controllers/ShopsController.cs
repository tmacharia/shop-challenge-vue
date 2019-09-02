using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shop.Web.Models;

namespace Shop.Web.Controllers
{
    [Route("api/shops")]
    public class ShopsController : Controller
    {
        private readonly ShopDbContext _context;
        /// <summary>
        /// Initialize controller with a <see cref="ShopDbContext"/> instance registered
        /// by the DI container in <see cref="Startup"/>
        /// 
        /// For more about Dependency injection in Asp.Net Core:
        /// <see cref="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.2"/>
        /// </summary>
        /// <param name="shopDbContext">DbContext</param>
        public ShopsController(ShopDbContext shopDbContext)
        {
            _context = shopDbContext;
        }

        /// <summary>
        /// Gets list of all shops from the database sorted by distance.
        /// </summary>
        /// <returns>List of shops as JSON</returns>
        [HttpGet]
        public IActionResult Index()
        {
            var shops = _context.Shops.OrderBy(x => x.Distance); // sorts shops in ascending order by distance.
            return Ok(shops);
        }
    }
}