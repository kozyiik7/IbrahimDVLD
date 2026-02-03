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
        public string NationalNUmber {  get; set; }
        public DateTime DateOfBirth {  get; set; }
        public bool Gendor {  get; set; }
        public string Phone {  get; set; }
        public string Email {  get; set; }
        public string Country { get; set; }
        public string Address {  get; set; }
        public string ImagePath {  get; set; }

        public static DataTable GetAllPeople()
        {
            return clsDataAccess.GetAllPeople();
        }
        public static bool IsNationalnumberExist(string number)
        {
            return IbrahimDVLDDataAccessLayer.clsDataAccess.isNationalNumberExist(number);
        }
    }
}
