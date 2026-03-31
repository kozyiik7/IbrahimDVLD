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
    public partial class frmManageApplication_TestType : Form
    {
        public enum enMode { ManageApplicationType ,ManageTestType }
        enMode Mode=enMode.ManageApplicationType;
        BindingSource bindingSource;
        public frmManageApplication_TestType()
        {
            InitializeComponent();
        }
        public frmManageApplication_TestType(enMode RecievedMode)
        {
            InitializeComponent();
            Mode=RecievedMode;
        }
        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
           refreshDatasource(Mode);

        }
        private void refreshDatasource(enMode recievedMode)
        {
            bindingSource = new BindingSource();
            switch(recievedMode)
            {
                case enMode.ManageApplicationType:
                    bindingSource.DataSource = IbrahimDVLDBusinessLayer.clsApplicationTypes.GetApplicationTypes();
                    lblFormAddress.Text = "Manage Application Types";
                    frmManageApplication_TestType.ActiveForm.Text = "Manage Application Types";
                  

                    break;
                case enMode.ManageTestType:
                    bindingSource.DataSource = IbrahimDVLDBusinessLayer.clsTestTypes.GetTestTypes();
                    lblFormAddress.Text = "Manage Test Types";
                    frmManageApplication_TestType.ActiveForm.Text = "Manage Test Types";
                    break;
            }
            dgvApplicationTypes.DataSource = bindingSource;
            dgvApplicationTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvApplicationTypes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders
            dgvApplicationTypes.AutoSize=true;
            this.AutoSize = true;
            //this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            lblNumberOfRecords.Text = bindingSource.Count.ToString();

                   
            }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch(Mode)
            {
                case enMode.ManageApplicationType:
                    int applicationTypeID = Convert.ToInt32(dgvApplicationTypes.CurrentRow.Cells["ApplicationTypeID"].Value);
                    string applicationTypeName = dgvApplicationTypes.CurrentRow.Cells["ApplicationTypeTitle"].Value.ToString();
                    float applicationFeesAmount = Convert.ToSingle(dgvApplicationTypes.CurrentRow.Cells["ApplicationFees"].Value);
                    frmUpdateApplicationType frm = new frmUpdateApplicationType(applicationTypeID, applicationTypeName, applicationFeesAmount);
                    frm.ShowDialog();
                    break;
                case enMode.ManageTestType:
                  //  editTestType();
                    break;
            }
            
           
            refreshDatasource(Mode);
        }
    }
}
