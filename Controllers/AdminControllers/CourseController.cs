using Microsoft.AspNetCore.Mvc;
using StudentDevelopmentPortal.Data;
using StudentDevelopmentPortal.Models.AdminModels;

namespace StudentDevelopmentPortal.Controllers.AdminControllers
{
    public class CourseController : Controller
    {
        public readonly ApplicationDbContext _db;
        public CourseController(ApplicationDbContext db) { _db = db; }
        public IActionResult Index()
        {
            List<Course> objCourseList = _db.Courses.ToList();
            return View("~/Views/AdminViews/Course/Index.cshtml", objCourseList);
        }

        public IActionResult Create()
        {
            return View("~/Views/AdminViews/Course/Create.cshtml");
        }
        [HttpPost]
        public IActionResult Create(Course obj)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Course added successfully";
                return RedirectToAction("Index");
            }
            return View("~/Views/AdminViews/Course/Create.cshtml");
        }


        public IActionResult Edit(string? CourseId)
        {
            if (CourseId == null || CourseId == "")
            {
                return NotFound();
            }
            Course? CourseFromDb = _db.Courses.Find(CourseId);
            if (CourseFromDb == null)
            {
                return NotFound();
            }
            return View("~/Views/AdminViews/Course/Edit.cshtml", CourseFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Course obj)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Course updated successfully";
                return RedirectToAction("Index");
            }
            return View("~/Views/AdminViews/Course/Edit.cshtml");
        }


        public IActionResult Delete(string? CourseId)
        {
            if (CourseId == null || CourseId == "")
            {
                return NotFound();
            }
            Course? CourseFromDb = _db.Courses.Find(CourseId);
            if (CourseFromDb == null)
            {
                return NotFound();
            }
            return View("~/Views/AdminViews/Course/Delete.cshtml",CourseFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(string? CourseId)
        {
            Course? obj = _db.Courses.Find(CourseId);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Courses.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Course removed successfully";
            return RedirectToAction("Index");
        }
    }
}
