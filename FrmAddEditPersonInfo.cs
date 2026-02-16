using IbrahimDVLD.Properties;
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
        private int _PersonID;
        public FrmAddEditPersonInfo(int ID)
        {

            InitializeComponent();
                _PersonID = ID;

        }
        private bool GetPersonInfo()
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", NationalNumber = "", Phone = "", Email = "", Address = "", imagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gendor = 0;
            int CountryID = -1;

            _Person = clsPeople.GetPersonInfo(_PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                                                          ref NationalNumber, ref DateOfBirth, ref Gendor, ref Phone,
                                                          ref Email, ref CountryID, ref Address, ref imagePath);
            if (_Person != null)
            {
             
                lblAddress.Text = "Edit Person Info";
                return true;
            }
            return false;
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
            btnSave.Image = Properties.Resources.icons8_save_48;
           
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Image = Properties.Resources.icons8_close_48;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            FillCountryComboBox();
            GetPersonInfo();
            if (_PersonID!=-1)
            {
                lblPersonID.Text = _PersonID.ToString();
                ucPersonInfo1.FirstName = _Person.FirstName;
                ucPersonInfo1.SecondName = _Person.SecondName;
                ucPersonInfo1.ThirdName = _Person.ThirdName;
                ucPersonInfo1.LastName = _Person.LastName;
                ucPersonInfo1.NationalNUmber = _Person.NationalNumber;
                ucPersonInfo1.DateOfBirth = _Person.DateOfBirth;
                ucPersonInfo1.Gendor = _Person.Gendor;
                ucPersonInfo1.Phone = _Person.Phone;
                ucPersonInfo1.Email = _Person.Email;
                ucPersonInfo1.CountryID = _Person.CountryID;
                ucPersonInfo1.Address = _Person.Address;
                ucPersonInfo1.ImagePath = _Person.ImagePath;
            }

        }
        private void GetUCInfo()
        {   _Person.FirstName = ucPersonInfo1.FirstName;
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
                MessageBox.Show("تم الحفظ بنجاح ");
                this.Close();
            }


        }
    }
}
