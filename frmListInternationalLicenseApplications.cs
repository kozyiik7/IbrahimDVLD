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
    public partial class frmListInternationalLicenseApplications : Form
    {
        public enum entxtfilterValue { text, Numbers }

        public entxtfilterValue txtfilterValue { get; set; } = entxtfilterValue.text;
        BindingSource bindingSource = new BindingSource();
        public frmListInternationalLicenseApplications()
        {
            InitializeComponent();
        }
        private void SetIntializeData()
        {
            txtFilter.Visible = false;
            bindingSource.DataSource = clsInternationalLicense.GetAllInternationalLicenses();
            dgvInternationalLicenseApplications.DataSource = bindingSource;
            lblRecordCount.Text = string.Format("# Records : " + dgvInternationalLicenseApplications.RowCount.ToString());

        }

        private void frmListInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            SetIntializeData();
            FillComboboxValue();
        }
        private void FillComboboxValue()
        {
            int i = 0;
            cmbFilter.Items.Add("None");
            foreach(DataGridViewColumn column in dgvInternationalLicenseApplications.Columns)
            {
                if (i < 4)
                {
                    cmbFilter.Items.Add(column.HeaderText);
                    i++;
                }
               

            }

            cmbFilter.SelectedIndex = 0;

        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbFilter.SelectedIndex)
            {
                case 0:
                    txtFilter.Visible = false;
                    txtFilter.Text = string.Empty;
                    bindingSource.Filter = string.Empty;
                    break;
                default:
                    txtFilter.Visible=true;
                    txtFilter.Text = string.Empty;
                    break;
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(txtFilter.Text,out int value))
            {
                bindingSource.Filter = string.Format("[{0}] = {1}", cmbFilter.Text, txtFilter.Text);
            }
            else
            {
                bindingSource.Filter=string.Empty;
            }
            lblRecordCount.Text = "# Records :" + dgvInternationalLicenseApplications.RowCount.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvInternationalLicenseApplications.CurrentRow != null)
            {
                frmPersonDetails frm = new frmPersonDetails(clsPeople.GetPersonIDByDriverID(Convert.ToInt32(dgvInternationalLicenseApplications.CurrentRow.Cells["DriverID"].Value.ToString())));
                frm.ShowDialog();
            }
        }

        private void showPersonLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvInternationalLicenseApplications.CurrentRow != null)
            {
                frmLicenseHistory frm = new frmLicenseHistory(clsPeople.GetPersonIDByDriverID(Convert.ToInt32(dgvInternationalLicenseApplications.CurrentRow.Cells["DriverID"].Value.ToString())));
                frm.ShowDialog();
            }
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(Convert.ToInt32(dgvInternationalLicenseApplications.CurrentRow.Cells["DriverID"].Value.ToString()));
            frm.ShowDialog();
        }
    }
}
