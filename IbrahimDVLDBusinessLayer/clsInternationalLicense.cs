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
    }
}
