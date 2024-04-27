using Microsoft.AspNetCore.Mvc;
using StudentDevelopmentPortal.Data;
using StudentDevelopmentPortal.Models.AdminModels;
using StudentDevelopmentPortal.Models.StudentModels;

namespace StudentDevelopmentPortal.Controllers.StudentControllers
{
    public class StudentProblemController : Controller
    {
            public readonly ApplicationDbContext _db;
            public StudentProblemController(ApplicationDbContext db) { _db = db; }
            public IActionResult Index(long? Prn)
            {
                ViewBag.Prn = Prn;
                List<Problem> objProblemList = _db.Problems.ToList();
                return View("~/Views/StudentViews/StudentProblem/Index.cshtml", objProblemList);
            }
        
        public IActionResult SolveProblem(long? Prn,string problemId)
        {
            ViewBag.Prn = Prn;
            if (problemId == null)
            {
                return NotFound();
            }
            Problem? problemFromDb = _db.Problems.Find(problemId);
            ViewBag.Problem = problemFromDb;
            if (problemFromDb == null)
            {
                return NotFound();
            }
            return View("~/Views/StudentViews/StudentProblem/SolveProblem.cshtml");
        }
        [HttpPost]
        public IActionResult SolveProblem(StudentProblem obj)
        {
            ViewBag.Prn = obj.Prn;

            if (ModelState.IsValid)
            {
                _db.StudentProblems.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Solution Submitted successfully";
                var problems = _db.Problems.ToList();

                if (problems != null)
                {
                    ViewBag.Problems = problems;
                }
                else
                {
                    ViewBag.Problems = new List<Problem>();
                }
                return View("~/Views/StudentViews/StudentProblem/Index.cshtml",problems);
            }
            TempData["error"] = "Something went wrong!";
            return View("~/Views/StudentViews/StudentProblem/SolveProblem.cshtml",(obj.Prn,obj.ProblemId));
        }
    }
}
