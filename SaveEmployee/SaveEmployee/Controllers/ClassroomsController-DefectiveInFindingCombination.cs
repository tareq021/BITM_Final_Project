using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using UniversityApplication.BLL;
using UniversityApplication.Context;
using UniversityApplication.Models;

namespace UniversityApplication.Controllers
{
    public class ClassroomsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        RoomManager roomManager = new RoomManager();
      
        public ActionResult AllocateClassRoom()
        {
            GenerateDropDownValue();

            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AllocateClassRoom([Bind(Include = "ClassRoomRoomNo,ClassRoomDepartmentCode,ClassRoomCourseID,ClassRoomWeekDay,ClassRoomStartsAt,ClassRoomEndssAt,ClassRoomCourseCode")] Classroom classroom)
        {
            GenerateDropDownValue();
            
            if (ModelState.IsValid)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    
                    db.Classrooms.Add(classroom);
                    db.SaveChanges();
                    ModelState.Clear();
                    classroom = null;
                }
            }
            return View(classroom);
        }

        public JsonResult IsStartTimeAvailable(TimeSpan classRoomStartsAt, string classRoomWeekDay, string classRoomRoomNo)
        {
            bool check = true;
            

            //foreach (var room in db.Classrooms)
            //{
            //    if (classRoomRoomNo.Equals(room.ClassRoomRoomNo))
            //    {
            //        foreach (var day in db.Classrooms)
            //        {
            //            if (classRoomWeekDay.Equals(day.ClassRoomWeekDay))
            //            {
            //                foreach (var time in db.Classrooms)
            //                {
            //                    if (classRoomStartsAt >= time.ClassRoomStartsAt && classRoomStartsAt < time.ClassRoomEndssAt)
            //                    {
            //                        check = false;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            /* Converted to Chain Expression*/

            foreach (var time in
                db.Classrooms.Where(room => classRoomRoomNo.Equals(room.ClassRoomRoomNo))
                    .SelectMany(room => db.Classrooms, (room, day) => new { room, day })
                    .Where(@t => classRoomWeekDay.Equals(@t.day.ClassRoomWeekDay))
                    .SelectMany(@t => db.Classrooms, (@t, time) => new { @t, time })
                    .Where(@t => classRoomStartsAt >= @t.time.ClassRoomStartsAt
                                 && classRoomStartsAt < @t.time.ClassRoomEndssAt).Select(@t => @t.time))
            {
                check = false;
            }

            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = check,
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

        public JsonResult IsStartAndEndTimeAvailable(TimeSpan classRoomEndssAt, TimeSpan classRoomStartsAt, string classRoomWeekDay, string classRoomRoomNo)
        {
            bool check = true;


            //foreach (var room in db.Classrooms)
            //{
            //    if (classRoomRoomNo.Equals(room.ClassRoomRoomNo))
            //    {
            //        foreach (var day in db.Classrooms)
            //        {
            //            if (classRoomWeekDay.Equals(day.ClassRoomWeekDay))
            //            {
            //                foreach (var time in db.Classrooms)
            //                {
            //                    if (classRoomEndssAt > time.ClassRoomStartsAt && classRoomEndssAt <= time.ClassRoomEndssAt
            //                        || classRoomStartsAt < time.ClassRoomStartsAt && classRoomEndssAt > time.ClassRoomStartsAt && classRoomEndssAt <= time.ClassRoomEndssAt
            //                        || classRoomStartsAt > time.ClassRoomStartsAt && classRoomEndssAt < time.ClassRoomEndssAt
            //                        || classRoomStartsAt >= time.ClassRoomStartsAt && classRoomStartsAt < time.ClassRoomEndssAt && classRoomEndssAt>=time.ClassRoomEndssAt
            //                        || classRoomStartsAt < time.ClassRoomStartsAt && classRoomEndssAt >= time.ClassRoomEndssAt)
            //                    {
            //                        check = false;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            /* Converted to Chain Expression*/

            foreach (var time in
                db.Classrooms.Where(room => classRoomRoomNo.Equals(room.ClassRoomRoomNo))
                    .SelectMany(room => db.Classrooms, (room, day) => new {room, day})
                    .Where(@t => classRoomWeekDay.Equals(@t.day.ClassRoomWeekDay))
                    .SelectMany(@t => db.Classrooms, (@t, time) => new {@t, time})
                    .Where(
                        @t =>
                            classRoomEndssAt > @t.time.ClassRoomStartsAt && classRoomEndssAt <= @t.time.ClassRoomEndssAt
                            ||
                            classRoomStartsAt < @t.time.ClassRoomStartsAt &&
                            classRoomEndssAt > @t.time.ClassRoomStartsAt && classRoomEndssAt <= @t.time.ClassRoomEndssAt
                            ||
                            classRoomStartsAt > @t.time.ClassRoomStartsAt && classRoomEndssAt < @t.time.ClassRoomEndssAt
                            ||
                            classRoomStartsAt >= @t.time.ClassRoomStartsAt &&
                            classRoomStartsAt < @t.time.ClassRoomEndssAt && classRoomEndssAt >= @t.time.ClassRoomEndssAt
                            ||
                            classRoomStartsAt < @t.time.ClassRoomStartsAt &&
                            classRoomEndssAt >= @t.time.ClassRoomEndssAt
                            || classRoomStartsAt == classRoomEndssAt).Select(@t => @t.time))
            {
                check = false;
            }
            

            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = check,
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
        public JsonResult GetCourseName(string departmentName)
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

        public JsonResult GetSchedule(string departmentName)
        {
            List<Course> allCourses = new List<Course>();
            //List<Classroom> allSchedule = new List<Classroom>();

            IEnumerable result = null;

            if (departmentName != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    allCourses = db.Courses.Where(a => a.CourseDepartmentCode.Equals(departmentName)).OrderBy(a => a.CourseCode).ToList();

                    //result = from crs in allCourses
                    //         join sch in db.Classrooms
                    //             on crs.CourseCode equals sch.ClassRoomCourseCode into crsGroup
                    //         from sch in crsGroup.DefaultIfEmpty()
                    //         select new
                    //         {
                    //             CourseSchedule = sch == null ? "Not Scheduled Yet" :
                    //                 "R. No. : " + sch.ClassRoomRoomNo + ", " + sch.ClassRoomWeekDay + ", " +
                    //                 sch.ClassRoomStartsAt + " - " + sch.ClassRoomEndssAt + ";"
                    //         };
                    // .ToList() was add later after cnverting to Chain

                    //result =
                    //    allCourses.GroupJoin(db.Classrooms, crs => crs.CourseCode, sch => sch.ClassRoomCourseCode,
                    //        (crs, crsGroup) => new {crs, crsGroup})
                    //        .SelectMany(@t => @t.crsGroup.DefaultIfEmpty(), (@t, sch) => new
                    //        {
                    //            CourseSchedule = sch == null
                    //                ? "Not Scheduled Yet"
                    //                : "R. No. : " + sch.ClassRoomRoomNo + ", " + sch.ClassRoomWeekDay + ", " +
                    //                  sch.ClassRoomStartsAt + " - " + sch.ClassRoomEndssAt + ";"
                    //        }).ToList();

                      result =
                          allCourses.GroupJoin(db.Classrooms, crs => crs.CourseCode, sch => sch.ClassRoomCourseCode,
                               (crs, crsGroup) => new { crs, crsGroup })
                               .SelectMany(@t => @t.crsGroup.DefaultIfEmpty(), (@t, sch) => new
                               {
                                    CourseSchedule = sch == null
                                        ? "Not Scheduled Yet"
                                        : "R. No. : " + sch.ClassRoomRoomNo + ", " + sch.ClassRoomWeekDay + ", " +
                                          TimeConverter(sch.ClassRoomStartsAt) + " - " + TimeConverter(sch.ClassRoomEndssAt) + ";"
                                }).ToList();

                    
                }
            }
            if (Request.IsAjaxRequest())
            {

                return new JsonResult
                {
                    Data = result,
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

        private string TimeConverter(TimeSpan time)
        {
            var hours = time.Hours;
            var minutes = time.Minutes;
            var amPmDesignator = "AM";
            if (hours == 0)
                hours = 12;
            else if (hours == 12)
                amPmDesignator = "PM";
            else if (hours > 12)
            {
                hours -= 12;
                amPmDesignator = "PM";
            }
            var formattedTime =
              String.Format("{0}:{1:00} {2}", hours, minutes, amPmDesignator);


            return formattedTime;
        }

        private void GenerateDropDownValue()
        {
            List<Department> allDepartments = new List<Department>();
            List<SelectListItem> departments = new List<SelectListItem>();
            List<Course> allCourses = new List<Course>();

            using (ApplicationContext db = new ApplicationContext())
            {
                allDepartments = db.Departments.OrderBy(a => a.DepartmentName).ToList();
            }

            foreach (var department in allDepartments)
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
            ViewBag.CourseCode = new SelectList(allCourses, "CourseCode", "CourseCode");
            
            
            var rooms = roomManager.GetRooms();

            List<SelectListItem> roomList = new List<SelectListItem>();

            foreach (var room in rooms)
            {
                roomList.Add(

                    new SelectListItem()
                    {
                        Value = room,
                        Text = room
                    }
                    );
            }

            ViewBag.Room = roomList;

            List<SelectListItem> weekdays = new List<SelectListItem>
            {
                new SelectListItem {Text = "Saturday", Value = "Saturday"},
                new SelectListItem {Text = "Sunday", Value = "Sunday"},
                new SelectListItem {Text = "Monday", Value = "Monday"},
                new SelectListItem {Text = "Tuesday", Value = "Tuesday"},
                new SelectListItem {Text = "Wednesday", Value = "Wednesday"},
                new SelectListItem {Text = "Thursday", Value = "Thursday"},
                new SelectListItem {Text = "Friday", Value = "Friday"}
            };

            ViewBag.Weekday = weekdays;
            
       }

        public ActionResult ClassScheduleAndRoomAllocation()
        {
            List<Department> allDepartments = new List<Department>();
            using (ApplicationContext db = new ApplicationContext())
            {
                allDepartments = db.Departments.OrderBy(a => a.DepartmentName).ToList();
            }
            ViewBag.Departments = new SelectList(allDepartments, "DepartmentCode", "DepartmentName");

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
