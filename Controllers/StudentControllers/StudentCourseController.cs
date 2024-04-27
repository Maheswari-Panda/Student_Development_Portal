using Microsoft.AspNetCore.Mvc;
using StudentDevelopmentPortal.Data;
using StudentDevelopmentPortal.Models.AdminModels;
using StudentDevelopmentPortal.Models.StudentModels;

namespace StudentDevelopmentPortal.Controllers.StudentControllers
{
    public class StudentCourseController : Controller
    {
        public readonly ApplicationDbContext _db;
        public StudentCourseController(ApplicationDbContext db) { _db = db; }
        public IActionResult Index(long? Prn)
        {
            ViewBag.Prn = Prn;
            var student = _db.Students.FirstOrDefault(s => s.Prn == Prn);
            
            if (student != null)
            {
                var studentCourseIds = _db.StudentCourses.Where(sc => sc.Prn == student.Prn).Select(sc => sc.CourseId).ToList();
                var courses = _db.Courses.Where(c => c.Program == student.Program && !studentCourseIds.Contains(c.CourseId)).ToList();
                var Enrolledcourses = _db.Courses.Where(c => c.Program == student.Program && studentCourseIds.Contains(c.CourseId)).ToList();
                ViewBag.EnrolledCourses = Enrolledcourses;
                ViewBag.Courses = courses;
            }
            else
            {
                ViewBag.Courses = new List<Course>();
            }

            return View("~/Views/StudentViews/StudentCourse/Index.cshtml");
        }

        [HttpPost]
        public IActionResult Index(StudentCourse obj)
        {
            ViewBag.Prn = obj.Prn;
            
            if (ModelState.IsValid)
            {
                _db.StudentCourses.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Course added successfully";
                var student = _db.Students.FirstOrDefault(s => s.Prn == obj.Prn);

                if (student != null)
                {
                    var studentCourseIds = _db.StudentCourses.Where(sc => sc.Prn == student.Prn).Select(sc => sc.CourseId).ToList();
                    var courses = _db.Courses.Where(c => c.Program == student.Program && !studentCourseIds.Contains(c.CourseId)).ToList();
                    var Enrolledcourses = _db.Courses.Where(c => c.Program == student.Program && studentCourseIds.Contains(c.CourseId)).ToList();
                    ViewBag.EnrolledCourses = Enrolledcourses;
                    ViewBag.Courses = courses;
                }
                else
                {
                    ViewBag.Courses = new List<Course>();
                }
                return View("~/Views/StudentViews/StudentCourse/Index.cshtml");
            }

            return View("~/Views/StudentViews/StudentCourse/Index.cshtml");
        }

	}
}
