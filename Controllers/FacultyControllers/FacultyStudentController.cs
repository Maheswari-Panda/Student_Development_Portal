using Microsoft.AspNetCore.Mvc;
using StudentDevelopmentPortal.Data;
using StudentDevelopmentPortal.Models.AdminModels;

namespace StudentDevelopmentPortal.Controllers.FacultyControllers
{
    public class FacultyStudentController : Controller
    {
        public readonly ApplicationDbContext _db;
        public FacultyStudentController(ApplicationDbContext db) { _db = db; }
        public IActionResult Index(long FacultyId)
        {
            ViewBag.FacultyId = FacultyId;
            ViewData["FSBEI_Students"] = _db.Students.Where(s => s.Program.Equals("FS BE-I")).Count();
            ViewData["FSBEII_Students"] = _db.Students.Where(s => s.Program.Equals("FS BE-II")).Count();
            ViewData["FSBEIII_Students"] = _db.Students.Where(s => s.Program.Equals("FS BE-III")).Count();
            ViewData["FSBEIV_Students"] = _db.Students.Where(s => s.Program.Equals("FS BE-IV")).Count();
            ViewData["SSBEI_Students"] = _db.Students.Where(s => s.Program.Equals("SS BE-I")).Count();
            ViewData["SSBEIi_Students"] = _db.Students.Where(s => s.Program.Equals("SS BE-II")).Count();
            ViewData["SSBEIII_Students"] = _db.Students.Where(s => s.Program.Equals("SS BE-III")).Count();
            ViewData["SSBEIV_Students"] = _db.Students.Where(s => s.Program.Equals("SS BE-IV")).Count();
            return View("~/Views/FacultyViews/FacultyStudent/Index.cshtml");
        }
        public IActionResult GetStudents(string Program,long FacultyId)
		{
            ViewBag.FacultyId = FacultyId;
			List<Student> objStudentList = _db.Students.Where(s=>s.Program.Equals(Program)).ToList();
			return View("~/Views/FacultyViews/FacultyStudent/StudentIndex.cshtml",objStudentList);
        }
    }
}
