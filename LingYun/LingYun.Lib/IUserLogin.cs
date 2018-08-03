using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LingYun.Data;

namespace LingYun.Lib
{
   public interface IUserLogin
    {
       /// <summary>
       /// web端登录
       /// </summary>
       /// <param name="username"></param>
       /// <param name="encodePsd"></param>
       /// <returns></returns>
         Msg Login(string username, string encodePsd);
        /// <summary>
        /// 安卓端用户首次登录验证
        /// </summary>
        /// <param name="username"></param>
        /// <param name="encodePsd"></param>
        /// <returns></returns>
         Msg Login(string username, string encodePsd, string Imei);
       /// <summary>
        /// 安卓端用户登录验证
        /// </summary>
        /// <param name="username"></param>
        /// <param name="encodePsd"></param>
        /// <returns></returns>
         Msg Login(string Imei);
    }
}
