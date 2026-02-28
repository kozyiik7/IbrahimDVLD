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
        public delegate void PersonIDToSend(object sender, int PersonID);
        public event PersonIDToSend OnPersonID;
        private void FillComboboxWithItems()
        {
            DataTable dt = clsPeople.GetAllPeople();
           foreach (DataColumn column in dt.Columns)
            {
                cmbFindBy.Items.Add(column.ColumnName);
            }
        }
     

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
                //Invoke the event to send the PersonID to the parent form
                OnPersonID?.Invoke(this, PersonID);
            }
            
          
        }


        private void gbFilter_Enter(object sender, EventArgs e)
        {

        }
    }
}
