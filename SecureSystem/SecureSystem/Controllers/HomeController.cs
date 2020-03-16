using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecureSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace SecureSystem.Controllers
{
   
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

       
        public IActionResult Index() => View();
        public async Task<IActionResult> SecureSys(SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<Product> products = db.Products;

            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["PriceSort"] = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;

            products = sortOrder switch
            {
                SortState.NameDesc => products.OrderByDescending(s => s.Name),
                SortState.PriceAsc => products.OrderBy(s => s.Price),
                SortState.PriceDesc => products.OrderByDescending(s => s.Price),
                _ => products.OrderBy(s => s.Name)
            };
            return View(await products.AsNoTracking().ToListAsync());
        }
        public IActionResult Сontacts() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

     
    }
}
