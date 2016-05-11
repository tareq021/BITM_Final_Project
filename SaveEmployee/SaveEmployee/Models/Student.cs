using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UniversityApplication.Models
{
    public class Student
    {
        [Key]
        public string StudentRegNo { get; set; }
        [Required]
        [DisplayName("Name")]
        public string StudentName { get; set; }

        [Required]
        [DisplayName("Contact No.")]
        public string StudentContact { get; set; }

        [Required]
        [DisplayName("Address")]
        [DataType(DataType.MultilineText)]
        public string StudentAddress { get; set; }
        
        [Required]
        [DisplayName("Department")]
        public string StudentDepartmentCode { get; set; }

        
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Remote("IsEmailExists", "Students", ErrorMessage = "Email already in use. Please try new email")]
        [DisplayName("Email")]
        public string StudentEmail { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime StudeRegDate { get; set; }
    }
}