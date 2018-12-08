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
        /*

        public static ForgetPassswordModel ForgotPassword(string Email)
        {
         //   string Email = "";
       try
            {
                using (SqlConnection connection = new SqlConnection(AppSetings.DbConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_ForgotPassword";
                    command.Connection = connection;

                    // Add Store Procedure Paramters
                   
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

            return Email;
        }


        public static ForgetPassswordModel UpdatePassword(string code ,string NewPssword)
        {
               string code = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(AppSetings.DbConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_ForgotPassword";
                    command.Connection = connection;

                    // Add Store Procedure Paramters

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

            return code;
        }


    */
    }
   
}
