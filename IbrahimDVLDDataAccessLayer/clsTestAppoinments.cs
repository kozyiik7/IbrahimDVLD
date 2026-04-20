using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDDataAccessLayer
{
    public class clsTestAppoinments
    {
        public static int GetNumberOfTrueTestsByAppID(int AppID)
        {
            int numberOfTests = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT        COUNT(TestAppointments.LocalDrivingLicenseApplicationID) AS NumberOFTests
                            FROM            Applications 
                            INNER JOIN LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID 
			            	INNER JOIN TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
							inner Join Tests on TestAppointments.TestAppointmentID=Tests.TestAppointmentID
                            WHERE       ( Applications.ApplicationID = @AppID and Tests.TestResult=1 )";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@AppID", AppID);
            try
            {
                connection.Open();
                numberOfTests = (int)Command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return numberOfTests;
        }

        public static int CreateTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool isLOcked)
        {
            int TestAppointmentID = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO TestAppointments
                            (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, isLOcked)
                            VALUES (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @isLOcked);
                            SELECT SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@isLOcked", isLOcked);
            try
            {
                connection.Open();
                TestAppointmentID = Convert.ToInt32(Command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return TestAppointmentID;
        }

        public static DataTable ReadAllTestAppointments()
        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM   TestAppointments";
            SqlCommand Command = new SqlCommand(Query, Connection);
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                table.Load(reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return table == null ? null : table;
        }
        public static DataTable GetVisionTestAppoinmetsByAppID(int AppID)
        {

            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT        TestAppointments.TestAppointmentID as 'Appointment ID' ,TestAppointments.AppointmentDate as 'Appointment Date',TestAppointments.PaidFees as 'Paid Fees' ,TestAppointments.IsLocked as 'Is Locked'
                             FROM            Applications
                            INNER JOIN LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
			                INNER JOIN TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
			              	
			                where Applications.ApplicationID=@AppID and TestAppointments.TestTypeID=1";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AppID", AppID);
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);
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
            return table.Rows.Count == 0 ? null : table;
        }
        public static bool ISThereVisionTest(int AppID)
        {

            bool ThereISVisionTest = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT       count( TestAppointments.TestAppointmentID )as ISThereVisionTest
                             FROM            Applications 
							 inner join LocalDrivingLicenseApplications on Applications.ApplicationID=LocalDrivingLicenseApplications.ApplicationID
							 inner join TestAppointments on TestAppointments.LocalDrivingLicenseApplicationID=LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                           
			                where Applications.ApplicationID=@AppID and TestAppointments.TestTypeID=1 and TestAppointments.IsLocked=0 ";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AppID", AppID);
            try
            {
                Connection.Open();
                object obj = Command.ExecuteScalar();
                ThereISVisionTest = Convert.ToInt32(obj) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return ThereISVisionTest;
        }

        public static DataRow GetVisionTestDataByAppID(int AppID)
        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT        LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID as DLAppID
             , LicenseClasses.ClassName as DClass
			 , People.FirstName+' '+People.SecondName+' '+ISNULL(People.ThirdName,'')+' '+People.LastName as 'Full Name'
			 , (select count (TestAppointments.TestTypeID ) from TestAppointments Where TestAppointments.LocalDrivingLicenseApplicationID=LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID and Applications.ApplicationID=@AppID) as Trials
			 , (Select TestTypes.TestTypeFees from TestTypes where TestTypes.TestTypeID=1) As Fees
               FROM            Applications INNER JOIN
                         LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID INNER JOIN
                         People ON Applications.ApplicantPersonID = People.PersonID
						 INNER JOIN
                         LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
					     where Applications.ApplicationID=@AppID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AppID", AppID);
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);
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
            return table.Rows.Count == 0 ? null : table.Rows[0];
        }
        public static int EditTestAppoinmentDate(int testAppointmentID, DateTime dateTime)
        {
            int AffectedRows = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE TestAppointments
                            SET AppointmentDate=@AppointmentDate
                            WHERE TestAppointmentID=@TestAppointmentID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AppointmentDate", dateTime);
            Command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
            try
            {
                Connection.Open();
                AffectedRows = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return AffectedRows;
        }
        public static DataTable getTestAppointmentDataByAppID(int AppID)
        {
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT        TestAppointments.TestAppointmentID, TestAppointments.TestTypeID, TestAppointments.LocalDrivingLicenseApplicationID, TestAppointments.AppointmentDate, TestAppointments.PaidFees, TestAppointments.CreatedByUserID, TestAppointments.isLOcked
                             FROM            Applications
                            INNER JOIN LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            INNER JOIN TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                            
                            where Applications.ApplicationID=@AppID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AppID", AppID);
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);
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
            return table;
        }

        public static bool LockTestAppointment(int AppID)
        {
            int AffectedRows = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE TestAppointments
                            SET isLOcked=1 ";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                AffectedRows = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return AffectedRows > 0;

        }
        public static int GetTestAppointmentIDByApplicationID(int AppID)
        {
            int TestAppointmentID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select TestAppointments.TestAppointmentID
                             from TestAppointments 
                             inner join LocalDrivingLicenseApplications on TestAppointments.LocalDrivingLicenseApplicationID=LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                             inner join Applications on Applications.ApplicationID=LocalDrivingLicenseApplications.ApplicationID
                             where Applications.ApplicationID=@AppID";
            SqlCommand Command=new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AppID", AppID);
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                    TestAppointmentID = (int)Result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Connection.Close(); }
            return TestAppointmentID;

        }
    }
}