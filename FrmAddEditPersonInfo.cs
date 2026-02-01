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
    public partial class FrmAddEditPersonInfo : Form
    {
        DataTable dtCountries = IbrahimDVLDBusinessLayer.clsCountry.GetAllCountries();
        public FrmAddEditPersonInfo(int ID)
        {

            InitializeComponent();
            







        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FillCountryComboBox()
        {
           
            
        }
        private void FrmAddEditPersonInfo_Load(object sender, EventArgs e)
        {
            FillCountryComboBox();

        }
    }
}
