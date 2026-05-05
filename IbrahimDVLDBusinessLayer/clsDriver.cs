using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDBusinessLayer
{
    public class clsDriver
    {

        public int DriverID {  get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID {  get; set; }
        public DateTime CreatedDate { get; set; }

        public clsDriver()
        {
            DriverID = 0;
            PersonID = 0;
            CreatedByUserID = 0;
            CreatedDate = DateTime.MinValue;
        }

        public int Create()
        {
            DriverID = IbrahimDVLDDataAccessLayer.clsDriver.CreateNewDriver(PersonID, CreatedByUserID, CreatedDate);
            return DriverID;
        }
        public static bool IsDriverExistByPersonID(int PersonID)
        {
            return IbrahimDVLDDataAccessLayer.clsDriver.IsDriverExistByPersonID(PersonID);
        }

        public static int GetDriverIDByPersonID(int PersonID)
        {
            return IbrahimDVLDDataAccessLayer.clsDriver.GetDriverIDByPersonID(PersonID);
        }
        public static DataTable GetAllDrivers()
        {
            return IbrahimDVLDDataAccessLayer.clsDriver.GetAllDrivers();
        }

        public static clsDriver Read(int DriverID)
        {
            DataRow Dr = IbrahimDVLDDataAccessLayer.clsDriver.GetDriverInfoByDriverID(DriverID);
            if (Dr != null)
            {
                clsDriver MyDriver = new clsDriver();
                MyDriver.DriverID = (int)Dr["DriverID"];
                MyDriver.PersonID = (int)Dr["PersonID"];
                MyDriver.CreatedByUserID = (int)Dr["CreatedByUserID"];
                MyDriver.CreatedDate = (DateTime)Dr["CreatedDate"];
                return MyDriver;
            }
            else
                return null;
        }
    }
}
