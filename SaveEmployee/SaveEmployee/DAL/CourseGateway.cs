using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityApplication.Models;

namespace UniversityApplication.DAL
{
    public class CourseGateway 
    {
        
        public List<Course> GetCourses()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            SqlConnection connection = new SqlConnection(dbConnection.connection);
            
            List<Course> courseListList = new List<Course>();

            string query = "SELECT * FROM Courses ORDER BY CourseName";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string name = reader["CourseName"].ToString();
                string code = reader["Coursecode"].ToString();
                double credit = Convert.ToDouble(reader["Coursecredit"]);
                
                Course aCourse = new Course();

                aCourse.CourseName = name;
                aCourse.CourseCode = code;
                aCourse.CourseCredit = credit;

                courseListList.Add(aCourse);
            }

            connection.Close();

            return courseListList;
        }
    }
}