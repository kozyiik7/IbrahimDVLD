using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IbrahimDVLDDataAccessLayer
{
    public class clsDataAccess
    {
        public static DataTable GetAllPeople()
        {
            DataTable dtPeople=new DataTable();

            SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * from People";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dtPeople.Load(reader);
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                
                connection.Close();
            }

            return dtPeople;

        }
        public static bool isNationalNumberExist(string NationalNumber)
        {
            bool isNationalNumberExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM People WHERE NationalNo = @NationalNumber";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
            try
            {
                connection.Open();
                SqlDataReader reader=command.ExecuteReader();
                if (reader.HasRows)
                {
                   isNationalNumberExist=true;
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {

                connection.Close();
            }

            return isNationalNumberExist;


        }
    }
}
