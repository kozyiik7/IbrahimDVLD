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
    public partial class PersonInfoShow : UserControl
    {
        private int _PersonID;
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
        }
      

        public PersonInfoShow(int PersonID)
        { 
        InitializeComponent();
            _PersonID = PersonID;
            


        }

        private void gbPersonInfo_Enter(object sender, EventArgs e)
        {

        }

        private void PersonInfoShow_Load(object sender, EventArgs e)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", NationalNumber = "", Phone = "", Email = "", Address = "", imagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gendor = 0;
            int CountryID = -1;

            clsPeople personInfo = clsPeople.GetPersonInfo(_PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                                                          ref NationalNumber, ref DateOfBirth, ref Gendor, ref Phone,
                                                          ref Email, ref CountryID, ref Address, ref imagePath);
            if (personInfo != null)
            {
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
    }
}
