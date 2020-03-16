using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureSystem.Models;
using SecureSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureSystem.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationContext db;
        public ProductController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Contract() => View();



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



        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return RedirectToAction("SecureSys");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Product product = await db.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            db.Products.Update(product);
            await db.SaveChangesAsync();
            return RedirectToAction("SecureSys");
        }


        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Product product = await db.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Product product = await db.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                if (product != null)
                {
                    db.Products.Remove(product);
                    await db.SaveChangesAsync();
                    return RedirectToAction("SecureSys");
                }
            }
            return NotFound();
        }
    }
}
