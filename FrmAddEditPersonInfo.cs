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
        public delegate void RefreshPersonID(object sender, int PersonID);
        public event RefreshPersonID RefreshPersonIDEvent;
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

            _Person = clsPeople.GetPersonInfoPersonID(_PersonID);
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
            // للتأكد فقط أثناء التطوير
          //  MessageBox.Show(ucPersonInfo1 == null ? "NULL" : "NOT NULL");

            // إعداد الأزرار
            btnSave.Image = Properties.Resources.icons8_save_48;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;

            btnClose.Image = Properties.Resources.icons8_close_48;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;

            // تعبئة الدول
            FillCountryComboBox();

            // حالة الإضافة
            if (_PersonID == -1)
            {
                _Person = new clsPeople();   // إنشاء كائن جديد
                lblAddress.Text = "Add New Person";
                return; // لا نكمل تحميل بيانات
            }

            // حالة التعديل
            if (GetPersonInfo())
            {
                lblPersonID.Text = _PersonID.ToString();
                ucPersonInfo1.LoadPersonInfo(_PersonID);
                //ucPersonInfo1.FirstName = _Person.FirstName;
                //ucPersonInfo1.SecondName = _Person.SecondName;
                //ucPersonInfo1.ThirdName = _Person.ThirdName;
                //ucPersonInfo1.LastName = _Person.LastName;
                //ucPersonInfo1.NationalNUmber = _Person.NationalNumber;
                //ucPersonInfo1.DateOfBirth = _Person.DateOfBirth;
                //ucPersonInfo1.Gendor = _Person.Gendor;
                //ucPersonInfo1.Phone = _Person.Phone;
                //ucPersonInfo1.Email = _Person.Email;
                //ucPersonInfo1.CountryID = _Person.CountryID;
                //ucPersonInfo1.Address = _Person.Address;
                //ucPersonInfo1.ImagePath = _Person.ImagePath;
            }
        }

        private bool GetUCInfo()
        {
            // حماية من أي خطأ غير متوقع
            if (ucPersonInfo1 == null)
            {
                MessageBox.Show("حدث خطأ: لم يتم تحميل بيانات الشخص.");
                return false;
            }

            // حماية من أن يكون _Person غير مهيأ (احتياط إضافي)
            if (_Person == null)
                _Person = new clsPeople();

            // نقل البيانات من الـ UserControl إلى الكائن
            _Person.FirstName = ucPersonInfo1.GetPersonInfo.FirstName;
            _Person.SecondName = ucPersonInfo1.GetPersonInfo.SecondName;
            _Person.ThirdName = ucPersonInfo1.GetPersonInfo.ThirdName;
            _Person.LastName = ucPersonInfo1.GetPersonInfo.LastName;
            _Person.NationalNumber = ucPersonInfo1.GetPersonInfo.NationalNumber;
            _Person.DateOfBirth = ucPersonInfo1.GetPersonInfo.DateOfBirth;
            _Person.Gendor = ucPersonInfo1.GetPersonInfo.Gendor;
            _Person.Phone = ucPersonInfo1.GetPersonInfo.Phone;
            _Person.Email = ucPersonInfo1.GetPersonInfo.Email;
            _Person.CountryID = ucPersonInfo1.GetPersonInfo.CountryID;
            _Person.Address = ucPersonInfo1.GetPersonInfo.Address;
            _Person.ImagePath = ucPersonInfo1.GetPersonInfo.ImagePath;

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1) اجلب البيانات من الـ UserControl
            if (!GetUCInfo())
                return;

            // 2) نفّذ عملية الإدخال أو التعديل
            _Person.Save();
            
            

            // 3) تحقق من نجاح العملية
            if (_Person.ID != -1)
            {
                lblPersonID.Text = _Person.ID.ToString();
                MessageBox.Show("تم الحفظ بنجاح");
                RefreshPersonIDEvent?.Invoke(this, _Person.ID); // إشعار النافذة الرئيسية
                this.Close();
            }
        }

    }
}
