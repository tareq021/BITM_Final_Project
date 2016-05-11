using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UniversityApplication.Models
{
    public class CourseStatics
    {

        [DisplayName("Department")]
        public string CourseStaticsDepartmentCode { get; set; }
        [DisplayName("Code")]
        public string CourseStaticsCourseCode { get; set; }
        [DisplayName("Name/Title")]
        public string CourseStaticsCourseName { get; set; }
        [DisplayName("Semester")]
        public string CourseStaticsCoursSemester { get; set; }
        [DisplayName("Assigned To")]
        public string CourseStaticsCourseTeacher { get; set; }
    }
}