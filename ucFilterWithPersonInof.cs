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
    public partial class ucFilterWithPersonInof : UserControl
    {
        public int PersonID
        {
            get=>ucFilter1.PersonID;
            set=>ucFilter1.PersonID = value;
        }
            
        public delegate void ucFilterWithPersonInofDelegate(object sender, int PersonIDval);
        public event ucFilterWithPersonInofDelegate OnPersonID;

        public bool EnableucFilter 
        {
            get=>ucFilter1.Enabled;
            set=>ucFilter1.Enabled = value;
        }
        public ucFilterWithPersonInof()
        {
            InitializeComponent();
        }
      public void GetPersonIDFromFilter(object sender, int PersonIDval)
        {
           PersonID = PersonIDval;
            ucPersonInfoShow1.PersonIDValue = PersonID;
            ucPersonInfoShow1.refreshPersonInfo();
            OnPersonID?.Invoke(this, PersonID);
        }
        private void ucFilterWithPersonInof_Load(object sender, EventArgs e)
        {
            ucFilter1.OnPersonID += GetPersonIDFromFilter;
        }
    }
}
