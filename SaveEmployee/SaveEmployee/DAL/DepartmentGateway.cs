using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityApplication.Models;

namespace UniversityApplication.DAL
{
    public class DepartmentGateway 
    {
        //SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS2; Database = UniversityApplicationDatabase; Integrated Security=true;");
        public List<Department> GetDepartments()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            SqlConnection connection = new SqlConnection(dbConnection.connection);
            
            List<Department> departmentList = new List<Department>();

            string query = "SELECT * FROM Departments ORDER BY DepartmentName";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string Name = reader["DepartmentName"].ToString();
                string code = reader["Departmentcode"].ToString();
                Department aDepartment = new Department();

                aDepartment.DepartmentName = Name;
                aDepartment.DepartmentCode = code;

                departmentList.Add(aDepartment);
            }

            connection.Close();

            return departmentList;
        }
    }
}