using SaveEmployee.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityApplication.DAL;

namespace SaveEmployee.DAL
{
    public class ResultViewGateway
    {
        public List<ViewResult> GetCourseInfos(string regNo)
        {
            List<ViewResult> ResultList = new List<ViewResult>();
            DatabaseConnection dbConnection = new DatabaseConnection();
            SqlConnection connection = new SqlConnection(dbConnection.connection);

            connection.Open();
            string regNoCheck = "select count(StudentResultRegNo) from StudentResults where StudentResultRegNo in(select CourseStudentRegNo from CourseStudents where CourseStudentRegNo='"+regNo+"');";
            SqlCommand commands = new SqlCommand(regNoCheck, connection); 
            string count = commands.ExecuteScalar().ToString();
            connection.Close();

            if (count!="0")
            {
                connection.Open();
                string query = "  select StudentResults.StudentResultCourse Code,Courses.CourseName Name,StudentResults.StudentResultGrade Grade  from StudentResults,Courses where Courses.CourseCode in(  select StudentResults.StudentResultCourse where  StudentResults.StudentResultRegNo='"+regNo+"'); ";
                
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string code = reader["Code"].ToString();
                    string name = reader["Name"].ToString();
                    string grade = reader["Grade"].ToString();

                    ViewResult aResult = new ViewResult();

                    aResult.CourseCode = code;
                    aResult.CourseName = name;
                    aResult.Grade = grade;

                    ResultList.Add(aResult);
                }

                connection.Close();               
            }
            else if(count=="0")
            {
                connection.Open();
                string query = "select Courses.CourseCode Code,Courses.CourseName Name from Courses,CourseStudents where Courses.CourseCode in( select CourseStudents.CourseStudentCourse where CourseStudentRegNo='" + regNo + "');";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string code = reader["Code"].ToString();
                    string name = reader["Name"].ToString();
                    ViewResult aResult = new ViewResult();

                    aResult.CourseCode = code;
                    aResult.CourseName = name;
                    aResult.Grade = "Not Graded Yet";

                    ResultList.Add(aResult);
                }
                connection.Close();  
            }

            return ResultList;
            
        }
    }
}