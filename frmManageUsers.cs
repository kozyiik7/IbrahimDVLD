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
        public frmManageUsers()
        {
            InitializeComponent();
        }
       
       
        
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
          
            txtFilter.Visible = false;
            BindingSource bs = new BindingSource();
            bs.DataSource = clsUsers.GetAllUsers();
            dgvUsers.DataSource = bs;
            lblRecoedValue.Text = bs.Count.ToString() + " Records Found";
            FillComboboxWithItems();

        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbFilter.SelectedIndex!=0)
            {
                txtFilter.Visible = true;
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedIndex != 0)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = clsUsers.GetAllUsers();
                bs.Filter = string.Format("CONVERT([{0}], 'System.String') like '%{1}%'", cmbFilter.Text,txtFilter.Text);
                dgvUsers.DataSource=bs;
                lblRecoedValue.Text = bs.Count.ToString();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmAddNewUser frmAddNewUser = new frmAddNewUser();
            frmAddNewUser.ShowDialog();
        }
    }
}
