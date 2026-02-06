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
                                         ref bool Gendor, ref string Phone, ref string Email, ref string Country,
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
                    Gendor = reader["Gendor"].ToString()=="True"? true:false;
                    Phone = reader["Phone"].ToString();
                    Email = reader["Email"].ToString();
                    Country=reader["Country"].ToString();
                    Address=reader["Address"].ToString();
                    if(reader["ImagePath"]!=DBNull.Value)
                    ImagePath=reader["ImagePath"].ToString();

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
                                         string Gendor,  string Phone,  string Email,  string Country,
                                         string Address,  string ImagePath)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Update people
                             Set FirstName=@FirstName
                                 SecondName=@SecondName
                                 ThirdName=@ThirdName
                                 LastName=@LastName
                                 NationalNumber=@NationalNumber ;
                                 DateOfBirth=@DateOfBirth;
                                 Gendor=@Gendor
                                 Phone=@Phone
                                 Email=@Email
                                 Country=@Country
                                 Address=@Address
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
            command.Parameters.AddWithValue("@Country", Country);
            command.Parameters.AddWithValue("@Address", Address);
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
    }
}
