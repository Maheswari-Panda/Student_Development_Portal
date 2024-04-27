using Microsoft.AspNetCore.Mvc;
using StudentDevelopmentPortal.Data;
using StudentDevelopmentPortal.Models.AdminModels;

namespace StudentDevelopmentPortal.Controllers.StudentControllers
{
	public class DashboardController : Controller
	{
		public readonly ApplicationDbContext _db;
		public DashboardController(ApplicationDbContext db) { _db = db; }
		public IActionResult Index()
		{
            return View("~/Views/StudentViews/Dashboard/Index.cshtml");
		}
        public IActionResult BackToIndex(long? Prn)
        {
			ViewBag.Prn = Prn;
            if (Prn == null || Prn == 0)
            {
                return NotFound();
            }
            Student? StudentFromDb = _db.Students.Find(Prn);
            if (StudentFromDb == null)
            {
                return NotFound();
            }
            return View("~/Views/StudentViews/Dashboard/Index.cshtml",StudentFromDb);
        }

        public IActionResult Profile(long? Prn)
		{
			if (Prn == null || Prn == 0)
			{
				return NotFound();
			}
			Student? StudentFromDb = _db.Students.Find(Prn);
			if (StudentFromDb == null)
			{
				return NotFound();
			}
			return View("~/Views/StudentViews/Dashboard/Profile.cshtml", StudentFromDb);
		}
		[HttpPost]
		public IActionResult Profile(Student obj)
		{
			if (ModelState.IsValid)
			{
				_db.Students.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Student Info updated successfully";
				return View("~/Views/StudentViews/Dashboard/Index.cshtml", obj);
			}
			TempData["error"] = "Error occured";
			return View("~/Views/StudentViews/Dashboard/Index.cshtml",obj);
		}

        
    }
}
