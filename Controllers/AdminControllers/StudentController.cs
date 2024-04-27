using Microsoft.AspNetCore.Mvc;
using StudentDevelopmentPortal.Data;
using StudentDevelopmentPortal.Models.AdminModels;

namespace StudentDevelopmentPortal.Controllers.AdminControllers
{
    public class StudentController : Controller
    {
        public readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db) { _db = db; }
        public IActionResult Index()
        {
            List<Student> objStudentList = _db.Students.ToList();
            return View("~/Views/AdminViews/Student/Index.cshtml", objStudentList);
        }

        public IActionResult Create()
        {
            return View("~/Views/AdminViews/Student/Create.cshtml");
        }
        [HttpPost]
        public IActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Student added successfully";
                return RedirectToAction("Index");
            }
            return View("~/Views/AdminViews/Student/Create.cshtml");
        }

        public IActionResult Edit(long? Prn)
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
            return View("~/Views/AdminViews/Student/Edit.cshtml", StudentFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Student Info updated successfully";
                return RedirectToAction("Index");
            }
            return View("~/Views/AdminViews/Student/Edit.cshtml");
        }


        public IActionResult Delete(long? Prn)
        {
            if (Prn == null || Prn == 0)
            {
                return NotFound();
            }
            Student? studentFromDb = _db.Students.Find(Prn);
            if (studentFromDb == null)
            {
                return NotFound();
            }
            return View("~/Views/AdminViews/Student/Delete.cshtml", studentFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(long? Prn)
        {
            Student? obj = _db.Students.Find(Prn);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Students.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Student removed successfully";
            return RedirectToAction("Index");
        }
    }
}
