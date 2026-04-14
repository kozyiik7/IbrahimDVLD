using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDDataAccessLayer
{
    public class clsApplicationTypes
    {
        public static DataTable GetApplicationTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM ApplicationTypes";
            SqlCommand Command = new SqlCommand(query, Connection);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                    dt.Load(Reader);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }
        public static int GetApplicationTypeIDFromApplicatioName(string ApplicationTypeTitle)
        {
           int ApplicationTypeID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT ApplicationTypeID FROM ApplicationTypes Where ApplicationTypeTitle=@ApplicationTypeTitle";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if(result != null)
                ApplicationTypeID = Convert.ToInt32(result);


            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return ApplicationTypeID;
        }
        public static int GetApplicationFeesFromApplicatioName(string ApplicationTypeTitle)
        {
            int ApplicationTypeFees = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT ApplicationFees FROM ApplicationTypes Where ApplicationTypeTitle=@ApplicationTypeTitle";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                    ApplicationTypeFees = Convert.ToInt32(result);


            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return ApplicationTypeFees;
        }
        public static bool UpdateApplicationTypes(int ApplicationTypeID,string ApplicationTypeTitle,float ApplicationFees)
        {
            bool result = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE ApplicationTypes
                             SET [ApplicationTypeTitle] = @ApplicationTypeTitle
                                ,[ApplicationFees] = @ApplicationFees
                                 WHERE ApplicationTypeID=@ApplicationTypeID";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            Command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);
            try
            {
                Connection.Open();
                int rowsAffected = Command.ExecuteNonQuery();
                result=(rowsAffected > 0)  ;
            }
            catch
            {
                result = false;
            }
            finally
            {
                Connection.Close();
            }   
            return result;
        }
    }
}
