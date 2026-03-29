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

namespace IbrahimDVLD
{
    public partial class frmManageUsers : Form
    {
        BindingSource bs = new BindingSource();
       private int _PersonID = -1;

        bool isNumericOnly = false;
        public frmManageUsers()
        {
            InitializeComponent();
        }
       clsUsers User = new clsUsers();


        private void FillComboboxWithItems()
        {
            cmbFilter.Items.Add("None");
            foreach (DataGridViewColumn column in dgvUsers.Columns)
            {
                cmbFilter.Items.Add(column.HeaderText);
            }
        }
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            bs.DataSource = clsUsers.GetAllUsers();
            cmbIsActive.Visible = false;
            txtFilter.Visible = false;
            //BindingSource bs = new BindingSource();
            //bs.DataSource = clsUsers.GetAllUsers();
            dgvUsers.DataSource = bs;
            dgvUsers.Columns["Password"].Visible = false;
            lblRecoedValue.Text = bs.Count.ToString() + " Records Found";
            FillComboboxWithItems();
           

        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbFilter.SelectedItem.ToString())
            {
                case "None":
                    txtFilter.Visible = false;
                    cmbIsActive.Visible = false;
                    break;
                case "UserID":
                case "PersonID":
                    isNumericOnly = true;
                    txtFilter.Visible = true;
                    break;
                case "IsActive":
                    txtFilter.Visible = false;
                    cmbIsActive.Visible = true;
                    cmbIsActive.SelectedIndex = 0;
                    break;
                default:
                    isNumericOnly = false;
                    txtFilter.Visible = true;
                    cmbIsActive.Visible = false;
                    break ;
            
            }
           
          
           
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedIndex != 0)
            {
                //BindingSource bs = new BindingSource();
                //bs.DataSource = clsUsers.GetAllUsers();
                bs.Filter = string.Format("CONVERT([{0}], 'System.String') like '%{1}%'", cmbFilter.Text,txtFilter.Text);
                dgvUsers.DataSource=bs;
                lblRecoedValue.Text = bs.Count.ToString();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmAddNewUser frmAddNewUser = new frmAddNewUser();
            frmAddNewUser.ShowDialog();
            bs.DataSource = clsUsers.GetAllUsers();
            dgvUsers.DataSource=bs;
            lblRecoedValue.Text = bs.Count.ToString() + " Records Found";   
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(isNumericOnly)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cmbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindingSource bs = new BindingSource();
            //bs.DataSource = clsUsers.GetAllUsers();
            if (cmbIsActive.SelectedIndex !=0)
            {
                bs.Filter = $"IsActive = {cmbIsActive.SelectedItem.ToString()}";
            }
            else 
            { bs.Filter = null; }
            dgvUsers.DataSource = bs;
            lblRecoedValue.Text = bs.Count.ToString();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmShowUserDetails showUserDetails = new frmShowUserDetails(Convert.ToInt32( dgvUsers.CurrentRow.Cells["PersonID"].Value.ToString()));
            showUserDetails.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewUser frmAddNewUser = new frmAddNewUser();
            int PersonID = Convert.ToInt32(dgvUsers.CurrentRow.Cells["PersonID"].Value.ToString());
            frmAddNewUser.PersonID = PersonID;

            frmAddNewUser.ucFilterValue = "PersonID";
            frmAddNewUser.ucTextValue = PersonID.ToString() ;
            frmAddNewUser.ucFilterEnable = false;
            frmAddNewUser.PersonID = PersonID;
            
            if((User=clsUsers.GetUserInfoByPersonID(PersonID))!=null)
            {
                frmAddNewUser.UserID = User.UserID;
                frmAddNewUser.UserName = User.UserName;
                frmAddNewUser.Password = User.Password;
                frmAddNewUser.IsActive = User.isActive;
                frmAddNewUser.editMode = true;
                
            }
           
            frmAddNewUser.ShowDialog();
            bs.DataSource = clsUsers.GetAllUsers();
            dgvUsers.DataSource = bs;
            lblRecoedValue.Text = bs.Count.ToString() + " Records Found";

        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewUser frmAddNewUser = new frmAddNewUser();
            frmAddNewUser.ShowDialog();
            bs.DataSource = clsUsers.GetAllUsers();
            dgvUsers.DataSource = bs;
            lblRecoedValue.Text = bs.Count.ToString() + " Records Found";
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _PersonID = Convert.ToInt32(dgvUsers.CurrentRow.Cells["PersonID"].Value.ToString());
            User = clsUsers.GetUserInfoByPersonID(_PersonID);
            if (User.DeleteUser(_PersonID))
            {
                MessageBox.Show("User Deleted Successfully");

            }
            else
            {
                MessageBox.Show("Failed to delete user");
            }
            bs.DataSource=clsUsers.GetAllUsers();
            dgvUsers.DataSource = bs;
            lblRecoedValue.Text = bs.Count.ToString() + " Records Found";
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword(Convert.ToInt32(dgvUsers.CurrentRow.Cells["PersonID"].Value.ToString()));
            frmChangePassword.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("working on");
        }

        private void sendSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("working on");
        }
    }
}
