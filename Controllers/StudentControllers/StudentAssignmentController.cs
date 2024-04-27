using Microsoft.AspNetCore.Mvc;
using StudentDevelopmentPortal.Data;
using StudentDevelopmentPortal.Models.AdminModels;
using StudentDevelopmentPortal.Models.StudentModels;

namespace StudentDevelopmentPortal.Controllers.StudentControllers
{
    public class StudentAssignmentController : Controller
    {
        public readonly ApplicationDbContext _db;
        public StudentAssignmentController(ApplicationDbContext db) { _db = db; }

        public IActionResult Index(long? Prn)
        {
            ViewBag.Prn = Prn;
            var student = _db.Students.FirstOrDefault(s => s.Prn == Prn);

            if (student != null)
            {
                var studentAssignmentIds = _db.StudentAssignments.Where(sc => sc.Prn == student.Prn).Select(sc => sc.AssignmentId).ToList();
                var studentCourseIds = _db.StudentCourses.Where(sc => sc.Prn == student.Prn).Select(sc => sc.CourseId).ToList();
                var PendingAssignments = _db.Assignments.Where(c => studentCourseIds.Contains(c.CourseId) && !studentAssignmentIds.Contains(c.AssignmentId)).ToList();
                var CompletedAssignments = _db.Assignments.Where(c => studentCourseIds.Contains(c.CourseId) && studentAssignmentIds.Contains(c.AssignmentId)).ToList();
                ViewBag.PendingAssignments = PendingAssignments;
                ViewBag.CompletedAssignments = CompletedAssignments;

                var studentMarks = _db.StudentAssignments.Where(sc => studentAssignmentIds.Contains(sc.AssignmentId)).Select(sc => sc.AssignedMarks).ToList();
                ViewBag.StudentMarks = studentMarks;

                var studentFeedback = _db.StudentAssignments.Where(sc => studentAssignmentIds.Contains(sc.AssignmentId)).Select(sc => sc.Feedback).ToList();
                ViewBag.StudentFeedback = studentFeedback;
            }
            else
            {
                ViewBag.PendingAssignments = new List<Assignment>();
            }

            return View("~/Views/StudentViews/StudentAssignment/Index.cshtml");
        }
        [HttpPost]
        public IActionResult Index(StudentAssignment obj)
        {

            string dueDateString = _db.Assignments.FirstOrDefault(s => s.AssignmentId == obj.AssignmentId).AssignedDueDate;
            DateTime dueDate;

            if (DateTime.TryParse(dueDateString, out dueDate))
            {
                if (dueDate < DateTime.Now)
                {
                    TempData["error"] = "Assignment due date has passed.";
                    var student = _db.Students.FirstOrDefault(s => s.Prn == obj.Prn);

                    if (student != null)
                    {
                        var studentAssignmentIds = _db.StudentAssignments.Where(sc => sc.Prn == student.Prn).Select(sc => sc.AssignmentId).ToList();
                        var studentCourseIds = _db.StudentCourses.Where(sc => sc.Prn == student.Prn).Select(sc => sc.CourseId).ToList();
                        var PendingAssignments = _db.Assignments.Where(c => studentCourseIds.Contains(c.CourseId) && !studentAssignmentIds.Contains(c.AssignmentId)).ToList();
                        var CompletedAssignments = _db.Assignments.Where(c => studentCourseIds.Contains(c.CourseId) && studentAssignmentIds.Contains(c.AssignmentId)).ToList();
                        ViewBag.PendingAssignments = PendingAssignments;
                        ViewBag.CompletedAssignments = CompletedAssignments;

                        var studentMarks = _db.StudentAssignments.Where(sc => studentAssignmentIds.Contains(sc.AssignmentId)).Select(sc => sc.AssignedMarks).ToList();
                        ViewBag.StudentMarks = studentMarks;

                        var studentFeedback = _db.StudentAssignments.Where(sc => studentAssignmentIds.Contains(sc.AssignmentId)).Select(sc => sc.Feedback).ToList();
                        ViewBag.StudentFeedback = studentFeedback;
                    }
                    else
                    {
                        ViewBag.PendingAssignments = new List<Assignment>();
                    }
                }
                else
                {
                    ViewBag.Prn = obj.Prn;
                    if (ModelState.IsValid)
                    {
                        var existingObj = _db.StudentAssignments.FirstOrDefault(s => s.Prn == obj.Prn && s.AssignmentId==obj.AssignmentId); // Assuming Id is the unique identifier

                        if (existingObj != null)
                        {
                            existingObj.SolutionUrl = obj.SolutionUrl;
                            _db.StudentAssignments.Update(existingObj);
                        }
                        else
                        {
                            _db.StudentAssignments.Add(obj);
                        }

                        _db.SaveChanges();
                        TempData["success"] = "Assignment submitted successfully";
                        var student = _db.Students.FirstOrDefault(s => s.Prn == obj.Prn);

                        if (student != null)
                        {
                            var studentAssignmentIds = _db.StudentAssignments.Where(sc => sc.Prn == student.Prn).Select(sc => sc.AssignmentId).ToList();
                            var studentCourseIds = _db.StudentCourses.Where(sc => sc.Prn == student.Prn).Select(sc => sc.CourseId).ToList();
                            var PendingAssignments = _db.Assignments.Where(c => studentCourseIds.Contains(c.CourseId) && !studentAssignmentIds.Contains(c.AssignmentId)).ToList();
                            var CompletedAssignments = _db.Assignments.Where(c => studentCourseIds.Contains(c.CourseId) && studentAssignmentIds.Contains(c.AssignmentId)).ToList();
                            ViewBag.PendingAssignments = PendingAssignments;
                            ViewBag.CompletedAssignments = CompletedAssignments;

                            var studentMarks = _db.StudentAssignments.Where(sc => studentAssignmentIds.Contains(sc.AssignmentId)).Select(sc => sc.AssignedMarks).ToList();
                            ViewBag.StudentMarks = studentMarks;

                            var studentFeedback = _db.StudentAssignments.Where(sc => studentAssignmentIds.Contains(sc.AssignmentId)).Select(sc => sc.Feedback).ToList();
                            ViewBag.StudentFeedback = studentFeedback;
                        }
                        else
                        {
                            ViewBag.PendingAssignments = new List<Assignment>();
                        }
                        return View("~/Views/StudentViews/StudentAssignment/Index.cshtml");
                    }
                }
            }
            else
            {
                TempData["error"] = "Date cannot be converted";
            }

            TempData["error"] = "Assignment due date has passed.";
            return View("~/Views/StudentViews/StudentAssignment/Index.cshtml");
        }


    }
}
