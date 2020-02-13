using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop2.Common
{
    [Serializable]
    public class UserLogin
    {
       
        public long UserID { set; get; }
        public String UserName { set; get; }

    }
}