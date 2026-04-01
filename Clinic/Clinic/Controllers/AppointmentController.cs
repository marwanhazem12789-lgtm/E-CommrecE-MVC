using Clinic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly Context c;
        public AppointmentController()
        {
            c = new Context();
        }
        // GET: PatientContoller
        public IActionResult Index()
        {
            var appointments = c.Appointments
                          .Include(a => a.Patient)
                          .Include(a => a.Doctor)
                          .ToList();

            return View(appointments);
        }

        // GET: PatientContoller/Details/5
        public IActionResult Details(int id)
        {
            var pat = c.Appointments.FirstOrDefault(x => x.Id == id);
            if (pat == null) { return NotFound(); }
            return View(pat);
        }

        // GET: PatientContoller/Create
        public IActionResult Create()
        {

            ViewData["PatientId"] = new SelectList(c.Patients, "Id", "Name");

            ViewData["DoctorId"] = new SelectList(c.Doctors, "Id", "Name");

            return View(); 
        }

        // POST: PatientContoller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Appointment collection)
        {
           
                c.Appointments.Add(collection);
                c.SaveChanges();
                return RedirectToAction("Index");
          
        }

        // GET: PatientContoller/Edit/5
        // GET: Appointment/Edit/5
        public IActionResult Edit(int id)
        {
            var appointment = c.Appointments.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }

            ViewData["PatientId"] = new SelectList(c.Patients, "Id", "Name", appointment.PatientId);
            ViewData["DoctorId"] = new SelectList(c.Doctors, "Id", "Name", appointment.DoctorId);

            return View(appointment);
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Appointment collection)
        {
          
                c.Update(collection);
                c.SaveChanges();
                return RedirectToAction("Index");
            
           
        }

        // GET: PatientContoller/Delete/5
        public IActionResult Delete(int id)
        {
            var pat = c.Appointments.Find(id);
            if (pat == null) { return NotFound(); }
            return View(pat);
        }

        // POST: PatientContoller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Appointment collection)
        {
           
                c.Appointments.Remove(collection);
                c.SaveChanges();
                return RedirectToAction("Index");
           
        }
    }
}
