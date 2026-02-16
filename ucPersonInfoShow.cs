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
    public partial class ucPersonInfoShow : UserControl
    {
        public int _PersonID;
        clsPeople personInfo=new clsPeople();
        public int PersonID
        {
            set { lblPersonIDValue.Text=value.ToString(); }
        }
        public string PersonName
        {
            
            set { lblName.Text = value; }
        }
        public string NationalNumber
        {
           
            set { lblNationalNumber.Text = value; }
        }
        public string DateOfBirth
        {
           
            set { lblDateOfBirth.Text = value; }
        }
        public string Gendor
        {
            get { return lblGendor.Text; }

            set { lblGendor.Text = value; }
        }
        public string Phone
        {
            
            set { lblPhone.Text = value; }
        }
        public string Email
        {
            
            set { lblEmail.Text = value; }
        }
        public string Country
        {
            
            set { lblCountry.Text = value; }
        }
        public string Address
        {
            
            set { lblAddress.Text = value; }
        }
        public string imagePath
        {
            
            set { pbPersonImage.ImageLocation = value; }
            get { return pbPersonImage.ImageLocation; }
        }
        public bool llPersonInfoSet
        { 
        set { llEditPersonInfo.Enabled = value; }
        }
       
        public Image setImage
        {
                       set { pbPersonImage.Image = value; }

        }
        public ucPersonInfoShow()
        {
            InitializeComponent();
         

        }

        public ucPersonInfoShow(int PersonID)
        { 
        InitializeComponent();
            _PersonID = PersonID;
            
        }

        public void refreshPersonInfo()
        {
            PersonInfoShow_Load(null, null);
        }

        private void PersonInfoShow_Load(object sender, EventArgs e)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", NationalNumber = "", Phone = "", Email = "", Address = "", imagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gendor = 0;
            int CountryID = -1;

            personInfo = clsPeople.GetPersonInfo(_PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                                                          ref NationalNumber, ref DateOfBirth, ref Gendor, ref Phone,
                                                          ref Email, ref CountryID, ref Address, ref imagePath);
            if (personInfo != null)
            {
                PersonID = personInfo.ID;
                PersonName = FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
                this.NationalNumber = NationalNumber;
                this.DateOfBirth = DateOfBirth.ToShortDateString();
                this.Gendor = (Gendor == 0) ? "Male" : "Female";
                this.Phone = Phone;
                this.Email = Email;
                this.Address = Address;
                this.imagePath = imagePath;
                this.Country = clsCountry.GetCountyNameByCountryID(CountryID).ToString();
                pbPersonImage.ImageLocation = imagePath;
               
                
            }
        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAddEditPersonInfo frmAddEdit = new FrmAddEditPersonInfo(_PersonID);
            frmAddEdit.ShowDialog();
        }

      
    }
}
