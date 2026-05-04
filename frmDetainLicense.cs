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
    public partial class frmDetainLicense : Form
    {
        public frmDetainLicense()
        {
            InitializeComponent();
        }
        private int _LicenseID=-1;
        clsLicense Mylicense=new clsLicense();
        clsDetainedLicenses MyDetainLicense=new clsDetainedLicenses();
        public void GetLicenseID(int LicenseID,object sender)
        {
            _LicenseID = LicenseID;
            Mylicense =clsLicense.GetDriverLicensDataLicenseID_object(_LicenseID);
            if (!Mylicense.IsActive == true)
            {
                MessageBox.Show("License Is Not Active ! ", "Error", MessageBoxButtons.OK);
                return;
            }
            MyDetainLicense=clsDetainedLicenses.Read(_LicenseID);
            if (MyDetainLicense!=null&&MyDetainLicense.IsReleased==true)
            {
                MessageBox.Show("License Is Not Detained ! ", "Error", MessageBoxButtons.OK);
                return;
            }
            if(MyDetainLicense!=null&&MyDetainLicense.IsReleased==false)
            {
                MessageBox.Show("License Is Already Detained ! ", "Error", MessageBoxButtons.OK);
                return;
            }
            _PrepareDetainInfo();
            btnDetain.Enabled = true;
            llShowLicensesHistory.Enabled = true;
            llShowLicenseInfo.Enabled = true;


        }
       private void _PrepareDetainInfo()
        {
            lblDetainDate.Text = DateTime.Now.ToString();
            lblCreatedBy.Text = IbrahimDVLDCommonLayer.UserSession.Instance.UserName;
            lblLicenseID.Text = _LicenseID.ToString();

        }
        private void _PrepareFormInitialState()
        {
            lblDetainDate.Text = string.Empty;
            lblCreatedBy.Text = string.Empty;
            lblLicenseID.Text = string.Empty;
            txtFineFees.Text = string.Empty;
            btnDetain.Enabled = false;
            llShowLicensesHistory.Enabled = false;
            llShowLicenseInfo.Enabled = false;

        }
        private void _DetainLicense()
        {
            if (string.IsNullOrEmpty(txtFineFees.Text))
            {
                MessageBox.Show("Please Enter Fine Fees ! ", "Error", MessageBoxButtons.OK);
                return;
            }
            MyDetainLicense = new clsDetainedLicenses();
            MyDetainLicense.LicenseID = _LicenseID;
            MyDetainLicense.DetainDate=DateTime.Now;
            MyDetainLicense.FineFees = (decimal.TryParse(txtFineFees.Text, out decimal Resault)) ? Resault : -1;
            MyDetainLicense.CreatedByUserID = IbrahimDVLDCommonLayer.UserSession.Instance.UserID;
            MyDetainLicense.IsReleased = false;
            MyDetainLicense.ReleaseDate = null;
            MyDetainLicense.ReleasedByUserID = null;
            MyDetainLicense.ReleaseApplicationID = null;
            lblDetainID.Text= MyDetainLicense.Create().ToString();
            MessageBox.Show($"License Detained Successfully !  with detainID {lblDetainID.Text} ", "Success", MessageBoxButtons.OK);
            btnDetain.Enabled = false;
        }
        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            ucFilterDriverLicense1.LicensedIDChanged += GetLicenseID;
            _PrepareFormInitialState();

        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if( !char.IsNumber(e.KeyChar)&&!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           frmLicenseHistory frm = new frmLicenseHistory(clsPeople.GetPersonIDByDriverID(Mylicense.DriverID));
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(clsLocalDrivingLicenseApplications.GetLocalDrivingLicensIDFromLicenseID(_LicenseID));
            frm.ShowDialog();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            _DetainLicense();
        }
    }
}
