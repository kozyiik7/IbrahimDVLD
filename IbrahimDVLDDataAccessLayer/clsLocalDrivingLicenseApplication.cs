using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDDataAccessLayer
{
    public class clsLocalDrivingLicenseApplication
    {


        public static int InsertLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int NewLocalDrivingLicenseApplicationID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
                             VALUES (@ApplicationID, @LicenseClassID);
                             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                Connection.Open();
                object result = command.ExecuteScalar();
                NewLocalDrivingLicenseApplicationID = result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Connection.Close();
            }
            return NewLocalDrivingLicenseApplicationID;
        }
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT        dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID AS [L.D.L.AppID], dbo.LicenseClasses.ClassName AS [Driving Class], dbo.People.NationalNo, 
                         dbo.People.FirstName + ' ' + dbo.People.SecondName + ' ' +ISNULL(dbo.People.ThirdName, '') + ' ' + dbo.People.LastName AS FullName, dbo.Applications.ApplicationDate,
                             (SELECT        COUNT(dbo.TestAppointments.TestTypeID) AS Expr1
                                FROM            dbo.TestAppointments INNER JOIN
                                                         dbo.Tests ON dbo.TestAppointments.TestAppointmentID = dbo.Tests.TestAppointmentID
                                WHERE        (dbo.TestAppointments.LocalDrivingLicenseApplicationID = dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID) AND (dbo.Tests.TestResult = 1)) AS PassedTests, 
                         CASE Applications.ApplicationStatus WHEN 1 THEN 'New' WHEN 2 THEN 'Canceled' WHEN 3 THEN 'Completed' END AS Status
FROM            dbo.Applications INNER JOIN
                         dbo.LocalDrivingLicenseApplications ON dbo.Applications.ApplicationID = dbo.LocalDrivingLicenseApplications.ApplicationID INNER JOIN
                         dbo.LicenseClasses ON dbo.LocalDrivingLicenseApplications.LicenseClassID = dbo.LicenseClasses.LicenseClassID INNER JOIN
                         dbo.People ON dbo.Applications.ApplicantPersonID = dbo.People.PersonID";
            SqlCommand command = new SqlCommand(Query, Connection);
            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching local driving license applications: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }
        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            bool isDeleted = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                Connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                isDeleted = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting local driving license application: " + ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return isDeleted;
        }

        public static int GetApplicationIDByLocalDrivingLicenseID(int LocalDrivingLicenseID)
        {
            int ApplicationID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select ApplicationID from LocalDrivingLicenseApplications
		                    where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseID", LocalDrivingLicenseID);
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                    ApplicationID = Convert.ToInt32(Result);
            }
            catch(Exception ex) 
            {
                throw new Exception(" there is a problem :", ex);
            }
               finally
            {
                Connection.Close();
            }
            return ApplicationID;

        }

        public static int GetLocalDrivingLicenseIdByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select LocalDrivingLicenseApplicationID from LocalDrivingLicenseApplications
		                    where ApplicationID=@ApplicationID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                    LocalDrivingLicenseID = Convert.ToInt32(Result);
            }
            catch (Exception ex)
            {
                throw new Exception(" there is a problem :", ex);
            }
            finally
            {
                Connection.Close();
            }
            return LocalDrivingLicenseID;

        }
        public static int GetNumberOFPassedTestByLocalDrivingLicenseID(int LocalDrivingLicenseID)
        {
            int PassedTests = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT        count(Tests.TestID) As PassedTest
                             FROM         Tests
                             inner join TestAppointments on TestAppointments.TestAppointmentID=Tests.TestAppointmentID
					         INNER JOIN LocalDrivingLicenseApplications ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
					         where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseID and Tests.TestResult=1";
            SqlCommand Command= new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseID", LocalDrivingLicenseID);
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                    PassedTests = Convert.ToInt32(Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { Connection.Close(); }
            return PassedTests;


        }

        public static int GetLocalDrivingLicensIDFromLicenseID(int LicenseID)
        {
            int LocalDrivingLicenseID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT        LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                           FROM            Licenses INNER JOIN
                           Applications ON Licenses.ApplicationID = Applications.ApplicationID INNER JOIN
                           LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
						   where Licenses.LicenseID=@LicenseID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                    LocalDrivingLicenseID = Convert.ToInt32(Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { 
                Connection.Close(); 
            }
            return LocalDrivingLicenseID;


        }
    }
}
