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
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode=enMode.AddNew;
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName {  get; set; }
        public string LastName {  get; set; }
        public string FullName { get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; } }
        public string NationalNumber {  get; set; }
        public DateTime DateOfBirth {  get; set; }
        public byte Gendor {  get; set; }
        public string Phone {  get; set; }
        public string Email {  get; set; }
        public int CountryID { get; set; }
        public clsCountry CountryInfo
        {
            get
            {
                if (CountryInfo == null && CountryID > 0)
                {
                    return clsCountry.GetCountryInfoByCountryID(CountryID);
                }
                return clsCountry.GetCountryInfoByCountryID(CountryID);
            }
        }
        public string Address {  get; set; }
        public string ImagePath {  get; set; }
         
        public clsPeople()
        { 
            this.ID = 0;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;
            this.ThirdName = string.Empty;
            this.LastName = string.Empty;
            this.NationalNumber = string.Empty;
            this.DateOfBirth = DateTime.Now;
            this.Gendor = 0;
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.CountryID = 0;
            this.Address = string.Empty;
            this.ImagePath = string.Empty;
            _Mode = enMode.AddNew;


        }
        private clsPeople(int ID, string firstName, string secondName, string thirdName, string lastName, string nationalNumber, DateTime dateOfBirth, byte gendor, string phone, string email, int countryID, string address, string imagePath)
        {
            this.ID = ID;
           this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.NationalNumber = nationalNumber;
            this.DateOfBirth = dateOfBirth;
            this.Gendor = gendor;
            this.Phone = phone;
            this.Email = email;
            this.CountryID = countryID;
            this.Address = address;
            this.ImagePath = imagePath;
            _Mode = enMode.Update; 
        }

         public  static clsPeople GetPersonInfoPersonID(int ID )
            
        {
            string FirstName = string.Empty;
            string SecondName = string.Empty;
            string ThirdName = string.Empty;
            string LastName = string.Empty;
            string NationalNumber = string.Empty;
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            string Phone = string.Empty;
            string Email = string.Empty;
            int CountryID = 0;
            string Address = string.Empty;
            string ImagePath = string.Empty;

            if ( clsPeopleDataAccess.GetPersonInfoByPersonID(ID, ref FirstName, ref SecondName, ref ThirdName,
                                         ref LastName, ref NationalNumber, ref DateOfBirth,
                                         ref Gendor, ref Phone, ref Email, ref CountryID,
                                         ref Address, ref ImagePath))
            {
                return new clsPeople(ID, FirstName, SecondName, ThirdName, LastName, NationalNumber, DateOfBirth,
                                   Gendor, Phone, Email, CountryID, Address, ImagePath);
            }
            else
            {
                return null;
            }

        }

        public static bool Delete(int PersonID)
        {
            return clsPeopleDataAccess.Delete(PersonID);
        }




        public static DataTable GetAllPeople()
        {
            return clsPeopleDataAccess.GetAllPeople();
        }
        public static bool IsNationalnumberExist(string number)
        {
            return clsPeopleDataAccess.isNationalNumberExist(number);
        }

       
        
       

        private  bool _Update()
        {

            return clsPeopleDataAccess.Update(this.ID, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.NationalNumber,
                this.DateOfBirth,this.Gendor, this.Phone, this.Email, this.CountryID, this.Address, this.ImagePath);
        }
        private  bool _AddNew()
            {
    
                this.ID = clsPeopleDataAccess.AddNew(this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.NationalNumber,
                    DateOfBirth, this.Gendor, this.Phone, this.Email, this.CountryID, this.Address, this.ImagePath);
                return this.ID > 0;
            }
        
        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                  
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                  else 
                    { 
                        return false;
                    }
                case enMode.Update:
                    return _Update();
                default:
                    return false;
            }
        }
        public static int GetPersonIDByNationalNumber(string NationalNumber)
        {
            return clsPeopleDataAccess.GetPersonIDByNationalNumber(NationalNumber);
        }

        public static bool IsPersonIDExist(int PersonID)
        {
            return clsPeopleDataAccess.isPersonIDExist(PersonID);
        }
        public static int GetPersonIDByDriverID(int DriverID)
        {
            return IbrahimDVLDDataAccessLayer.clsUsers.GetPersonIDByDriverID(DriverID);
        }
    }
}
