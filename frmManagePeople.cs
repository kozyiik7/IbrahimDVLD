using IbrahimDVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IbrahimDVLD
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            //BindingSource bs = new BindingSource();
            //bs.DataSource=clsPeople.GetAllPeople();
            //lblNumberOfRecords.Text=bs.Count.ToString();

            dataGridView1.DataSource = clsPeople.GetAllPeople();
            lblNumberOfRecords.Text = dataGridView1.RowCount.ToString();
            txtSearch.Visible = false;
            FillcmbFilterWithItems();
        }
        
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            Form frmAddEdit = new FrmAddEditPersonInfo(-1);
            frmAddEdit.ShowDialog();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.Text != "None")
            { 
                txtSearch.Visible = true;
            }
        }
        private void FillcmbFilterWithItems()
        {
            cmbFilter.Items.Add("None");
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                cmbFilter.Items.Add(column.HeaderText);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cmbFilter.Text != "None")
            {


                BindingSource bs = new BindingSource();
                bs.DataSource = clsPeople.GetAllPeople();
                bs.Filter = string.Format("{0} like '%{1}%'", cmbFilter.Text, txtSearch.Text);
                dataGridView1.DataSource = bs;
                lblNumberOfRecords.Text = (dataGridView1.RowCount - 1).ToString();
                //DataTable dt=(DataTable)dataGridView1.DataSource ;
                //dt.DefaultView.RowFilter = string.Format("[{0}] like '%{1}%'", cmbFilter.Text, txtSearch.Text);
                //lblNumberOfRecords.Text=(dataGridView1.RowCount-1).ToString();
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You clicked Show Details");
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAddEdit = new FrmAddEditPersonInfo(-1);
            frmAddEdit.ShowDialog();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You clicked Edit");
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You clicked Edit");
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You clicked Send Email");
        }

        private void sendSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You clicked Send SMS");
        }
    }
}
