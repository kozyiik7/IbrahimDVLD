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
    }
}
