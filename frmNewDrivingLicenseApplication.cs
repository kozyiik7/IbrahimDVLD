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
    public partial class frmNewDrivingLicenseApplication : Form
    {
        public enum enApplicationStatus
        {
            New=1,
            processing=2,
            Canceled=3,
           
        }
        private int _ApplicationID=-1;
        private int _LicenseClassID;
        private int _LocalDrivingLicenseApplicationID;
        public int cmbLicenseClass { get => Convert.ToInt32(cmbLicenseClasses.ValueMember); set => cmbLicenseClasses.ValueMember = value.ToString(); }
        private  int _PersonID;
        private int _ApplicationTypeID;
        clsApplication ApplicationData;
        clsPeople PersonData=new clsPeople();

        public frmNewDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tcPersonInfoApplication.SelectedTab = tpApplicationInfo;
            btnSave.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FillCmbLicenseClassesItems()
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource=clsLicenseClasses.GetAllLicenseClasses();
            cmbLicenseClasses.DataSource = bindingSource;
            cmbLicenseClasses.DisplayMember = "ClassName";
            cmbLicenseClasses.SelectedIndex = 2;
            cmbLicenseClasses.ValueMember = "LicenseClassID";
        }
        private void FillApplicationInfoData() 
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = clsApplicationTypes.GetApplicationFeesFromApplicatioName("New Local Driving License Service").ToString();
            lblCreatedBy.Text=clsUsers.GetUserInfoByPersonID(IbrahimDVLDCommonLayer.UserSession.Instance.PersonID).UserName;

        }

        private void frmNewDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            FillCmbLicenseClassesItems();   
            FillApplicationInfoData();
            ucFilterWithPersonInof1.OnPersonID += GetPersonIDFromFilter;
            _ApplicationTypeID=clsApplicationTypes.GetApplicationTypeIDFromApplicatioName("New Local Driving License Service");

        }
       
        public void GetPersonIDFromFilter(object sender, int PersonIDval)
        {
            _PersonID = PersonIDval;
            this.PersonData=PersonData.GetPersonInfoByPersonID(_PersonID);
            
        }
        private bool FillApplicationData() 
        {
            ApplicationData = new clsApplication();
            ApplicationData.ApplicationPersonID = _PersonID;
            ApplicationData.ApplicationDate = Convert.ToDateTime(lblApplicationDate.Text);
            ApplicationData.ApplicationTypeID = clsApplicationTypes.GetApplicationTypeIDFromApplicatioName("New Local Driving License Service");
            ApplicationData.ApplicationStatus = (short)enApplicationStatus.New;
            ApplicationData.LastStatusDate = DateTime.Now;
            ApplicationData.PaidFees = clsApplicationTypes.GetApplicationFeesFromApplicatioName("New Local Driving License Service");
            ApplicationData.CreatedcByUserID = IbrahimDVLDCommonLayer.UserSession.Instance.PersonID;
            return true;
        }
        private void tpPersonInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FillApplicationData();
            if (ApplicationData != null && PersonData != null && !clsApplication.IsDriverHasSameApplicationTypeWithStatus(_PersonID, _LicenseClassID) )
            {
               _ApplicationID= ApplicationData.InsertApplication();
                lblApplicationID.Text = _ApplicationID.ToString();
                _LicenseClassID=clsLicenseClasses.GetLicenseClassIDFromClassName(cmbLicenseClasses.Text);
               _LocalDrivingLicenseApplicationID= clsLocalDrivingLicenseApplications.InsertLocalDrivingLicenseApplication(_ApplicationID, _LicenseClassID);
                if(_ApplicationID > 0 && _LocalDrivingLicenseApplicationID > 0)
                MessageBox.Show("Application Saved Successfully, Application ID is " + _ApplicationID.ToString() + " and Local Driving License Application ID is " + _LocalDrivingLicenseApplicationID.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
                MessageBox.Show("Error Saving Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmbLicenseClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LicenseClassID=clsLicenseClasses.GetLicenseClassIDFromClassName(cmbLicenseClasses.Text);
        }
    }
}
