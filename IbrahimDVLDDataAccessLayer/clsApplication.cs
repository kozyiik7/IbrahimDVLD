using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDDataAccessLayer
{
    public class clsApplication
    {
        public static int InsertApplication(int ApplicationPersonID, DateTime ApplicationDate, int ApplicationTypeID, short ApplicationStatus, DateTime LastStatusDate, int PaidFees, int CreatedcByUserID)
        {
            int NewApplicationID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                             VALUES (@ApplicationPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedcByUserID);
                             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedcByUserID", CreatedcByUserID);
            try
            {
                Connection.Open();
                object result = command.ExecuteScalar();
                NewApplicationID = result != null ? Convert.ToInt32(result) : -1;


            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                throw new Exception("An error occurred while inserting the application.", ex);
            }
            finally
            {
                Connection.Close();
            }
            return NewApplicationID;



        }
        public static bool IsDriverHasSameApplicationTypeWithStatus(int PersonID, int licenseTypeID)
        {
            bool hasSameApplication = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT count(*) FROM Applications inner join LocalDrivingLicenseApplications
                            
							 on Applications.ApplicationID=LocalDrivingLicenseApplications.ApplicationID
							  WHERE ApplicantPersonID = @PersonID
                             AND LocalDrivingLicenseApplications.LicenseClassID = @licenseTypeID
                             AND ApplicationStatus in (1)";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@LicenseTypeID", licenseTypeID);
            try
            {
                Connection.Open();
                int count = Convert.ToInt32(Command.ExecuteScalar());
                hasSameApplication = count > 0;
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                throw new Exception("An error occurred while checking for existing applications.", ex);
            }
            finally
            {
                Connection.Close();
            }
            return hasSameApplication;

        }
        public static DataRow GetApplicationDataByApplicationID(int ApplicationID)
        {
            
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            DataTable dt = new DataTable();
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching application data.", ex);
            }
            finally
            {
                Connection.Close();
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static bool IsApplicationExists(int ApplicationID)
        {
            bool isFound = false;   
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT COUNT(*) FROM Applications WHERE ApplicationID = @ApplicationID";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                Connection.Open();
              object result = Command.ExecuteScalar();
                if (result != null)
                {
                    isFound =true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while checking if the application exists.", ex);
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"delete from Applications
		                    where ApplicationID=@ApplicationID;";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ApplicationID",ApplicationID);
            try
            {
                Connection.Open();
                object Result = command.ExecuteNonQuery();
                if (Result != null)
                isFound = true;    

            }
            catch (Exception ex)
            {
                throw ;
               
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }
        public static bool CancelApplication(int ApplicationID)
        {
            bool isCanceled = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE Applications
                             SET ApplicationStatus = 2,
                                 LastStatusDate=GetDate()
                             WHERE ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                Connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                isCanceled = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Connection.Close();
            }
            return isCanceled;
        }
        public static DataRow GetDrivingLicenseInfo(int AppID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT        LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID,LicenseClasses.ClassName,LicenseClasses.ClassDescription,(select count(TestAppointments.TestTypeID) from TestAppointments where LocalDrivingLicenseApplicationID=LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID) as PassedTests
                             FROM            Applications INNER JOIN
                            LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID INNER JOIN
                            ApplicationTypes ON Applications.ApplicationTypeID = ApplicationTypes.ApplicationTypeID
						    inner join LicenseClasses on LicenseClasses.LicenseClassID=LocalDrivingLicenseApplications.LicenseClassID
						     where Applications.ApplicationID=@AppID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AppID", AppID);
            DataTable dt = new DataTable();
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                throw ;
            }
            finally
            {
                Connection.Close();
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
        public static DataTable GetApplicationInfoWithDetailsByAppID(int AppID)
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT        Applications.ApplicationID, 
                             case 
			                 when Applications.ApplicationStatus=1 then 'New'
			                 when Applications.ApplicationStatus=2 then 'Cancelled '
			                 when Applications.ApplicationStatus=3 then 'Completed'
			                 end as Status,
			                 Applications.PaidFees,
			                 ApplicationTypes.ApplicationTypeTitle,
			                 People.FirstName+' '+People.SecondName+' '+ISNULL(People.ThirdName,'')+' '+People.LastName As Applicant,
			                 Applications.ApplicationDate,
			                 Applications.LastStatusDate,
			                 Users.UserName
                             FROM                            Applications INNER JOIN
                                         People ON Applications.ApplicantPersonID = People.PersonID INNER JOIN
                                         ApplicationTypes ON Applications.ApplicationTypeID = ApplicationTypes.ApplicationTypeID INNER JOIN
                                         Users ON Applications.CreatedByUserID = Users.UserID
			                			 where Applications.ApplicationID=@AppID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AppID", AppID);
            DataTable dt = new DataTable();
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Connection.Close();
            }
            return dt!=null && dt.Rows.Count > 0 ? dt : null;
        }
    }
}
