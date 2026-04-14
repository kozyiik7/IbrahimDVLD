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
    public partial class frmUpdateTestType : Form
    {

        public int TestTypeID { get=>Convert.ToInt32(lblID.Text); set=>lblID.Text=value.ToString(); }
        public string TestTypeName { get=>txtTitle.Text; set=> txtTitle.Text=value; }
        public string TestTypeDescription { get=>txtDescription.Text; set=> txtDescription.Text=value; }
        public float TestTypeFeesAmount { get=>Convert.ToSingle(txtFees.Text); set=> txtFees.Text=value.ToString(); }
        public frmUpdateTestType()
        {
            InitializeComponent();
        }
        public frmUpdateTestType(int id, string name, string description, float fees) 
        {
           InitializeComponent();
            TestTypeID = id;
            TestTypeName = name;
            TestTypeDescription = description;
            TestTypeFeesAmount = fees;
            FillDate();
        }
        private void FillDate()
        {
            lblID.Text = TestTypeID.ToString();
            txtTitle.Text = TestTypeName;
            txtDescription.Text = TestTypeDescription;
            txtFees.Text = TestTypeFeesAmount.ToString();
        }
        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("Test Type Name cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitle.Focus();
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
                {
                MessageBox.Show("Test Type Description cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescription.Focus();
                }

            
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '.')
            {
                if (e.KeyChar == '.' && txtFees.Text.Contains('.'))
                {
                    e.Handled = true; // Prevent multiple decimal points
                }
            }
            else
            {
                e.Handled = true; // Prevent non-numeric input
            }
        }
    }
}
