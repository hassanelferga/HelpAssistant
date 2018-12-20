using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpAssistant.Api.Models;

namespace HelpAssistant.Api.DAL
{
    public class ForgetPassword
    {

        // To Check if the email is exist

        public static string ForgotPassword(UserModel User)
        {
            string ErrorMsg = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(AppSetings.DbConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_ForgotPassword";
                    command.Connection = connection;

                    // Add Store Procedure Paramters
                    command.Parameters.AddWithValue("@Email", User.Email);

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

            return ErrorMsg;
        }


        public static string UpdatePassword(ForgetPassswordModel UpdatePassword)
        {
            string Errormsg = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(AppSetings.DbConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_ApplyNewPassword";
                    command.Connection = connection;

                    // Add Store Procedure Paramters
                    command.Parameters.AddWithValue("@code", UpdatePassword.Code);
                    command.Parameters.AddWithValue("@NewPasword", UpdatePassword.NewPassword);

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

            return Errormsg;
        }
    }
   
}
