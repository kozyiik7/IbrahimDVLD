using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDDataAccessLayer
{
    public class clsDetainedLicenses
    {

        public static DataRow GetDetainedLicenseDataByLicenseID(int LicenseID)
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = $"SELECT * FROM DetainedLicenses WHERE LicenseID =@LicenseID";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID)
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {

                    dt.Load(Reader);


                }
                Reader.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();

            }
            return (dt.Rows.Count > 0) ? dt.Rows[0] : null;
        }
           
    }
}
