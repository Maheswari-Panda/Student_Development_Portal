using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentDevelopmentPortal.Data;
using StudentDevelopmentPortal.Models.AdminModels;
using StudentDevelopmentPortal.Models.StudentModels;

namespace StudentDevelopmentPortal.Controllers.FacultyControllers
{
    public class FacultyAssignmentController : Controller
    {
        public readonly ApplicationDbContext _db;
        public FacultyAssignmentController(ApplicationDbContext db) { _db = db; }
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

            return View("~/Views/FacultyViews/FacultyAssignment/Index.cshtml");
        }

        public IActionResult AssignmentIndex(long? FacultyId,string courseId)
        {
            ViewBag.FacultyId = FacultyId;
            Faculty? FacultyFromDb = _db.Faculty.Find(FacultyId);
            ViewBag.FacultyName = FacultyFromDb.FullName;

            if (FacultyId != null || FacultyId!=0)
            {
                var assignedAssignments = _db.Assignments.Where(c => (c.CourseId.Equals(courseId)) && c.FacultyId.Equals(FacultyId.ToString())).ToList();
                ViewBag.AssignedAssignments = assignedAssignments;
            }
            else
            {
                ViewBag.AssignedAssignments = new List<Assignment>();
            }

            return View("~/Views/FacultyViews/FacultyAssignment/AssignmentIndex.cshtml");
        }

