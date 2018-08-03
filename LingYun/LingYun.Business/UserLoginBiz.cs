using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LingYun.Data;
using LingYun.Common;
using LingYun.Data.Enum;
using LingYun.Dal;
using System.Data.SqlClient;
using System.Data.EntityClient;

namespace LingYun.Business
{
    public class UserLoginBiz
    {
     
    

        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="username"></param>
        /// <param name="encodePsd"></param>
        /// <returns></returns>
        public static Msg Login(string username, string encodePsd)
        {
            Msg loginMsg = null;
            Tbl_User user = null;
            UserInfo userinfo = null;
           
           try{
               using (var en = new LingYunEntities(DBConnect.DataBaseConnectionString()))
            {
                
                    user = en.Tbl_User.Where(a => a.Name == username).FirstOrDefault();
                    if (user != null)
                    {
                        if (user.LoginPwd1.Equals(encodePsd))//管理员密码登录
                        {
                            userinfo = new UserInfo();
                            userinfo.Id = user.ID;
                            userinfo.UserName = user.Name;
                            userinfo.Identify = user.Access;
                            userinfo.Type = (int)LoginType.主管密码;
                            userinfo.Psd = user.LoginPwd1;
                            loginMsg = new Msg(true) { UserData = userinfo };
                        }
                        else if (user.CheckPwd.Equals(encodePsd))//确认密码登录
                        {
                            userinfo = new UserInfo();
                            userinfo.Id = user.ID;
                            userinfo.UserName = user.Name;
                            userinfo.Identify = user.Access;
                            userinfo.Type = (int)LoginType.确认密码;
                            userinfo.Psd = user.CheckPwd;
                            loginMsg = new Msg(true) { UserData = userinfo };
                        }
                        else
                        {
                            loginMsg = new Msg(false) { Message = "用户名或密码错误" };
                        }


                    }
                    else
                    {
                        loginMsg = new Msg(false) { Message = "当前系统不存在您的信息" };
                    }
                }


           }
           catch (Exception ex)
           {
               loginMsg = new Msg(false) { Message = ex.Message };
           }
            
        
            return loginMsg;
        }

      
        /// <summary>
        /// 安卓端用户首次登录验证
        /// </summary>
        /// <param name="username"></param>
        /// <param name="encodePsd"></param>
        /// <returns></returns>
        public static Msg Login(string username, string encodePsd, string Imei)
        {
            Msg loginMsg = new Msg();
            Tbl_User userInfo = new Tbl_User(); ;
            try
            {
                using (var en = new LingYunEntities())
                {
                    
                        Tbl_User Users = en.Tbl_User.Where(b => b.Name == username&&b.CheckPwd==encodePsd).FirstOrDefault();
                        if (Users != null)
                        {
                            if (Users.CheckPwd == encodePsd)
                            {
                                Users.APP = Imei;
                                en.SaveChanges();
                                loginMsg = new Msg(true) { UserData = Users };
                            }
                            else
                            {
                                loginMsg = new Msg { Message = "error:用户名或密码不正确" };
                            }


                        }
                        else
                        {
                            loginMsg = new Msg { Message = "error:用户名不存在" };
                        }
                    

                   
                }
            }
            catch (Exception ex)
            {
                loginMsg = new Msg { Message = ex.Message };
            }
            return loginMsg;

        }

        /// <summary>
        /// 安卓端用户登录验证
        /// </summary>
        /// <param name="username"></param>
        /// <param name="encodePsd"></param>
        /// <returns></returns>
        public static Msg Login(string Imei)
        {
            Msg loginMsg = new Msg();
            List<Tbl_User> userInfo=null;
            try
            {

                using (var en = new LingYunEntities())
                {
                   userInfo=en.Tbl_User.Where(a => a.APP == Imei).ToList();
                   if (userInfo != null&&userInfo.Count>0)
                   {
                       loginMsg = new Msg(true) { UserData=userInfo};

                   }
                   else
                   {
                       loginMsg = new Msg() { Status = false, Message ="请先登录" };
                   }
                }
            }
            catch (Exception ex)
            {
                loginMsg = new Msg { Message = ex.Message };
            }
            return loginMsg;

        }

        

      
    }
}