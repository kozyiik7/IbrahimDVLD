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
        // public string FullName { get; set; }
        public string UserName { get; set; }
        public bool isActive { get; set; }
        public string Password { get; set; }

        public static DataTable GetAllUsers()
        {

            return IbrahimDVLDDataAccessLayer.clsUsers.GetAllUsers();

        }

        public static bool IsUserExist(string userName, string password)
        {
            return IbrahimDVLDDataAccessLayer.clsUsers.IsUserExist(userName, password);
        }
        public static bool IsUserNameExist(string userName)
        {
            return IbrahimDVLDDataAccessLayer.clsUsers.IsUserNameExist(userName);
        }
        public static bool isUserActive(string UserName)
        {
            return IbrahimDVLDDataAccessLayer.clsUsers.isUserActive(UserName);
        }
        public static bool isPersonIDAlreadyHaveUser(int PersonID)
        {
            return IbrahimDVLDDataAccessLayer.clsUsers.IsPersonIDAlreadyUser(PersonID);
        }
        public static int AddNewUser(int PersonID, string UserName, string Password, bool isActive)
        {
            return IbrahimDVLDDataAccessLayer.clsUsers.AddUser(PersonID, UserName, Password, isActive);
        }
        public static clsUsers GetUserInfoByPersonID(int PersonID)
        {
            clsUsers user = new clsUsers();
            int UserID = 0;
            string UserName = string.Empty;
            string Password = string.Empty;
            bool isActive = false;
            if (IbrahimDVLDDataAccessLayer.clsUsers.getuserInfoByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref isActive))
            {

                user.UserID = UserID;
                user.PersonID = PersonID;
                user.UserName = UserName;
                user.isActive = isActive;
                user.Password = Password;
            }
            return user;
        }
        public  bool UpdateUserInfo(int PersonID, string UserName, string Password, bool isActive)
        {
            return IbrahimDVLDDataAccessLayer.clsUsers.UpdateUser(PersonID, UserName, Password, isActive);
        }
         public bool DeleteUser(int PersonID)
        {     return IbrahimDVLDDataAccessLayer.clsUsers.DeleteUser(PersonID); }

        public static int GetPersonIDByUserName(string UserName)
        {
            return IbrahimDVLDDataAccessLayer.clsUsers.getPersonIdByUserName(UserName);
        }
        public static clsUsers GetUserInfoByUserID(int UserID)
        {
            DataRow dr =IbrahimDVLDDataAccessLayer.clsUsers.GetUserInfoByUserID(UserID);
            if (dr != null)
            {
                clsUsers user = new clsUsers();
                user.UserID = UserID;
                user.PersonID = Convert.ToInt32(dr["PersonID"]);
                user.UserName = dr["UserName"].ToString();
                user.isActive = Convert.ToBoolean(dr["IsActive"]);
                user.Password = dr["Password"].ToString();
                return user;

            }
            else
            {
                return null;
            }
        }
    }
}
