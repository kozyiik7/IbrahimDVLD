using IbrahimDVLDBusinessLayer;
using IbrahimDVLDCommonLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IbrahimDVLD
{
    public partial class frmScheduleTest : Form
    {
        public enum enFormMode { add, edit,TakeTest }
        enFormMode FormMode { get; set; }
        private int _AppID;
        public int AppID { get; set; }
        public frmScheduleTest()
        {
            InitializeComponent();
        }
       
        public frmScheduleTest(int AppID, enFormMode formMode)
        {
            InitializeComponent();
            FormMode = formMode;
            _AppID = AppID;
            this.AppID = AppID;
        }
        private bool IsTestAppointmentISLocked()
        {
          
            
            clsTestAppointments testAppointments=clsTestAppointments.GetTestAppointmentByAppID(_AppID);
          return   testAppointments.isLOcked == true;

        }
        private void CheckMode()
        {
            if (!DesignMode)
            {
                ucVisionTest1.AppID = _AppID;
                switch (FormMode)
                {
                    case enFormMode.add:
                        ucVisionTest1.lblTestIDVisible = false;
                        pnlTest.Visible = false;
                        break;
                    case enFormMode.edit:
                        ucVisionTest1.lblTestIDVisible = false;
                        if(IsTestAppointmentISLocked())
                        {
                            this.btnSave.Enabled = false;
                            ucVisionTest1.lblMainAddressText = "Retake Test";
                            ucVisionTest1.visibleSubAddressLable = true;
                            ucVisionTest1.EnableDateTimePicker = false;
                        }
                        pnlTest.Visible = false;
                        break;
                    case enFormMode.TakeTest:
                        ucVisionTest1.lblTestIDVisible = false;
                        ucVisionTest1.gbRetakeTestVisible = false;
                        rbPass.Checked = true;
                        break;

                }
            }

        }
        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            CheckMode();
        }
        private clsTestAppointments PrepareTestAppointmentData()
        {
            clsTestAppointments testAppointment = new clsTestAppointments();
            testAppointment.LocalDrivingLicenseApplicationID = ucVisionTest1.DLAppID;
            testAppointment.TestTypeID = 1; // Assuming 1 represents the vision test
            testAppointment.AppointmentDate = ucVisionTest1.AppointmentDate;
            testAppointment.PaidFees = ucVisionTest1.Fees;
            testAppointment.CreatedByUserID = UserSession.Instance.PersonID;
            testAppointment.isLOcked = false;
            return testAppointment;

        }

        private void AddTestAppointment()
        {
            clsTestAppointments testAppointment = PrepareTestAppointmentData();
            int result = testAppointment.CreateTestAppointment();
            if (result > 0)
            {
                MessageBox.Show("Test appointment scheduled successfully.");
            }
            else
            {
                MessageBox.Show("Failed to schedule test appointment. Please try again.");

            }
        }
        private void EditTestAppointment()
        {
            int result = 0;
            clsTestAppointments testAppointment = clsTestAppointments.GetTestAppointmentByAppID(_AppID);
            if (testAppointment != null)
            {
                result = testAppointment.UpdateTestAppointmentDate(testAppointment.TestAppointmentsID, ucVisionTest1.AppointmentDate);
            }
            if (result > 0)
            {
                MessageBox.Show("Test appointment updated successfully.");
            }
            else
            {
                MessageBox.Show("Failed to update test appointment. Please try again.");
            }
        }
        private void TakeTest()
        {
            int testAppointmentID=clsTestAppointments.GetTestAppointmentIDByAppID(_AppID);
            clsTests tests = new clsTests {TestAppointmentID=testAppointmentID,TestResult =  rbPass.Checked ? true : false ,Notes=txtNotes.Text,CreatedByUserID=UserSession.Instance.PersonID};
            int TestID = 0;
            TestID= tests.Create();
            if (TestID != 0)
            {
                ucVisionTest1.lblTestIDText = TestID;
                MessageBox.Show("Test Added Successfully");
                clsTestAppointments.LockTestAppointmet(_AppID);
                
            }
            else 
            {
                MessageBox.Show("Failed to Add Test");
                ucVisionTest1.lblTetakeTestIDValue = TestID;
            }


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            switch(FormMode)
            {
                case enFormMode.add:
                   AddTestAppointment();
                    btnSave.Enabled=false;
                    break;
                case enFormMode.edit:
                   EditTestAppointment();
                    btnSave.Enabled = false;
                    break;
                case enFormMode.TakeTest:
                    TakeTest();
                    btnSave.Enabled = false;
                    this.Close();
                    break;
            }
           
        }

        private void ucVisionTest1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
