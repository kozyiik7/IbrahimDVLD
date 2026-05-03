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

        public int LicenseClassID {  get; set; }
        public string ClassName { get; set; }
        public string ClassDescription {  get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength {  get; set; }
        public decimal ClassFees { get; set; }
        public clsLicenseClasses()
        {
            LicenseClassID= 0;
            ClassName=string.Empty;
            ClassDescription=string.Empty;
            MinimumAllowedAge=0;
            DefaultValidityLength = 0;
            ClassFees=0;
        }
        public static DataTable GetAllLicenseClasses()
        {
            return IbrahimDVLDDataAccessLayer.clsLicenseClasses.GetAllLicenseClasses();
        }
        public static int GetLicenseClassIDFromClassName(string ClassName)
        {
            return IbrahimDVLDDataAccessLayer.clsLicenseClasses.GetLicenseClassIDFromClassName(ClassName);
        }

        public static clsLicenseClasses GetLicenseClassDataByLicenseClassID(int LicenseClassID)
        {
            clsLicenseClasses GettingLicenseClassData = new clsLicenseClasses();
            DataTable LicensClassData=IbrahimDVLDDataAccessLayer.clsLicenseClasses.GetLicenseClassDataByLicenseClassID(LicenseClassID);
            if(LicensClassData == null)
                return null;
             DataRow LicenseClassDataRow=LicensClassData.Rows[0];
            GettingLicenseClassData.LicenseClassID = LicenseClassID;
            GettingLicenseClassData.ClassName = (string)LicenseClassDataRow["ClassName"];
            GettingLicenseClassData.ClassDescription = (string)LicenseClassDataRow["ClassDescription"];
            GettingLicenseClassData.MinimumAllowedAge = (byte)LicenseClassDataRow["MinimumAllowedAge"];
            GettingLicenseClassData.DefaultValidityLength = (byte)LicenseClassDataRow["DefaultValidityLength"];
            GettingLicenseClassData.ClassFees = (decimal)LicenseClassDataRow["ClassFees"];
            return GettingLicenseClassData;

        }
    }
}
