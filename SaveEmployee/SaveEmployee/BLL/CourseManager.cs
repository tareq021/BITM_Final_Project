using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityApplication.DAL;
using UniversityApplication.Models;

namespace UniversityApplication.BLL
{
    public class CourseManager
    {
        CourseGateway gateway = new CourseGateway();
        public List<Course> GetCourses()
        {
            return gateway.GetCourses();
        }
    }
}