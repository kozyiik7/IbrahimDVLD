using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDBusinessLayer
{
    public class clsDetainedLicenses
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }  //Allow Nullable if not released yet
        public int ReleasedByUserID { get; set; }   //Allow Nullable if not released yet
        public int ReleaseApplicationID { get; set; } //Allow Nullable if not released yet
        public clsDetainedLicenses()
        {
            DetainID = 0;
            LicenseID = 0;
            DetainDate = DateTime.Now;
            FineFees = 0;
            CreatedByUserID = 0;
            IsReleased = false;
            ReleaseDate = DateTime.Now;
            ReleasedByUserID = 0;
            ReleaseApplicationID = 0;


        }
    }
}
