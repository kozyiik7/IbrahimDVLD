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
    public partial class frmManageTestTypes : Form
    {
        BindingSource bsTestTypes;
        public frmManageTestTypes()
        {
            InitializeComponent();
        }
         
        private void refreshDatasource()
        {
            bsTestTypes = new BindingSource();
            bsTestTypes.DataSource = IbrahimDVLDBusinessLayer.clsTestTypes.GetTestTypes();
            dgvManageTestTypes.DataSource = bsTestTypes;
            lblNumberOfRecords.Text = bsTestTypes.Count.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            refreshDatasource();
        }
    }
}
