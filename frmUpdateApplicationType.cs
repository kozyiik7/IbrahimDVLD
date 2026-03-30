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
    public partial class frmUpdateApplicationType : Form
    {
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeName { get=>txtTitle.Text; set=>txtTitle.Text=value; }
        public float ApplicationFeesAmountsq { get=>Convert.ToSingle(txtFees.Text); set=>txtFees.Text=value.ToString(); }
        public frmUpdateApplicationType()
        {
            InitializeComponent();
        }
        public frmUpdateApplicationType(int applicationTypeID, string applicationTypeName, float applicationFeesAmount)
        {
            InitializeComponent();
            ApplicationTypeID = applicationTypeID;
            ApplicationTypeName = applicationTypeName;
            ApplicationFeesAmountsq = applicationFeesAmount;
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            FillData();
        }
        private void FillData()
        {
            lblID.Text = ApplicationTypeID.ToString();
            txtTitle.Text = ApplicationTypeName;
            txtFees.Text = ApplicationFeesAmountsq.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
           if( clsApplicationTypes.update(ApplicationTypeID, ApplicationTypeName, ApplicationFeesAmountsq))
                MessageBox.Show("Application Type Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
           else
                MessageBox.Show("Failed to Update Application Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }
    }
}
