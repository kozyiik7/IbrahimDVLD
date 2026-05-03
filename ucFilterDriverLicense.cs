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
    public partial class ucFilterDriverLicense : UserControl
    {
        public ucFilterDriverLicense()
        {
            InitializeComponent();
        }
       public delegate void LicenseID(int licendID,object sender);
        public event LicenseID LicensedIDChanged;
        private void gbFilter_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void ucFilterDriverLicense_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           if(int.TryParse(txtFilter.Text, out int result) )
            if (clsLicense.GetDriverLicensDataLicenseID(result).Rows.Count>0)
            {
                    int LocalDrivngLicenseID=clsLocalDrivingLicenseApplications.GetLocalDrivingLicensIDFromLicenseID(result);
                    // OnlicensIDChanged?.Invoke(Convert.ToInt32(txtFilter.Text), this);
                    ucLicenseInfo1.LocalDrivingLicenseID = LocalDrivngLicenseID;
                    LicensedIDChanged?.Invoke(result, this);
            }
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.SuppressKeyPress = true;
                txtFilter.SelectAll();
                txtFilter.Focus();
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
