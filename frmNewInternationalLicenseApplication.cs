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
    public partial class frmNewInternationalLicenseApplication : Form
    {
        public int LicenseID {  get; set; }
        public static string LicenseAppName = "New International License";
        private int _LicenseID;
       
        clsLicense License = new clsLicense();
        clsApplication InternationalLicensApplication = new clsApplication();
        clsInternationalLicense InternationalLicense = new clsInternationalLicense();

        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void ucFilterDriverLicense1_Load(object sender, EventArgs e)
        {

        }
        public void GetLicenseID(int licenseID,object sender)
        {
            this.LicenseID = licenseID;
            _LicenseID = licenseID;
             License=clsLicense.GetDriverLicensDataLicenseID_object(_LicenseID);
            if (License != null)
            {
                _PrepareApplication();

                _PrepareInternationalLicense();
                btnIssue.Enabled = true;
                llShowLicensesHistory.Enabled = true;
                if (clsInternationalLicense.IsDriverHasActiveInternationalLicenseByDriverID(License.DriverID))
                {
                    llShowLicensesHistory.Enabled = true;
                    llShowLicenseInfo.Enabled = true;
                    MessageBox.Show("This Driver has An Active International license ! ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnIssue.Enabled = false;
                }

                
            }
            
        }
        private bool _PrepareApplication()
        {
            bool isLocalDrivingLicenseValid = clsLicense.IsDriverLicensClass3ExistsAndCByLicenseID(_LicenseID);
            if (isLocalDrivingLicenseValid)
            {



                InternationalLicensApplication.ApplicationPersonID = clsPeople.GetPersonIDByDriverID(License.DriverID);
                InternationalLicensApplication.ApplicationDate = DateTime.Now;
                InternationalLicensApplication.ApplicationTypeID = clsApplicationTypes.GetApplicationTypeIDFromApplicatioName(LicenseAppName);

                InternationalLicensApplication.ApplicationStatus = 1;
                InternationalLicensApplication.LastStatusDate = DateTime.Now;

                InternationalLicensApplication.PaidFees = clsApplicationTypes.GetApplicationFeesFromApplicatioName(LicenseAppName);
                InternationalLicensApplication.CreatedcByUserID = IbrahimDVLDCommonLayer.UserSession.Instance.UserID;
                InternationalLicensApplication.ApplicationID = InternationalLicensApplication.InsertApplication();
                lblLocalLicenseID.Text = _LicenseID.ToString();
                return true;

            }
            return false;

        }
        private void _PrepareInternationalLicense()
        {


            InternationalLicense.ApplicationID = InternationalLicensApplication.ApplicationID;
            InternationalLicense.DriverID = License.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = License.LicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            InternationalLicense.IsActive = true;
            InternationalLicense.CreatedByUserID = IbrahimDVLDCommonLayer.UserSession.Instance.UserID;


        }
        private void _FillApplicationGroupboxData()
        {
            lblApplicationDate.Text = InternationalLicense.IssueDate.ToString();
            lblIssueDate.Text = InternationalLicense.IssueDate.ToString();
            lblFees.Text = clsApplicationTypes.GetApplicationFeesFromApplicatioName(LicenseAppName).ToString();
            lblExpirationDate.Text = InternationalLicense.ExpirationDate.ToString();
            lblCreatedBy.Text = IbrahimDVLDCommonLayer.UserSession.Instance.UserName;


        }
        private void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            ucFilterDriverLicense1.LicensedIDChanged += GetLicenseID;
            ucFilterDriverLicense1.Focus();
            _FillApplicationGroupboxData();
            btnIssue.Enabled=false;
            llShowLicensesHistory.Enabled=false;
            llShowLicenseInfo.Enabled=false;
            

        }
        private void IssueInternaltionalLicense()
        {
            InternationalLicense.InternationalLicenseID = InternationalLicense.Creat();
            lblILApplicationID.Text = InternationalLicensApplication.ApplicationID.ToString();
           // lblLocalLicenseID.Text = _LicenseID.ToString();
            lblILLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();

        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            if (InternationalLicensApplication.ApplicationID != 0)
            {
                //if(clsInternationalLicense.IsDriverHasActiveInternationalLicenseByDriverID(License.DriverID))
                //{
                //    MessageBox.Show("This Driver has An Active International license ! ","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                //    return;
                //}
                IssueInternaltionalLicense();
                llShowLicenseInfo.Enabled = true;
                btnIssue.Enabled = false;
            }

            MessageBox.Show("Added Successfully");
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
            frmInternationalLicenseInfo frm=new frmInternationalLicenseInfo(License.DriverID); 
            frm.ShowDialog();
        }
    }
}
