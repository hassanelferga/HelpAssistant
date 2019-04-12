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
        public  static int Register(RegisterModel user, out string errorMessage, out long userID)
        {
            int status = 0;
            userID = 0;
            errorMessage = string.Empty;
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
                    SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                    while(reader.Read())
                    {
                        errorMessage = reader["ErrorMsg"].ToString();
                        userID = Convert.ToInt64(reader["UserID"].ToString());
                        status = Convert.ToInt32(reader["Status"].ToString());
                    }
                    
                }
                return status;
            }
            catch (Exception ex)
            {

                throw ex;
            }
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
                    command.Parameters.AddWithValue("@UserPassword", modify.Password);


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

        public static UserModel GetUser(long userID)
        {
            UserModel user = new UserModel();
            try
            {


                using (SqlConnection connection = new SqlConnection(AppSetings.DbConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "Sp_GetUser";
                    command.Connection = connection;


                    // Add Store Procedure Paramters
                    command.Parameters.AddWithValue("@UserID", userID);



                    // Open Connection
                    connection.Open();

                    // Insert Record to the database
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                       
                        user.UserID = Convert.ToInt64(reader["UserID"].ToString());
                        user.FirstName = reader["FirstName"].ToString();
                        user.LastName = reader["LastName"].ToString();
                        user.UserName = reader["UserName"].ToString();
                        user.Email = reader["Email"].ToString();
                        user.PhoneNumber = reader["PhoneNumber"].ToString();
                    }
                }
            }
            catch (Exception exp)
            {

                throw exp;
            }
            return user;
        }

        public static UserModel SignIn(string userName, string email)
        {
            UserModel User = new UserModel();

            try
            {
                using (SqlConnection connection = new SqlConnection(AppSetings.DbConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "Sp_SignIn";
                    command.Connection = connection;


                    // Add Store Procedure Paramters
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@Email", userName);
                    //command.Parameters.AddWithValue("@Password", User.UserPassword);

                    // Open Connection
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        User.UserID = Convert.ToInt64(reader["UserID"].ToString());
                        User.FirstName = reader["FirstName"].ToString();
                        User.LastName = reader["LastName"].ToString();
                        User.PhoneNumber = reader["PhoneNumber"].ToString();
                        User.UserPassword = reader["UserPassword"].ToString();
                        User.Email = reader["Email"].ToString();
                        User.UserName = reader["UserName"].ToString();
                        User.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());

                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


            return User;

        }

        public static int DeleteUser(RegisterModel Delete)
        {
          int  UserID = 0;


            try
            {


                using (SqlConnection connection = new SqlConnection(AppSetings.DbConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "Sp_DeleteUser";
                    command.Connection = connection;


                    // Add Store Procedure Paramters
                    command.Parameters.AddWithValue("@UserID", Delete.UserID);
                    

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


            return UserID;


        }

        public static EmergencyModel smsHelper(long UserID)
        {
            EmergencyModel sms = new EmergencyModel();
            try
            {


                using (SqlConnection connection = new SqlConnection(AppSetings.DbConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "sp_smsHelper";
                    command.Connection = connection;


                    // Add Store Procedure Paramters
                    command.Parameters.AddWithValue("@UserID", UserID);



                    // Open Connection
                    connection.Open();

                    // Insert Record to the database
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        sms.Numbers = reader["MobileNo"].ToString();
                        sms.Message = reader["ContwntSMS"].ToString();
                    }
              }
            }
            catch (Exception exp)
            {

                throw exp;
            }


            return sms;
        }
       
        
        
    }

}

