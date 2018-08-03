using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LingYun.Common
{
    public class BasePage : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {

            base.OnInit(e);
            if (ValidateUserLoginState && CurrentUserInfo == null)
            {
               
                    //不存在用户信息，导向到登录页面
                    Response.Redirect("UserLogin.aspx?Fr=" + this.Page.Request.Url);
             
            }
        }
        /// <summary>
        /// 设置当前用户信息
        /// </summary>
        /// <param name="curUser"></param>
        public void SetUserInfo(UserInfo curUser)
        {

            Session["UserInfo"] = curUser;
        }

        /// <summary>
        /// 设置当前用户信息
        /// </summary>
        /// <param name="curUser"></param>
        public static void SetUserInfo_Static(UserInfo curUser)
        {
            HttpContext.Current.Session["UserInfo"] = curUser;
        }

        /// <summary>
        /// 用户信息注销
        /// </summary>
        public void LogOut()
        {
            Session["UserInfo"] = null;
        }
        /// <summary>
        /// 当前登录用户信息
        /// </summary>
        public UserInfo CurrentUserInfo
        {
            get
            {
                UserInfo user = Session["UserInfo"] as UserInfo;
                return user;
            }

        }


        private bool bUserLoginState = true;

        /// <summary>
        /// 是否开启验证用户登录
        /// </summary>
        public bool ValidateUserLoginState
        {
            get
            {
                return bUserLoginState;
            }
            set
            {
                bUserLoginState = value;
            }

        }
    }
}