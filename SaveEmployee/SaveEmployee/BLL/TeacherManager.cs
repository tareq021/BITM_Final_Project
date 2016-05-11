using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityApplication.DAL;
using UniversityApplication.Models;

namespace UniversityApplication.BLL
{
    public class TeacherManager
    {
        TeachersGateway gateway = new TeachersGateway();
        public List<Teacher> GetTeachers(string departmentName)
        {
            return gateway.GetTeachers(departmentName);
        }
    }
}