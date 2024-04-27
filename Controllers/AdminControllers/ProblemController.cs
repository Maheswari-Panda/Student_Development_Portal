using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentDevelopmentPortal.Data;
using StudentDevelopmentPortal.Models.AdminModels;

namespace StudentDevelopmentPortal.Controllers.AdminControllers
{
    public class ProblemController : Controller
    {
        public readonly ApplicationDbContext _db;
        public ProblemController(ApplicationDbContext db) { _db = db; }
        public IActionResult Index()
        {
            List<Problem> objProblemList = _db.Problems.ToList();
            return View("~/Views/AdminViews/Problem/Index.cshtml", objProblemList);
        }
        public IActionResult Create()
        {
                var courses = _db.Courses.ToList();

                // Check if any courses are fetched
                if (courses != null && courses.Any())
                {
                    // Populate ViewBag with the list of courses
                    ViewBag.Courses = courses;
                }
                else
                {
                    ViewBag.Courses = new List<Course>(); // Empty list if no courses are found
                }

                var faculties = _db.Faculty.ToList();

                // Check if any courses are fetched
                if (faculties != null && faculties.Any())
                {
                    // Populate ViewBag with the list of courses
                    ViewBag.faculties = faculties;
                }
                else
                {
                    ViewBag.faculties = new List<Faculty>(); // Empty list if no courses are found
                }
            return View("~/Views/AdminViews/Problem/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Problem obj)
        {
            if (ModelState.IsValid)
            {
                _db.Problems.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Problem added successfully";
                return RedirectToAction("Index");
            }
            return View("~/Views/AdminViews/Problem/Create.cshtml");
        }

        public IActionResult Edit(string problemId)
        {
            // Fetch the list of courses from the database
            var courses = _db.Courses.ToList();

            // Check if any courses are fetched
            if (courses != null && courses.Any())
            {
                // Populate ViewBag with the list of courses
                ViewBag.Courses = courses;
            }
            else
            {
                ViewBag.Courses = new List<Course>(); // Empty list if no courses are found
            }

            var faculties = _db.Faculty.ToList();

            // Check if any courses are fetched
            if (faculties != null && faculties.Any())
            {
                // Populate ViewBag with the list of courses
                ViewBag.faculties = faculties;
            }
            else
            {
                ViewBag.faculties = new List<Faculty>(); // Empty list if no courses are found
            }


            if (problemId == null)
            {
                return NotFound();
            }
            Problem? problemFromDb = _db.Problems.Find(problemId);
            if (problemFromDb == null)
            {
                return NotFound();
            }
            return View("~/Views/AdminViews/Problem/Edit.cshtml", problemFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Problem obj)
        {
            if (ModelState.IsValid)
            {
                _db.Problems.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Problem updated successfully";
                return RedirectToAction("Index");
            }
            return View("~/Views/AdminViews/Problem/Edit.cshtml");
        }

        public IActionResult Delete(string problemId)
        {
            if (problemId == null)
            {
                return NotFound();
            }
            Problem? problemFromDb = _db.Problems.Find(problemId);
            if (problemFromDb == null)
            {
                return NotFound();
            }
            return View("~/Views/AdminViews/Problem/Delete.cshtml", problemFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string problemId)
        {
            Problem? obj = _db.Problems.Find(problemId);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Problems.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Problem deleted successfully";
            return RedirectToAction("Index");
        }


    }
}
