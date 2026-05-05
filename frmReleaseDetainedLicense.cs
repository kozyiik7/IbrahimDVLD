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
    public partial class frmReleaseDetainedLicense : Form
    {
        private static string ApplicationName = "Release Detained Driving Licsense";
        private int _LicenseID = -1;
        clsLicense Mylicense = new clsLicense();
        clsDetainedLicenses MyDetainLicense = new clsDetainedLicenses();
        clsApplicationTypes MyapplicationTypes = new clsApplicationTypes();
        clsApplication MyApplication=new clsApplication();
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void GetLicenseID(int LicenseID, object sender)
        {
            _LicenseID = LicenseID;
            if(_LicenseID>0) 
            Mylicense = clsLicense.GetDriverLicensDataLicenseID_object(_LicenseID);
            if(Mylicense!=null)
            {
                MyDetainLicense=clsDetainedLicenses.Read(_LicenseID);
                if (!Mylicense.IsActive)
                {
                    _GetDetainInfo();
                    llShowLicenseInfo.Enabled = true;
                    llShowLicensesHistory.Enabled = true;
                    MessageBox.Show("This License is Not Active ");

                    return;
                }
                if(MyDetainLicense!=null && MyDetainLicense.IsReleased)
                {
                    _GetDetainInfo();
                    llShowLicenseInfo.Enabled = true;
                    llShowLicensesHistory.Enabled = true;
                    MessageBox.Show("This License is Already Released ");
                    return;
                }
                _GetDetainInfo();
                btnRelease.Enabled = true;
                llShowLicenseInfo.Enabled = true;
                llShowLicensesHistory.Enabled = true;
            }

        }
        private void _PrepareApplication()
        {
            MyApplication.ApplicationPersonID=clsPeople.GetPersonIDByDriverID(Mylicense.DriverID);
            MyApplication.ApplicationTypeID=clsApplicationTypes.GetApplicationTypeIDFromApplicatioName(ApplicationName);
            MyApplication.ApplicationDate=DateTime.Now;
            MyApplication.ApplicationStatus = 3;
            MyApplication.LastStatusDate= DateTime.Now;
            MyApplication.PaidFees=clsApplicationTypes.GetApplicationFeesFromApplicatioName(ApplicationName);
            MyApplication.CreatedcByUserID=IbrahimDVLDCommonLayer.UserSession.Instance.UserID;
            MyApplication.ApplicationID = MyApplication.InsertApplication();
            lblApplicationID.Text = MyApplication.ApplicationID.ToString();

        }
        private void _GetDetainInfo()
        {
           lblDetainID.Text =MyDetainLicense.DetainID.ToString();
           lblDetainDate.Text= MyDetainLicense.DetainDate.ToString();
           lblLicenseID.Text= MyDetainLicense.LicenseID.ToString();
           lblCreatedBy.Text=clsUsers.GetUserInfoByUserID(MyDetainLicense.CreatedByUserID).UserName;
            lblApplicationFees.Text=clsApplicationTypes.GetApplicationFeesFromApplicatioName(ApplicationName).ToString();
           lblFineFees.Text= MyDetainLicense.FineFees.ToString();
           lblTotalFees.Text= (MyDetainLicense.FineFees+ clsApplicationTypes.GetApplicationFeesFromApplicatioName(ApplicationName)).ToString();
            



        }
        private void _PrepareInitialState()
        {
            btnRelease.Enabled = false;
            llShowLicenseInfo.Enabled = false;
            llShowLicensesHistory.Enabled = false;
        }
        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            _PrepareInitialState();
            ucFilterDriverLicense1.LicensedIDChanged += GetLicenseID;
        }
        private void  _ReleaseLicense()
        {
            if (MyDetainLicense == null)
            {
                MessageBox.Show("No Detain Information Found ! ", "Error", MessageBoxButtons.OK);
                return;
            }
            if (MyApplication.ApplicationID <= 0)
            {
                MessageBox.Show("Application Not Created ! ", "Error", MessageBoxButtons.OK);
                return;
            }
            MyDetainLicense.IsReleased = true;
            MyDetainLicense.ReleaseDate = DateTime.Now;
            MyDetainLicense.ReleasedByUserID = IbrahimDVLDCommonLayer.UserSession.Instance.UserID;
            MyDetainLicense.ReleaseApplicationID = MyApplication.ApplicationID;
            MyDetainLicense.Update();
            MessageBox.Show("License Released Successfully ! ", "Success", MessageBoxButtons.OK);
            
            btnRelease.Enabled = false;
        }
        private void btnRelease_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You sure you want to Release Licens !","Confirmation",MessageBoxButtons.YesNo) ==DialogResult.Yes)
            {
                _PrepareApplication();
                _ReleaseLicense();
            }
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(clsLocalDrivingLicenseApplications.GetLocalDrivingLicensIDFromLicenseID(_LicenseID));
            frm.ShowDialog();
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(clsPeople.GetPersonIDByDriverID(Mylicense.DriverID));
            frm.ShowDialog();
        }
    }
}
