using E_CommrecE_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommrecE_MVC.Controllers
{
    public class CustomerController : Controller
    {
        public readonly Context c;
        public CustomerController()
        {
            c = new Context();
        }
        // GET: CustomerController
        public IActionResult Index()
        {
            var cu = c.Customers.ToList();
            return View(cu);
        }

        // GET: CustomerController/Details/5
        public IActionResult Details(int id)
        {
            var cu = c.Customers.FirstOrDefault(x => x.Id == id);
            if(c == null)
            {
                return NotFound();
            }
            return View(cu);
        }

        // GET: CustomerController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer collection)
        {
            c.Customers.Add(collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: CustomerController/Edit/5
        public IActionResult Edit(int id)
        {
            var cu = c.Customers.Find(id);
            if(cu == null) { return NotFound(); }
            return View(cu);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Customer collection)
        {
            c.Update(collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: CustomerController/Delete/5
        public IActionResult Delete(int id)
        {
            var cu = c.Customers.Find(id);
            if (cu == null) { return NotFound(); }
            return View(cu);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Customer collection)
        {
            c.Customers.Remove(collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
