using IbrahimDVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDBusinessLayer
{
    public class clsLicense
    {
        public int LicenseID {  get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate {  get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public Decimal PaidFees {  get; set; }
        public bool IsActive {  get; set; }
        public byte IssueReason { get; set; }
        public int CreatedByUserID { get; set; }    

        public clsLicense()
        {
            LicenseID = 0;
            ApplicationID = 0;
            DriverID = 0;
            LicenseClass = 0;
            IssueDate = DateTime.MinValue;
            ExpirationDate = DateTime.MinValue;
            Notes = string.Empty;
            PaidFees = 0;
            IsActive = false;
            IssueReason = 0;
            CreatedByUserID = 0;

        }
        public int Create()
        {
          return LicenseID=IbrahimDVLDDataAccessLayer.clsLicense.CreateNewLicense(ApplicationID, DriverID, LicenseClass, IssueDate,ExpirationDate, Notes,PaidFees,IsActive,IssueReason,CreatedByUserID);
        }
        public static DataTable GetDriverLicenseData(int LocalDrivingLicenseID)
        {
            return IbrahimDVLDDataAccessLayer.clsLicense.GetDriverLicenseInfo(LocalDrivingLicenseID);
        }

        public static bool IsThereNonExpiredLicenseForThisPerson(int PersonID,int licenseClassID)
        {
            return IbrahimDVLDDataAccessLayer.clsLicense.IsThereNonExpiredLicenseForThisPerson(PersonID, licenseClassID);
        }

        public static DataTable GetLocalDrivingLicenseHistoryByPersonID(int PersonID)
        {
            return IbrahimDVLDDataAccessLayer.clsLicense.GetLocalDrivingLicenseHistoryByPersonID(PersonID);
        }

        public static bool IsDriverLicensClass3ExistsAndCByLicenseID(int DrvingLicenseID)
        {
            return IbrahimDVLDDataAccessLayer.clsLicense.IsDriverLicensClass3ExistsAndCByLicenseID(DrvingLicenseID);
        }

    }
}
