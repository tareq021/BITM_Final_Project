using System.Collections.Generic;
using System.Data.SqlClient;

namespace UniversityApplication.DAL
{
    public class ResultGateway 
    {
        //SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS2; Database = UniversityApplicationDatabase; Integrated Security=true;");
        
        public List<string> GetResults()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            SqlConnection connection = new SqlConnection(dbConnection.connection);

            List<string> resultList = new List<string>();

            string query = "SELECT * FROM Results";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string result = reader["Grade"].ToString();

                resultList.Add(result);
            }

            connection.Close();

            return resultList;
        }
    }
}