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
    public partial class FrmAddEditPersonInfo : Form
    {
        DataTable dtCountries = IbrahimDVLDBusinessLayer.clsCountry.GetAllCountries();
        clsPeople _Person=new clsPeople();
        public FrmAddEditPersonInfo(int ID)
        {

            InitializeComponent();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FillCountryComboBox()
        {
           
            
        }
        private void FrmAddEditPersonInfo_Load(object sender, EventArgs e)
        {
            FillCountryComboBox();

        }
        private void GetUCInfo()
        {             _Person.FirstName = ucPersonInfo1.FirstName;
            _Person.SecondName = ucPersonInfo1.SecondName;
            _Person.ThirdName = ucPersonInfo1.ThirdName;
            _Person.LastName = ucPersonInfo1.LastName;
            _Person.NationalNumber = ucPersonInfo1.NationalNUmber;
            _Person.DateOfBirth = ucPersonInfo1.DateOfBirth;
            _Person.Gendor = ucPersonInfo1.Gendor;
            _Person.Phone = ucPersonInfo1.Phone;
            _Person.Email = ucPersonInfo1.Email;
            _Person.CountryID = ucPersonInfo1.CountryID;
            _Person.Address = ucPersonInfo1.Address;
                _Person.ImagePath = ucPersonInfo1.ImagePath;
            }   
        private void btnSave_Click(object sender, EventArgs e)
        {
            GetUCInfo();
            if ((_Person.ID= _Person.Insert(_Person.FirstName, _Person.SecondName, _Person.ThirdName, _Person.LastName, _Person.NationalNumber, _Person.DateOfBirth, _Person.Gendor, _Person.Phone, _Person.Email, _Person.CountryID, _Person.Address, _Person.ImagePath))!=-1)
            {
               this.lblPersonID.Text=_Person.ID.ToString();
                MessageBox.Show("Saved Successfully");
                this.Close();
            }


        }
    }
}
