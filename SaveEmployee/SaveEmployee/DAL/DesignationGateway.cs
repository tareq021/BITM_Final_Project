using System.Collections.Generic;
using System.Data.SqlClient;

namespace UniversityApplication.DAL
{
    public class DesignationGateway 
    {
        //SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS2; Database = UniversityApplicationDatabase; Integrated Security=true;");
        public List<string> GetDesignation()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            SqlConnection connection = new SqlConnection(dbConnection.connection);

            List<string> designationList = new List<string>();

            string query = "SELECT * FROM Designations";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string designation = reader["Designation"].ToString();

                designationList.Add(designation);
            }

            connection.Close();

            return designationList;
        }
    }
}