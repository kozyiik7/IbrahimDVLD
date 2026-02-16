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
    public partial class frmPersonDetails : Form
    {
        private int _PersonID;
        clsPeople _Person=new clsPeople();
        public frmPersonDetails()
        {
            InitializeComponent();
        }
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            ucPersonInfoShow._PersonID = _PersonID;

        }
        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
          
            if (ucPersonInfoShow.imagePath == ""||ucPersonInfoShow.imagePath==string.Empty)
            {

                ucPersonInfoShow.setImage=(ucPersonInfoShow.Gendor=="Male"? imageList1.Images[0]: imageList1.Images[0]);
               
            }
            btnClose.Image = Properties.Resources.icons8_close_48;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.TextAlign = ContentAlignment.MiddleRight;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
