using System;
using System.Linq;
using System.Web.Mvc;
using UniversityApplication.Context;
using UniversityApplication.Models;

namespace UniversityApplication.Controllers
{
    public class DepartmentsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

       
        // GET: Departments
        public ActionResult ShowAllDepartments()
        {
            return View(db.Departments.ToList());
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Departments/Create
        public JsonResult IsCodeExists(string departmentCode)
        {
            return Json(!db.Departments.Any(x => x.DepartmentCode == departmentCode), JsonRequestBehavior.AllowGet);
        }
        public JsonResult IsNameExists(string departmentName)
        {
            return Json(!db.Departments.Any(x => x.DepartmentName == departmentName), JsonRequestBehavior.AllowGet);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentCode,DepartmentName")] Department department)
        {
            ViewBag.Message = "Department Not saved";
            ViewBag.Status = "Error";
            
            if (ModelState.IsValid)
            {
                try
                {
                    db.Departments.Add(department);
                    db.SaveChanges();
                    ViewBag.Status = "Success";
                    ViewBag.Message = "Success! Department Information Successfully Saved.";
                    
                }
                catch (Exception)
                {
                    ViewBag.Status = "Error";
                    ViewBag.Message = "Required! Department Code and Name required.";
                }
                
                ModelState.Clear();
            }

            
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
