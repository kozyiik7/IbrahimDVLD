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
        public int PersonID;
        public delegate void ucFilterWithPersonInofDelegate(object sender, int PersonIDval);
        public event ucFilterWithPersonInofDelegate OnPersonID;
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
