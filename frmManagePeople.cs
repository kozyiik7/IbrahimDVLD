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
            dataGridView1.DataSource=clsPeople.GetAllPeople();
            lblNumberOfRecords.Text=dataGridView1.RowCount.ToString();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            Form frmAddEdit = new FrmAddEditPersonInfo(-1);
            frmAddEdit.ShowDialog();
        }
    }
}
