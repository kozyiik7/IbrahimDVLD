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
            return table==null?null:table   ;
        }
        public static DataRow GetVisionTestAppoinmetsByAppID(int AppID) 
        {
        
            DataTable table = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT        TestAppointments.TestAppointmentID as 'Appointment ID' ,TestAppointments.AppointmentDate as 'Appointment Date',TestAppointments.PaidFees as 'Paid Fees' ,TestAppointments.IsLocked as 'Is Locked'
                             FROM            Applications
                            INNER JOIN LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
			                INNER JOIN TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
			              	inner join Tests on TestAppointments.TestAppointmentID=Tests.TestAppointmentID
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
            return table.Rows.Count == 0 ? null : table.Rows[0];
        }
    }
}