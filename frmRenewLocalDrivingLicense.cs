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
    public partial class frmRenewLocalDrivingLicense : Form
    {
        private static string ApplicationName = "Renew Driving License Service";
        public static int LicenseClassID = 0;
        private int _LicenseID = -1;
        clsLicense License = new clsLicense();
        clsApplication NewApplication= new clsApplication();
        clsLicense NewLicense = new clsLicense();
        public frmRenewLocalDrivingLicense()
        {
            InitializeComponent();
        }

        private void frmRenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            ucFilterDriverLicense1.LicensedIDChanged += GetLicenseID;
            ucFilterDriverLicense1.Focus();
            llShowLicenseInfo.Enabled = false;
            llShowLicensesHistory.Enabled = false;



        }
        public void GetLicenseID(int LicenceID,object Sender)
        {
            _LicenseID=LicenceID;
            if (_LicenseID != -1)
            License = clsLicense.GetDriverLicensDataLicenseID_object(_LicenseID);
            if (License != null)
            {
                FillRenewLicenseData();
                if (License.ExpirationDate > DateTime.Now)
                {
                    btnRenew.Enabled = false;
                    llShowLicenseInfo.Enabled = false;
                    MessageBox.Show("This License is not expired yet, you can't renew it");
                   
                }
                if(License.IsActive==false)
                {
                    btnRenew.Enabled = false;
                    llShowLicenseInfo.Enabled = false;
                    MessageBox.Show("This License is not active, you can't renew it");
                }

            }
           

        }
        private void FillRenewLicenseData()
        {
            //clsLicense License = clsLicense.GetDriverLicensDataLicenseID_object(_LicenseID);
            LicenseClassID = License.LicenseClass;
            clsLicenseClasses licenseClassData = clsLicenseClasses.GetLicenseClassDataByLicenseClassID(LicenseClassID);;
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblOldLicenseID.Text = _LicenseID.ToString();
            lblApplicationFees.Text = clsApplicationTypes.GetApplicationFeesFromApplicatioName(ApplicationName).ToString();
            lblLicenseFees.Text=licenseClassData.ClassFees.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(licenseClassData.DefaultValidityLength).ToString();
            lblTotalFees.Text = (Convert.ToDecimal(lblApplicationFees.Text)+Convert.ToDecimal(lblLicenseFees.Text)).ToString();
            lblCreatedBy.Text = IbrahimDVLDCommonLayer.UserSession.Instance.UserName;
           
         

        }

        private void DeActiveLicense()
        {
            NewLicense = License;
            License.IsActive = false;
            License.Update();
        }
        private void PerformNewApplication()
        {
            NewApplication.ApplicationPersonID=clsPeople.GetPersonIDByDriverID(License.DriverID) ;
            NewApplication.ApplicationDate = DateTime.Now;
            NewApplication.ApplicationTypeID = clsApplicationTypes.GetApplicationTypeIDFromApplicatioName(ApplicationName);
            NewApplication.ApplicationStatus =3;
            NewApplication.LastStatusDate = DateTime.Now;
            NewApplication.PaidFees=clsApplicationTypes.GetApplicationFeesFromApplicatioName(ApplicationName);
            NewApplication.CreatedcByUserID = IbrahimDVLDCommonLayer.UserSession.Instance.UserID;
            NewApplication.ApplicationID=NewApplication.InsertApplication();
            clsLocalDrivingLicenseApplications LocalDrivingLicenseApplication=new clsLocalDrivingLicenseApplications();
            int localDrivingLicenseApplicationID = clsLocalDrivingLicenseApplications.InsertLocalDrivingLicenseApplication(NewApplication.ApplicationID, License.LicenseClass);

        }
        private void PerformNewLicense()
        {
            NewLicense.LicenseID = -1;
            NewLicense.ApplicationID = NewApplication.ApplicationID;
            NewLicense.DriverID = License.DriverID;
            NewLicense.LicenseClass = License.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;
            clsLicenseClasses licenseClassData = clsLicenseClasses.GetLicenseClassDataByLicenseClassID(License.LicenseClass);
            NewLicense.ExpirationDate = DateTime.Now.AddYears(licenseClassData.DefaultValidityLength);
            NewLicense.Notes = "Renewed License";
            NewLicense.PaidFees = Convert.ToDecimal(lblTotalFees.Text);
            NewLicense.IsActive = true;
            NewLicense.IssueReason = 2;
            NewLicense.CreatedByUserID = IbrahimDVLDCommonLayer.UserSession.Instance.UserID;
            NewLicense.Create();
        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
            DeActiveLicense();
            PerformNewApplication();
            PerformNewLicense();
            MessageBox.Show("License Renewed Successfully with ID " + NewLicense.LicenseID);
            lblRLApplicationID.Text = NewApplication.ApplicationID.ToString();
            lblRenewedLicenseID.Text = NewLicense.LicenseID.ToString();
            btnRenew.Enabled = false;
            llShowLicenseInfo.Enabled = true;
            llShowLicensesHistory.Enabled = true;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(clsPeople.GetPersonIDByDriverID(License.DriverID));
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(clsLocalDrivingLicenseApplications.GetLocalDrivingLicensIDFromLicenseID(NewLicense.LicenseID));
            frm.ShowDialog();
        }
    }
}
