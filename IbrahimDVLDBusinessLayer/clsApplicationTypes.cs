using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDBusinessLayer
{
    public class clsApplicationTypes
    {

         public static DataTable GetApplicationTypes()
        {
            return IbrahimDVLDDataAccessLayer.clsApplicationTypes.GetApplicationTypes();
        }
        public static bool update( int ApplicationTypeID, string ApplicationTypeTitle, float ApplicationFees)
        {
            return IbrahimDVLDDataAccessLayer.clsApplicationTypes.UpdateApplicationTypes(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
        }
            
    }
}
