using IbrahimDVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IbrahimDVLD
{
    public partial class ucLicenseInfo : UserControl
    {
        private int _LocalDrivingLicenseID = -1;
        public int LocalDrivingLicenseID
        {
            get=>_LocalDrivingLicenseID;
            set 
            {
                _LocalDrivingLicenseID = value;
                GetDriverLicenseData();
            }
        }
        public string licenseClassName {  get=>lblClassName.Text; set=>lblClassName.Text=value; }
        public string PersonName { get=>lblPersonName.Text; set=>lblPersonName.Text=value; }
        public int LicenseID { get=>(int.TryParse(lblLicenseID.Text,out int Result))?Result:-1; set=>lblLicenseID.Text=value.ToString(); }
        public string NationalNumber { get => lblNationalNumber.Text;set=>lblNationalNumber.Text=value;  }
        public byte Gendor 
        {
            get
            {
                return (byte) ((lblGendor.Text == "Male") ? 0 : 1);
            }
            set
            {
                lblGendor.Text=(value==0) ? "Male" : "Female";
            }
         }
        public DateTime IssueDate
        { get => dtpIssueDate.Value;
          set
            {
                if(!DesignMode)
                dtpIssueDate.Value = (DateTime.TryParse(value.ToString(), out DateTime Result)) ? Result : DateTime.Now;
            }
        }
        public string IssueReason { get=>lblIssueReason.Text; set=>lblIssueReason.Text=value; }
        public string Notes { get=>lblNotes.Text; set=>lblNotes.Text=value; }   
        public bool IsActive
        {
            get
            {
                return ((lblIsActive.Text == "Yes") ? true : false);
            }
            set
            {
                lblIsActive.Text = (value==true )? "Yes" : "No";
            }
        }
        public DateTime DateOfBirth 
        {
            get => dtpDateOfBirth.Value;
            set
            {
                dtpDateOfBirth.Value = (DateTime.TryParse(value.ToString(), out DateTime Result)) ? Result : DateTime.Now;
            }
        }
        public int DriverID {
            get => (int.TryParse(lblDriverID.Text, out int result) ? result : -1);
            set
            {
                lblDriverID.Text = (value.ToString());

            }
        }
        public DateTime ExpirationDate
        {
            get => dtpExpirationDate.Value;
            set
            {
                dtpExpirationDate.Value = (DateTime.TryParse(value.ToString(), out DateTime Result)) ? Result : DateTime.Now;
            }
        }
        public bool IsDetained 
        {

            get
            {
                return ((lblIsDetained.Text == "Yes") ? true : false);
            }
            set
            {
                lblIsDetained.Text = value ? "Yes" : "No";
            }
        }
        public string ImagePath
        {
            get => pbPersonImage.ImageLocation;
            set { pbPersonImage.ImageLocation = value; }
        }
        public ucLicenseInfo()
        {
            InitializeComponent();
            licenseClassName=string.Empty;
            PersonName=string.Empty;
            NationalNumber=string.Empty;
            LicenseID=0;
            Gendor=0;
            IssueDate=DateTime.Now;
            IssueReason=string.Empty;
            Notes=string.Empty;
            IsActive = false;
            DateOfBirth=DateTime.Now;
            DriverID = 0;
            ExpirationDate = DateTime.Now;
            IsDetained = false;
            ImagePath = string.Empty;
        }
        public ucLicenseInfo(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            this.LocalDrivingLicenseID = LocalDrivingLicenseID;
        }
        private void ucLicenseInfo_Load(object sender, EventArgs e)
        {
            if(DesignMode)
                { return; }
        }
        private void GetDriverLicenseData()
        {
            if(_LocalDrivingLicenseID!=-1)
            {
                DataTable DriverLicenseData=new DataTable();
                if (clsLicense.GetDriverLicenseData(_LocalDrivingLicenseID) != null)
                {
                    DriverLicenseData = clsLicense.GetDriverLicenseData(_LocalDrivingLicenseID);
                    DataRow Data = DriverLicenseData.Rows[0];
                    licenseClassName = (string)Data["License Class"];
                    PersonName = (string)Data["PersonName"];
                    LicenseID = (int)Data["LicenseID"];
                    NationalNumber = (string)Data["NationalNo"];
                    Gendor = (byte)Data["Gendor"];
                    IssueDate = Convert.ToDateTime(Data["IssueDate"]);
                    IssueReason = ((byte)Data["IssueReason"]) switch 
                                  {
                                    1=>  "New License",
                                    2=>  "Renew",
                                    3=>  "Damaged",
                                    4=>  "Lost",
                                    _=>  "Unknown"
                                  };

                    Notes = (string)Data["Notes"];
                    IsActive = (bool)Data["IsActive"];
                    DateOfBirth = Convert.ToDateTime(Data["DateOfBirth"]);
                    DriverID = (int)Data["DriverID"];
                    ExpirationDate = Convert.ToDateTime(Data["ExpirationDate"]);
                   // Console.WriteLine(Data["IsDetained"].GetType().Name);
                    IsDetained = (int)(Data["IsDetained"]) > 0 ;
                    ImagePath = (string)Data["ImagePath"];
                }


            }
        }

        private void gbLicenseInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}
