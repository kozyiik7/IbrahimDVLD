using IbrahimDVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IbrahimDVLD
{
    public partial class frmIssueDriverLicenseForTheFirstTime : Form
    {
        int PersonID = 0;
        private int LicenseClassID = 0;
        private int _AppID=0;
        clsDriver Driver = new clsDriver();
        clsLicenseClasses licenseClass=new clsLicenseClasses();
        clsApplication Application= new clsApplication();
        clsLicense License = new clsLicense();
        private int DriverID = 0;
        private int LicenseID = 0;
        public frmIssueDriverLicenseForTheFirstTime()
        {
            InitializeComponent();
        }
        public frmIssueDriverLicenseForTheFirstTime(int AppID)
        {
            InitializeComponent();
            _AppID = AppID;
           PrepareFormData();
        }

        private void PrepareFormData()
        {
            ucDrivingLicenseApplicationInfo1.DLAppID = _AppID;
            ucApplicationBasicInfo1.ApplicationID = _AppID;
            string LicenseClassName = "";
            if (ucDrivingLicenseApplicationInfo1.AppliedForLicense != null)
            {
                LicenseClassName = ucDrivingLicenseApplicationInfo1.AppliedForLicense;
                LicenseClassID = clsLicenseClasses.GetLicenseClassIDFromClassName(LicenseClassName);
            }
            if(ucApplicationBasicInfo1.PersonID!=-1)
            PersonID=ucApplicationBasicInfo1.PersonID;
        }
        private void GetDriverInfoAndCreateDriver()
        {
            if (clsDriver.IsDriverExistByPersonID(PersonID))
            {
                DriverID = clsDriver.GetDriverIDByPersonID(PersonID);
                Driver.DriverID = DriverID;
                return;
            }
            Driver.PersonID=PersonID;
            Driver.CreatedByUserID=IbrahimDVLDCommonLayer.UserSession.Instance.UserID;
            Driver.CreatedDate=DateTime.Now;
           DriverID= Driver.Create();
        }

        private void GetLicensClassInfo()
        {
           licenseClass= licenseClass.GetLicenseClassDataByLicenseClassID(LicenseClassID);
        }
        private void GetApplicationInfo()
        {
            Application = clsApplication.GetApplicationData(_AppID);
        }
        private void PrepareLicenseData()
        {
            License.ApplicationID= _AppID;

            License.DriverID = Driver.DriverID;
            License.LicenseClass = licenseClass.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(licenseClass.DefaultValidityLength);
            License.Notes =txtNotes.Text!=string.Empty?txtNotes.Text:"" ;
            License.PaidFees = licenseClass.ClassFees;
            License.IsActive = true;
            License.IssueReason = 1;
            License.CreatedByUserID = IbrahimDVLDCommonLayer.UserSession.Instance.UserID;
            LicenseID=  License.LicenseID = License.Create();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool UpdateApplicationStatus()
        {
            
            Application.ApplicationStatus = 3;
            Application.LastStatusDate = DateTime.Now;
           return  Application.Update();

        }
        private void frmIssueDriverLicenseForTheFirstTime_Load(object sender, EventArgs e)
        {
           


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GetDriverInfoAndCreateDriver();
            GetLicensClassInfo();
            GetApplicationInfo();
            PrepareLicenseData();
            if (UpdateApplicationStatus())
                MessageBox.Show(@$"Driver Added Succcessfully with DriverID :{DriverID}
                                   And Give him LicenseID : {LicenseID}
                                   Application StatusUpdate Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnIssue.Enabled = false;
            
        }
    }
}
