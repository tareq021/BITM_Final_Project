using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UniversityApplication.Models
{
    public class Course
    {
        [Key]
        [Required]
        [Remote("IsCourseCodeExists", "Courses", ErrorMessage = "Course Code already in use. Please try new code")]
        [StringLength(50, ErrorMessage = "Must be at minimum 5 characters long.", MinimumLength = 5)]
        [DisplayName("Code")]
        public string CourseCode { get; set; }
        [Required]
        [Remote("IsCourseNameExists", "Courses", ErrorMessage = "Course Name already in use. Please try new Name")]
        [DisplayName("Name")]
        public string CourseName { get; set; }
        [Required]
        [Range(0.5, 5, ErrorMessage = "Credits must be between 0.5 to 5.0")]
        [DisplayName("Credit")]
        public double? CourseCredit { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Description")]
        public string CourseDescription { get; set; }
        [DisplayName("Department")]
        [Required(ErrorMessage = " Please select a Department ")]
        public string CourseDepartmentCode { get; set; }
        [DisplayName("Semester")]
        [Required(ErrorMessage = " Please select a Semester ")]
        public string CourseSemester { get; set; }
    }
}