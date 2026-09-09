using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDBusinessLayer
{
    public class clsCountry
    {
        public enum enMode { AddNew=0, Update=1 }
        private enMode _Mode = enMode.AddNew;
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public clsCountry() 
        {
        this.CountryID = 0;
        this.CountryName = string.Empty;
        _Mode = enMode.AddNew;
        }
        private clsCountry(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
            _Mode = enMode.Update;
        }
        public static clsCountry GetCountryInfoByCountryID(int CountryID)
        {
            string CountryName = string.Empty;
            if (IbrahimDVLDDataAccessLayer.clsCountry.GetCountryInfoByCountryID(CountryID, ref CountryName))
            {
                return new clsCountry(CountryID, CountryName);
            }
            return null;
        }



        public static DataTable GetAllCountries()
        {
            return IbrahimDVLDDataAccessLayer.clsCountry.GetAllCountries();

        }

        
        public static int GetCountyIDByCountryName(string CountryNam)
        {
            return IbrahimDVLDDataAccessLayer.clsCountry.GetCountyIDByCountryName(CountryNam);
        }
        public static string GetCountyNameByCountryID(int CountryID)
        {
            return IbrahimDVLDDataAccessLayer.clsCountry.GetCountyNameBYCountryID(CountryID);
        }
    }
}
