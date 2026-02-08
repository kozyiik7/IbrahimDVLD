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
