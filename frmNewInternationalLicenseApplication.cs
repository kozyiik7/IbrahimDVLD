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

        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void ucFilterDriverLicense1_Load(object sender, EventArgs e)
        {

        }
        public void GetLicenseID(int licenseID,object sender)
        {

        }
        private void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
           // ucFilterDriverLicense1.LicensedIDChanged += GetLicenseID(int LicenseID,this );
        }
    }
}
