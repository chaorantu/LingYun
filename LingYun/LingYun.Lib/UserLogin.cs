using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LingYun.Data;
using LingYun.Business;

namespace LingYun.Lib
{
   public class UserLogin:IUserLogin
    {
        public Msg Login(string username, string encodePsd)
        {
            return UserLoginBiz.Login(username, encodePsd);
        }

        public Msg Login(string username, string encodePsd, string Imei)
        {
            return UserLoginBiz.Login(username, encodePsd, Imei);
        }

        public Msg Login(string Imei)
        {
            return UserLoginBiz.Login(Imei);
        }
    }
}
