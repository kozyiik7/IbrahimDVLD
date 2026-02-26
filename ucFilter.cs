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
    public partial class ucFilter : UserControl
    {
       
       public int PersonID= -1;
        public ucFilter()
        {
            InitializeComponent();
        }
        private void FillComboboxWithItems()
        {
            DataTable dt = clsPeople.GetAllPeople();
           foreach (DataColumn column in dt.Columns)
            {
                cmbFindBy.Items.Add(column.ColumnName);
            }
        }
        public int NationalNumber { get { return Convert.ToInt32( txtFindBy.Text); } set { txtFindBy.Text =  value.ToString(); } }

        private void ucFilter_Load(object sender, EventArgs e)
        {
            FillComboboxWithItems();
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            string NationalNo=string.Empty;
            if (txtFindBy.Text != string.Empty)
            {
                if(clsPeople.GetPersonIDByNationalNumber(txtFindBy.Text)!=-1)
                PersonID = clsPeople.GetPersonIDByNationalNumber( txtFindBy.Text);
                
            }
        }


        private void gbFilter_Enter(object sender, EventArgs e)
        {

        }
    }
}
