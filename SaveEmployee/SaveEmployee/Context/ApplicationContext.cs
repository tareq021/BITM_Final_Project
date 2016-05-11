using System.Data.Entity;
using UniversityApplication.Models;

namespace UniversityApplication.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<CourseTeacher> CoursesTeachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<CourseStudent> CoursesStudents { get; set; }
        public DbSet<StudentResult> StudentResults { get; set; }
        public System.Data.Entity.DbSet<SaveEmployee.Models.ViewResult> ViewResults { get; set; }
  
        
    }
}