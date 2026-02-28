using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using IbrahimDVLDCommonLayer;
using System.Drawing.Text;


namespace IbrahimDVLD
{

    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            label1.Text = @"    Welcom to" + Environment.NewLine +
                           "Driver And Vehicle" + Environment.NewLine +
                           "License Department" + Environment.NewLine +
                           "    DVLD System" + Environment.NewLine +
                           "    Vresion 1.0";
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
           _LoadUserNameIfExist();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void _SaveUserNameIfChecked(string UserName,string Password)
        {
          
            Properties.Settings.Default.SaveUserAndPass=true;
            
            string folder = "C:\\Users\\kozy\\source\\repos\\IbrahimDVLD\\UsersNameAndPassword";

            // إنشاء المجلد إذا لم يكن موجودًا
            Directory.CreateDirectory(folder);

            // اسم الملف (الأفضل عدم وضع كلمة المرور في اسم الملف)
            string fileName = UserName + ".txt";

            // دمج المسار مع اسم الملف بطريقة آمنة
            string path = Path.Combine(folder, fileName);
            Properties.Settings.Default.Path = path;
            Properties.Settings.Default.Save();
            // محتوى الملف
            string content = UserName + "###" + Password;

            
                File.WriteAllText(path, content);

           

        }

        private void _LoadUserNameIfExist()
        {
            if (Properties.Settings.Default.SaveUserAndPass)
            {
                string[] UserNameAndPassword = File.ReadAllText(Properties.Settings.Default.Path).Split(new string[] { "###" }, StringSplitOptions.None);
                txtUserName.Text = UserNameAndPassword[0];
                    txtPassword.Text = UserNameAndPassword[1];
                    chkRememberMe.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           

            if (IbrahimDVLDBusinessLayer.clsUsers.IsUserExist(txtUserName.Text, txtPassword.Text))
            {
                MessageBox.Show("البيانات صحيحة");
                if(!IbrahimDVLDBusinessLayer.clsUsers.isUserActive(txtUserName.Text))
                {
                    MessageBox.Show("المستخدم غير نشط , يرجى التواصل مع مدير النظام");
                    return;
                }
                this.Hide();
                if (chkRememberMe.Checked)
                {
                    _SaveUserNameIfChecked(txtUserName.Text,txtPassword.Text);
                }
                else
                {
                    _SaveUserNameIfChecked(string.Empty, string.Empty);
                }
                MainForm frmMain = new MainForm();
                frmMain.Show();
            }
            else
            {
                MessageBox.Show("البيانات خاطئة ,  يرجى اعادة الادخال");
                txtUserName.Clear();
                txtPassword.Clear();
                txtUserName.Focus();

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
