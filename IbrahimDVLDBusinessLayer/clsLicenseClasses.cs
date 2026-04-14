using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDBusinessLayer
{
    public class clsLicenseClasses
    {
        public static DataTable GetAllLicenseClasses()
        {
            return IbrahimDVLDDataAccessLayer.clsLicenseClasses.GetAllLicenseClasses();
        }
        public static int GetLicenseClassIDFromClassName(string ClassName)
        {
            return IbrahimDVLDDataAccessLayer.clsLicenseClasses.GetLicenseClassIDFromClassName(ClassName);
        }
    }
}
