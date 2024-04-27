using Microsoft.AspNetCore.Mvc;
using StudentDevelopmentPortal.Data;
using StudentDevelopmentPortal.Models.AdminModels;
using StudentDevelopmentPortal.Models.StudentModels;

namespace StudentDevelopmentPortal.Controllers.FacultyControllers
{
    public class FacultyProblemController : Controller
    {
        public readonly ApplicationDbContext _db;
        public FacultyProblemController(ApplicationDbContext db) { _db = db; }
        public IActionResult Index(long? FacultyId)
        {
            ViewBag.FacultyId = FacultyId;
            var faculty = _db.Faculty.FirstOrDefault(s => s.FacultyId == FacultyId);

            if (faculty != null)
            {
                var facultyCourseIds = _db.FacultyCourses.Where(sc => sc.FacultyId == faculty.FacultyId).Select(sc => sc.CourseId).ToList();
                var Assignedcourses = _db.Courses.Where(c => facultyCourseIds.Contains(c.CourseId)).ToList();
                ViewBag.AssignedCourses = Assignedcourses;
            }
            else
            {
                ViewBag.AssignedCourses = new List<Course>();
            }

            return View("~/Views/FacultyViews/FacultyProblem/Index.cshtml");
        }


        public IActionResult ProblemIndex(long? FacultyId, string courseId)
        {
            ViewBag.FacultyId = FacultyId;
            Faculty? FacultyFromDb = _db.Faculty.Find(FacultyId);
            ViewBag.FacultyName = FacultyFromDb.FullName;


            Course? CourseFromDb = _db.Courses.Find(courseId);
            ViewBag.CourseName = CourseFromDb.CourseName;

            if (FacultyId != null || FacultyId != 0)
            {
                var assignedProblems = _db.Problems.Where(c => (c.CourseId.Equals(courseId) && c.FacultyId.Equals(FacultyId))).ToList();
                ViewBag.AssignedProblems = assignedProblems;
            }
            else
            {
                ViewBag.AssignedProblems = new List<Problem>();
            }

            return View("~/Views/FacultyViews/FacultyProblem/ProblemIndex.cshtml");
        }
        public IActionResult Create(long? FacultyId)
        {
            ViewBag.FacultyId = FacultyId;
            Faculty? FacultyFromDb = _db.Faculty.Find(FacultyId);
            ViewBag.FacultyName = FacultyFromDb.FullName;

            if (FacultyId != 0 || FacultyId != null)
            {
                var facultyCourseIds = _db.FacultyCourses.Where(sc => sc.FacultyId == FacultyId).Select(sc => sc.CourseId).ToList();
                var courses = _db.Courses.Where(c => facultyCourseIds.Contains(c.CourseId)).ToList();
                if (courses != null && courses.Any())
                {
                    ViewBag.Courses = courses;
                }
                else
                {
                    ViewBag.Courses = new List<Course>();
                }
            }
            return View("~/Views/FacultyViews/FacultyProblem/Create.cshtml");
        }


        [HttpPost]
        public IActionResult Create(Problem obj)
        {
            ViewBag.FacultyId = obj.FacultyId;
            Faculty? FacultyFromDb = _db.Faculty.Find(obj.FacultyId);
            ViewBag.FacultyName = FacultyFromDb.FullName;

            if (ModelState.IsValid)
            {
                _db.Problems.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Problem added successfully";

                var assignedProblems = _db.Problems.Where(c => (c.CourseId.Equals(obj.CourseId)) && c.FacultyId.Equals(obj.FacultyId)).ToList();
                ViewBag.AssignedProblems = assignedProblems;
                return View("~/Views/FacultyViews/FacultyProblem/ProblemIndex.cshtml");
            }

            TempData["error"] = "Something went Wrong!";
            return View("~/Views/FacultyViews/FacultyProblem/Create.cshtml", obj);
        }


