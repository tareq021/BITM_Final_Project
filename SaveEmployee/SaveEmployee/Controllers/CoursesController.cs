using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversityApplication.BLL;
using UniversityApplication.Context;
using UniversityApplication.Models;

namespace UniversityApplication.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        
        DepartmentManager departmentManager = new DepartmentManager();
        SemesterManager semesterManager = new SemesterManager();
       
        // GET: Courses/Create
        public ActionResult Create()
        {
            GenerateDropDownValue();
            
            return View();
        }

        public JsonResult IsCourseCodeExists(string courseCode)
        {
            return Json(!db.Courses.Any(x => x.CourseCode == courseCode), JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsCourseNameExists(string courseName)
        {
            return Json(!db.Courses.Any(x => x.CourseName == courseName), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseCode,CourseName,CourseCredit,CourseDescription,CourseDepartmentCode,CourseSemester")] Course course)
        {
            GenerateDropDownValue();
            
            ViewBag.Message = "Course Not saved";
            ViewBag.Status = "Error";

            if (ModelState.IsValid)
            {
                try
                {
                    db.Courses.Add(course);
                    db.SaveChanges();
                    ViewBag.Status = "Success";
                    ViewBag.Message = "Success! Course Information Successfully Saved.";
                    
                }
                catch (Exception)
                {
                    ViewBag.Status = "Error";
                    ViewBag.Message = "Required! Course Code and Name required.";
                }
                ModelState.Clear();
            }
            
            return View();
        }

        private void GenerateDropDownValue()
        {
            var departments = departmentManager.GetDepartments();

            List<SelectListItem> departmentList = new List<SelectListItem>();

            foreach (var department in departments)
            {
                departmentList.Add(

                    new SelectListItem()
                    {
                        Value = department.DepartmentCode,
                        Text = department.DepartmentName
                    }
                    );
            }

            ViewBag.Departments = departmentList;

            var semesters = semesterManager.GetSemester();

            List<SelectListItem> semesterList = new List<SelectListItem>();

            foreach (var semester in semesters)
            {
                semesterList.Add(

                    new SelectListItem()
                    {
                        Value = semester,
                        Text = semester
                    }
                    );
            }

            ViewBag.Semesters = semesterList;   
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
