using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
