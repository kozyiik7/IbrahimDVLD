using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDDataAccessLayer
{
   public  class clsCountry
    {
        public static DataTable GetAllCountries()
        {
            DataTable dtCountry = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * from Countries";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dtCountry.Load(reader);
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                
                connection.Close();
            }
            return dtCountry;
        }
    }
}
