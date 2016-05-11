using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityApplication.DAL;
using UniversityApplication.Models;

namespace SaveEmployee.DAL
{
    public class StudentGateWay
    {
        public List<Student> GetStudentInfos(string email)
        {
            List<Student> StudentList = new List<Student>();

            DatabaseConnection dbConnection = new DatabaseConnection();
            SqlConnection connection = new SqlConnection(dbConnection.connection);

            connection.Open();

            string getInfo = "select * from Students where StudentEmail='" + email + "';";
            SqlCommand command = new SqlCommand(getInfo, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string regNo = reader["StudentRegNo"].ToString();
                string name = reader["StudentName"].ToString();
                string contact = reader["StudentContact"].ToString();
                string address = reader["StudentAddress"].ToString();
                string department = reader["StudentDepartmentCode"].ToString();
                string mail = reader["StudentEmail"].ToString();
                string date = reader["StudeRegDate"].ToString();

                Student aStudent = new Student();

                aStudent.StudentRegNo = regNo;
                aStudent.StudentName = name;
                aStudent.StudentContact = contact;
                aStudent.StudentAddress = address;
                aStudent.StudentDepartmentCode = department;
                aStudent.StudentEmail = mail;
                aStudent.StudeRegDate = DateTime.Parse(date);

                StudentList.Add(aStudent);
            }

            connection.Close();
            return StudentList;

        }
    }
}
