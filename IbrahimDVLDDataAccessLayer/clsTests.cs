using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDDataAccessLayer
{
    public  class clsTests
    {
        public clsTests() { }
        public static DataTable GetAllTest()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Tests";
            SqlCommand Command = new SqlCommand(Query, Connection);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    dt.Load(Reader);
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
            return dt;
        }

        public static int CreateNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int TestID = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID) 
                                        VALUES (@TestAppointmentID, isnull(@TestResult,null), @Notes, @CreatedByUserID);
                                        select SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);
            Command.Parameters.AddWithValue("@Notes", Notes);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                Connection.Open();
                TestID = Convert.ToInt32(Command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return TestID;
        }
        public static int GetNumberOFTestsByLocalDrivingLicenseIDAndLicenseClassID(int LocalDrivingLicenseID,int LicenseClassID,int TestTypeID)
        {
            int NumberOfTests = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select count(TestAppointments.TestAppointmentID) as Trials from TestAppointments                    
                             where TestAppointments.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseID  and TestAppointments.TestTypeID=@TestTypeID";
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseID", LocalDrivingLicenseID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {  Connection.Open();
                object Result = command.ExecuteScalar();
                if (Result!=null)
                {
                    NumberOfTests = Convert.ToInt32(Result);
                    
                }


            }
            catch(Exception ex) 
            {
                throw ex;

            }
            finally
            {
                Connection.Close();
            }
            return NumberOfTests;

        }
        public static int GetLastTestIDByApplicationID()
        {
            int NumberOfTests = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //   string Query = @"SELECT      Max(Tests.TestID) as LastID
            //                  FROM            Tests INNER JOIN
            //                  LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID INNER JOIN
            //                  TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
            //                  Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
            //where Applications.ApplicationID=@ApplicationID";
            string Query = @"SELECT      Max(Tests.TestID) as LastID
                              FROM            Tests";
            SqlCommand Command = new SqlCommand(Query, Connection);
           // Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                {
                    NumberOfTests = Convert.ToInt32(Result);
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
            return NumberOfTests;
        }


    }
}
