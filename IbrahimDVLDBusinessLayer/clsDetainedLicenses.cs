using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDBusinessLayer
{
    public class clsDetainedLicenses
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public Nullable< DateTime> ReleaseDate { get; set; }  //Allow Nullable if not released yet
        public Nullable<int> ReleasedByUserID { get; set; }   //Allow Nullable if not released yet
        public Nullable<int> ReleaseApplicationID { get; set; } //Allow Nullable if not released yet
        public clsDetainedLicenses()
        {
            DetainID = 0;
            LicenseID = 0;
            DetainDate = DateTime.Now;
            FineFees = 0;
            CreatedByUserID = 0;
            IsReleased = false;
            ReleaseDate =null;
            ReleasedByUserID = null;
            ReleaseApplicationID = null;


        }
        public static clsDetainedLicenses Read(int LicenseID)
        {
            DataRow dr=IbrahimDVLDDataAccessLayer.clsDetainedLicenses.GetDetainedLicenseDataByLicenseID(LicenseID);
            if (dr != null)
            {
                clsDetainedLicenses detainedLicense = new clsDetainedLicenses();
                detainedLicense.LicenseID = LicenseID;
                detainedLicense.DetainID = (int)dr["DetainID"];
                detainedLicense.DetainDate = (DateTime)dr["DetainDate"];
                detainedLicense.FineFees = (decimal)dr["FineFees"];
                detainedLicense.CreatedByUserID = (int)dr["CreatedByUserID"];
                detainedLicense.IsReleased = (bool)dr["IsReleased"];
                detainedLicense.ReleaseDate = dr["ReleaseDate"] != DBNull.Value ? (DateTime)dr["ReleaseDate"] : DateTime.MinValue;
                detainedLicense.ReleasedByUserID = dr["ReleasedByUserID"] != DBNull.Value ? (int)dr["ReleasedByUserID"] : 0;
                detainedLicense.ReleaseApplicationID = dr["ReleaseApplicationID"] != DBNull.Value ? (int)dr["ReleaseApplicationID"] : 0;
                return detainedLicense;
            }
            return null;
        }
        public int Create()
        {

            DetainID = IbrahimDVLDDataAccessLayer.clsDetainedLicenses.CreateDetainLicense(LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            return DetainID;
                
        }
        public bool Update()
        {
            return IbrahimDVLDDataAccessLayer.clsDetainedLicenses.UpdateDetainLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
        }
    }
}
