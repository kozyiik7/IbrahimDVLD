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
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
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
          
        public static int CreateDetainLicense(int LicenseID,DateTime DetainDate,decimal FineFees,int CreatedByUserID,bool IsReleased,Nullable< DateTime> ReleaseDate, Nullable<int> ReleasedByUserID, Nullable<int> ReleaseApplicationID)
        {
            int DetainID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [dbo].[DetainedLicenses]
                            ([LicenseID]
                            ,[DetainDate]
                            ,[FineFees]
                            ,[CreatedByUserID]
                            ,[IsReleased]
                            ,[ReleaseDate]
                            ,[ReleasedByUserID]
                            ,[ReleaseApplicationID])
                      VALUES
                            (@LicenseID
                            ,@DetainDate
                            ,@FineFees
                            ,@CreatedByUserID
                            ,@IsReleased
                            ,ISNULL(@ReleaseDate, NULL)
                            ,ISNULL(@ReleasedByUserID, NULL)
                            ,ISNULL(@ReleaseApplicationID, NULL));
                             select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DetainDate);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsReleased", IsReleased);
            Command.Parameters.AddWithValue("@ReleaseDate", (object)ReleaseDate ?? DBNull.Value);
            Command.Parameters.AddWithValue("@ReleasedByUserID",(object)ReleasedByUserID ?? DBNull.Value);
            Command.Parameters.AddWithValue("@ReleaseApplicationID", (object)ReleaseApplicationID ?? DBNull.Value);
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                {

                   DetainID= Convert.ToInt32(Result);


                }
               

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();

            }
            return DetainID;
        }
        public static bool UpdateDetainLicense(int DetainID,int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased,Nullable< DateTime> ReleaseDate, Nullable<int> ReleasedByUserID, Nullable<int> ReleaseApplicationID)
        {
            int AffectedRows = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Update [dbo].[DetainedLicenses]
                           set
                            ([LicenseID]=@LicenseID
                            ,[DetainDate]=@DetainDate
                            ,[FineFees]=@FineFees
                            ,[CreatedByUserID]=@CreatedByUserID
                            ,[@IsReleased]=@IsReleased
                            ,[ReleaseDate]=ISNULL(@ReleaseDate, NULL)
                            ,[ReleasedByUserID]=ISNULL(@ReleasedByUserID, NULL)
                            ,[ReleaseApplicationID]=ISNULL(@ReleaseApplicationID, NULL));
                             where DetainID=@DetainID";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DetainDate);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsReleased", IsReleased);
            Command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            Command.Parameters.AddWithValue("@DetainID", DetainID);
            try
            {
                Connection.Open();
                int Resault=Command.ExecuteNonQuery();
                if (Resault >0)
                {

                    AffectedRows = Resault;


                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();

            }
            return AffectedRows>0;


        }
    }
}
