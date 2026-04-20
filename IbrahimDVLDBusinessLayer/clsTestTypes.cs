using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDBusinessLayer
{
    public class clsTestTypes
    {



        public static DataTable GetTestTypes()
        {
            return IbrahimDVLDDataAccessLayer.clsTestTypes.GetTestTypes();
        }
        public static bool Update(int TestTypeID, string TestTypeTitle, string TestTypeDescription, float TestTypeFees)
        {
            return IbrahimDVLDDataAccessLayer.clsTestTypes.UpdateTestTypes(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
        }
        public static int GetTestTypeIDByTestTypeTitle(string TestTypeTitle)
        {
            return IbrahimDVLDDataAccessLayer.clsTestTypes.GetTestTypeIDFromTestTypeTitle(TestTypeTitle);
        }
    }
}
