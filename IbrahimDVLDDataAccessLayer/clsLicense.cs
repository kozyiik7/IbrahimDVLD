using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDDataAccessLayer
{
    public class clsLicense
    {
        public static int CreateNewLicense(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int LicenseID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO [dbo].[Licenses]
                          ([ApplicationID]
                          ,[DriverID]
                          ,[LicenseClass]
                          ,[IssueDate]
                          ,[ExpirationDate]
                          ,[Notes]
                          ,[PaidFees]
                          ,[IsActive]
                          ,[IssueReason]
                          ,[CreatedByUserID])
                    VALUES
                          ( @ApplicationID
                          ,@DriverID
                          ,@LicenseClass
                          ,@IssueDate
                          ,@ExpirationDate
                          ,@Notes
                          ,@PaidFees
                          ,@IsActive
                          ,@IssueReason
                          ,@CreatedByUserID);
                           select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Command.Parameters.AddWithValue("@Notes", Notes);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@IssueReason", IssueReason);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                {
                    LicenseID = Convert.ToInt32(Result);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return LicenseID;

        }

        public static DataTable GetDriverLicenseInfo(int LocalDrivingLicenseID)
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT  
                            LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                            ,(select LicenseClasses.ClassName from LicenseClasses where LicenseClasses.LicenseClassID=LocalDrivingLicenseApplications.LicenseClassID )as 'License Class'--Licenses.LicenseClass
                            , (select People.FirstName+ ' ' +People.SecondName+ ' '+ISNULL(People.ThirdName,'')+' '+People.LastName from People where PersonID= Drivers.PersonID)As PersonName
                            , Licenses.LicenseID
                            , People.NationalNo
                            , People.Gendor
                            , Licenses.IssueDate
                            , Licenses.IssueReason
                            , ISNULL( Licenses.Notes,'') as Notes
                            , Licenses.IsActive
                            , People.DateOfBirth
                            , Drivers.DriverID
                            , Licenses.ExpirationDate
                            ,(select count(*) from DetainedLicenses where DetainedLicenses.LicenseID=Licenses.LicenseID and IsReleased is null) as IsDetained
                            ,ISNULL( People.ImagePath,'') as ImagePath
                            FROM            People
                            INNER JOIN Applications 
                            ON People.PersonID = Applications.ApplicantPersonID
                            INNER JOIN LocalDrivingLicenseApplications
                            ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            INNER JOIN Drivers 
                            ON People.PersonID = Drivers.PersonID 
                            INNER JOIN Licenses 
                            ON Applications.ApplicationID = Licenses.ApplicationID AND Drivers.DriverID = Licenses.DriverID 
                            
                            where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseID", LocalDrivingLicenseID);
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
        public static bool IsThereNonExpiredLicenseForThisPerson(int PersonID, int DrvingLicenseID)
        {
            bool ThereIsNonExpiredLicenseForThisPerson = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select Count(*)  As ThereIsLicense from
                            (
                            SELECT   Applications.ApplicantPersonID,LicenseClasses.LicenseClassID  ,Licenses.ExpirationDate   
                            FROM            Applications INNER JOIN
                                                     People ON Applications.ApplicantPersonID = People.PersonID INNER JOIN
                                                     LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID INNER JOIN
                                                     Licenses ON Applications.ApplicationID = Licenses.ApplicationID INNER JOIN
                                                     LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID AND Licenses.LicenseClass = LicenseClasses.LicenseClassID ) T1
                            						 where T1.ApplicantPersonID=@PersonID And T1.LicenseClassID=@DrvingLicenseID and (GETDATE()<= T1.ExpirationDate);";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@DrvingLicenseID", DrvingLicenseID);
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                    ThereIsNonExpiredLicenseForThisPerson = Convert.ToInt32(Result) > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return ThereIsNonExpiredLicenseForThisPerson;

        }
        public static DataTable GetLocalDrivingLicenseHistoryByPersonID(int PersonID)
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT        Licenses.LicenseID
              ,Applications.ApplicationID
              ,(select LicenseClasses.ClassName from LicenseClasses where LicenseClasses.LicenseClassID= Licenses.LicenseClass)as 'Class Name'
              ,Licenses.IssueDate
              ,Licenses.ExpirationDate
              ,Licenses.IsActive
               FROM            People INNER JOIN
                         Applications ON People.PersonID = Applications.ApplicantPersonID INNER JOIN
                         Licenses ON Applications.ApplicationID = Licenses.ApplicationID INNER JOIN
                         LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
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
        public static bool IsDriverLicensClass3ExistsAndCByLicenseID(int DrvingLicenseID)
        {
            bool thereIsLicense = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select top 1 * from Licenses
                             where Licenses.LicenseID=@DrvingLicenseID and Licenses.LicenseClass=3";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DrvingLicenseID", DrvingLicenseID);
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                    thereIsLicense = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return thereIsLicense;

        }
        public static DataTable GetDriverLicensDataLicenseID(int DrvingLicenseID)
        {
            DataTable dtLicenseInfo = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select top 1 * from Licenses
                            where Licenses.LicenseID=@DrvingLicenseID ";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DrvingLicenseID", DrvingLicenseID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                    dtLicenseInfo.Load(Reader);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return dtLicenseInfo;

        }
        public static bool Active_DeaciveLicense(int LicensID, bool Active_Deactive)
        {
            bool IsUpdated = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"update Licenses
                             set IsActive=@Active_DeActive
                             where LicenseID=@LicenseID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Active_Deactive", Active_Deactive); // or true depending on the desired action
            Command.Parameters.AddWithValue("@LicenseID", LicensID);
            try
            {
                Connection.Open();
                int AffectedRows = Command.ExecuteNonQuery();
                if (AffectedRows > 0)
                    IsUpdated = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return IsUpdated;

        }
        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            bool IsUpdated = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE [dbo].[Licenses]
                             SET [ApplicationID] = ApplicationID
                                ,[DriverID] =@DriverID
                                ,[LicenseClass] =@LicenseClass
                                ,[IssueDate] =@IssueDate
                                ,[ExpirationDate] = @ExpirationDate
                                ,[Notes] = @Notes
                                ,[PaidFees] = @PaidFees
                                ,[IsActive] =@IsActive
                                ,[IssueReason] = @IssueReason
                                ,[CreatedByUserID] = @CreatedByUserID
                                 WHERE Licenses.LicenseID=@LicenseID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Command.Parameters.AddWithValue("@Notes", Notes);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@IssueReason", IssueReason);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                Connection.Open();
                int AffectedRows = Command.ExecuteNonQuery();
                if (AffectedRows > 0)
                    IsUpdated = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return IsUpdated;
        }
    }
}
