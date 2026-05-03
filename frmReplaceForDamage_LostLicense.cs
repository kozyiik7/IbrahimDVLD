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
    public partial class frmReplaceForDamage_LostLicense : Form
    {
        public frmReplaceForDamage_LostLicense()
        {
            InitializeComponent();
        }
        public static string ApplicationDamagedName = "Replacement for a Damaged Driving License";
        public static string ApplicationLostName=  "Replacement for a Lost Driving License";
        public enum enFormType 
        {
            DamagedLicense,
            LostLicense
        }
        private enFormType _enFormType=enFormType.DamagedLicense;
        private int _LicenseID = -1;
        clsLicense License = new clsLicense();
        clsApplication NewApplication= new clsApplication();
        int LocalDrivingLicenseID = -1;
        clsLicense NewLicense = new clsLicense();


        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            lblMainAddress.Text= "Replace for Damaged License";
            _enFormType= enFormType.DamagedLicense;
            lblApplicationFees.Text = clsApplicationTypes.GetApplicationFeesFromApplicatioName(ApplicationDamagedName).ToString();
        }

        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            lblMainAddress.Text = "Replace for Lost License";
            _enFormType = enFormType.LostLicense;
            lblApplicationFees.Text = clsApplicationTypes.GetApplicationFeesFromApplicatioName(ApplicationLostName).ToString();
        }
        public void GetLicenseID(int LicenceID, object Sender)
        {
            _LicenseID = LicenceID;
            License=clsLicense.GetDriverLicensDataLicenseID_object(_LicenseID);
            if(License==null)
            {
                MessageBox.Show("This License does not exist, you can't apply for replacement");
                return;
            }
            if(License.IsActive==false)
            {             
                MessageBox.Show("This License is not active, you can't apply for replacement");
                return;
            }
            if( License.ExpirationDate<DateTime.Now)
            {
                MessageBox.Show("This License is expired, you can't apply for replacement");
                return;
            }
            btnIssueReplacement.Enabled = true;
           // llShowNewLicenseInfo.Enabled = true;
            llShowLicensesHistory.Enabled = true;
            _PrepareNewApplicationInfo();
            _PrepareLDLApplication();


        }
        private void _PrepareForm()
        {
            rbDamaged.Checked = true;
            ucFilterDriverLicense1.LicensedIDChanged += GetLicenseID;
            _enFormType = enFormType.DamagedLicense;
            btnIssueReplacement.Enabled=false;
            llShowLicensesHistory.Enabled=false;
            llShowNewLicenseInfo.Enabled=false;
            ucFilterDriverLicense1.Focus();

        }
        private void _PrepareNewApplicationInfo()
        {
            switch(_enFormType)
            {
                case enFormType.DamagedLicense:
                    NewApplication.ApplicationPersonID = clsPeople.GetPersonIDByDriverID(License.DriverID);
                    NewApplication.ApplicationDate = DateTime.Now;
                    NewApplication.ApplicationTypeID = clsApplicationTypes.GetApplicationTypeIDFromApplicatioName(ApplicationDamagedName);
                    NewApplication.ApplicationStatus = 3;
                    NewApplication.LastStatusDate = DateTime.Now;
                    NewApplication.PaidFees = clsApplicationTypes.GetApplicationFeesFromApplicatioName(ApplicationDamagedName);
                    NewApplication.CreatedcByUserID = IbrahimDVLDCommonLayer.UserSession.Instance.UserID;
                    NewApplication.ApplicationID= NewApplication.InsertApplication();
                    break;
                case enFormType.LostLicense:
                    NewApplication.ApplicationPersonID = clsPeople.GetPersonIDByDriverID(License.DriverID);
                    NewApplication.ApplicationDate = DateTime.Now;
                    NewApplication.ApplicationTypeID = clsApplicationTypes.GetApplicationTypeIDFromApplicatioName(ApplicationLostName);
                    NewApplication.ApplicationStatus = 3;
                    NewApplication.LastStatusDate = DateTime.Now;
                    NewApplication.PaidFees = clsApplicationTypes.GetApplicationFeesFromApplicatioName(ApplicationLostName);
                    NewApplication.CreatedcByUserID = IbrahimDVLDCommonLayer.UserSession.Instance.UserID;
                    NewApplication.ApplicationID = NewApplication.InsertApplication();
                    break;
            }
            lblApplicationDate.Text = NewApplication.ApplicationDate.ToString();
            lblApplicationFees.Text = NewApplication.PaidFees.ToString();
            lblOldLicenseID.Text = _LicenseID.ToString();
            lblCreatedBy.Text = IbrahimDVLDCommonLayer.UserSession.Instance.UserName;

        }
        private void _PrepareLDLApplication()
        {
          LocalDrivingLicenseID=clsLocalDrivingLicenseApplications.InsertLocalDrivingLicenseApplication(NewApplication.ApplicationID,License.LicenseClass);

        }
        private void _IssueNewLicense()
        {
          if(  MessageBox.Show("Are you sure you want to issue the replacement license?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { 
            switch (_enFormType)
            {
                case enFormType.DamagedLicense:
                    License.IsActive = false;
                        License.Update();
                    NewLicense.ApplicationID = NewApplication.ApplicationID;
                    NewLicense.DriverID = License.DriverID;
                    NewLicense.LicenseClass = License.LicenseClass;
                    NewLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClasses.GetLicenseClassDataByLicenseClassID(License.LicenseClass).DefaultValidityLength);
                    NewLicense.IssueDate = DateTime.Now;
                    NewLicense.Notes = _enFormType.ToString();
                    NewLicense.PaidFees = clsLicenseClasses.GetLicenseClassDataByLicenseClassID(License.LicenseClass).ClassFees;
                    NewLicense.IsActive = true;
                    NewLicense.IssueReason = Convert.ToByte(rbDamaged.Tag);
                    NewLicense.CreatedByUserID = IbrahimDVLDCommonLayer.UserSession.Instance.UserID;
                    NewLicense.LicenseID = NewLicense.Create();
                    break;
                case enFormType.LostLicense:
                    License.IsActive = false;
                        License.Update();
                    NewLicense.ApplicationID = NewApplication.ApplicationID;
                    NewLicense.DriverID = License.DriverID;
                    NewLicense.LicenseClass = License.LicenseClass;
                    NewLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClasses.GetLicenseClassDataByLicenseClassID(License.LicenseClass).DefaultValidityLength);
                    NewLicense.IssueDate = DateTime.Now;
                    NewLicense.Notes = _enFormType.ToString();
                    NewLicense.PaidFees = clsLicenseClasses.GetLicenseClassDataByLicenseClassID(License.LicenseClass).ClassFees;
                    NewLicense.IsActive = true;
                    NewLicense.IssueReason = Convert.ToByte(rbLost.Tag);
                    NewLicense.CreatedByUserID = IbrahimDVLDCommonLayer.UserSession.Instance.UserID;
                    NewLicense.LicenseID = NewLicense.Create();
                    break;
                default:
                    break;
                    
            }
            llShowNewLicenseInfo.Enabled = true;
            lblLRApplicationID.Text = NewApplication.ApplicationID.ToString();
            lblReplacedLicenseID.Text = NewLicense.LicenseID.ToString();
                MessageBox.Show("Replacement License has been issued successfully. You can view the new license information by clicking on the 'Show New License Info' link.");
                btnIssueReplacement.Enabled = false;
            }
        }

        private void frmReplaceForDamage_LostLicense_Load(object sender, EventArgs e)
        {
           _PrepareForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            _IssueNewLicense();
        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm=new frmLicenseInfo(clsLocalDrivingLicenseApplications.GetLicenseIDByApplicationID(NewApplication.ApplicationID));
            frm.ShowDialog();
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(clsPeople.GetPersonIDByDriverID(License.DriverID));
            frm.ShowDialog();
        }
    }
}
