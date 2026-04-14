using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDBusinessLayer
{
    public class clsLocalDrivingLicenseApplications
    {
        public static int InsertLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            return IbrahimDVLDDataAccessLayer.clsLocalDrivingLicenseApplication.InsertLocalDrivingLicenseApplication(ApplicationID, LicenseClassID);
        }
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return IbrahimDVLDDataAccessLayer.clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
        }
        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            return IbrahimDVLDDataAccessLayer.clsLocalDrivingLicenseApplication.DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);
        }
       
        public static int GetApplicationIDByLicenseID(int LicenseID)
        {
            return IbrahimDVLDDataAccessLayer.clsLocalDrivingLicenseApplication.GetApplicationIDByLocalDrivingLicenseID(LicenseID);
        }
        public static int GetLicenseIDByApplicationID(int ApplicationID)
        {
            return IbrahimDVLDDataAccessLayer.clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseIdByApplicationID(ApplicationID);
        }

    }
}
