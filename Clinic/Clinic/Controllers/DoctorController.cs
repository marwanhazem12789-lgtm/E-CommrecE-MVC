using Clinic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    public class DoctorController : Controller
    {
        private readonly Context _context;

        public DoctorController()
        {
            _context = new Context();
        }

        // GET: Doctor
        public IActionResult Index()
        {
            var doctors = _context.Doctors.ToList();
            return View(doctors);
        }

        // GET: Doctor/Details/5
        public IActionResult Details(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor == null) return NotFound();
            return View(doctor);
        }

        // GET: Doctor/Create
        public IActionResult Create() => View();

        // POST: Doctor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Doctor doctor)
        {

            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        // GET: Doctor/Edit/5
        public IActionResult Edit(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor == null) return NotFound();
            return View(doctor);
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Doctor doctor)
        {


            _context.Update(doctor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));


        }

        // GET: Doctor/Delete/5
        public IActionResult Delete(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor == null) return NotFound();
            return View(doctor);
        }

        // POST: Doctor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var doctor = _context.Doctors.Find(id);

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Search()
        {
            var allDoctors = _context.Doctors.ToList();
            return View(allDoctors);
        }
        [HttpPost]
        public IActionResult Search (string name)
        {
            var d = _context.Doctors.Where(x => x.Name.Contains(name)).ToList();
            return View(d);

        }
    }
}