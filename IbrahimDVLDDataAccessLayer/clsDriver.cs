using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDDataAccessLayer
{
    public class clsDriver
    {
        public clsDriver() { }

        public static int CreateNewDriver(int PersonID,int CreatedByPersonID,DateTime CreatedDate)
        {
            int DriverID = 0;
            SqlConnection Connection=new SqlConnection(clsDataAccessSettings.ConnectionString)  ;
            string Query = @"INSERT INTO [dbo].[Drivers]
                           ([PersonID]
                           ,[CreatedByUserID]
                           ,[CreatedDate])
                     VALUES
                            (@PersonID
                           ,@CreatedByPersonID
                           ,@CreatedDate);
                           select SCOPE_IDENTITY(); ";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@CreatedByPersonID", CreatedByPersonID);
            Command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                    DriverID = Convert.ToInt32(Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return DriverID;

        }
        public static bool IsDriverExistByPersonID(int PersonID)
        {
            int DriverCount = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select count(DriverID) As DriverCount from Drivers
                             where PersonID=@PersonID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
           
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                    DriverCount = Convert.ToInt32(Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return DriverCount>0;

        }

        public static int GetDriverIDByPersonID(int PersonID)
        {
            int DriverID = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select DriverID As DriverID from Drivers
                              where PersonID=@PersonID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                    DriverID = Convert.ToInt32(Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return DriverID;

        }
        public static DataTable GetAllDrivers()
        {
            DataTable dtDrivers = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT      distinct    Drivers.DriverID
              , People.PersonID
              , People.NationalNo
              , CONCAT_WS(' ', People.FirstName,People.SecondName,ISNULL(People.ThirdName,''),People.LastName)as 'Full Name'
              , Drivers.CreatedDate
             
			  ,(select   Count(Licenses.LicenseID) from Licenses where Licenses.DriverID=Drivers.DriverID and Licenses.IsActive=1)as 'Active Licenses'
               FROM            Drivers INNER JOIN People 
                ON Drivers.PersonID = People.PersonID 
				INNER JOIN Licenses 
				ON Drivers.DriverID = Licenses.DriverID";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader reader= Command.ExecuteReader();
                if(reader.HasRows)
                    dtDrivers.Load(reader);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
            return dtDrivers;
        }
    }
}
