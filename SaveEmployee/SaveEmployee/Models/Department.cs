using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web.Mvc;

namespace UniversityApplication.Models
{

    public class Department
    {
        [Key]
        [Required(ErrorMessage = "Required")]
        [Remote("IsCodeExists", "Departments", ErrorMessage = "Department Code is in use. Please try new code")]
        [StringLength(7, ErrorMessage = "Must be between {2} and {1} characters long.", MinimumLength = 2)]
        [DisplayName("Code")]
        public string DepartmentCode { get; set; }
        [Required(ErrorMessage = "Required")]
        [Remote("IsNameExists", "Departments", ErrorMessage = "Department Name is in use. Please try new name")]
        [DisplayName("Name")]
        public string DepartmentName { get; set; }
    }
}