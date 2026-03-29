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
    public partial class frmShowUserDetails : Form
    {
        private int _PersonID = -1;
        private clsUsers User = new clsUsers();
        public frmShowUserDetails()
        {
            InitializeComponent();
        }
        public frmShowUserDetails(int PersonID)
        {
            _PersonID = PersonID;
            InitializeComponent();
            ucPersonInfoShow1.PersonIDValue = _PersonID;
            loginInformation1.PersonID = _PersonID;
            User = clsUsers.GetUserInfoByPersonID(_PersonID);
        }

        private void frmShowUserDetails_Load(object sender, EventArgs e)
        {

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
