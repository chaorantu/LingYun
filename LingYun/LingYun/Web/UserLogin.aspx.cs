using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using LingYun.Common;
using LingYun.Helper.Web;
using LingYun.Data;
using LingYun.LingYunService;


namespace LingYun.Web
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
                LingYunServiceSoapClient service = new LingYunServiceSoapClient();
              
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string result = service.Login(username, psd);
                Msg msg = jss.Deserialize<Msg>(result);
               

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