using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversityApplication.BLL;
using UniversityApplication.Context;
using UniversityApplication.Models;

namespace UniversityApplication.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        DepartmentManager departmentManager = new DepartmentManager();

        
        public ActionResult Create()
        {
            GenerateDropDownValue();
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentRegNo,StudentName,StudentContact,StudentAddress,StudentDepartmentCode,StudentEmail,StudeRegDate")] Student student)
        {
            GenerateDropDownValue();

            ViewBag.Message = "Student Not saved";
            ViewBag.Status = "Error";

            if (ModelState.IsValid)
            {
                try
                {
                    //var year = student.StudeRegDate.Year;

                    string combineDepartmentYear = student.StudentDepartmentCode + "-" +
                                                   student.StudeRegDate.Year + "-";
                    student.StudentRegNo = combineDepartmentYear + GetSerial(combineDepartmentYear); 
                    db.Students.Add(student);
                    db.SaveChanges();
                    ViewBag.Status = "Success";
                    ViewBag.Message = "Student Saved Successfuly";
                    ViewBag.StudentRegNo = student.StudentRegNo;

                }
                catch (Exception)
                {
                    ViewBag.Status = "Error";
                    ViewBag.Message = "Student Email and Name required";
                }
                ModelState.Clear();
            }

            return View();
        }

        private string GetSerial(string combineDepartmentYear)
        {
            string maxId = db.Students.Where(p => p.StudentRegNo.Contains(combineDepartmentYear)).Select(i => i.StudentRegNo).Max();
            string finalSerial;

            if (maxId == null)
            {
                return finalSerial = "001";
            }
            
            int serial = Convert.ToInt32(maxId.Substring(maxId.LastIndexOf("-") + 1)) + 1;

            
            if (serial < 10)
            {
                finalSerial = "00" + serial.ToString();
            }
            else if (serial >= 10 && serial < 100)
            {
                finalSerial = "0" + serial.ToString();
            }
            else
            {
                finalSerial = serial.ToString();
            }

            return finalSerial;
        }


        public JsonResult IsEmailExists(string studentEmail)
        {
            return Json(!db.Students.Any(x => x.StudentEmail == studentEmail), JsonRequestBehavior.AllowGet);
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
