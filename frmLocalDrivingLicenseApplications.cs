using IbrahimDVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Internal;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IbrahimDVLD
{
    public partial class frmLocalDrivingLicenseApplications : Form
    {
        BindingSource bindingSource=new BindingSource();
        public enum entxtfilterValue { text, Numbers }
        public entxtfilterValue txtfilterValue { get; set; }=entxtfilterValue.text;
        public frmLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void frmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            SetIntializeData();

        }
        private void SetIntializeData()
        {
            cmbFilter.SelectedIndex = 0;
            txtFilter.Visible = false;
            bindingSource.DataSource = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();
            dgvLocalDrivingLicenseApplications.DataSource = bindingSource;
            lblRecordCount.Text = string.Format("# Records : " + dgvLocalDrivingLicenseApplications.RowCount.ToString());

        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbFilter.Text)
            {
                case "None":
                    txtFilter.Text = string.Empty;
                    txtFilter.Visible = false;
                    break;
                case "L.D.L.AppID":
                    txtFilter.Text = string.Empty;
                    txtFilter.Visible = true;
                    txtfilterValue = entxtfilterValue.Numbers;
                    break;
                case "NationalNo":
                case "FullName":
                case "Status":
                    txtFilter.Text = string.Empty;
                    txtFilter.Visible = true;
                    txtfilterValue = entxtfilterValue.text;
                    break;
            }
        }
       
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
           switch(txtfilterValue)
            {
                case entxtfilterValue.text:
                    bindingSource.Filter = string.Format("[{0}] LIKE '%{1}%'", cmbFilter.Text, txtFilter.Text);
                    break;
                case entxtfilterValue.Numbers:
                    if (int.TryParse(txtFilter.Text, out int filterValue))
                    {
                        bindingSource.Filter = string.Format("[{0}] = {1}", cmbFilter.Text, filterValue);
                    }
                    else
                    {
                        bindingSource.RemoveFilter();
                    }
                    break;
            }
            lblRecordCount.Text = string.Format("# Records : " + dgvLocalDrivingLicenseApplications.RowCount.ToString());
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtfilterValue == entxtfilterValue.Numbers)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           frmNewDrivingLicenseApplication frm = new frmNewDrivingLicenseApplication();
            frm.ShowDialog();
           SetIntializeData();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplications = Convert.ToInt32(dgvLocalDrivingLicenseApplications.CurrentRow.Cells["L.D.L.AppID"].Value.ToString());
            
            int ApplicationID =clsLocalDrivingLicenseApplications.GetApplicationIDByLicenseID(LocalDrivingLicenseApplications);
            if (clsApplication.ISApplicationExists(ApplicationID))
            {
                try
                {
                    if (MessageBox.Show("Are you sure You want to delete !", "Deleting", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        clsLocalDrivingLicenseApplications.DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplications);
                        clsApplication.DeleteApplicant(ApplicationID);
                        SetIntializeData() ;
                        MessageBox.Show("Deleted Successfully !", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception ex)
                {
                MessageBox.Show("Error Occurred !\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
               
                
           
            }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = Convert.ToInt32(dgvLocalDrivingLicenseApplications.CurrentRow.Cells["L.D.L.AppID"].Value.ToString());
            int ApplicationID = clsLocalDrivingLicenseApplications.GetApplicationIDByLicenseID(LocalDrivingLicenseApplicationID);
            clsApplication application = clsApplication.GetApplicationData(ApplicationID);
            if (application != null)
            {
                try
                {
                    if (MessageBox.Show("Are you sure You want to cancel !", "Canceling", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                       application.CancelApplication(ApplicationID);
                        SetIntializeData();
                        MessageBox.Show("Canceled Successfully !", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Occurred !\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppID=clsLocalDrivingLicenseApplications.GetApplicationIDByLicenseID(Convert.ToInt32(dgvLocalDrivingLicenseApplications.CurrentRow.Cells["L.D.L.AppID"].Value.ToString()));
            frmVisionTestApointments frm = new frmVisionTestApointments(AppID,frmVisionTestApointments.enMode.VisionTest);
            frm.ShowDialog();
            SetIntializeData();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int AppID = clsLocalDrivingLicenseApplications.GetApplicationIDByLicenseID(Convert.ToInt32(dgvLocalDrivingLicenseApplications.CurrentRow.Cells["L.D.L.AppID"].Value.ToString()));
            
            int NumberOFAppliedTest = clsTestAppointments.GetNumberOfTrueTestsByAppID(AppID);
            clsApplication Application = clsApplication.GetApplicationData(AppID);
            if(Application.ApplicationStatus != 1)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
                return;
            }
            else { 
            switch (NumberOFAppliedTest)
            {
                case 0:
                    scheduleVisionTestToolStripMenuItem.Enabled = true;
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                    break;
                case 1:
                    scheduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWrittenTestToolStripMenuItem.Enabled = true;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                    break;
                case 2:
                    scheduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = true;
                    break;
                default:
                    scheduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWrittenTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                    break;
                }
            }
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppID = clsLocalDrivingLicenseApplications.GetApplicationIDByLicenseID(Convert.ToInt32(dgvLocalDrivingLicenseApplications.CurrentRow.Cells["L.D.L.AppID"].Value.ToString()));
            frmVisionTestApointments frm = new frmVisionTestApointments(AppID, frmVisionTestApointments.enMode.WriteTest);
            frm.ShowDialog();
            SetIntializeData();
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppID = clsLocalDrivingLicenseApplications.GetApplicationIDByLicenseID(Convert.ToInt32(dgvLocalDrivingLicenseApplications.CurrentRow.Cells["L.D.L.AppID"].Value.ToString()));
            frmVisionTestApointments frm = new frmVisionTestApointments(AppID, frmVisionTestApointments.enMode.StreetTest);
            frm.ShowDialog();
            SetIntializeData();
        }
    }
}
