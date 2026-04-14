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
            int Counter= 0;
            foreach (DataColumn column in dt.Columns)
            {
                if(Counter<2)
                {
                    Counter++;
                    cmbFindBy.Items.Add(column.ColumnName);
                }
                else
                {
                    break;
                }

            }

        }


        private void ucFilter_Load(object sender, EventArgs e)
        {
            FillComboboxWithItems();
            cmbFindBy.SelectedIndex = 0;
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            //string NationalNo=string.Empty;
           
            switch(cmbFindBy.SelectedItem.ToString())
            {
               
                case "NationalNo":
                    if (txtFindBy.Text != string.Empty)
                    {
                        if (clsPeople.GetPersonIDByNationalNumber(txtFindBy.Text) != -1)
                        {
                            PersonID = clsPeople.GetPersonIDByNationalNumber(txtFindBy.Text);
                            //Invoke the event to send the PersonID to the parent form
                            OnPersonID?.Invoke(this, PersonID);
                        }
                        else
                        {
                            MessageBox.Show("no Person found with this National Number", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    break;
                case "PersonID":
                    if (txtFindBy.Text != string.Empty&&clsPeople.IsPersonIDExist(int.Parse(txtFindBy.Text)))
                    {
                        PersonID = Convert.ToInt32(txtFindBy.Text);
                        OnPersonID?.Invoke(this, PersonID);
                    }
                    break;
                default:
                    MessageBox.Show("Please select a valid filter criteria", "Invalid Filter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
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

        private void txtFindBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cmbFindBy.SelectedItem.ToString()=="PersonID")
            {
                // Allow only digits and control characters (like backspace)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Ignore the input
                }
            }
        }
    }
}
