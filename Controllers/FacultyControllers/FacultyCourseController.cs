using Microsoft.AspNetCore.Mvc;
using StudentDevelopmentPortal.Data;
using StudentDevelopmentPortal.Models.AdminModels;
using StudentDevelopmentPortal.Models.StudentModels;
using StudentDevelopmentPortal.Models.FacultyModels;

namespace StudentDevelopmentPortal.Controllers.FacultyControllers
{
    public class FacultyCourseController : Controller
    {
        public readonly ApplicationDbContext _db;
        public FacultyCourseController(ApplicationDbContext db) { _db = db; }
        public IActionResult Index(long? FacultyId)
        {
            ViewBag.FacultyId = FacultyId;
            var faculty = _db.Faculty.FirstOrDefault(s => s.FacultyId == FacultyId);

            if (faculty != null)
            {
                var facultyCourseIds = _db.FacultyCourses.Where(sc => sc.FacultyId == faculty.FacultyId).Select(sc => sc.CourseId).ToList();
                var courses = _db.Courses.Where(c=>!facultyCourseIds.Contains(c.CourseId)).ToList();
                var Assignedcourses = _db.Courses.Where(c=>facultyCourseIds.Contains(c.CourseId)).ToList();
                ViewBag.AssignedCourses = Assignedcourses;
                ViewBag.Courses = courses;
            }
            else
            {
                ViewBag.Courses = new List<Course>();
            }

            return View("~/Views/FacultyViews/FacultyCourse/Index.cshtml");
        }

        [HttpPost]
        public IActionResult Index(FacultyCourse obj)
        {
            ViewBag.FacultyId = obj.FacultyId;

            if (ModelState.IsValid)
            {
                _db.FacultyCourses.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Course added successfully";
                var faculty = _db.Faculty.FirstOrDefault(s => s.FacultyId == obj.FacultyId);

                if (faculty != null)
                {
                    var facultyCourseIds = _db.FacultyCourses.Where(sc => sc.FacultyId == faculty.FacultyId).Select(sc => sc.CourseId).ToList();
                    var courses = _db.Courses.Where(c => !facultyCourseIds.Contains(c.CourseId)).ToList();
                    var Assignedcourses = _db.Courses.Where(c => facultyCourseIds.Contains(c.CourseId)).ToList();
                    ViewBag.AssignedCourses = Assignedcourses;
                    ViewBag.Courses = courses;
                }
                else
                {
                    ViewBag.Courses = new List<Course>();
                }

                return View("~/Views/FacultyViews/FacultyCourse/Index.cshtml");
            }

            TempData["error"] = "Course cannot added! Try Again";
            return View("~/Views/FacultyViews/FacultyCourse/Index.cshtml");
        }
    }
}
