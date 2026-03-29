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

        public int PersonID { get; private set; }
        public string UserName { get; private set; }

        private UserSession() { }

        public void SetUser(int personId, string userName)
        {
            PersonID = personId;
            UserName = userName;
        }

        public void Clear()
        {
            PersonID = 0;
            UserName = null;
        }
    }

}
