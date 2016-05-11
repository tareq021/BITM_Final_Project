using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversityApplication.BLL;
using UniversityApplication.Context;
using UniversityApplication.Models;

namespace UniversityApplication.Controllers
{
    public class TeachersController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        DepartmentManager departmentManager = new DepartmentManager();
        DesignationManager designationManager = new DesignationManager();

        // GET: Teachers/Create
        public ActionResult Create()
        {
            GenerateDropDownValue();
            return View();
        }
        public JsonResult IsEmailExists(string teacherEmail)
        {
            return Json(!db.Teachers.Any(x => x.TeacherEmail == teacherEmail), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeacherDesignation,TeacherCredit,TeacherEmail,TeacherName,TeacherContact,TeacherAddress,TeacherDepartmentCode")] Teacher teacher)
        {
            GenerateDropDownValue();

            ViewBag.Message = "Teacher Not saved";
            ViewBag.Status = "Error";

            if (ModelState.IsValid)
            {
                try
                {
                    db.Teachers.Add(teacher);
                    db.SaveChanges();
                    ViewBag.Status = "Success";
                    ViewBag.Message = "Success!  Teacher Information Successfully Saved.";
                }
                catch (Exception)
                {
                    ViewBag.Status = "Error";
                    ViewBag.Message = "Required! Teacher Email and Name required";
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

            var designations = designationManager.GetDesignation();

            List<SelectListItem> designationList = new List<SelectListItem>();

            foreach (var designation in designations)
            {
                designationList.Add(

                    new SelectListItem()
                    {
                        Value = designation,
                        Text = designation
                    }
                    );
            }

            ViewBag.Designations = designationList;
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
