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
    public partial class frmListDetainedLicenses : Form
    {
        public enum enfilterMode { Numbers,strings,YesNo }
        enfilterMode filterMode=enfilterMode.strings;
        BindingSource bsAllDetainedLicensesSource= new BindingSource();
        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            bsAllDetainedLicensesSource.DataSource = clsDetainedLicenses.GetAllDetainedLicense();
            if(bsAllDetainedLicensesSource!=null)
            {
                dgvAllDetainedLicenses.DataSource = bsAllDetainedLicensesSource;
                dgvAllDetainedLicenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            txtFilter.Visible = false;
            cmbFilterValue.Visible = false;
            cmbFilter.SelectedIndex = 0;

        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm=new frmDetainLicense();
            frm.ShowDialog();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm= new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cmbFilter.SelectedIndex)
            {
                case 0:
                    txtFilter.Visible = false;
                    txtFilter.Text = "";
                    cmbFilterValue.Visible = false;
                    bsAllDetainedLicensesSource.Filter = string.Empty;
                    dgvAllDetainedLicenses.DataSource = bsAllDetainedLicensesSource;
                    break;
                case 1:
                case 5:
                    bsAllDetainedLicensesSource.Filter = string.Empty;
                    txtFilter.Visible = true;
                    txtFilter.Text = "";
                    filterMode = enfilterMode.Numbers;
                    break;
                    case 2:
                    bsAllDetainedLicensesSource.Filter = string.Empty;
                    txtFilter.Visible = false;
                    cmbFilterValue.Visible = true;
                   // cmbFilterValue.SelectedIndex = 0;
                    filterMode = enfilterMode.YesNo;
                    break;
                    case 4:
                    case 3:
                    bsAllDetainedLicensesSource.Filter = string.Empty;
                    txtFilter.Visible = true;
                    cmbFilterValue.Visible = false;
                    txtFilter.Text = "";
                    cmbFilterValue.SelectedIndex = 0;
                    filterMode = enfilterMode.strings;
                    break;
                    default:
                    break;


            }
        }

        private void cmbFilterValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            bsAllDetainedLicensesSource.Filter = string.Format("[IsReleased] = {0}", cmbFilterValue.Text);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            switch(filterMode)
            {
                case enfilterMode.strings:
                    bsAllDetainedLicensesSource.Filter = string.Format("[{0}] like '%{1}%'", cmbFilter.Text, txtFilter.Text);
                    break;
                case enfilterMode.Numbers:
                    if(int.TryParse(txtFilter.Text,out int value))
                    bsAllDetainedLicensesSource.Filter = string.Format("[{0}] = {1}", cmbFilter.Text, value);
                    else
                        bsAllDetainedLicensesSource.Filter = string.Empty;
                    break;
                default:
                    break;
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(filterMode==enfilterMode.Numbers) 
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cmsDGVOptions_Opening(object sender, CancelEventArgs e)
        {
            if (dgvAllDetainedLicenses.CurrentRow.Cells["ReleaseApplicationID"].Value.ToString() == "")
            {
                releaseDetainedLicenseToolStripMenuItem.Enabled = true;
            }
            else
            {
                releaseDetainedLicenseToolStripMenuItem.Enabled = false;
            }
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense((int)dgvAllDetainedLicenses.CurrentRow.Cells["LicenseID"].Value);
            frm.ShowDialog();
            dgvAllDetainedLicenses.DataSource = bsAllDetainedLicensesSource;
        }

        private void showPersonLicensesHistorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(clsPeople.GetPersonIDByNationalNumber((string)dgvAllDetainedLicenses.CurrentRow.Cells["N.No"].Value));
            frm.ShowDialog();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(clsPeople.GetPersonIDByNationalNumber((string)dgvAllDetainedLicenses.CurrentRow.Cells["N.No"].Value));
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(clsLocalDrivingLicenseApplications.GetLocalDrivingLicensIDFromLicenseID((int)dgvAllDetainedLicenses.CurrentRow.Cells["LicenseID"].Value));
            frm.ShowDialog();
        }
    }
}
