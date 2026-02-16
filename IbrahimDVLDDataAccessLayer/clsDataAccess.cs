using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDDataAccessLayer
{
    public class clsDataAccess
    {
        public static DataTable GetAllPeople()
        {
            DataTable dtPeople=new DataTable();

            SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * from People";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dtPeople.Load(reader);
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                
                connection.Close();
            }

            return dtPeople;

        }
        public static bool isNationalNumberExist(string NationalNumber)
        {
            bool isNationalNumberExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM People WHERE NationalNo = @NationalNumber";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
            try
            {
                connection.Open();
                SqlDataReader reader=command.ExecuteReader();
                if (reader.HasRows)
                {
                   isNationalNumberExist=true;
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {

                connection.Close();
            }

            return isNationalNumberExist;


        }

        
        public static bool GetPersonInfo(int ID, ref string FirstName, ref string SecondName, ref string ThirdName,
                                         ref string LastName, ref string NationalNUmber, ref DateTime DateOfBirth,
                                         ref short Gendor, ref string Phone, ref string Email, ref int CountryID,
                                         ref string Address, ref string ImagePath)
        {
            bool IsFound=false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select * from People where PersonID=@ID ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound=true;
                    FirstName=reader["FirstName"].ToString();
                    SecondName=reader["SecondName"].ToString();
                    ThirdName=reader["ThirdName"].ToString();
                    LastName=reader["LastName"].ToString();
                    NationalNUmber=reader["NationalNo"].ToString();
                    DateOfBirth=Convert.ToDateTime( reader["DateOfBirth"]);
                    Gendor = reader["Gendor"].ToString()=="1"? (short)1 : (short)0;
                    Phone = reader["Phone"].ToString();
                    Email = reader["Email"].ToString();
                    CountryID = (int)reader["NationalityCountryID"];
                    Address=reader["Address"].ToString();
                    if(reader["ImagePath"]!=DBNull.Value)
                    ImagePath=reader["ImagePath"].ToString();
                    else
                        ImagePath=string.Empty;

                }
                reader.Close();

            }
            catch (Exception ex)
            {

            }
            finally
            {

                connection.Close();
              
            }
            return IsFound;
        }
        public static bool  Delete(int PersonID)
        {
            
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "DELETE FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                int RowAffected = command.ExecuteNonQuery();
                if (RowAffected>0)
                {
                   IsFound = true;
                }

            }
            catch (Exception ex)
            {
             IsFound=false;
            }
            finally
            {

                connection.Close();
            }

            return IsFound;

        }
        public static bool Update(int PersonID,  string FirstName,  string SecondName,  string ThirdName,
                                         string LastName,  string NationalNumber,  DateTime DateOfBirth,
                                         short Gendor,  string Phone,  string Email,  int CountryID,
                                         string Address,  string ImagePath)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Update people
                             Set FirstName=@FirstName,
                                 SecondName=@SecondName,
                                 ThirdName=@ThirdName,
                                 LastName=@LastName,
                                 NationalNo=@NationalNumber ,
                                 DateOfBirth=@DateOfBirth,
                                 Gendor=@Gendor,
                                 Phone=@Phone,
                                 Email=@Email,
                                 NationalityCountryID=@CountryID,
                                 Address=@Address,
                                 ImagePath=@ImagePath
                             WHERE PersonID=@PersonID;";

                                                     
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@Address", Address);
            if(string.IsNullOrEmpty(ImagePath))
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            try
            {
                connection.Open();
                int RowAffected = command.ExecuteNonQuery();
                if (RowAffected>0)
                {
                   IsFound = true;

                }
               

            }
            catch (Exception ex)
            {

            }
            finally
            {

                connection.Close();

            }
            return IsFound;
        }
        public static int AddNew( string FirstName, string SecondName, string ThirdName,
                                         string LastName, string NationalNumber, DateTime DateOfBirth,
                                         short Gendor, string Phone, string Email, int CountryID,
                                         string Address, string ImagePath)
        {
            int PersonID = -1; 

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
            INSERT INTO [dbo].[People]
            ([NationalNo]
           ,[FirstName]
           ,[SecondName]
           ,[ThirdName]
           ,[LastName]
           ,[DateOfBirth]
           ,[Gendor]
           ,[Address]
           ,[Phone]
           ,[Email]
           ,[NationalityCountryID]
           ,[ImagePath])
VALUES
           (@NationalNumber,
            @FirstName,
            @SecondName,
            @ThirdName,
            @LastName,
            @DateOfBirth,
            @Gendor,
            @Address,
            @Phone,
            @Email,
            @CountryID,
            @ImagePath);
SELECT SCOPE_IDENTITY();
";



            SqlCommand command = new SqlCommand(query, connection);
           
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@Address", Address);
            if (string.IsNullOrEmpty(ImagePath))
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

            try
            {
                connection.Open();
               object value1 = command.ExecuteScalar();
                if (value1!=null )
                {
                    PersonID=Convert.ToInt32(value1);

                }
               


            }
            catch (Exception ex)
            {
               ex.Message.ToString();
            }
            finally
            {

                connection.Close();

            }
            return PersonID;
        }
    }
}
