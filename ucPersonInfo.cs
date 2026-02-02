using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace IbrahimDVLD
{
    public partial class ucPersonInfo : UserControl
    {
        string SourceFolder = "";
        string DestinationFolder= @"C:\Users\kozy\source\repos\IbrahimDVLD\Project_People_Images";
        string DestinationWithNewName = "";
        public string FirstName { get { return txtFirstName.Text; } set { txtFirstName.Text = value; } }
        public string SecondName { get { return txtSecondName.Text; } set { txtSecondName.Text = value; } }
        public string ThirdName { get { return txtThirdName.Text; } set { txtThirdName.Text = value; } }
        public string LastName { get { return txtLastName.Text; } set { txtLastName.Text = value; } }
        public string NationalNUmber { get { return txtNationalNumber.Text; } set { txtNationalNumber.Text = value; } }
        public DateTime DateOfBirth { get { return dtpDateOfBirth.Value; } set {dtpDateOfBirth.Value=value; } }
        public string Gendor 
        {
            get
            { 
                if (rbMale.Checked) return "Male";
                if (rbFemale.Checked) return "Female";
                else return null;
            }
            set
            {
                if (value == "Male")
                    rbMale.Checked = true;
                else if (value =="Female")
                    rbFemale.Checked = true;
            }
        }
        public string Phone { get { return txtPhone.Text; } set { txtPhone.Text = value; } }
        public string Email { get { return txtEmail.Text; } set { txtEmail.Text = value; } }
        public string Country
        {
            get { return cmbCountry.SelectedItem?.ToString(); }

            set { cmbCountry.SelectedItem = value; }
        }
        public string Address { get { return txtAddress.Text; } set { txtAddress.Text = value; } }
        public string ImagePath { get { return pbImage.ImageLocation; } set { pbImage.ImageLocation = value; } }


        public ucPersonInfo()
        {
            InitializeComponent();
            FillCountriesComboBox();
            SetDateTimePickerRange();
            rbMale.Checked = true;
            pbImage.Image = imageList1.Images[0];
            llRemove.Visible = false;
            
        }
        private void FillCountriesComboBox()
        {
            cmbCountry.DataSource=IbrahimDVLDBusinessLayer.clsCountry.GetAllCountries();
            cmbCountry.DisplayMember = "CountryName";
            cmbCountry.SelectedIndex=cmbCountry.FindStringExact("Syria");

        }
        private void SetDateTimePickerRange()
        {
            dtpDateOfBirth.MinDate = DateTime.Parse("1900-01-01");
            dtpDateOfBirth.MaxDate = DateTime.Today.AddYears(-18);
        }

        private void txtNationalNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNationalNumber.Text))
            {
                errorProvider1.SetError(txtNationalNumber, "يجب إدخال قيمة");
                txtNationalNumber.Focus();
            }
            else
            { 
               if (IbrahimDVLDBusinessLayer.clsPeople.IsNationalnumberExist(txtNationalNumber.Text))
                {
                errorProvider1.SetError(txtNationalNumber, "الرقم موجود");
                    txtNationalNumber.Focus();
                }
               else
               {
                errorProvider1.SetError(txtNationalNumber, string.Empty);
               }


            }

        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Guid newGuid = Guid.NewGuid();
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK&&openFileDialog1.FileName!=null)
            {
                SourceFolder = openFileDialog1.FileName;
                DestinationWithNewName = Path.Combine(DestinationFolder, newGuid.ToString() + ".jpg");
                File.Copy(SourceFolder, DestinationWithNewName, true);
                pbImage.ImageLocation = DestinationWithNewName;
                llRemove.Visible = true;
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            pbImage.Image = imageList1.Images[0];
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            pbImage.Image = imageList1.Images[1];

        }

        

        private void txtSecondName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSecondName.Text))
            {
                errorProvider1.SetError(txtSecondName, "يجب ادخال الاسم الثاني");
                txtSecondName.Focus();
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                errorProvider1.SetError(txtFirstName, "يجب ادخال الاسم الاول");
                txtFirstName.Focus();
            }
        }

        private void txtThirdName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtThirdName.Text))
            {
                errorProvider1.SetError(txtThirdName, "يجب ادخال الاسم الثالث");
                txtThirdName.Focus();
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                errorProvider1.SetError(txtLastName, "يجب ادخال الاسم الاخير");
                txtLastName.Focus();
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                errorProvider1.SetError(txtPhone, "يجب ادخال رقم الهاتف");
                txtPhone.Focus();
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                if (!txtEmail.Text.Contains("@"))
                    errorProvider1.SetError(txtEmail, "يجب ادخال ايميل صحيح");
            }
        }

        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            File.Delete(pbImage.ImageLocation);

            if (rbMale.Checked)
            {
                pbImage.Image = imageList1.Images[0];
            }
            else if (rbFemale.Checked)
            {
                pbImage.Image = imageList1.Images[1];
            }
            llRemove.Visible = false;
        }
    }
}
