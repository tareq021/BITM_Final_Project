using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversityApplication.Context;
using UniversityApplication.Models;

namespace UniversityApplication.Controllers
{
    public class CourseTeacherController : Controller
    {
        private ApplicationContext db = new ApplicationContext();
        
        public ActionResult AssignCourse()
        {
            GenerateDropDownValue();
            
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignCourse(CourseTeacher courseTeacher)
        {
            GenerateDropDownValue();

            ViewBag.Message = "Course Not assigned";
            ViewBag.Status = "Error";
            
            if (ModelState.IsValid)
            {
                try
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        courseTeacher.CourseTeacherCourseCredit =
                            db.Courses.Where(c => c.CourseCode == courseTeacher.CourseTeacherCourseCode)
                                .Select(p => (double?) p.CourseCredit)
                                .Single();

                        courseTeacher.CourseTeacherTeacherName =
                            db.Teachers.Where(a => a.TeacherEmail.Equals(courseTeacher.CourseTeacherEmail))
                                .Select(p => p.TeacherName)
                                .Single();
                        db.CoursesTeachers.Add(courseTeacher);
                        db.SaveChanges();
                        ViewBag.Status = "Success";
                        ViewBag.Message = "Success! Course Successfully Assigned."; 
                        ModelState.Clear();
                        courseTeacher = null;
                    }
                }
                catch (Exception)
                {
                    ViewBag.Status = "Error";
                    ViewBag.Message = "Required! All fields are required";
                }
            }
            return View(courseTeacher);
        }

        private void GenerateDropDownValue()
        {
            List<Department> alldeDepartments = new List<Department>();
            List<SelectListItem> departments = new List<SelectListItem>();

            List<Course> allCourses = new List<Course>();
            List<Teacher> allTeachers = new List<Teacher>();

            using (ApplicationContext db = new ApplicationContext())
            {
                alldeDepartments = db.Departments.OrderBy(a => a.DepartmentCode).ToList();
            }

            foreach (var department in alldeDepartments)
            {
                departments.Add(

                    new SelectListItem()
                    {
                        Value = department.DepartmentCode,
                        Text = department.DepartmentName
                    }
                    );
            }

            ViewBag.Departments = departments;
            ViewBag.TeachersName = new SelectList(allTeachers, "TeacherEmail", "TeacherName");
            ViewBag.CourseCode = new SelectList(allCourses, "CourseCode", "CourseCode");
            ViewBag.CreditToTake = "0.0";
            ViewBag.RemainingCredit = "0.0";
        }

        public JsonResult IsCodeExists(string courseTeacherCourseCode)
        {
            return Json(!db.CoursesTeachers.Any(x => x.CourseTeacherCourseCode == courseTeacherCourseCode), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetTeachers(string departmentName)
        {
            List<Teacher> allTeachers = new List<Teacher>();
           
            if (departmentName!=null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    allTeachers = db.Teachers.Where(a => a.TeacherDepartmentCode.Equals(departmentName)).OrderBy(a => a.TeacherName).ToList();
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = allTeachers,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                return new JsonResult
                {
                    Data = "Not valid request",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }

        [HttpGet]
        public JsonResult GetTeachersCreditToTake(string teacherName)
        {
            double creditToTake = 0.0;

            if (teacherName != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    creditToTake = (db.Teachers.Where(p => p.TeacherEmail == teacherName).Select(p => p.TeacherCredit)).Single();
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = creditToTake,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                return new JsonResult
                {
                    Data = "Not valid request",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }

        [HttpGet]
        public JsonResult GetTeachersRemainingCredit(string teacherName)
        {
            double? totalCredit = 0.0;
            double? creditToTake = 0.0;

            if (teacherName != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    creditToTake = (db.Teachers.Where(p => p.TeacherEmail == teacherName).Select(p => (double?)p.TeacherCredit)).Single();
                    double? credit = db.CoursesTeachers.Where(p=>p.CourseTeacherEmail==teacherName).Sum(e =>(double?) e.CourseTeacherCourseCredit);
                    if (credit == null)
                    {
                        totalCredit = 0.0;
                    }
                    else
                    {
                        totalCredit = credit;
                    }
                    
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = creditToTake-totalCredit,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                return new JsonResult
                {
                    Data = "Not valid request",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }

        [HttpGet]
        public JsonResult GetCourseCode(string departmentName)
        {
            List<Course> allCourses = new List<Course>();

            if (departmentName != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    allCourses = db.Courses.Where(a => a.CourseDepartmentCode.Equals(departmentName)).OrderBy(a => a.CourseCode).ToList();
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = allCourses,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                return new JsonResult
                {
                    Data = "Not valid request",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }
        [HttpGet]
        public JsonResult GetCourseName(string teacherName)
        {
            string course="";

            if (!string.IsNullOrEmpty(teacherName))
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    course = db.Courses.Where(c => c.CourseCode == teacherName).Select(p => p.CourseName).Single();
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = course,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                return new JsonResult
                {
                    Data = "Not valid request",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }
        [HttpGet]
        public JsonResult GetCourseCredit(string teacherName)
        {
            double? credit = 0.0;

            if (!string.IsNullOrEmpty(teacherName))
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    credit = db.Courses.Where(c => c.CourseCode == teacherName).Select(p =>(double?) p.CourseCredit).Single();
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = credit,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                return new JsonResult
                {
                    Data = "Not valid request",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }

        
    }
}