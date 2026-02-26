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

    }
}
