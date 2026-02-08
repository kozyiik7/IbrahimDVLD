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
        public static int GetCountyIDByCountryName(string CountryNam)
        {
            int CountryID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select CountryID from Countries Where CountryName =@CountryName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryNam);
            try
            {
                connection.Open();
                object Value1 = command.ExecuteScalar();
                if (Value1!=null)
                {
                   CountryID= Convert.ToInt32( Value1);
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {

                connection.Close();
            }
            return CountryID;
        }

        public static string GetCountyNameBYCountryID(int CountryID)
        {
            

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select CountryName from Countries Where CountryID =@CountryID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            try
            {
                connection.Open();
                object Value1 = command.ExecuteScalar();
                if (Value1 != null)
                {
                    return Convert.ToString(Value1);
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {

                connection.Close();
            }
            return "";
        }
    }
}
