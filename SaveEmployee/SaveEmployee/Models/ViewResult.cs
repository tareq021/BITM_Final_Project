using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaveEmployee.Models
{
    public class ViewResult
    {
        [Key]
        [Required(ErrorMessage = "Registration No. is Required!")]
        [DisplayName("Student Reg.No.")]
        public string RegNo { get; set; }


        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string Department { get; set; }

        //Result Generating
        [DisplayName("Course Code")]
        public string CourseCode { get; set; }
        [DisplayName("Name")]
        public string CourseName { get; set; }
        [DisplayName("Grade")]
        public string Grade { get; set; }
    }
}