        public IActionResult Edit(string? problemId)
        {
            if (problemId == "" || problemId == null)
            {
                return NotFound();
            }

            Problem? obj = _db.Problems.Find(problemId);
            ViewBag.FacultyId = obj.FacultyId;
            Faculty? FacultyFromDb = _db.Faculty.Find(obj.FacultyId);
            ViewBag.FacultyName = FacultyFromDb.FullName;


            var facultyCourseIds = _db.FacultyCourses.Where(sc => sc.FacultyId == obj.FacultyId).Select(sc => sc.CourseId).ToList();
            var courses = _db.Courses.Where(c => facultyCourseIds.Contains(c.CourseId)).ToList();
            if (courses != null && courses.Any())
            {
                ViewBag.Courses = courses;
            }
            else
            {
                ViewBag.Courses = new List<Course>();
            }

            if (obj == null)
            {
                return NotFound();
            }
            return View("~/Views/FacultyViews/FacultyProblem/Edit.cshtml", obj);
        }

        [HttpPost]
        public IActionResult Edit(Problem obj)
        {
            ViewBag.FacultyId = obj.FacultyId;
            Faculty? FacultyFromDb = _db.Faculty.Find(obj.FacultyId);
            ViewBag.FacultyName = FacultyFromDb.FullName;

            if (ModelState.IsValid)
            {
                _db.Problems.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Problem updated successfully";

                var assignedProblems = _db.Problems.Where(c => (c.CourseId.Equals(obj.CourseId) && c.FacultyId.Equals(obj.FacultyId))).ToList();
                ViewBag.AssignedProblems = assignedProblems;
                return View("~/Views/FacultyViews/FacultyProblem/ProblemIndex.cshtml");
            }

            TempData["error"] = "Something went Wrong!";
            return View("~/Views/FacultyViews/FacultyProblem/Edit.cshtml", obj);
        }

        public IActionResult Delete(string problemId)
        {
            if (problemId == null || problemId == "")
            {
                return NotFound();
            }
            Problem? obj = _db.Problems.Find(problemId);
            ViewBag.FacultyId = obj.FacultyId;
            Faculty? FacultyFromDb = _db.Faculty.Find(obj.FacultyId);
            ViewBag.FacultyName = FacultyFromDb.FullName;


            var facultyCourseIds = _db.FacultyCourses.Where(sc => sc.FacultyId == obj.FacultyId).Select(sc => sc.CourseId).ToList();
            var courses = _db.Courses.Where(c => facultyCourseIds.Contains(c.CourseId)).ToList();
            if (courses != null && courses.Any())
            {
                ViewBag.Courses = courses;
            }
            else
            {
                ViewBag.Courses = new List<Course>();
            }

            if (obj == null)
            {
                return NotFound();
            }
            return View("~/Views/FacultyViews/FacultyProblem/Delete.cshtml", obj);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string problemId)
        {
            Problem? obj = _db.Problems.Find(problemId);
            ViewBag.FacultyId = obj.FacultyId;
            if (obj == null)
            {
                return NotFound();
            }
            _db.Problems.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Problem removed successfully";

            var assignedProblems = _db.Problems.Where(c => (c.CourseId.Equals(obj.CourseId) && c.FacultyId.Equals(obj.FacultyId))).ToList();
            ViewBag.AssignedProblems = assignedProblems;
            return View("~/Views/FacultyViews/FacultyProblem/ProblemIndex.cshtml");
        }

        public IActionResult ViewSubmissions(string problemId,long FacultyId)
        {
            Problem? obj = _db.Problems.Find(problemId);
            ViewBag.ProblemId = obj.ProblemId;
            ViewBag.FacultyId = obj.FacultyId;

            var studentProblemIds = _db.StudentProblems.Where(sc => sc.ProblemId.Equals(problemId)).Select(sc => sc.Prn).ToList();

            var studentMarks = _db.StudentProblems.Where(sc => sc.ProblemId.Equals(problemId)).Select(sc => sc.IsCorrect).ToList();
            ViewBag.StudentIsCorrect = studentMarks;
            List<Student> objStudentList = _db.Students.Where(s => studentProblemIds.Contains(s.Prn)).ToList();
            return View("~/Views/FacultyViews/FacultyProblem/StudentSubmissions.cshtml", objStudentList);
        }
        public IActionResult ViewSolution(long Prn, string ProblemId, long FacultyId)
        {
            StudentProblem? obj = _db.StudentProblems.FirstOrDefault(s => s.Prn == Prn && s.ProblemId == ProblemId);
            Problem? ProblemObj = _db.Problems.Find(ProblemId);
            ViewBag.ProblemObj = ProblemObj;
            ViewBag.FacultyId = FacultyId;

            return View("~/Views/FacultyViews/FacultyProblem/ViewSolution.cshtml", obj);
        }

    }
}
