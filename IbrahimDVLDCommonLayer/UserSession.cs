using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IbrahimDVLDCommonLayer
{
    public sealed class UserSession
    {
        private static readonly Lazy<UserSession> _instance =
            new Lazy<UserSession>(() => new UserSession());
        
        public static UserSession Instance => _instance.Value;

        public int UserID { get; set; }
        public int PersonID { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public bool IsActive { get; private set; }


        private UserSession() { }

        public void SetUser(int personId, string userName,int Userid,string password,bool isactive)
        {
            PersonID = personId;
            UserName = userName;
            Password = password;
            UserID = Userid;
            IsActive = isactive;
        }

        public void Clear()
        {
            PersonID = 0;
            UserName = string.Empty;
            UserID= 0;
            Password = string.Empty;
            IsActive= false;
        }
    }

}
