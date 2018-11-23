using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpAssistant.Api.Models;
using System.Data.SqlClient;

namespace HelpAssistant.Api.DAL
{
    public static class SignSetting
    {
        public static int Sign(SignInModel User)
        {
          
            try
            {
                using (SqlConnection connection = new SqlConnection(AppSetings.DbConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "Sp_SignIn";
                    command.Connection = connection;


                    // Add Store Procedure Paramters
                    command.Parameters.AddWithValue("@UserName", User.UserName);
                    command.Parameters.AddWithValue("@Email", User.Email);
                    command.Parameters.AddWithValue("@Password",User.Password);

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


            return 0;
        }
    }

}
