using Microsoft.AspNetCore.Mvc;
using StudentDevelopmentPortal.Data;
using StudentDevelopmentPortal.Models.AdminModels;

namespace StudentDevelopmentPortal.Controllers.FacultyControllers
{
    public class FacultyJobReadinessController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FacultyJobReadinessController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(long? FacultyId)
        {
            ViewBag.FacultyId = FacultyId;
            List<JobReadiness> jobReadinessList = _db.JobRedinessQ.Where(j=>j.FacultyId==FacultyId).ToList();
            return View("~/Views/FacultyViews/FacultyJobreadiness/Index.cshtml", jobReadinessList);
        }

        public IActionResult Create(long? FacultyId)
        {
            ViewBag.FacultyId = FacultyId;
            Faculty? FacultyFromDb = _db.Faculty.Find(FacultyId);
            ViewBag.FacultyName = FacultyFromDb.FullName;

            return View("~/Views/FacultyViews/FacultyJobreadiness/Create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(JobReadiness obj)
        {
            ViewBag.FacultyId = obj.FacultyId;
            if (ModelState.IsValid)
            {
                _db.JobRedinessQ.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Content added successfully";

                List<JobReadiness> jobReadinessList = _db.JobRedinessQ.Where(j => j.FacultyId == obj.FacultyId).ToList();
                return View("~/Views/FacultyViews/FacultyJobreadiness/Index.cshtml",jobReadinessList);
            }
            return View("~/Views/FacultyViews/FacultyJobreadiness/Create.cshtml", obj);
        }

        public IActionResult Edit(string questionId)
        {
            if (questionId == null)
            {
                return NotFound();
            }
            JobReadiness? jobReadiness = _db.JobRedinessQ.Find(questionId);
            ViewBag.FacultyId = jobReadiness.FacultyId;
            Faculty? FacultyFromDb = _db.Faculty.Find(jobReadiness.FacultyId);
            ViewBag.FacultyName = FacultyFromDb.FullName;
            if (jobReadiness == null)
            {
                return NotFound();
            }
            return View("~/Views/FacultyViews/FacultyJobreadiness/Edit.cshtml", jobReadiness);
        }

        [HttpPost]
        public IActionResult Edit(JobReadiness obj)
        {
            ViewBag.FacultyId = obj.FacultyId;
            Faculty? FacultyFromDb = _db.Faculty.Find(obj.FacultyId);
            ViewBag.FacultyName = FacultyFromDb.FullName;
            if (ModelState.IsValid)
            {
                _db.JobRedinessQ.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Content Updated successfully";
                List<JobReadiness> jobReadinessList = _db.JobRedinessQ.Where(j => j.FacultyId == obj.FacultyId).ToList();
                return View("~/Views/FacultyViews/FacultyJobreadiness/Index.cshtml", jobReadinessList);
            }
            return View("~/Views/FacultyViews/FacultyJobreadiness/Index.cshtml", ViewBag.FacultyId);
        }

        public IActionResult Delete(string questionId)
        {
            if (questionId == null)
            {
                return NotFound();
            }
            JobReadiness? jobReadiness = _db.JobRedinessQ.Find(questionId);
            ViewBag.FacultyId = jobReadiness.FacultyId;
            Faculty? FacultyFromDb = _db.Faculty.Find(jobReadiness.FacultyId);
            ViewBag.FacultyName = FacultyFromDb.FullName;

            if (jobReadiness == null)
            {
                return NotFound();
            }
            return View("~/Views/FacultyViews/FacultyJobreadiness/Delete.cshtml", jobReadiness);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string questionId)
        {
            JobReadiness? obj = _db.JobRedinessQ.Find(questionId);
            ViewBag.FacultyId = obj.FacultyId;
            if (obj == null)
            {
                return NotFound();
            }
            _db.JobRedinessQ.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Content removed successfully";
            List<JobReadiness> jobReadinessList = _db.JobRedinessQ.Where(j => j.FacultyId == obj.FacultyId).ToList();
            return View("~/Views/FacultyViews/FacultyJobreadiness/Index.cshtml", jobReadinessList);
        }
    }
}
