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
        private int _PersonID=-1;
        clsPeople _Person;
        public frmPersonInfo(int PersonID ,bool UpdateMode)
        {
            InitializeComponent();
            _PersonID = PersonID;
            
            ucPersonInfo1.Enabled = UpdateMode;
            if(UpdateMode==false)
                btnSave.Visible = false;

           
        }

        private void frmPersonInfo_Load(object sender, EventArgs e)
        {
            clsPeople Person = new clsPeople();
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", NationalNUmber = "", Phone = "", Email = "", Country = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            bool Gendor = false;
            if (Person.GetPersonInfo(_PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref NationalNUmber, ref DateOfBirth, ref Gendor, ref Phone, ref Email, ref Country, ref Address, ref ImagePath)!=null)
            {
                _Person = Person;
                lblPersonIDValue.Text = _PersonID.ToString();
                ucPersonInfo1.FirstName = FirstName;
                ucPersonInfo1.SecondName = SecondName;
                ucPersonInfo1.ThirdName = ThirdName;
                ucPersonInfo1.LastName = LastName;
                ucPersonInfo1.NationalNUmber = NationalNUmber;
                ucPersonInfo1.DateOfBirth = DateOfBirth;
                ucPersonInfo1.Gendor = Gendor.ToString();
                ucPersonInfo1.Phone = Phone;
                ucPersonInfo1.Email = Email;
                ucPersonInfo1.Country = Country;
                ucPersonInfo1.Address = Address;
                ucPersonInfo1.ImagePath = ImagePath;


            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           if( _Person.Update(_PersonID,ucPersonInfo1.FirstName.ToString(),ucPersonInfo1.SecondName.ToString(),ucPersonInfo1.ThirdName.ToString(),
                            ucPersonInfo1.LastName.ToString(),ucPersonInfo1.NationalNUmber.ToString(),(DateTime)ucPersonInfo1.DateOfBirth,ucPersonInfo1.Gendor.ToString(),
                            ucPersonInfo1.Phone.ToString(),ucPersonInfo1.Email.ToString(),ucPersonInfo1.Country.ToString(),ucPersonInfo1.Address.ToString(),
                            ucPersonInfo1.ImagePath.ToString()))
            {
                MessageBox.Show("تم التعديل");
                

            }
        }
    }
}
