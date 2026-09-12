using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Diagnostics;


namespace IbrahimDVLDCommonLayer
{
    public class clsCommonLayer
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


        public static bool SaveUserNameAndPasswoordInRegistry(string UserName, string Password)
        {
            try
            {
                // Hash the password before saving
               // string hashedPassword = clsCommonLayer.HashPassword(Password);
                // Save the username and hashed password in the registry
                string RegistryPath = @"HKEY_CURRENT_USER\SOFTWARE\IbrahimDVLD";
                
                string UserNameKey = "Username";
                string PasswordKey = "Password";
                Registry.SetValue(RegistryPath, UserNameKey, UserName,RegistryValueKind.String);
                Registry.SetValue(RegistryPath, PasswordKey, Password, RegistryValueKind.String);
                
                return true;
                
            }
            catch (Exception ex)
            {
                 IbrahimDVLDCommonLayer.clsCommonLayer.EventLogInformation("Error in SaveUserNameAndPasswoordInRegistry: " + ex.Message);
                return false;
            }
        }
        public static bool EventLogInformation(string message)
        {
            try
            {
                EventLog.WriteEntry("IbrahimDVLD", message, EventLogEntryType.Information);
                return true;
            }
            catch (Exception ex)
            {
               
               throw ex;
            }
           
        }
    }
}
    

