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

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string folder = "C:\\Users\\kozy\\source\\repos\\IbrahimDVLD\\UsersNameAndPassword";

            //// إنشاء المجلد إذا لم يكن موجودًا
            //Directory.CreateDirectory(folder);

            //// اسم الملف (الأفضل عدم وضع كلمة المرور في اسم الملف)
            //string fileName = txtUserName.Text + ".txt";

            //// دمج المسار مع اسم الملف بطريقة آمنة
            //string path = Path.Combine(folder, fileName);

            //// محتوى الملف
            //string content = txtUserName.Text + "###" + clsCommonLayer.HashPassword(txtPassword.Text);

            //if (!string.IsNullOrEmpty(txtUserName.Text) &&
            //    !string.IsNullOrEmpty(txtPassword.Text) &&
            //    chkRememberMe.Checked)
            //{
            //    File.WriteAllText(path, content);
            //    MessageBox.Show("True");
            //}


            string folder = "C:\\Users\\kozy\\source\\repos\\IbrahimDVLD\\UsersNameAndPassword";
            String fileName = txtUserName.Text + ".txt";
            string path = Path.Combine(folder, fileName);
            if (File.Exists(path))
            {
                string[] UserNameAndPassword = File.ReadAllText(path).Split(new string[] { "###" }, StringSplitOptions.None);


                if (UserNameAndPassword[0] == txtUserName.Text && UserNameAndPassword[1] == clsCommonLayer.HashPassword(txtPassword.Text))
                {
                    MessageBox.Show("البيانات صحيحة");
                    this.Hide();
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
            else
            {
                MessageBox.Show("المستخدم غير موجود");
            }
        }
    }
}
