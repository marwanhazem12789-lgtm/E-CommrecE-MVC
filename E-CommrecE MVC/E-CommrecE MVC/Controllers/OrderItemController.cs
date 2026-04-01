using E_CommrecE_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_CommrecE_MVC.Controllers
{
    public class OrderItemController : Controller
    {
      
            public readonly Context c;  
            public OrderItemController() { c = new Context(); }

            public IActionResult Edit(int id)
            {
                var item = c.OrderItems.Include(oi => oi.Product).FirstOrDefault(oi => oi.Id == id);
                if (item == null) return NotFound();

                ViewBag.ProductName = item.Product.Name;
                return View(item);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, OrderItem item)
        {
            if (id != item.Id) return NotFound();
            var oldItem = c.OrderItems.Find(id);
            if (oldItem == null) return NotFound();
            oldItem.Quantity = item.Quantity;
            oldItem.UnitPrice = item.UnitPrice;
            oldItem.OrderId = item.OrderId;
            oldItem.ProductId = item.ProductId;

            c.SaveChanges();
            return RedirectToAction("Details", "Order", new { id = oldItem.OrderId });
        }
        public IActionResult Delete(int id)
            {
                var item = c.OrderItems.Find(id);
                if (item == null) return NotFound();

                int orderId = item.OrderId; 

                c.OrderItems.Remove(item);
                c.SaveChanges();

                return RedirectToAction("Details", "Orders", new { id = orderId });
            }
        }
    }

