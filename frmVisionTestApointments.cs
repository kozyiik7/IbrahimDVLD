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
        public frmVisionTestApointments()
        {
            InitializeComponent();
        }
        public frmVisionTestApointments(int AppID)
        {
            InitializeComponent();
            _AppID = AppID;
           this.AppID = AppID;
        }
        private void FillDataGridView()
        {
            if (clsTestAppointments.GetVisionTestAppoinmetsByAppID(AppID) != null)
            {
                bs.DataSource = clsTestAppointments.GetVisionTestAppoinmetsByAppID(AppID);
                dgvAppointments.DataSource = bs;
            }
            lblNumberOfRecords.Text = lblNumberOfRecords.Text + " " + dgvAppointments.Rows.Count.ToString();
        }
        private void frmVisionTestApointments_Load(object sender, EventArgs e)
        {
            ucApplicationAllInfo1.AppID = _AppID;
            FillDataGridView();

        }
       
    }
}
