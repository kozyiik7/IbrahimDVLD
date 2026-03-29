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
    public partial class frmManageApplicationTypes : Form
    {
        BindingSource bindingSource;
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
           bindingSource = new BindingSource();
           bindingSource.DataSource = IbrahimDVLDBusinessLayer.clsApplicationTypes.GetApplicationTypes();
           dgvApplicationTypes.DataSource = bindingSource;
           lblNumberOfRecords.Text = bindingSource.Count.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
