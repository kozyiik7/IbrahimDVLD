using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDBusinessLayer
{
   

    public class clsTests
    {
        public int TestID { get; set; }

        public int TestAppointmentID { get; set; }  
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public clsTests()
        {
            TestID = 0;
            TestAppointmentID = 0;
            TestResult = false;
            Notes = string.Empty;
            CreatedByUserID = 0;
        }
        public static DataTable GetAllTests()
        {
            return IbrahimDVLDDataAccessLayer.clsTests.GetAllTest();
        }
        public int Create()
        {
            this.TestID= IbrahimDVLDDataAccessLayer.clsTests.CreateNewTest(TestAppointmentID, TestResult, Notes, CreatedByUserID);
            return this.TestID;
        }

        public static int GetNumberOFTestsByLocalDrivingLicenseIDAndLicenseClassID(int LocalDrivingLicenseID, int LicenseClassID ,int TestTypeID)
        {
            return IbrahimDVLDDataAccessLayer.clsTests.GetNumberOFTestsByLocalDrivingLicenseIDAndLicenseClassID(LocalDrivingLicenseID, LicenseClassID,TestTypeID) ;
        }
        public static int GetLastTestIDByApplicationID( )
        {
            return IbrahimDVLDDataAccessLayer.clsTests.GetLastTestIDByApplicationID();
        }
    }
}
