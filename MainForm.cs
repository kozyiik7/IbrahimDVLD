using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IbrahimDVLDBusinessLayer;
using IbrahimDVLDCommonLayer;

namespace IbrahimDVLD
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople Managepeople=new frmManagePeople();
            Managepeople.MdiParent = this;
            Managepeople.Show();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.MdiParent = this;
            login.Show();
        }

        private void drivresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers users = new frmManageUsers();
            users.MdiParent = this;
            users.Show();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
                frmLogin login = new frmLogin();
                login.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserDetails frmShowUserDetails = new frmShowUserDetails(UserSession.Instance.PersonID);
            frmShowUserDetails.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword(UserSession.Instance.PersonID);
            frmChangePassword.ShowDialog();

        }

        private void signOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = new frmLogin();
            UserSession.Instance.Clear();
            login.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplication_TestType frmManageApplicationTypes = new frmManageApplication_TestType(frmManageApplication_TestType.enMode.ManageApplicationType);
            frmManageApplicationTypes.ShowDialog();
        }

        private void manageTestsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmManageApplication_TestType frmManageApplicationTypes = new frmManageApplication_TestType(frmManageApplication_TestType.enMode.ManageTestType);
            frmManageApplicationTypes.ShowDialog();
        }

        private void newDrivingLisenceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewDrivingLicenseApplication frmNewDrivingLicenseApplication = new frmNewDrivingLicenseApplication();
            frmNewDrivingLicenseApplication.ShowDialog();
        }

        private void manageApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplications LDLApplications=new frmLocalDrivingLicenseApplications();
            LDLApplications.ShowDialog();
        }
    }
}
