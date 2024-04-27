using Microsoft.AspNetCore.Mvc;
using StudentDevelopmentPortal.Data;
using StudentDevelopmentPortal.Models.AdminModels;

namespace StudentDevelopmentPortal.Controllers.AdminControllers
{
    public class FacultyController : Controller
    {
        public readonly ApplicationDbContext _db;
        public FacultyController(ApplicationDbContext db) { _db = db; }
        public IActionResult Index()
        {
            List<Faculty> objFacultyList = _db.Faculty.ToList();
            return View("~/Views/AdminViews/Faculty/Index.cshtml", objFacultyList);
        }

        public IActionResult Create()
        {
            return View("~/Views/AdminViews/Faculty/Create.cshtml");
        }
        [HttpPost]
        public IActionResult Create(Faculty obj)
        {
            if (ModelState.IsValid)
            {
                _db.Faculty.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Faculty added successfully";
                return RedirectToAction("Index");
            }
            return View("~/Views/AdminViews/Faculty/Create.cshtml");
        }


        public IActionResult Edit(long? FacultyId)
        {
            if (FacultyId == null || FacultyId == 0)
            {
                return NotFound();
            }
            Faculty? FacultyFromDb = _db.Faculty.Find(FacultyId);
            if (FacultyFromDb == null)
            {
                return NotFound();
            }
            return View("~/Views/AdminViews/Faculty/Edit.cshtml", FacultyFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Faculty obj)
        {
            if (ModelState.IsValid)
            {
                _db.Faculty.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Faculty updated successfully";
                return RedirectToAction("Index");
            }
            return View("~/Views/AdminViews/Faculty/Edit.cshtml");
        }


        public IActionResult Delete(long? FacultyId)
        {
            if (FacultyId == null || FacultyId == 0)
            {
                return NotFound();
            }
            Faculty? FacultyFromDb = _db.Faculty.Find(FacultyId);
            if (FacultyFromDb == null)
            {
                return NotFound();
            }
            return View("~/Views/AdminViews/Faculty/Delete.cshtml", FacultyFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(long? FacultyId)
        {
            Faculty? obj = _db.Faculty.Find(FacultyId);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Faculty.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Faculty removed successfully";
            return RedirectToAction("Index");
        }
    }
}
