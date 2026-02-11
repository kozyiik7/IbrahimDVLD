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
        private void RefreshDataGridView()
        {
            dataGridView1.DataSource = clsPeople.GetAllPeople();
            lblNumberOfRecords.Text = dataGridView1.RowCount.ToString();
        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            //BindingSource bs = new BindingSource();
            //bs.DataSource=clsPeople.GetAllPeople();
            //lblNumberOfRecords.Text=bs.Count.ToString();

           RefreshDataGridView();
            txtSearch.Visible = false;
            FillcmbFilterWithItems();
        }
        
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            Form frmAddEdit = new FrmAddEditPersonInfo(-1);
            frmAddEdit.ShowDialog();
            RefreshDataGridView();
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
           // MessageBox.Show("You clicked Show Details");
            frmPersonInfo PersonInfo=new frmPersonInfo(Convert.ToInt32( dataGridView1.CurrentRow.Cells[0].Value.ToString()),false);
            PersonInfo.ShowDialog();
            RefreshDataGridView();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAddEdit = new FrmAddEditPersonInfo(-1);
            frmAddEdit.ShowDialog();
            RefreshDataGridView();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditPersonInfo PersonInfo1 = new FrmAddEditPersonInfo(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            PersonInfo1.ShowDialog();
            RefreshDataGridView();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Want to Delete ? ","CONFIRM",MessageBoxButtons.OKCancel)==DialogResult.OK && clsPeople.Delete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()))) 
            {
                MessageBox.Show("تم الحذف بنجاح");
            }
            else
            { 
                MessageBox.Show("هناك مشكلة يبدو ان الاسم مرتبط بسجل اخر ");
            }
            RefreshDataGridView();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You clicked Send Email");
            RefreshDataGridView();
        }

        private void sendSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You clicked Send SMS");
            RefreshDataGridView();
        }
        
    }
}
