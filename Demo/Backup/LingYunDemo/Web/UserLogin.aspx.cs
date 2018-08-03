using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Common;
using LingYunDemo.Helper.Web;
using LingYunDemo.Helper.Security;
using LingYunDemo.Data;
using LingYunDemo.Model;
using System.Web.Services;
using System.Web.Script.Serialization;
using LingYunDemo.Dal;

namespace LingYunDemo.Web
{
    public partial class UserLogin : BasePage
    {
        protected override void OnInit(EventArgs e)
        {
            this.ValidateUserLoginState = false;
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.CurrentUserInfo != null)
            {
                this.Response.Redirect("index.aspx");
            }

        }
        [WebMethod]
        public static string CheckUser(string username)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();

            Boolean haveUser = UserLoginModel.CheckUser(username);
            return jss.Serialize(haveUser);
        }

  

        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            string username = TxtUserName.Value.Trim();
            string psd = TxtPassword.Value.Trim();
            if (string.IsNullOrWhiteSpace(username))
            {
                PageHelper.ShowAlertMsg(this, "用户名不能为空");

            }
            else if (string.IsNullOrWhiteSpace(psd))
            {

                PageHelper.ShowAlertMsg(this, "用户名不能为空");
            }
            else
            {
                string encodePsd = Md5Helper.GetMD5Hash(psd);
                Msg msg = UserLoginModel.Login(username, psd);

                if (msg.Status)
                {
                    UserInfo myInfo = msg.UserData as UserInfo;
                    this.SetUserInfo(myInfo);//设置会话session
                    this.Response.Redirect("index.aspx");
                }
                else
                {
                    PageHelper.ShowAlertMsg(this, msg.Message);
                }
            }
        }
    }
}