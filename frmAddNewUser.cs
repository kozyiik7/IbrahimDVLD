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
    public partial class frmAddNewUser : Form
    {
        public frmAddNewUser()
        {
            InitializeComponent();
            ucFilter1.OnPersonID += ucFilterValueToReceive;
        }
        private int _PersonID = -1;
         private void ucFilterValueToReceive(object sender, int PersonID)
        {
            _PersonID = PersonID;
            if (_PersonID != -1)
            {
               ucPersonInfoShow1.PersonIDValue = _PersonID;
               ucPersonInfoShow1.refreshPersonInfo();
            }

        }



        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            
        }
    }
}
