using Microsoft.AspNetCore.Mvc;
using StudentDevelopmentPortal.Data;
using StudentDevelopmentPortal.Models.AdminModels;
using System.Collections.Generic;
using System.Linq;

namespace StudentDevelopmentPortal.Controllers.AdminControllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Admin> adminList = _db.Admins.ToList();
            return View("~/Views/AdminViews/Admin/Index.cshtml", adminList);
        }

        public IActionResult Create()
        {
            return View("~/Views/AdminViews/Admin/Create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(Admin obj)
        {
            if (ModelState.IsValid)
            {
                _db.Admins.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Admin added successfully";
                return RedirectToAction("Index");
            }
            return View("~/Views/AdminViews/Admin/Create.cshtml");
        }

        public IActionResult Edit(string adminId)
        {
            if (string.IsNullOrEmpty(adminId))
            {
                return NotFound();
            }
            Admin adminFromDb = _db.Admins.FirstOrDefault(a => a.AdminId == adminId);
            if (adminFromDb == null)
            {
                return NotFound();
            }
            return View("~/Views/AdminViews/Admin/Edit.cshtml", adminFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Admin obj)
        {
            if (ModelState.IsValid)
            {
                _db.Admins.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Admin info updated successfully";
                return RedirectToAction("Index");
            }
            return View("~/Views/AdminViews/Admin/Edit.cshtml");
        }

        public IActionResult Delete(string adminId)
        {
            if (string.IsNullOrEmpty(adminId))
            {
                return NotFound();
            }
            Admin adminFromDb = _db.Admins.FirstOrDefault(a => a.AdminId == adminId);
            if (adminFromDb == null)
            {
                return NotFound();
            }
            return View("~/Views/AdminViews/Admin/Delete.cshtml", adminFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string adminId)
        {
            Admin admin = _db.Admins.FirstOrDefault(a => a.AdminId == adminId);
            if (admin == null)
            {
                return NotFound();
            }
            _db.Admins.Remove(admin);
            _db.SaveChanges();
            TempData["success"] = "Admin removed successfully";
            return RedirectToAction("Index");
        }
    }
}
