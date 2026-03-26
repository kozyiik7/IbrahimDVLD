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
    public partial class frmAddNewUser : Form
    {
        public frmAddNewUser()
        {
            InitializeComponent();
           
        }
        private int _PersonID = -1;
        private int _UserID = -1;
        public bool ucFilterEnable { set { ucFilter1.Enabled = value; } }
        public string ucFilterValue { get { return ucFilter1.FilterValue; } set { ucFilter1.FilterValue = value; } }
        public string ucTextValue { get { return ucFilter1.TextValue; } set { ucFilter1.TextValue = value; } }
        public int UserID { set { lblUserIDValue.Text=value.ToString(); }  }
        public string UserName { set { txtUserName.Text = value; } }
        public string Password 
        {
            set { txtPassword.Text = value; txtConfirmPasword.Text = value; }
        }
        public bool IsActive { set { chkIsActive.Checked = value; } }
        public int PersonID { get => _PersonID; set => _PersonID = value; }

        public bool EnableNextbutton { set { btnNext.Enabled = value; } }
        public bool EnableSavebutton { set { btnSave.Enabled = value; } }
        
       
        public bool editMode { get; set; } = false;

        private void ucFilterValueToReceive(object sender, int PersonID)
        {
            _PersonID = PersonID;
            if (_PersonID != -1)
            {
               ucPersonInfoShow1.PersonIDValue = _PersonID;
               ucPersonInfoShow1.refreshPersonInfo();
                btnNext.Enabled = true;
            }

        }



        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            ucFilter1.OnPersonID += ucFilterValueToReceive;
            ucPersonInfoShow1.PersonIDValue = _PersonID;
            ucPersonInfoShow1.refreshPersonInfo();
            if(editMode==false)
            { 
            btnSave.Enabled = false;
               

            }
            else
            {
                lblFormAddress.Text = "Edit User Info";
                btnNext.Enabled = true;
            }
           // btnNext.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
           if(!clsUsers.isPersonIDAlreadyHaveUser(_PersonID)||editMode==true)
            { 
            tabUser.SelectedTab = tabUser.TabPages[1];
                btnNext.Enabled = false;
            }
           else
            {
                MessageBox.Show("This Person Already Have User Account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {if(!editMode)
            { 
            if(txtUserName.Text.Trim() == "")
            {
                errorProviderAddNewUser.SetError(txtUserName, "Please Enter User Name");
                e.Cancel = true;
            }
            else if (clsUsers.IsUserNameExist(txtUserName.Text.Trim()))
            {
                errorProviderAddNewUser.SetError(txtUserName, "This User Name is Already Exist");
                e.Cancel = true;
            }
            else
            {
                errorProviderAddNewUser.SetError(txtUserName, "");
            }

            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text.Trim() == "")
            {
                errorProviderAddNewUser.SetError(txtPassword, "Please Enter Password");
                e.Cancel = true;
            }
            else
            {
                errorProviderAddNewUser.SetError(txtPassword, "");
            }
        }

        private void txtConfirmPasword_Validating(object sender, CancelEventArgs e)
        {
            if(txtConfirmPasword.Text.Trim()!=txtPassword.Text.Trim())
            {
                errorProviderAddNewUser.SetError(txtConfirmPasword, "Password Not Match");
                e.Cancel = true;
            }
           
            else
            {
                errorProviderAddNewUser.SetError(txtConfirmPasword, "");
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!editMode)
            { 
                _UserID = clsUsers.AddNewUser(_PersonID, txtUserName.Text.Trim(), txtPassword.Text.Trim(), chkIsActive.Checked);
                if (_UserID != -1)
                {
                    lblFormAddress.Text = "Update User";
                    lblUserIDValue.Text = _UserID.ToString();
                    MessageBox.Show("User Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      
               
                }
                else
                {
                    MessageBox.Show("Error While Adding New User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                }
            }
            else
            {
                clsUsers user = clsUsers.GetUserInfoByPersonID(_PersonID);
               if( user.UpdateUserInfo(_PersonID, txtUserName.Text.Trim(), txtPassword.Text.Trim(), chkIsActive.Checked) )
                { 
                    MessageBox.Show("User Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error While Updating User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               

            }
        }
    }
}
