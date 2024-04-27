using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using StudentDevelopmentPortal.Data;
using StudentDevelopmentPortal.Models;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace StudentDevelopmentPortal.Controllers.AdminControllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _logger;

        public HomeController(ApplicationDbContext logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View("~/Views/AdminViews/Home/Login.cshtml");
        }

        [HttpPost]
        public IActionResult Login(string UserId, string Password, string Role)
        {
            Role = Role.ToUpper();

            if (Role == "ADMIN")
            {
                var isAdminValid = _logger.Admins.Any(admin =>
                    admin.AdminId == UserId &&
                    admin.AdminPassword == Password
                );
                if (isAdminValid) { 
                    return RedirectToAction("Index");
                }
            }

            if (Role == "STUDENT")
            {
                var isStudentValid = _logger.Students.Any(student =>
                    student.Prn == (long)Convert.ToInt64(UserId) &&
                    student.Password == Password
                );
                if(isStudentValid)
                {
                    ViewBag.Prn = (long)Convert.ToInt64(UserId);
                    ViewBag.StudentObj = _logger.Students.FirstOrDefault(student => student.Prn == (long)Convert.ToInt64(UserId));
                    return View("~/Views/StudentViews/Dashboard/Index.cshtml",ViewBag.StudentObj);
                }
            }

            if (Role == "FACULTY")
            {
                var isFacultyValid = _logger.Faculty.Any(faculty =>
                    faculty.FacultyId == (long)Convert.ToInt64(UserId) &&
                    faculty.Password == Password
                );
                if (isFacultyValid)
                {
                    ViewBag.FacultyId = (long)Convert.ToInt64(UserId);
                    ViewBag.FacultyObj = _logger.Faculty.FirstOrDefault(faculty => faculty.FacultyId == (long)Convert.ToInt64(UserId));
                    return View("~/Views/FacultyViews/Dashboard/Index.cshtml", ViewBag.FacultyObj);
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid user ID or password. Please Try Again!");
            return View("~/Views/AdminViews/Home/Login.cshtml");
        }
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public IActionResult LogOut()
        {
            ViewBag.CloseWindowScript = "<script>window.open('', '_self', ''); window.close();</script>";
            return RedirectToAction("Login","Home");
        }
        public IActionResult Index()
        {

            ViewData["NumberOfAdmins"] = _logger.Admins.Count();
            ViewData["NumberOfStudents"] = _logger.Students.Count();
            ViewData["NumberOfFaculty"] = _logger.Faculty.Count();
            ViewData["NumberOfCourses"] = _logger.Courses.Count();
            ViewData["NumberOfProblems"] = _logger.Problems.Count();
            ViewData["NumberOfAssignments"] = _logger.Assignments.Count();
            ViewData["NumberOfJobReadiness"] = _logger.JobRedinessQ.Count();
            ViewData["NumberOfEvents"] = _logger.Events.Count();

            return View("~/Views/AdminViews/Home/Index.cshtml");
        }

        public IActionResult Privacy()
        {
            return View("~/Views/AdminViews/Home/Privacy.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
