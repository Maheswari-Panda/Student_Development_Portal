using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentDevelopmentPortal.Data;
using StudentDevelopmentPortal.Models.AdminModels;

namespace StudentDevelopmentPortal.Controllers.AdminControllers
{
    public class JobReadinessController : Controller
    {
        private readonly ApplicationDbContext _db;

        public JobReadinessController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<JobReadiness> jobReadinessList = _db.JobRedinessQ.ToList();
            return View("~/Views/AdminViews/JobReadiness/Index.cshtml", jobReadinessList);
        }

        public IActionResult StudentIndex(long Prn)
        {
            ViewBag.Prn = Prn;
            List<JobReadiness> jobReadinessList = _db.JobRedinessQ.ToList();
            return View("~/Views/StudentViews/StudentJobReadiness/Index.cshtml", jobReadinessList);
        }

        public IActionResult Create()
        {
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

            return View("~/Views/AdminViews/JobReadiness/Create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(JobReadiness obj)
        {
            if (ModelState.IsValid)
            {
                _db.JobRedinessQ.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Content added successfully";
                return RedirectToAction("Index");
            }
            return View("~/Views/AdminViews/JobReadiness/Create.cshtml");
        }

        public IActionResult Edit(string questionId)
        {

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

            if (questionId == null)
            {
                return NotFound();
            }
            JobReadiness? jobReadiness = _db.JobRedinessQ.Find(questionId);
            if (jobReadiness == null)
            {
                return NotFound();
            }
            return View("~/Views/AdminViews/JobReadiness/Edit.cshtml", jobReadiness);
        }

        [HttpPost]
        public IActionResult Edit(JobReadiness obj)
        {
            if (ModelState.IsValid)
            {
                _db.JobRedinessQ.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Content Updated successfully";
                return RedirectToAction("Index");
            }
            return View("~/Views/AdminViews/JobReadiness/Edit.cshtml");
        }

        public IActionResult Delete(string questionId)
        {

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
            if (questionId == null)
            {
                return NotFound();
            }
            JobReadiness? jobReadiness = _db.JobRedinessQ.Find(questionId);
            if (jobReadiness == null)
            {
                return NotFound();
            }
            return View("~/Views/AdminViews/JobReadiness/Delete.cshtml", jobReadiness);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string questionId)
        {
            JobReadiness? obj = _db.JobRedinessQ.Find(questionId);
            if (obj == null)
            {
                return NotFound();
            }
            _db.JobRedinessQ.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Content removed successfully";
            return RedirectToAction("Index");
        }
    }

}
