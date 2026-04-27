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
    public partial class frmManageDrivers : Form
    {
        BindingSource bindingSource=new BindingSource();
        public frmManageDrivers()
        {
            InitializeComponent();
        }

        private void PrepareDataGridViewData()
        {
            bindingSource.DataSource = clsDriver.GetAllDrivers();
            dgvDrivers.DataSource = bindingSource;
            dgvDrivers.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            PrepareDataGridViewData();
        }
    }
}
