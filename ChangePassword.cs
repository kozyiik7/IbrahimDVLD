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
    public partial class frmChangePassword : Form
    {
        private int _PersonID = -1;
       private  clsUsers User = new clsUsers();
        public frmChangePassword()
        {
            InitializeComponent();
        }
        public frmChangePassword(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            ucPersonInfoShow1.PersonIDValue = _PersonID;
            ucloginInformation1.PersonID = _PersonID;
            User= clsUsers.GetUserInfoByPersonID(_PersonID);
        }
        
        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if(User!=null)
            {
               if(clsUsers.IsUserExist(User.UserName, txtCurrentPassword.Text))
                {
                    errorProvider1.SetError(txtCurrentPassword, null);
                }
                else
                {
                    errorProvider1.SetError(txtCurrentPassword, "Current Password is not correct");
                    e.Cancel = true;
                }
            }

        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                errorProvider1.SetError(txtNewPassword, "New Password is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Confirm Password does not match New Password");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (User.UpdateUserInfo(User.PersonID, User.UserName, txtNewPassword.Text, User.isActive))
            {
                MessageBox.Show("Password changed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to change password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
