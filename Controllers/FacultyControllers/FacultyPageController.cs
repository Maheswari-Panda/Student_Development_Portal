using Microsoft.AspNetCore.Mvc;
using StudentDevelopmentPortal.Data;
using StudentDevelopmentPortal.Models.AdminModels;

namespace StudentDevelopmentPortal.Controllers.FacultyControllers
{
    public class FacultyPageController : Controller
    {
        public readonly ApplicationDbContext _db;
        public FacultyPageController(ApplicationDbContext db) { _db = db; }
        public IActionResult Index()
        {
            return View("~/Views/FacultyViews/Dashboard/Index.cshtml");
        }
        public IActionResult BackToIndex(long? FacultyId)
        {
            ViewBag.FacultyId = FacultyId;
            if (FacultyId == null || FacultyId == 0)
            {
                return NotFound();
            }
            Faculty? FacultyFromDb = _db.Faculty.Find(FacultyId);
            if (FacultyFromDb == null)
            {
                return NotFound();
            }
            return View("~/Views/FacultyViews/Dashboard/Index.cshtml", FacultyFromDb);
        }

        public IActionResult Profile(long? FacultyId)
        {
            ViewBag.FacultyId = FacultyId;
            if (FacultyId == null || FacultyId == 0)
            {
                return NotFound();
            }
            Faculty? FacultyFromDb = _db.Faculty.Find(FacultyId);
            if (FacultyFromDb == null)
            {
                return NotFound();
            }
            return View("~/Views/FacultyViews/Dashboard/Profile.cshtml", FacultyFromDb);
        }
        [HttpPost]
        public IActionResult Profile(Faculty obj)
        {

            ViewBag.FacultyId = obj.FacultyId;
            if (ModelState.IsValid)
            {
                _db.Faculty.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Your Info updated successfully";
                return View("~/Views/FacultyViews/Dashboard/Index.cshtml", obj);
            }
            TempData["error"] = "Error occured";
            return View("~/Views/FacultyViews/Dashboard/Index.cshtml", obj);
        }
    }
}
