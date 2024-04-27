using Microsoft.AspNetCore.Mvc;
using StudentDevelopmentPortal.Data;
using StudentDevelopmentPortal.Models.AdminModels;
using System.Collections.Generic;
using System.Linq;

namespace StudentDevelopmentPortal.Controllers.AdminControllers
{
    public class AssignmentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AssignmentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Assignment> assignments = _db.Assignments.ToList();
            return View("~/Views/AdminViews/Assignment/Index.cshtml",assignments);
        }

        public IActionResult Create()
        {
            var courses = _db.Courses.ToList();

            if (courses != null && courses.Any())
            {
                ViewBag.Courses = courses;
            }
            else
            {
                ViewBag.Courses = new List<Course>(); 
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

            // Return your view
            return View("~/Views/AdminViews/Assignment/Create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _db.Assignments.Add(assignment);
                _db.SaveChanges();
                TempData["success"] = "Assignment added successfully";
                return RedirectToAction("Index");
            }
            return View("~/Views/AdminViews/Assignment/Create.cshtml");
        }

        public IActionResult Edit(long? assignmentId)
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

            if (assignmentId == null || assignmentId == 0)
            {
                return NotFound();
            }

            Assignment? assignment = _db.Assignments.Find(assignmentId);

            if (assignment == null)
            {
                return NotFound();
            }

            return View("~/Views/AdminViews/Assignment/Edit.cshtml", assignment);
        }

        [HttpPost]
        public IActionResult Edit(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _db.Assignments.Update(assignment);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["success"] = "Assignment Updated successfully";
            return View("~/Views/AdminViews/Assignment/Edit.cshtml");
        }

        public IActionResult Delete(long? assignmentId)
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

            if (assignmentId == null || assignmentId == 0)
            {
                return NotFound();
            }

            Assignment? assignment = _db.Assignments.Find(assignmentId);

            if (assignment == null)
            {
                return NotFound();
            }

            return View("~/Views/AdminViews/Assignment/Delete.cshtml", assignment);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(long? assignmentId)
        {
            if (assignmentId == null || assignmentId == 0)
            {
                return NotFound();
            }

            Assignment? assignment = _db.Assignments.Find(assignmentId);

            if (assignment == null)
            {
                return NotFound();
            }

            _db.Assignments.Remove(assignment);
            _db.SaveChanges();
            TempData["success"] = "Assignment Removed successfully";
            return RedirectToAction("Index");
        }
    }
}
