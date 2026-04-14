using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDDataAccessLayer
{
    public class clsLicenseClasses
    {
        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM LicenseClasses";
            SqlCommand Command = new SqlCommand(query, Connection);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {

                    dt.Load(Reader);
                    return dt;
                }
                else
                {
                    return null;
                }








            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Connection.Close();
            }

        }

        public static int GetLicenseClassIDFromClassName(string ClassName)
        {
            int LicenseClassID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT LicenseClassID FROM LicenseClasses Where ClassName=@ClassName";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@ClassName", ClassName);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    LicenseClassID = Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Connection.Close();
            }
            return LicenseClassID;

        }
    }
}