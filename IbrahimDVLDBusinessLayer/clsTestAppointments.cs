using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDBusinessLayer
{
    public class clsTestAppointments
    {
        public int TestAppointmentsID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool isLOcked { get; set; }

        public clsTestAppointments()
        {
            TestAppointmentsID = 0;
            TestTypeID = 0;
            LocalDrivingLicenseApplicationID = 0;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = 0;
            isLOcked = false;
        }
        public int CreateTestAppointment()
        {
            return IbrahimDVLDDataAccessLayer.clsTestAppoinments.CreateTestAppointment(TestTypeID,LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, isLOcked);
        }
         public static int GetNumberOfTrueTestsByAppID(int AppID)
        {
            return IbrahimDVLDDataAccessLayer.clsTestAppoinments.GetNumberOfTrueTestsByAppID(AppID);
        }
        public clsTestAppointments ReadAllTestAppoinment()
        {
           DataTable dt = IbrahimDVLDDataAccessLayer.clsTestAppoinments.ReadAllTestAppointments();
            if (dt.Rows.Count > 0)
            {
                TestAppointmentsID =(int)dt.Rows[0]["TestAppointmentsID"];
                TestTypeID = (int)dt.Rows[0]["TestTypeID"];
                LocalDrivingLicenseApplicationID = (int)dt.Rows[0]["LocalDrivingLicenseApplicationID"];
                AppointmentDate = (DateTime)dt.Rows[0]["AppointmentDate"];
                PaidFees = (decimal)dt.Rows[0]["PaidFees"];
                CreatedByUserID = (int)dt.Rows[0]["CreatedByUserID"];
                isLOcked = (bool)dt.Rows[0]["isLOcked"];
            }
            return this;
        }
        public static DataRow GetVisionTestAppoinmetsByAppID(int AppID)
        {
            return IbrahimDVLDDataAccessLayer.clsTestAppoinments.GetVisionTestAppoinmetsByAppID(AppID);
        }
    }
}
