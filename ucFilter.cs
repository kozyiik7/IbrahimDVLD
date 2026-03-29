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

        public string TextValue
        {
            get { return txtFindBy.Text; }
            set { txtFindBy.Text = value; }
        }
        public string FilterValue
            {
            get { return cmbFindBy.SelectedValue.ToString(); }
            set { cmbFindBy.Text= value; }
            }
        public int PersonIDValue
        {
            get { return PersonID; }
            set { PersonID = value; }
        }
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
                if ( clsPeople.GetPersonIDByNationalNumber(txtFindBy.Text) != -1)
                { 
                    PersonID = clsPeople.GetPersonIDByNationalNumber(txtFindBy.Text);
                //Invoke the event to send the PersonID to the parent form
                OnPersonID?.Invoke(this, PersonID);
                }
                else                {
                    MessageBox.Show("no Person found with this National Number", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           

            
          
        }


        private void gbFilter_Enter(object sender, EventArgs e)
        {

        }
        public void recievePersonIDFromAddNewPerson(object sender, int PersonID)
        {
            this.PersonID = PersonID;
            if (this.PersonID != -1)
            {
                OnPersonID?.Invoke(this, this.PersonID);
            }
        }
        private void pbAddNewPerson_Click(object sender, EventArgs e)
        {
            FrmAddEditPersonInfo addEditPersonInfo = new FrmAddEditPersonInfo(-1);
            addEditPersonInfo.RefreshPersonIDEvent += recievePersonIDFromAddNewPerson;
            addEditPersonInfo.ShowDialog();
        }
    }
}
