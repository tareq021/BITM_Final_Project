




using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;

namespace UniversityApplication.Models
{
    public class CourseStudent
    {
        [Required]
        [DisplayName("Student Reg. No.")]
        public string CourseStudentRegNo { get; set; }

        [DisplayName("Name")]
        [NotMapped]
        public string CourseStudentName { get; set; }

        [DisplayName("Email")]
        [NotMapped]
        public string CourseStudentEmail { get; set; }

        [DisplayName("Department")]
        [NotMapped]
        public string CourseStudentDepartmentCode { get; set; }

        [Required]
        [Remote("IsCourseNameExists", "CourseStudents", AdditionalFields = "CourseStudentRegNo", ErrorMessage = "Selected Student has taken this course already.")]
        [DisplayName("Select Course")]
        public string CourseStudentCourse { get; set; }

        [Required]
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime CourseStudentRegDate { get; set; }
        
        
        [Key]
        public int CourseStudentID { get; set; }
    }
}