        public IActionResult Create(long? FacultyId)
        {
            ViewBag.FacultyId = FacultyId;
            Faculty? FacultyFromDb = _db.Faculty.Find(FacultyId);
            ViewBag.FacultyName = FacultyFromDb.FullName;
            if(FacultyId!=0 || FacultyId != null) { 
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
            return View("~/Views/FacultyViews/FacultyAssignment/Create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(Assignment obj)
        {
            ViewBag.FacultyId = long.Parse(obj.FacultyId);
            Faculty? FacultyFromDb = _db.Faculty.Find(long.Parse(obj.FacultyId));
            ViewBag.FacultyName = FacultyFromDb.FullName;

            if (ModelState.IsValid)
            {
                _db.Assignments.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Assignment added successfully";

                var assignedAssignments = _db.Assignments.Where(c => (c.CourseId.Equals(obj.CourseId)) && c.FacultyId.Equals(obj.FacultyId.ToString())).ToList();
                ViewBag.AssignedAssignments = assignedAssignments;
                return View("~/Views/FacultyViews/FacultyAssignment/AssignmentIndex.cshtml");
            }

            TempData["error"] = "Something went Wrong!";
            return View("~/Views/FacultyViews/FacultyAssignment/Create.cshtml", obj);
        }

        public IActionResult Edit(long? assignmentId)
        {
            if (assignmentId == 0 || assignmentId == null)
            {
                return NotFound();
            }

            Assignment? obj = _db.Assignments.Find(assignmentId);
            ViewBag.FacultyId = long.Parse(obj.FacultyId);
            Faculty? FacultyFromDb = _db.Faculty.Find(long.Parse(obj.FacultyId));
            ViewBag.FacultyName = FacultyFromDb.FullName;


            var facultyCourseIds = _db.FacultyCourses.Where(sc => sc.FacultyId == long.Parse(obj.FacultyId)).Select(sc => sc.CourseId).ToList();
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
            return View("~/Views/FacultyViews/FacultyAssignment/Edit.cshtml",obj);
        }

        [HttpPost]
        public IActionResult Edit(Assignment obj)
        {
            ViewBag.FacultyId = long.Parse(obj.FacultyId);
            Faculty? FacultyFromDb = _db.Faculty.Find(long.Parse(obj.FacultyId));
            ViewBag.FacultyName = FacultyFromDb.FullName;

            if (ModelState.IsValid)
            {
                _db.Assignments.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Assignment updated successfully";

                var assignedAssignments = _db.Assignments.Where(c => (c.CourseId.Equals(obj.CourseId)) && c.FacultyId.Equals(obj.FacultyId.ToString())).ToList();
                ViewBag.AssignedAssignments = assignedAssignments;
                return View("~/Views/FacultyViews/FacultyAssignment/AssignmentIndex.cshtml");
            }

            TempData["error"] = "Something went Wrong!";
            return View("~/Views/FacultyViews/FacultyAssignment/Edit.cshtml", obj);
        }

        public IActionResult Delete(long assignmentId)
        {
            if (assignmentId == null || assignmentId == 0)
            {
                return NotFound();
            }
            Assignment? obj = _db.Assignments.Find(assignmentId);
            ViewBag.FacultyId = long.Parse(obj.FacultyId);
            Faculty? FacultyFromDb = _db.Faculty.Find(long.Parse(obj.FacultyId));
            ViewBag.FacultyName = FacultyFromDb.FullName;


            var facultyCourseIds = _db.FacultyCourses.Where(sc => sc.FacultyId == long.Parse(obj.FacultyId)).Select(sc => sc.CourseId).ToList();
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
            return View("~/Views/FacultyViews/FacultyAssignment/Delete.cshtml", obj);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(long assignmentId)
        {
            Assignment? obj = _db.Assignments.Find(assignmentId);
            ViewBag.FacultyId = long.Parse(obj.FacultyId);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Assignments.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Assignment removed successfully";
            var assignedAssignments = _db.Assignments.Where(c => (c.CourseId.Equals(obj.CourseId)) && c.FacultyId.Equals(obj.FacultyId.ToString())).ToList();
            ViewBag.AssignedAssignments = assignedAssignments;
            return View("~/Views/FacultyViews/FacultyAssignment/AssignmentIndex.cshtml");
        }

        public IActionResult ViewSubmissions(long assignmentId)
		{
			Assignment? obj = _db.Assignments.Find(assignmentId);
            ViewBag.AssignmentId = obj.AssignmentId;
			ViewBag.FacultyId = long.Parse(obj.FacultyId);

			var studentAssignmentIds = _db.StudentAssignments.Where(sc => sc.AssignmentId == assignmentId).Select(sc => sc.Prn).ToList();

			var studentMarks = _db.StudentAssignments.Where(sc => sc.AssignmentId == assignmentId).Select(sc => sc.AssignedMarks).ToList();
            ViewBag.StudentMarks = studentMarks;
			List<Student> objStudentList = _db.Students.Where(s=> studentAssignmentIds.Contains(s.Prn)).ToList();
			return View("~/Views/FacultyViews/FacultyAssignment/StudentSubmissions.cshtml",objStudentList);
        }
		public IActionResult ViewAssignment(long Prn,long AssignmentId,long FacultyId)
		{
			StudentAssignment? obj = _db.StudentAssignments.FirstOrDefault(s => s.Prn == Prn && s.AssignmentId == AssignmentId);
			Assignment? AssignmentObj = _db.Assignments.Find(AssignmentId);
            ViewBag.AssignmentObj = AssignmentObj;
			ViewBag.FacultyId = FacultyId;

			return View("~/Views/FacultyViews/FacultyAssignment/ViewAssignment.cshtml",obj);
		}
        [HttpPost]
		public IActionResult ViewAssignment(StudentAssignment obj)
		{
			Assignment? AssignmentObj = _db.Assignments.Find(obj.AssignmentId);
			ViewBag.AssignmentObj = AssignmentObj;
			ViewBag.FacultyId = long.Parse(AssignmentObj.FacultyId);

			_db.StudentAssignments.Update(obj);
			_db.SaveChanges();
			TempData["success"] = "Assignment returned successfully";

			var studentAssignmentIds = _db.StudentAssignments.Where(sc => sc.AssignmentId == obj.AssignmentId).Select(sc => sc.Prn).ToList();
			List<Student> objStudentList = _db.Students.Where(s => studentAssignmentIds.Contains(s.Prn)).ToList();

            var studentMarks = _db.StudentAssignments.Where(sc => sc.AssignmentId == obj.AssignmentId).Select(sc => sc.AssignedMarks).ToList();
            ViewBag.StudentMarks = studentMarks;
            return View("~/Views/FacultyViews/FacultyAssignment/StudentSubmissions.cshtml", objStudentList);
		}
	}
}
