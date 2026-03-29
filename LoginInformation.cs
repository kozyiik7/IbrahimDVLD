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
    public partial class LoginInformation : UserControl
    {
        private int _PersonID = -1;



        public int PersonID
        {
            get { return _PersonID; }
            set { _PersonID = value; }
        }


        public int UserID { get => Convert.ToInt32(lblUserID.Text); set => lblUserID.Text = value.ToString(); }
        public string UserName { get => lblUserName.Text; set => lblUserName.Text = value; }
        public bool IsActive { get => lblIsActive.Text=="active"?true:false; set => lblIsActive.Text=value ? "Active" : "Inactive";  }
        public LoginInformation()
        {
            InitializeComponent();
        }

        private void gbLoginInfo_Enter(object sender, EventArgs e)
        {

        }

        private void LoginInformation_Load(object sender, EventArgs e)
        {
            if (PersonID != -1)
            {
                if (clsUsers.GetUserInfoByPersonID(PersonID) != null)
                {
                    clsUsers userInfo = clsUsers.GetUserInfoByPersonID(PersonID);
                    UserID = userInfo.UserID;
                    UserName = userInfo.UserName;
                    IsActive = userInfo.isActive ;
                }
            }
        }
        public void refreshLoginInfo()
        {
            LoginInformation_Load(this, new EventArgs());
            //if (PersonID != -1)
            //{
            //    if (clsUsers.GetUserInfoByPersonID(PersonID) != null)
            //    {
            //        clsUsers userInfo = clsUsers.GetUserInfoByPersonID(PersonID);
            //        UserID = userInfo.UserID;
            //        UserName = userInfo.UserName;
            //        IsActive = userInfo.isActive ? "Active" : "Inactive";
            //    }
            //}
        }
    }
}
