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
    public partial class frmInternationalLicenseInfo : Form
    {
        private int _DriverID=0;
        public frmInternationalLicenseInfo( int DriverID)
        {
            InitializeComponent();
            _DriverID = DriverID;
        }

        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            DataRow dr = clsInternationalLicense.GetDriverInternationalLicenseInfoByDriverID(_DriverID);
            if(dr!=null)
            {
                lblName.Text = (string)dr["FullName"];
                lblinternationalLicenseID.Text = ((int)dr["InternationalLicenseID"]).ToString();
                lblApplicationID.Text= ((int)dr["ApplicationID"]).ToString();
                lblLicenseID.Text= ((int)dr["IssuedUsingLocalLicenseID"]).ToString();
                lblIsActive.Text = ((bool)dr["IsActive"])==true?"Yes":"No";
                lblNationalNumber.Text = ((string)dr["NationalNo"]);
                lblDateOfBirth.Text = ((DateTime)dr["DateOfBirth"]).ToString();
                lblGendor.Text = ((byte)dr["Gendor"]) == 0 ? "Male" : "Female";
                lblDriverID.Text= ((int)dr["DriverID"]).ToString();
                lblIssueDate.Text = ((DateTime)dr["IssueDate"]).ToString();
                lblExpirationDate.Text = ((DateTime)dr["ExpirationDate"]).ToString();
                pbPersonImage.Image = Image.FromFile((string)dr["ImagePath"]);


            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
