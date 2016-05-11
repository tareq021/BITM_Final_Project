using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UniversityApplication.Models
{
    public class Teacher
    {
        [DisplayName("Designation")]
        [Required(ErrorMessage = "Please select a Designation")]
        public string TeacherDesignation { get; set; }
        
        [Required]
        [DisplayName("Credit to be taken")]
        [Range(0.0, double.MaxValue,ErrorMessage = "Credit Must be a positive value")]
        public double TeacherCredit { get; set; }
       
        [Key]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Remote("IsEmailExists", "Teachers", ErrorMessage = "Email already in use. Please try new email")]
        [DisplayName("Email")]
        public string TeacherEmail { get; set; }
        
        [Required]
        [DisplayName("Name")]
        public string TeacherName { get; set; }
       
        [Required]
        [DisplayName("Contact No.")]
        public string TeacherContact { get; set; }
        
        [Required]
        [DisplayName("Address")]
        public string TeacherAddress { get; set; }
       
        [DisplayName("Department")]
        [Required(ErrorMessage = "Please select a Department")]
        public string TeacherDepartmentCode { get; set; }


    }
}