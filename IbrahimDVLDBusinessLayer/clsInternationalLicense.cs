using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDBusinessLayer
{
    public class clsInternationalLicense
    {
        public static DataTable GetInternationalLicenseHistoryByPersonID(int PersonID)
        {
            return IbrahimDVLDDataAccessLayer.clsInternationalLicenses.GetInternationalLicenseHistoryByPersonID(PersonID);
        }
    }
}
