using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpAssistant.Api.Models;
using System.Data.SqlClient;

namespace HelpAssistant.Api.DAL
{
    public static class  SetupContacts
    {
        public static bool Emergency(string userID, string numbers, string message )
        {
            bool isDone = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(AppSetings.DbConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "Sp_EmergencyContact";
                    command.Connection = connection;

                    
                    // Add Store Procedure Paramters
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@Numbers", numbers);
                    command.Parameters.AddWithValue("@Message", message);

                    // Open Connection
                    connection.Open();

                    // Insert Record to the database
                    int noOfRows = command.ExecuteNonQuery();
                    if (noOfRows > 0)
                        isDone = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return isDone;

        }

    }
}
