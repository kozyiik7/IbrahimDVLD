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
    public partial class ucApplicationBasicInfo : UserControl
    {
        private int _ApplicationID { get; set; }
        public ucApplicationBasicInfo()
        {
            InitializeComponent();
        }
        public ucApplicationBasicInfo(int AppID)
        {
            InitializeComponent();
            _ApplicationID = AppID;
        }
        public int ApplicationID 
        {
            get => lblID.Text != string.Empty ?( int.TryParse(lblID.Text, out int AppID) ? AppID : 0):0;//Convert.ToInt32(lblID.Text):0;
            set
            {
                _ApplicationID=value;
                lblID.Text = value.ToString();
                InitializeData();
            }
        } 
        public string Status { get => lblStatus.Text; set { lblStatus.Text = value; } }
        public decimal Fees {
            get
            { if (decimal.TryParse(lblFees.Text, out decimal fees)) 
                    return fees;
            else return 0;
            }
            set { lblFees.Text = value.ToString(); } } 
        public string Type { get => lblType.Text; set { lblType.Text = value; } }
        public string ApplicantName { get => lblApplicatnt.Text; set { lblApplicatnt.Text = value; } }
        public DateTime ApplicationDate { get => dtpApplicationDate.Value; set { dtpApplicationDate.Value = value; } }
        public DateTime StatusDate { get => dtpStatusDate.Value; set { dtpStatusDate.Value = value; } }
        public string CreatedBy { get => lblCreatedBy.Text; set { lblCreatedBy.Text = value; } }
         public int PersonID { get; set; }
        private void InitializeData()
        {
            DataTable dt = new DataTable();

            if((dt=clsApplication.GetApplicationInfoWithDetailsByAppID(_ApplicationID)) == null) return;
            DataRow dr = dt.Rows[0];
            if (dr == null) return;
           // ApplicationID = Convert.ToInt32(dr["ApplicationID"]);
            Status = dr["Status"].ToString();
            Fees = Convert.ToInt32(dr["PaidFees"]);
            Type = dr["ApplicationTypeTitle"].ToString();
            ApplicantName = dr["Applicant"].ToString();
            ApplicationDate = Convert.ToDateTime(dr["ApplicationDate"]);
            StatusDate = Convert.ToDateTime(dr["LastStatusDate"]);
            CreatedBy = dr["UserName"].ToString();
            GetPersonID();

        }
        private void GetPersonID()
        {
            if(_ApplicationID == 0) return;
            clsApplication application = clsApplication.GetApplicationData(ApplicationID);
            this.PersonID = application.ApplicationPersonID;
        }
        private void gbApplicationBasicInfo_Enter(object sender, EventArgs e)
        {

        }

        private void ucApplicationBasicInfo_Load(object sender, EventArgs e)
        {
            if(DesignMode) return;
            
        }
       
        private void lblViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (PersonID == 0) return;
            frmPersonInfo personInfo = new frmPersonInfo(PersonID,false);
            personInfo.ShowDialog();

        }
    }
}
