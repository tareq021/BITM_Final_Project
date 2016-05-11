using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityApplication.DAL;

namespace SaveEmployee.DAL
{
    public class UnassignGateWay
    {
        public int Unassigned()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            SqlConnection connection = new SqlConnection(dbConnection.connection);
            int rowEffected = 0;
            connection.Open();
            string query = "update CourseTeachers set CourseTeachers.CourseTeacherCourseCode='Unassigned',CourseTeachers.CourseTeacherCourseCredit=0;";
            SqlCommand cmd = new SqlCommand(query, connection);
            rowEffected = cmd.ExecuteNonQuery();
            connection.Close();
            return rowEffected;
        }


        public int Unallocate()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            SqlConnection connection = new SqlConnection(dbConnection.connection);
            int rowEffected = 0;
            connection.Open();
            string query = "update Classrooms set Classrooms.ClassRoomRoomNo='Unallocated',Classrooms.ClassRoomDepartmentCode='Unallocated',Classrooms.ClassRoomCourseCode='Unallocated',Classrooms.ClassRoomWeekDay='Unallocated';";
            SqlCommand cmd = new SqlCommand(query, connection);
            rowEffected = cmd.ExecuteNonQuery();
            connection.Close();
            return rowEffected;
        }
    }
}