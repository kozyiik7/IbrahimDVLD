using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbrahimDVLDBusinessLayer
{
    public class clsUsers
    {
        public clsUsers() { }
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public bool isActive { get; set; }
        
        public static DataTable GetAllUsers()
        {
            
                return IbrahimDVLDDataAccessLayer.clsUsers.GetAllUsers();
            
        }

        public static bool IsUserExist(string userName, string password)
        {
            return IbrahimDVLDDataAccessLayer.clsUsers.IsUserExist(userName, password);
        }

        public static bool isUserActive(string UserName)
        {
            return IbrahimDVLDDataAccessLayer.clsUsers.isUserActive(UserName);
        }
    }
}
