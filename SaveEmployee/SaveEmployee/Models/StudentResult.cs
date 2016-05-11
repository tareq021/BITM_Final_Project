using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApplication.Models
{
    public class StudentResult
    {
        [Required]
        [DisplayName("Student Reg. No.")]
        public string StudentResultRegNo { get; set; }
        [DisplayName("Name")]
        [NotMapped]
        public string StudentResultName { get; set; }
        [DisplayName("Email")]
        [NotMapped]
        public string StudentResultEmail { get; set; }
        [DisplayName("Department")]
        [NotMapped]
        public string StudentResultDepartmentCode { get; set; }
        [Required]
        [DisplayName("Select Course")]
        public string StudentResultCourse { get; set; }
        [Required]
        [DisplayName("Select Grade Letter")]
        public string StudentResultGrade { get; set; }
        [Key]
        public int StudentResultId { get; set; }
    }
}