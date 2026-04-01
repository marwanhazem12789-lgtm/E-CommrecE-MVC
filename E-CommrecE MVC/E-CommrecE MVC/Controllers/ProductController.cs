using E_CommrecE_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommrecE_MVC.Controllers
{
    public class ProductController : Controller
    {
        public readonly Context c;
        public ProductController()
        {
            c = new Context();
        }
        // GET: ProductController
        public IActionResult Index()
        {
            var pro = c.Products.ToList();
            return View(pro);
        }

        // GET: ProductController/Details/5
        public IActionResult Details(int id)
        {
            var pro = c.Products.FirstOrDefault(x => x.Id == id);
            if(pro == null)
            {
                return NotFound();
            }
            return View(pro);
        }

        // GET: ProductController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product collection)
        {
            c.Products.Add(collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Edit/5
        public IActionResult Edit(int id)
        {
                var pro = c.Products.Find(id);
                if(pro == null) { return NotFound(); }
            return View(pro);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product collection)
        {
            c.Update(collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Delete/5
        public IActionResult Delete(int id)
        {
                var pro = c.Products.Find(id);
                    if(pro == null) { return NotFound(); }
            return View(pro);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Product collection)
        {
            c.Products.Remove(collection);
            c.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
