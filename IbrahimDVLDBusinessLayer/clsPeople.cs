using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IbrahimDVLDDataAccessLayer;

namespace IbrahimDVLDBusinessLayer
{
    public class clsPeople
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName {  get; set; }
        public string LastName {  get; set; }
        public string NationalNumber {  get; set; }
        public DateTime DateOfBirth {  get; set; }
        public short Gendor {  get; set; }
        public string Phone {  get; set; }
        public string Email {  get; set; }
        public int CountryID { get; set; }
        public string Address {  get; set; }
        public string ImagePath {  get; set; }
         
        public clsPeople()
        { 
        
        }
        public clsPeople(int ID, string firstName, string secondName, string thirdName, string lastName, string nationalNumber, DateTime dateOfBirth, short gendor, string phone, string email, int countryID, string address, string imagePath)
        {
            this.ID = ID;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            NationalNumber = nationalNumber;
            DateOfBirth = dateOfBirth;
            Gendor = gendor;
            Phone = phone;
            Email = email;
            CountryID = countryID;
            Address = address;
            ImagePath = imagePath;
        }

        public static DataTable GetAllPeople()
        {
            return clsDataAccess.GetAllPeople();
        }
        public static bool IsNationalnumberExist(string number)
        {
            return clsDataAccess.isNationalNumberExist(number);
        }

        public  static clsPeople GetPersonInfo(int ID , ref string FirstName, ref string SecondName, ref string ThirdName,
                                         ref string LastName, ref string NationalNUmber,ref DateTime DateOfBirth ,
                                         ref short Gendor, ref string Phone, ref string Email, ref int CountryID,
                                         ref string Address , ref string ImagePath)
        {
            
           if( clsDataAccess.GetPersonInfo(ID, ref FirstName, ref SecondName, ref ThirdName,
                                         ref LastName, ref NationalNUmber, ref DateOfBirth,
                                         ref Gendor, ref Phone, ref Email, ref CountryID,
                                         ref Address, ref ImagePath))
            {
                return new clsPeople(ID, FirstName, SecondName, ThirdName, LastName, NationalNUmber, DateOfBirth,
                                   Gendor, Phone, Email, CountryID, Address, ImagePath);
            }
            else
            {
                return null;
            }

        }
        public static bool Delete(int PersonID)
        {
            return clsDataAccess.Delete(PersonID);
        }

        public  bool Update(int PersonID, string FirstName, string SecondName, string ThirdName,
                                         string LastName, string NationalNumber, DateTime DateOfBirth,
                                         short Gendor, string Phone, string Email, int CountryID,
                                         string Address, string ImagePath)
        {

            return clsDataAccess.Update(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNumber,
                DateOfBirth,Gendor, Phone, Email, CountryID, Address, ImagePath);
        }
        public  int Insert(string FirstName, string SecondName, string ThirdName,
                                            string LastName, string NationalNumber, DateTime DateOfBirth,
                                            short Gendor, string Phone, string Email, int CountryID,
                                            string Address, string ImagePath)
            {
    
                return clsDataAccess.AddNew(FirstName, SecondName, ThirdName, LastName, NationalNumber,
                    DateOfBirth, Gendor, Phone, Email, CountryID, Address, ImagePath);
        }
    }
}
