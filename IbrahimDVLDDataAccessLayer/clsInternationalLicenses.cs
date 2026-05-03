using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace IbrahimDVLDDataAccessLayer
{
    public class clsInternationalLicenses
    {
        public static DataTable GetInternationalLicenseHistoryByPersonID(int PersonID)
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT        InternationalLicenses.InternationalLicenseID
              , Applications.ApplicationID
              , InternationalLicenses.IssuedUsingLocalLicenseID
              , InternationalLicenses.IssueDate
              , InternationalLicenses.ExpirationDate, 
                         InternationalLicenses.IsActive
                 FROM            Applications INNER JOIN People
                 ON Applications.ApplicantPersonID = People.PersonID 
				 INNER JOIN InternationalLicenses 
				 ON Applications.ApplicationID = InternationalLicenses.ApplicationID
				 where People.PersonID=@PersonID ;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
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

        public static int InsertNewInternationalLicenseData(int ApplicationID,int DriverID , int IssuedUsingLocalLicenseID, DateTime IssueDate , DateTime ExpirationDate , bool IsActive ,int CreatedByUserID)
        {
            int InternationalLicenseID = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO [dbo].[InternationalLicenses]
                            ([ApplicationID]
                            ,[DriverID]
                            ,[IssuedUsingLocalLicenseID]
                            ,[IssueDate]
                            ,[ExpirationDate]
                            ,[IsActive]
                            ,[CreatedByUserID])
                            VALUES
                            (@ApplicationID
                            ,@DriverID
                            ,@IssuedUsingLocalLicenseID
                            ,@IssueDate
                            ,@ExpirationDate
                            ,@IsActive
                            ,@CreatedByUserID);
                             select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                Connection.Open();
                object  Result = Command.ExecuteScalar();
                if (Result!=null)
                 InternationalLicenseID=   Convert.ToInt32(Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return InternationalLicenseID;


        }
        public static bool IsDriverHasActiveInternationalLicenseByDriverID(int DriverID)
        {
            int InternationalLicenseID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select InternationalLicenseID from InternationalLicenses
                           where DriverID=@DriverID and GETDATE()<=ExpirationDate";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                    InternationalLicenseID = Convert.ToInt32(Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return InternationalLicenseID>0;

        }
        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dtInternationalLicenses= new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select InternationalLicenseID,ApplicationID,DriverID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive from InternationalLicenses";
            SqlCommand Command = new SqlCommand(Query, Connection);
    
            try
            {
                Connection.Open();
               SqlDataReader Reader=Command.ExecuteReader();
                if (Reader.HasRows)
                    dtInternationalLicenses.Load(Reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return dtInternationalLicenses;

        }
        public static DataRow GetDriverInternationalLicenseInfoByDriverID(int DriverID)
        {
            DataTable dtDriverInternationalLicenses= new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT        Applications.ApplicantPersonID
            ,(select CONCAT_WS(' ',People.FirstName,People.SecondName,ISNULL(People.ThirdName,''),People.LastName) from People where People.PersonID=Applications.ApplicantPersonID) as 'FullName'
            , InternationalLicenses.InternationalLicenseID
			, InternationalLicenses.ApplicationID
			, InternationalLicenses.IssuedUsingLocalLicenseID
			, InternationalLicenses.IsActive
			, (select People.NationalNo from People where People.PersonID=Applications.ApplicantPersonID) as 'NationalNo'
			, (select People.DateOfBirth from People where People.PersonID=Applications.ApplicantPersonID) as 'DateOfBirth'
		    , (select People.Gendor from People where People.PersonID=Applications.ApplicantPersonID) as 'Gendor'
		    , InternationalLicenses.DriverID
		    , InternationalLicenses.IssueDate
		    , InternationalLicenses.ExpirationDate
		    ,(select People.ImagePath from People where People.PersonID=Applications.ApplicantPersonID) as 'ImagePath'
             FROM            Applications INNER JOIN InternationalLicenses 
             ON Applications.ApplicationID = InternationalLicenses.ApplicationID
						where InternationalLicenses.DriverID=@DriverID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DriverID", DriverID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                    dtDriverInternationalLicenses.Load(Reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
          return  (dtDriverInternationalLicenses!=null)?dtDriverInternationalLicenses.Rows[0]:null;
        }
        public static DataRow GetDriverInternationalLicenseInfoByInternationalLicenseID(int InternationalLicenseID)
        {
            DataTable dtDriverInternationalLicenses = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT    top 1   * from InternationalLicenses
						where InternationalLicenses.InternationalLicenseID=@InternationalLicenseID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                    dtDriverInternationalLicenses.Load(Reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return (dtDriverInternationalLicenses != null) ? dtDriverInternationalLicenses.Rows[0] : null;
        }
    }
}
