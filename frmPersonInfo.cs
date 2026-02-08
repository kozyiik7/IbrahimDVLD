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
    public partial class frmPersonInfo : Form
    {
        int CountryId = -1;
        private int _PersonID=-1;
        clsPeople _Person;
        private bool _UpdateMode = false;
        public frmPersonInfo(int PersonID ,bool UpdateMode)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _UpdateMode = UpdateMode;
            ucPersonInfo1.Enabled = _UpdateMode;
            ucPersonInfo1.LinkedlabelSetImageVisible = _UpdateMode;
            ucPersonInfo1.LinkedLabeleRemoveVisible = _UpdateMode;
            btnSave.Visible = _UpdateMode;
            

        }

        private void frmPersonInfo_Load(object sender, EventArgs e)
        {
            
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", NationalNUmber = "", Phone = "", Email = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gendor = 0;
            int CountryID = 0;
            // CountryId =clsCountry.GetCountyIDByCountryName(ucPersonInfo1.CountryID);
            _Person = clsPeople.GetPersonInfo(_PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref NationalNUmber, ref DateOfBirth, ref Gendor, ref Phone, ref Email, ref CountryID, ref Address, ref ImagePath);
            if (_Person!=null)
            {
                
                lblPersonIDValue.Text = _PersonID.ToString();
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
               ucPersonInfo1.LinkedLabeleRemoveVisible=(_Person.ImagePath!=null&&_UpdateMode);


            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           if( _Person.Update(_PersonID,ucPersonInfo1.FirstName.ToString(),ucPersonInfo1.SecondName.ToString(),ucPersonInfo1.ThirdName.ToString(),
                            ucPersonInfo1.LastName.ToString(),ucPersonInfo1.NationalNUmber.ToString(),(DateTime)ucPersonInfo1.DateOfBirth,ucPersonInfo1.Gendor,
                            ucPersonInfo1.Phone.ToString(),ucPersonInfo1.Email.ToString(),ucPersonInfo1.CountryID ,ucPersonInfo1.Address.ToString(),
                            ucPersonInfo1.ImagePath.ToString()))
            {
                MessageBox.Show("تم التعديل");
                

            }
        }
    }
}
