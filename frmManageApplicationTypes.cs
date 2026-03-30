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
           refreshDatasource();

        }
        private void refreshDatasource()
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

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int applicationTypeID = Convert.ToInt32(dgvApplicationTypes.CurrentRow.Cells["ApplicationTypeID"].Value);
            string applicationTypeName = dgvApplicationTypes.CurrentRow.Cells["ApplicationTypeTitle"].Value.ToString();
            float applicationFeesAmount = Convert.ToSingle(dgvApplicationTypes.CurrentRow.Cells["ApplicationFees"].Value);
            frmUpdateApplicationType frm = new frmUpdateApplicationType(applicationTypeID,applicationTypeName,applicationFeesAmount);
            frm.ShowDialog();
            refreshDatasource();
        }
    }
}
