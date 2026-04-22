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
    public partial class ucVisionTest : UserControl
    {
        private int _AppID;
        private frmVisionTestApointments.enMode _EnTestMode;
        public int AppID
        {   get => _AppID; 
            set 
            { _AppID = value;
                SetVisionTestData();
            }
        }
        public frmVisionTestApointments.enMode EnTestMode {get=> _EnTestMode;set=>_EnTestMode=value;  }
        public int DLAppID { get=>int.Parse(lblDLAppID.Text); set { lblDLAppID.Text = value.ToString(); } }
        public int TestTypeID { get=>clsTestTypes.GetTestTypeIDByTestTypeTitle(lblDClass.Text); private set { }  }
        public DateTime AppointmentDate { get => dtpDate.Value; set => dtpDate.Value = value; }
        public decimal Fees { get => decimal.Parse(lblFees.Text); set => lblFees.Text = value.ToString(); }
        public bool lblTestIDVisible 
        {
            get { return lblTestID.Visible; }
            set { lblTestID.Visible = value;
                lblTestIDValue.Visible = value;
                iconTestID.Visible = value;
            }
        }
        public Image MainImage {  get=>pbMainImage.Image; set=>pbMainImage.Image=value; }
        public string lblMainAddressText { get => lblMainAddress.Text;set=>lblMainAddress.Text=value;  }
        public bool visibleSubAddressLable { get=>lblSubAddress.Visible; set => lblSubAddress.Visible = value; }
        public bool EnableDateTimePicker { get => dtpDate.Enabled;set => dtpDate.Enabled = value;  }
        public int lblTestIDText{ get => Convert.ToInt32(lblTestID.Text); set => lblTestID.Text = value.ToString(); }
        public bool gbRetakeTestVisible 
        {  get=>gbVisionTest.Visible;
            set
            {
                gbRetakeTestInfo.Visible = value;
            }
               

        }
        public int lblTetakeTestIDValue { get => Convert.ToInt32(lblRTestAppID.Text);set=>lblRTestAppID.Text=value.ToString();  }

        public ucVisionTest()
        {
            InitializeComponent();
        }
        public ucVisionTest(int AppID)
        {
            InitializeComponent();
            _AppID = AppID;
        }
        private void ucVisionTest_Load(object sender, EventArgs e)
        {

        

        }
        private void SetRetakePanelData()
        {
            int NumberOFTest = clsTests.GetNumberOFTestsByLocalDrivingLicenseIDAndLicenseClassID(Convert.ToInt32(lblDLAppID.Text), clsLicenseClasses.GetLicenseClassIDFromClassName(Convert.ToString(lblDClass.Text)),(int)_EnTestMode);
            switch (NumberOFTest)
            {
                case 0:

                    gbRetakeTestInfo.Enabled = false;
                        break;
                    default :
                    gbRetakeTestInfo.Enabled=true;
                    lblRAppFees.Text = "5";
                    lblTotalFees.Text = (Convert.ToDecimal(lblRAppFees.Text)+Convert.ToDecimal(lblFees.Text)).ToString();
                    Nullable<int> LastTestID = clsTests.GetLastTestIDByApplicationID();
                    if (LastTestID!=null)
                    lblRTestAppID.Text=LastTestID.ToString();
                    break;
                }
        }
        private void SetVisionTestData()
        {
            DataRow dr = clsTestAppointments.GetVisionTestDataByAppID(_AppID,(int)_EnTestMode);
            if (dr != null)
            {

                lblDLAppID.Text = dr["DLAppID"].ToString();
                lblDClass.Text = dr["DClass"].ToString();
                lblName.Text = dr["Full Name"].ToString();
                lblTrials.Text=dr["Trials"].ToString();
                lblFees.Text = dr["Fees"].ToString();
                dtpDate.MinDate = DateTime.Now;
                dtpDate.MaxDate = DateTime.Now.AddDays(30);
                dtpDate.Value = DateTime.Now;
                SetRetakePanelData();
            }
        }
    }
}
