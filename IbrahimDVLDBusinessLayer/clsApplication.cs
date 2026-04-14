using IbrahimDVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDBusinessLayer
{
    public class clsApplication
    {
        public int ApplicationID { get; set; }
        public int ApplicationPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public short ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public int PaidFees { get; set; }
        public int CreatedcByUserID { get; set; }

        public int InsertApplication()
        {
            return IbrahimDVLDDataAccessLayer.clsApplication.InsertApplication(ApplicationPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedcByUserID);
        }
        public static bool IsDriverHasSameApplicationTypeWithStatus(int PersonID, int LicenseTypeID)
        {
            return IbrahimDVLDDataAccessLayer.clsApplication.IsDriverHasSameApplicationTypeWithStatus(PersonID, LicenseTypeID);
        }
        public static clsApplication GetApplicationData(int ApplicationID)
        {
            clsApplication application = new clsApplication();
            DataRow ApplicationDataRow = IbrahimDVLDDataAccessLayer.clsApplication.GetApplicationDataByApplicationID(ApplicationID);
            if (ApplicationDataRow != null)
            {
   
                application.ApplicationID = (int)ApplicationDataRow["ApplicationID"];
                application.ApplicationPersonID = (int)ApplicationDataRow["ApplicantPersonID"];
                application.ApplicationDate = (DateTime)ApplicationDataRow["ApplicationDate"];
                application.ApplicationTypeID = (int)ApplicationDataRow["ApplicationTypeID"];
                application.ApplicationStatus = Convert.ToInt16(ApplicationDataRow["ApplicationStatus"]);

                  application.LastStatusDate = (DateTime)ApplicationDataRow["LastStatusDate"];
                application.PaidFees = Convert.ToInt32( ApplicationDataRow["PaidFees"]);
                application.CreatedcByUserID = (int)ApplicationDataRow["CreatedByUserID"];
            }
            return application;
        }
        public static bool ISApplicationExists(int ApplicationID)
        {
            return IbrahimDVLDDataAccessLayer.clsApplication.IsApplicationExists(ApplicationID);
        }
        public static bool DeleteApplicant(int ApplicationID)
        {
            return IbrahimDVLDDataAccessLayer.clsApplication.DeleteApplication(ApplicationID);
        }
        public bool CancelApplication(int ApplicationID)
        {
            return IbrahimDVLDDataAccessLayer.clsApplication.CancelApplication(ApplicationID);
        }
       public static DataRow GetDrivingLicenseInfo(int ApplicationID)
        {
            DataRow row = null;
            row = IbrahimDVLDDataAccessLayer.clsApplication.GetDrivingLicenseInfo(ApplicationID);
            return row;
        }
        public static DataTable GetApplicationInfoWithDetailsByAppID(int AppID)
        {        
           return IbrahimDVLDDataAccessLayer.clsApplication.GetApplicationInfoWithDetailsByAppID(AppID);
       
        }
    }
}
