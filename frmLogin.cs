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
            string path = "C:\\Users\\user\\source\\repos\\IbrahimDVLD\\UsersNameAndPassword" + txtUserName.Text + txtPassword.Text + ".txt";
            string content = txtUserName.Text +"###"+ txtPassword.Text;
            if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                File.WriteAllText(path,content);
               
                MessageBox.Show("True");
            }
        }
    }
}
