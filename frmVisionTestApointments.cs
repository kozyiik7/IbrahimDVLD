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
        public enum enMode :Int32 { VisionTest=1, WriteTest=2, StreetTest=3 } 
        private enMode _Mode = enMode.VisionTest;
        public frmVisionTestApointments()
        {
            InitializeComponent();
        }
        public frmVisionTestApointments(int AppID,enMode Mode)
        {
            InitializeComponent();
            _AppID = AppID;
           this.AppID = AppID;
            _Mode = Mode;
        }
        private void FillDataGridView()
        {
            switch(_Mode)
            {
               case enMode.VisionTest:
                    if (clsTestAppointments.GetVisionTestAppoinmetsByAppID(AppID) != null)
                    {
                        bs.DataSource = clsTestAppointments.GetVisionTestAppoinmetsByAppID(AppID);
                        dgvAppointments.DataSource = bs;
                        dgvAppointments.Sort(dgvAppointments.Columns["Appointment ID"], ListSortDirection.Descending);
                    }
                    break;
               case enMode.WriteTest:
                    if (clsTestAppointments.GetWriteTestAppoinmetsByAppID(AppID) != null)
                    {
                        bs.DataSource = clsTestAppointments.GetWriteTestAppoinmetsByAppID(AppID);
                        dgvAppointments.DataSource = bs;
                        dgvAppointments.Sort(dgvAppointments.Columns["Appointment ID"], ListSortDirection.Descending);
                    }
                    break;
               case enMode.StreetTest:
                    if (clsTestAppointments.GetStreetTestAppoinmetsByAppID(AppID) != null)
                    {
                        bs.DataSource = clsTestAppointments.GetStreetTestAppoinmetsByAppID(AppID);
                        dgvAppointments.DataSource = bs;
                        dgvAppointments.Sort(dgvAppointments.Columns["Appointment ID"], ListSortDirection.Descending);
                    }
                    break;

            }
           
                dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvAppointments.AllowUserToAddRows = false;
            
            lblNumberOfRecords.Text = "#Records :" + " " + dgvAppointments.Rows.Count.ToString();
        }
        private void FillFormData()
        {
            switch (_Mode)
            {
                case enMode.VisionTest:
                    pbMainImage.Image = ImageListMode.Images[0];
                    lblMainAddress.Text = "Vision Test Appointment";
                    break;
                case enMode.WriteTest:
                    pbMainImage.Image = ImageListMode.Images[1];
                    lblMainAddress.Text = "Write Test Appointment";
                    break;
                case enMode.StreetTest:
                    pbMainImage.Image = ImageListMode.Images[2];
                    lblMainAddress.Text = "Street Test Appointment";
                    break;

            }
        }
        private void frmVisionTestApointments_Load(object sender, EventArgs e)
        {
            
            ucApplicationAllInfo1.AppID = _AppID;
            FillFormData();
            FillDataGridView();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseID = 0;
            LocalDrivingLicenseID=clsLocalDrivingLicenseApplications.GetLicenseIDByApplicationID(AppID);
            switch(_Mode)
            { 
                case enMode.VisionTest:

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
                        frmScheduleTest frm = new frmScheduleTest(_AppID, frmScheduleTest.enFormMode.add,_Mode);
                        frm.ShowDialog();
                        FillDataGridView();

                    }
                    break;
                case enMode.WriteTest:

                    if (clsLocalDrivingLicenseApplications.GetNumberOFPassedTestByLocalDrivingLicenceID(LocalDrivingLicenseID) == 2)
                    {
                        MessageBox.Show("Person has passed this Test");
                        return;
                    }
                    if (clsTestAppointments.ISThereWriteTest(AppID))
                    {

                        MessageBox.Show("There is already a vision test appointment for this application, you can't schedule another one until the current one is locked");
                        return;
                    }
                    else
                    {
                        frmScheduleTest frm = new frmScheduleTest(_AppID, frmScheduleTest.enFormMode.add, _Mode);
                        frm.ShowDialog();
                        FillDataGridView();

                    }
                    break;
                case enMode.StreetTest:

                    if (clsLocalDrivingLicenseApplications.GetNumberOFPassedTestByLocalDrivingLicenceID(LocalDrivingLicenseID) == 3)
                    {
                        MessageBox.Show("Person has passed this Test");
                        return;
                    }
                    if (clsTestAppointments.ISThereStreetTest(AppID))
                    {

                        MessageBox.Show("There is already a vision test appointment for this application, you can't schedule another one until the current one is locked");
                        return;
                    }
                    else
                    {
                        frmScheduleTest frm = new frmScheduleTest(_AppID, frmScheduleTest.enFormMode.add, _Mode);
                        frm.ShowDialog();
                        FillDataGridView();

                    }
                    break;

            }
            
        }
     
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmScheduleTest frm = new frmScheduleTest(_AppID, frmScheduleTest.enFormMode.edit,_Mode);
            frm.ShowDialog();
            FillDataGridView();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (dgvAppointments.CurrentRow.Cells["Is Locked"].Value.ToString()=="False")
            {
                frmScheduleTest Test = new frmScheduleTest(_AppID, frmScheduleTest.enFormMode.TakeTest,_Mode);
                
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
