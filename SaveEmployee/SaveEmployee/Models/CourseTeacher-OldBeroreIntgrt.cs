using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace UniversityApplication.Models
{
    public class CourseTeacher
    {
        [DisplayName("Department")]
        public string CourseTeacherDepartmentCode { get; set; }
        [DisplayName("Teacher")]
        public string CourseTeacherEmail { get; set; }
        [DisplayName("Credit to be taken")]
        [NotMapped]
        public double CourseTeacherCreditToTake { get; set; }
        [DisplayName("Remaining Credit")]
        [NotMapped]
        public double? CourseTeacherRemainingCredit { get; set; }
        [DisplayName("Course Code")]
        [Remote("IsCodeExists", "CourseTeacher", ErrorMessage = "Course already assigned")]
        public string CourseTeacherCourseCode { get; set; }
        [DisplayName("Name")]
        [NotMapped]
        public string CourseTeacherCourseName { get; set; }
        [DisplayName("Credit")]
        public double? CourseTeacherCourseCredit { get; set; }

        public string CourseTeacherTeacherName { get; set; }
        
        [Key]
        public int CourseTeacherID { get; set; }
    }
}