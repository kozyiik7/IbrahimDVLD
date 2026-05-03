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
    public partial class frmLicenseInfo : Form
    {
        public frmLicenseInfo()
        {
            InitializeComponent();
        }

        public frmLicenseInfo(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            ucLicenseInfo1.LocalDrivingLicenseID = LocalDrivingLicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
