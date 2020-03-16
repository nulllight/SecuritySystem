using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureSystem.Controllers
{
    public class OrderController: Controller
    {
        private ApplicationContext db;
        public OrderController(ApplicationContext context)
        {
            db = context;
        }
        public IActionResult CompPurchase() => View();

        [HttpGet]
        public IActionResult Order(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.ProductId = id;
            return View();
        }
        [HttpPost]
        public IActionResult Order(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("CompPurchase", "Order");
        }
    }
}
