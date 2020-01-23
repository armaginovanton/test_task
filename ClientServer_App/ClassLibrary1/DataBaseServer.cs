using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServer_App
{
    public class DataBaseServer
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public Message Get(int id)
        {
            string sqlExpression = "dbo.GetMessage";
            Message result = null;

            using (SqlConnection connection = new SqlConnection(connectionString))

            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    result = new Message
                    {
                        Id = reader.GetInt32(0),
                        Text = reader.GetString(1),
                        Ip = reader.GetString(2),
                        GetDateTime = reader.GetDateTime(3)
                    };
                }
                reader.Close();
            }
            return result;
        }

        public int Save(Message message)
        {
            string sqlExpression = "dbo.SaveMessage";
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@text", message.Text);
                command.Parameters.AddWithValue("@getDateTime", message.GetDateTime);
                command.Parameters.AddWithValue("@ip", message.Ip);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    result = reader.GetInt32(0);
                }
                reader.Close();
            }
            return result;
        }
        
    }
}
