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
        public int UserID { get=>Convert.ToInt32( lblUserID.Text); set=>lblUserID.Text=value.ToString(); }
        public LoginInformation()
        {
            InitializeComponent();
        }

        private void gbLoginInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}
