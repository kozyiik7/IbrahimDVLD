using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDBusinessLayer
{
    public class clsInternationalLicense
    {
        public int InternationalLicenseID {  get; set; }
        public int ApplicationID {  get; set; }
        public int DriverID { get; set; }   
        public int IssuedUsingLocalLicenseID {  get; set; }
        public DateTime IssueDate {  get; set; }
        public DateTime ExpirationDate {  get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID {  get; set; }

        public clsInternationalLicense()
        {
            InternationalLicenseID = 0;
            ApplicationID = 0;
            DriverID = 0;
            IssuedUsingLocalLicenseID = 0;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = false;
            CreatedByUserID = 0;
        }
        public static DataTable GetInternationalLicenseHistoryByPersonID(int PersonID)
        {
            return IbrahimDVLDDataAccessLayer.clsInternationalLicenses.GetInternationalLicenseHistoryByPersonID(PersonID);
        }
        public int Creat()
        {
            int InternationalLicenseID = IbrahimDVLDDataAccessLayer.clsInternationalLicenses.InsertNewInternationalLicenseData(ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            return InternationalLicenseID;
        }
        public static bool IsDriverHasActiveInternationalLicenseByDriverID(int DriverID)
        {
            return IbrahimDVLDDataAccessLayer.clsInternationalLicenses.IsDriverHasActiveInternationalLicenseByDriverID(DriverID);
        }
        public static DataRow GetDriverInternationalLicenseInfoByDriverID(int DriverID)
        {
            return IbrahimDVLDDataAccessLayer.clsInternationalLicenses.GetDriverInternationalLicenseInfoByDriverID(DriverID);
        }
        public static DataTable GetAllInternationalLicenses()
        {
            return IbrahimDVLDDataAccessLayer.clsInternationalLicenses.GetAllInternationalLicenses();
        }
        public static clsInternationalLicense GetDriverInternationalLicenseInfoByInternationalLicenseID(int InternationalLicenseID)
        {
            DataRow drLicenseInfo = IbrahimDVLDDataAccessLayer.clsInternationalLicenses.GetDriverInternationalLicenseInfoByInternationalLicenseID(InternationalLicenseID);
            clsInternationalLicense MyLicense = new clsInternationalLicense();
            if (drLicenseInfo != null)
            {
                MyLicense.ApplicationID = (int)drLicenseInfo["ApplicationID"];
                MyLicense.DriverID = (int)drLicenseInfo["DriverID"];
                MyLicense.IssuedUsingLocalLicenseID = (int)drLicenseInfo["IssuedUsingLocalLicenseID"];
                MyLicense.IssueDate = (DateTime)drLicenseInfo["IssueDate"];
                MyLicense.ExpirationDate = (DateTime)drLicenseInfo["ExpirationDate"];
                MyLicense.IsActive = (bool)drLicenseInfo["IsActive"];
                MyLicense.CreatedByUserID = (int)drLicenseInfo["CreatedByUserID"];
                MyLicense.InternationalLicenseID = (int)drLicenseInfo["InternationalLicenseID"];

                return MyLicense;
            }
            return null;
        }
    }
}
