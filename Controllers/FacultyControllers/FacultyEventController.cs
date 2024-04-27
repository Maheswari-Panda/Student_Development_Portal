using Microsoft.AspNetCore.Mvc;
using StudentDevelopmentPortal.Data;
using StudentDevelopmentPortal.Models.AdminModels;

namespace StudentDevelopmentPortal.Controllers.FacultyControllers
{
    public class FacultyEventController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FacultyEventController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(long? FacultyId)
        {
            ViewBag.FacultyId = FacultyId;
            List<Event> EventList = _db.Events.Where(j => j.FacultyId == FacultyId).ToList();
            return View("~/Views/FacultyViews/FacultyEvent/Index.cshtml", EventList);
        }

        public IActionResult Create(long? FacultyId)
        {
            ViewBag.FacultyId = FacultyId;
            Faculty? FacultyFromDb = _db.Faculty.Find(FacultyId);
            ViewBag.FacultyName = FacultyFromDb.FullName;

            return View("~/Views/FacultyViews/FacultyEvent/Create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(Event obj)
        {
            ViewBag.FacultyId = obj.FacultyId;
            if (ModelState.IsValid)
            {
                _db.Events.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Event added successfully";

                List<Event> EventList = _db.Events.Where(j => j.FacultyId == obj.FacultyId).ToList();
                return View("~/Views/FacultyViews/FacultyEvent/Index.cshtml", EventList);
            }

            TempData["success"] = "Something went Wrong!";
            return View("~/Views/FacultyViews/FacultyEvent/Create.cshtml", obj);
        }

        public IActionResult Edit(long eventId)
        {
            if (eventId == null || eventId==0)
            {
                return NotFound();
            }
            Event? events = _db.Events.Find(eventId);
            ViewBag.FacultyId = events.FacultyId;
            Faculty? FacultyFromDb = _db.Faculty.Find(events.FacultyId);
            ViewBag.FacultyName = FacultyFromDb.FullName;
            if (events == null)
            {
                return NotFound();
            }
            return View("~/Views/FacultyViews/FacultyEvent/Edit.cshtml", events);
        }

        [HttpPost]
        public IActionResult Edit(Event obj)
        {
            ViewBag.FacultyId = obj.FacultyId;
            Faculty? FacultyFromDb = _db.Faculty.Find(obj.FacultyId);
            ViewBag.FacultyName = FacultyFromDb.FullName;
            if (ModelState.IsValid)
            {
                _db.Events.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Event Updated successfully";
                List<Event> EventList = _db.Events.Where(j => j.FacultyId == obj.FacultyId).ToList();
                return View("~/Views/FacultyViews/FacultyEvent/Index.cshtml", EventList);
            }
            return View("~/Views/FacultyViews/FacultyEvent/Index.cshtml", ViewBag.FacultyId);
        }

        public IActionResult Delete(long eventId)
        {
            if (eventId == null || eventId==0)
            {
                return NotFound();
            }
            Event? events = _db.Events.Find(eventId);
            ViewBag.FacultyId = events.FacultyId;
            Faculty? FacultyFromDb = _db.Faculty.Find(events.FacultyId);
            ViewBag.FacultyName = FacultyFromDb.FullName;
            if (events == null)
            {
                return NotFound();
            }
            return View("~/Views/FacultyViews/FacultyEvent/Delete.cshtml", events);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(long eventId)
        {
            Event? obj = _db.Events.Find(eventId);
            ViewBag.FacultyId = obj.FacultyId;
            if (obj == null)
            {
                return NotFound();
            }
            _db.Events.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Event removed successfully";
            List<Event> EventList = _db.Events.Where(j => j.FacultyId == obj.FacultyId).ToList();
            return View("~/Views/FacultyViews/FacultyEvent/Index.cshtml", EventList);
        }
    }
}
