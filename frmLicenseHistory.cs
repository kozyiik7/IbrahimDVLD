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
using static System.Net.Mime.MediaTypeNames;

namespace IbrahimDVLD
{
    public partial class frmLicenseHistory : Form
    {
        BindingSource bindingSource=new BindingSource();
        private int _PersonID = 0;
        public frmLicenseHistory()
        {
            InitializeComponent();
        }
        public frmLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
           ucPersonInfoShow1._PersonID = _PersonID;
        }
        private void GetLocalDrivingLicenseHistory()
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = clsLicense.GetLocalDrivingLicenseHistoryByPersonID(_PersonID);
            dgvLocalDrivingLicensesHistory.DataSource = bindingSource;
            dgvLocalDrivingLicensesHistory.AllowUserToAddRows = false;
            dgvLocalDrivingLicensesHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // dgvLocalDrivingLicensesHistory.Font.Size.Equals(8);
            lblRecords.Text = "#Records : " + dgvLocalDrivingLicensesHistory.RowCount.ToString();
        }
        private void GetInternationalLicenseHistory()
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = clsInternationalLicense.GetInternationalLicenseHistoryByPersonID(_PersonID);
            dgvInternationalLicenses.DataSource = bindingSource;
            dgvInternationalLicenses.AllowUserToAddRows = false;
            dgvInternationalLicenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // dgvLocalDrivingLicensesHistory.Font.Size.Equals(8);
           
        }
        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            GetLocalDrivingLicenseHistory();
           GetInternationalLicenseHistory();
            tabControl1.SelectedIndex = 0;

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                    case 0:
                    lblRecords.Text = "#Records : " + dgvLocalDrivingLicensesHistory.RowCount.ToString();
                    break;
                    case 1:
                    lblRecords.Text = "#Records : " + dgvInternationalLicenses.RowCount.ToString();
                    break ;
                default:
                    break;   
            }
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch(tabControl1.SelectedIndex)
            {
                case 0:
                    int localDrivringLicenseID =clsLocalDrivingLicenseApplications.GetLicenseIDByApplicationID( Convert.ToInt32(dgvLocalDrivingLicensesHistory.CurrentRow.Cells["ApplicationID"].Value.ToString()));
                    frmLicenseInfo frm = new frmLicenseInfo(localDrivringLicenseID);
                        frm.ShowDialog();
                    break;
                case 1:
                    clsInternationalLicense ILicense = clsInternationalLicense.GetDriverInternationalLicenseInfoByInternationalLicenseID( Convert.ToInt32(dgvInternationalLicenses.CurrentRow.Cells["InternationalLicenseID"].Value.ToString()));
                    frmInternationalLicenseInfo frm2 = new frmInternationalLicenseInfo(ILicense.DriverID);
                        frm2.ShowDialog();
                    break;
                default:
                    break;




            }
        }
    }
}
