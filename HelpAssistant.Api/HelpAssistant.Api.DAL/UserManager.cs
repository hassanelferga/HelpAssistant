using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpAssistant.Api.Models;
using System.Data.SqlClient;

namespace HelpAssistant.Api.DAL
{
    public static class UserManager
    {
        public  static long Register(RegisterModel user)
        {
            long userId = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(AppSetings.DbConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "Sp_RegisterUser";
                    command.Connection = connection;

                    // Add Store Procedure Paramters
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", user.Email);

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

            return userId;
        }

        public static int Update(RegisterModel modify)
        {
            int userId = 0;

            try
            {


                using (SqlConnection connection = new SqlConnection(AppSetings.DbConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "Sp_UpdateUser";
                    command.Connection = connection;


                    // Add Store Procedure Paramters
                    command.Parameters.AddWithValue("@UserID", modify.UserID);
                    command.Parameters.AddWithValue("@FirstName", modify.FirstName);
                    command.Parameters.AddWithValue("@LastName", modify.LastName);
                    command.Parameters.AddWithValue("@PhoneNumber", modify.PhoneNumber);
                    //command.Parameters.AddWithValue("@UserName", modify.UserName);
                    command.Parameters.AddWithValue("@UserPassword", modify.Password);
                    //command.Parameters.AddWithValue("@Email", modify.Email);


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



            return userId;
            // what the return will be ??
            //there is a logic error in this statement
        }
    }
}
