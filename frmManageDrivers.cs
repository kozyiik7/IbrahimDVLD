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
    public partial class frmManageDrivers : Form
    {
        public enum enSearchType { text, Numbers }
        public enSearchType SearchType = enSearchType.text;
        BindingSource bindingSource=new BindingSource();
        public frmManageDrivers()
        {
            InitializeComponent();
        }

        private void PrepareDataGridViewData()
        {
            bindingSource.DataSource = clsDriver.GetAllDrivers();
            dgvDrivers.DataSource = bindingSource;
            dgvDrivers.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FillCmbFilterData()
        {
            int i = 0;
            cmbFilter.Items.Add("None");
            foreach (DataGridViewColumn Column in dgvDrivers.Columns)
            {
                if (i == 4)
                    return;

                cmbFilter.Items.Add(Column.HeaderText);
                i++;

            }

        }
        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            PrepareDataGridViewData();
            FillCmbFilterData();
            cmbFilter.SelectedIndex = 0;
            txtFilter.Visible = false;
            lblRecords.Text = "#Records :" + dgvDrivers.RowCount;
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbFilter.SelectedIndex)
            {
                case 0:
                    txtFilter.Visible = false;
                    txtFilter.Text = string.Empty;
                    SearchType = enSearchType.Numbers;
                    lblRecords.Text = "#Records :" + dgvDrivers.RowCount;
                    break;
                case 1:
                case 2:
                    txtFilter.Visible = true;
                    txtFilter.Text = string.Empty;
                    SearchType = enSearchType.Numbers;
                    txtFilter.Focus();
                    lblRecords.Text = "#Records :" + dgvDrivers.RowCount;
                    break;
                default:
                    txtFilter.Visible = true;
                    txtFilter.Text = string.Empty;
                    SearchType = enSearchType.text;
                    txtFilter.Focus();
                    lblRecords.Text = "#Records :" + dgvDrivers.RowCount;
                    break;
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            switch (SearchType)
            {
                case enSearchType.Numbers:

                    if (string.IsNullOrEmpty(txtFilter.Text))
                    {
                        bindingSource.Filter = string.Empty;
                        return;
                    }
                    if (int.TryParse(txtFilter.Text, out int value))
                    {
                        bindingSource.Filter = $"[{cmbFilter.Text}]={value.ToString()}";
                        dgvDrivers.DataSource = bindingSource;
                        lblRecords.Text = "#Records :" + dgvDrivers.RowCount;
                    }
                    break;

                case enSearchType.text:
                    if (string.IsNullOrEmpty(txtFilter.Text))
                    {
                        bindingSource.Filter = string.Empty;
                        return;
                    }
                    bindingSource.Filter = $"[{cmbFilter.Text}] like '%{txtFilter.Text}%'";
                    dgvDrivers.DataSource = bindingSource;
                    lblRecords.Text = "#Records :" + dgvDrivers.RowCount;
                    break;
                default:
                    break;
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (SearchType == enSearchType.Numbers)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;

                }

            }
        }
    }
}
