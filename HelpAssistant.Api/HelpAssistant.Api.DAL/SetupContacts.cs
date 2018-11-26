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
        public static int Emergency(EmergencyModel contact )
        {
            int EmergencyId=0;
            try
            {
                using (SqlConnection connection = new SqlConnection(AppSetings.DbConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "Sp_EmergencyContact";
                    command.Connection = connection;

                    
                    // Add Store Procedure Paramters
                    command.Parameters.AddWithValue("@EmergencyID", contact.EmergencyId);
                    command.Parameters.AddWithValue("@MobileNo", contact.MobileNumber);
                    command.Parameters.AddWithValue("@ContentSMS", contact.ContentSMS);

                    // Open Connection
                    connection.Open();

                    // Insert Record to the database
                    int noOfRows = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return EmergencyId;
        }

    }
}
