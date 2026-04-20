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
    public partial class frmVisionTestApointments : Form
    {
        BindingSource bs = new BindingSource();
        private int _AppID;
        public int AppID { get; set; }
        public frmVisionTestApointments()
        {
            InitializeComponent();
        }
        public frmVisionTestApointments(int AppID)
        {
            InitializeComponent();
            _AppID = AppID;
           this.AppID = AppID;
        }
        private void FillDataGridView()
        {
            if (clsTestAppointments.GetVisionTestAppoinmetsByAppID(AppID) != null)
            {
                bs.DataSource = clsTestAppointments.GetVisionTestAppoinmetsByAppID(AppID);
                dgvAppointments.DataSource = bs;
                dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
               dgvAppointments.AllowUserToAddRows = false;
            }
            lblNumberOfRecords.Text = "#Records :" + " " + dgvAppointments.Rows.Count.ToString();
        }
        private void frmVisionTestApointments_Load(object sender, EventArgs e)
        {
            ucApplicationAllInfo1.AppID = _AppID;
            FillDataGridView();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseID = 0;
            LocalDrivingLicenseID=clsLocalDrivingLicenseApplications.GetLicenseIDByApplicationID(AppID);
            if (clsLocalDrivingLicenseApplications.GetNumberOFPassedTestByLocalDrivingLicenceID(LocalDrivingLicenseID) == 1)
            {
                MessageBox.Show("Person has passed this Test");
                return;
            }
            if (clsTestAppointments.ISThereVisionTest(AppID))
            {
                
                MessageBox.Show("There is already a vision test appointment for this application, you can't schedule another one until the current one is locked");
                return;
            }
            else
            {
                frmScheduleTest frm = new frmScheduleTest(_AppID,frmScheduleTest.enFormMode.add);
                frm.ShowDialog();
                FillDataGridView();
               
            }
        }
        private void RefreshForm()
        {
            frmVisionTestApointments_Load(null, null)   ;
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmScheduleTest frm = new frmScheduleTest(_AppID, frmScheduleTest.enFormMode.edit);
            frm.ShowDialog();
            FillDataGridView();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (dgvAppointments.CurrentRow.Cells["Is Locked"].Value.ToString()=="False")
            {
                frmScheduleTest Test = new frmScheduleTest(_AppID, frmScheduleTest.enFormMode.TakeTest);
                
                Test.ShowDialog();
                FillDataGridView();
                
            }
            else
            {
                MessageBox.Show("the Test is locked !"); 
                return;
            }
            
        }
    }
}
