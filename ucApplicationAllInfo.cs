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
    public partial class ucApplicationAllInfo : UserControl
    {
        private int _AppID;
        public int AppID { 
            get=>_AppID;
            set 
            {
                _AppID = value;
                SendAppIDToChildControls();
            
            }
        }
        public ucApplicationAllInfo()
        {
            InitializeComponent();
        }
        public ucApplicationAllInfo(int AppID)
        {
            InitializeComponent();
           _AppID = AppID;
        }
       
        private void ucApplicationAllInfo_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            
        }
       private void SendAppIDToChildControls()
        {
            ucApplicationBasicInfo1.ApplicationID = _AppID;
            ucDrivingLicenseApplicationInfo1.DLAppID = _AppID;
        }
    }
}
