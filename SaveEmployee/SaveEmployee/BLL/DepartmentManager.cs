using System.Collections.Generic;
using UniversityApplication.DAL;
using UniversityApplication.Models;

namespace UniversityApplication.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway gateway = new DepartmentGateway();
        public List<Department> GetDepartments()
        {
            return gateway.GetDepartments();
        }
    }
}