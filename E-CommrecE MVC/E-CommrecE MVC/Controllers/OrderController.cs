using E_CommrecE_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_CommrecE_MVC.Controllers
{
    public class OrderController : Controller
    {
        public readonly Context c;
        public OrderController()
        {
            c = new Context();
        }
        // GET: OrderController
        public IActionResult Index()
        {
            var or = c.Orders.Include(Context => Context.Customer).ToList();

            return View(or);
        }

        // GET: OrderController/Details/5
        public IActionResult Details(int id)
        {
                var or = c.Orders.Include(Context => Context.Customer).FirstOrDefault(x => x.Id == id);
                if(or == null) { return NotFound(); }
            return View(or);
        }

        // GET: OrderController/Create
        public IActionResult Create()
        {
            var vm = new OrderCustomer
            {
                Customers = c.Customers.ToList(),
                OrderProducts = c.Products.Select(p => new OrderProduct { ProductId = p.Id, Name = p.Name, Price = p.Price }).ToList()


            };
          
            return View(vm);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderCustomer vm)
        {
            var newOrder = new Order
            {
                CustomerId = vm.selectedCustomerId,
                OrderDate = DateOnly.FromDateTime(DateTime.Now)
            };
            c.Orders.Add(newOrder);
            c.SaveChanges();
            decimal total = 0;

            foreach (var item in vm.OrderProducts)
            {
                if (item.Quantity > 0)
                {
                    var detail = new OrderItem
                    {
                        OrderId = newOrder.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.Price
                    };

                    total += (item.Price * item.Quantity);
                    c.OrderItems.Add(detail);
                }
            }
            newOrder.TotalAmount = total;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: OrderController/Edit/5
        public IActionResult Edit(int id)
        {
            var order = c.Orders.Find(id);
            if (order == null) return NotFound();
            var vm = new OrderCustomer
            {
                selectedCustomerId = order.CustomerId, 
                Customers = c.Customers.ToList() 
            };

            return View(vm); 
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, OrderCustomer vm)
        {
            var oldOrder = c.Orders.Find(id);
            if (oldOrder == null) return NotFound();
            oldOrder.CustomerId = vm.selectedCustomerId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Delete(int id)
        {
            var order = c.Orders.Find(id);
            if (order == null) { return NotFound(); }
            var items = c.OrderItems.Where(oi => oi.OrderId == id).ToList();
            c.OrderItems.RemoveRange(items);
            c.Orders.Remove(order);
            c.SaveChanges(); 
            return RedirectToAction(nameof(Index));
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Order collection)
        {
            var order = c.Orders.Find(id);
            if (order == null) return NotFound();
            var items = c.OrderItems.Where(oi => oi.OrderId == id).ToList();
            c.OrderItems.RemoveRange(items);
            c.Orders.Remove(order);
            c.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
