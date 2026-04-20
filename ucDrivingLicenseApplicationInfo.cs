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
    public partial class ucDrivingLicenseApplicationInfo : UserControl
    {
        private int _dlAppID;
        private int localDrivingLicenseID = 0;
        public ucDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }
        public ucDrivingLicenseApplicationInfo(int DlAppID)   
        {
            InitializeComponent();
           this. DLAppID = DlAppID;
        }
        public int DLAppID
        { 
            get=>lblDrivingLicenseApplicatonID.Text != string.Empty ? Convert.ToInt32(lblDrivingLicenseApplicatonID.Text) : 0; 
            set
            {
                _dlAppID=value;
                GetLocalDrivingLicenseID();
                InitializeUCInfo();
                lblDrivingLicenseApplicatonID.Text = localDrivingLicenseID.ToString();
            }
        }
        public string AppliedForLicense {  get=>lblAppliedForLicense.Text; set=>lblAppliedForLicense.Text=value; }
        public string LicenseInfo {  get=>lblShowLicesnseInfo.Text; set=> lblShowLicesnseInfo.Text=value; }
        public int PassedTests {  get=>lblPassedTests.Text != string.Empty ? Convert.ToInt32(lblPassedTests.Text) : 0; set=>lblPassedTests.Text=value.ToString()+"/3"; }

        private void InitializeUCInfo()
        {
            DataRow row = null;
            if (_dlAppID > 0)
            {
                row = IbrahimDVLDBusinessLayer.clsApplication.GetDrivingLicenseInfo(_dlAppID);
            }
            if (row != null)
            {
               // DLAppID = Convert.ToInt32(row["ApplicationID"]);
                AppliedForLicense = row["ClassName"].ToString();
                LicenseInfo = row["ClassDescription"] == DBNull.Value ? string.Empty : row["ClassDescription"].ToString();
                PassedTests = clsLocalDrivingLicenseApplications.GetNumberOFPassedTestByLocalDrivingLicenceID(localDrivingLicenseID);
            }
        }
        private void GetLocalDrivingLicenseID()
        {
            if (_dlAppID!=0)
             localDrivingLicenseID = clsLocalDrivingLicenseApplications.GetLicenseIDByApplicationID(_dlAppID);
        }
        private void ucDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            if(DesignMode) return;
        }

        private void gbDrivingLicenseApplicationInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}
