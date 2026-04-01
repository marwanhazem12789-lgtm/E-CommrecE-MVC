using Clinic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using System.Numerics;

namespace Clinic.Controllers
{
    public class PatientController : Controller
    {
        private readonly Context c;
        public PatientController()
        {
            c = new Context();
        }
        // GET: PatientContoller
        public IActionResult Index()
        {
            var pat = c.Patients.ToList();
            return View(pat);
        }

        // GET: PatientContoller/Details/5
        public IActionResult Details(int id)
        {
            var pat = c.Patients.FirstOrDefault(x => x.Id == id);
            if (pat == null) { return NotFound(); }
            return View(pat);
        }

        // GET: PatientContoller/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: PatientContoller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Patient collection)
        {
           
                c.Patients.Add(collection);
                c.SaveChanges();
                return RedirectToAction("Index");
            
           
        }

        // GET: PatientContoller/Edit/5
        public IActionResult Edit(int id)
        {
            var pat = c.Patients.Find(id);
            if(pat == null) { return NotFound(); }  
            return View(pat);
        }

        // POST: PatientContoller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Patient collection)
        {
                c.Update(collection);
                c.SaveChanges();
                return RedirectToAction("Index");
           
        }

        // GET: PatientContoller/Delete/5
        public IActionResult Delete(int id)
        {
            var pat = c.Patients.Find(id);
            if (pat == null) { return NotFound(); }
            return View(pat);
        }

        // POST: PatientContoller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Patient collection)
        {
           
                c.Patients.Remove(collection);
                c.SaveChanges();
                return RedirectToAction("Index");
          
        }
    }
}
