using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDDataAccessLayer
{
    public class clsUsers
    {
        public clsUsers() { }
        public static DataTable GetAllUsers()
        {
            DataTable dtUsers = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * from Users";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dtUsers.Load(reader);
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {

                connection.Close();
            }
            return dtUsers;
        }
        public static bool IsUserExist(string userName, string password)
        {
            bool isExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * from Users where UserName=@UserName and Password=@Password";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", userName);
            command.Parameters.AddWithValue("@Password", password);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {


                    isExist = true;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return isExist;

        }

        public static bool isUserActive(string userName)
        {
            bool isActive = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select IsActive from Users where UserName=@UserName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", userName);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    isActive = Convert.ToBoolean(result);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return isActive;

        }
    }
}
