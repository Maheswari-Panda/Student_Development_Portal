using Microsoft.AspNetCore.Mvc;
using StudentDevelopmentPortal.Data;
using StudentDevelopmentPortal.Models.AdminModels;
using System.Collections.Generic;
using System.Linq;

namespace StudentDevelopmentPortal.Controllers.AdminControllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EventController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Event> events = _db.Events.ToList();
            return View("~/Views/AdminViews/Event/Index.cshtml",events);
        }
        public IActionResult StudentIndex(long Prn)
        {
            ViewBag.Prn = Prn;
            List<Event> events = _db.Events.ToList();
            return View("~/Views/StudentViews/StudentEvent/Index.cshtml", events);
        }
        public IActionResult Create()
        {
            var faculties = _db.Faculty.ToList();

            // Check if any faculties are fetched
            if (faculties != null && faculties.Any())
            {
                // Populate ViewBag with the list of faculties
                ViewBag.Faculties = faculties;
            }
            else
            {
                ViewBag.Faculties = new List<Faculty>(); // Empty list if no faculties are found
            }

            return View("~/Views/AdminViews/Event/Create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(Event obj)
        {
            if (ModelState.IsValid)
            {
                _db.Events.Add(obj);
                _db.SaveChanges();

                TempData["success"] = "Event added successfully";
                return RedirectToAction("Index");
            }
            return View("~/Views/AdminViews/Event/Create.cshtml");
        }

        public IActionResult Edit(long? eventId)
        {
            var faculties = _db.Faculty.ToList();

            // Check if any faculties are fetched
            if (faculties != null && faculties.Any())
            {
                // Populate ViewBag with the list of faculties
                ViewBag.Faculties = faculties;
            }
            else
            {
                ViewBag.Faculties = new List<Faculty>(); // Empty list if no faculties are found
            }

            if (eventId == null || eventId == 0)
            {
                return NotFound();
            }
            Event? eventItem = _db.Events.Find(eventId);
            if (eventItem == null)
            {
                return NotFound();
            }
            return View("~/Views/AdminViews/Event/Edit.cshtml", eventItem);
        }

        [HttpPost]
        public IActionResult Edit(Event obj)
        {
            if (ModelState.IsValid)
            {
                _db.Events.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Event updated successfully";
                return RedirectToAction("Index");
            }
            return View("~/Views/AdminViews/Event/Edit.cshtml");
        }

        public IActionResult Delete(long? eventId)
        {
            var faculties = _db.Faculty.ToList();

            // Check if any faculties are fetched
            if (faculties != null && faculties.Any())
            {
                // Populate ViewBag with the list of faculties
                ViewBag.Faculties = faculties;
            }
            else
            {
                ViewBag.Faculties = new List<Faculty>(); // Empty list if no faculties are found
            }

            if (eventId == null || eventId == 0)
            {
                return NotFound();
            }
            Event? eventItem = _db.Events.Find(eventId);
            if (eventItem == null)
            {
                return NotFound();
            }
            return View("~/Views/AdminViews/Event/Delete.cshtml", eventItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(long? eventId)
        {
            if (eventId == null || eventId == 0)
            {
                return NotFound();
            }
            Event? eventItem = _db.Events.Find(eventId);
            if (eventItem == null)
            {
                return NotFound();
            }
            _db.Events.Remove(eventItem);
            _db.SaveChanges();
            TempData["success"] = "Event removed successfully";
            return RedirectToAction("Index");
        }
    }
}
