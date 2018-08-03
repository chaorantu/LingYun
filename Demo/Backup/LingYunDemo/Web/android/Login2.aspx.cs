using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Model;
using LingYunDemo.Data;
using System.Web.Script.Serialization;
using LingYunDemo.Dal;

namespace LingYunDemo.Web.android
{
    public partial class Login2 : System.Web.UI.Page
    {
        public class LoginRet
        {
            public string UserName { get; set; }
            public int Identify { get; set; }
            public int Status { get; set; }
            public string Message { get; set; }
        } 
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = this.Request["username"];
            string psd = this.Request["psd"];
            string imei = this.Request["imei"];
          
            Msg msg = UserLoginModel.Login(username, psd, imei);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            if (msg.Status)
            {
                Tbl_User oUser = msg.UserData as Tbl_User;
                LoginRet loginRet = new LoginRet();
                loginRet.Identify = oUser.Access;
                loginRet.UserName = oUser.Name;
                loginRet.Status = 1;
                this.Response.Write(jss.Serialize(loginRet));
             
            }
            else
            {
                LoginRet loginRet = new LoginRet();
                loginRet.Message = msg.Message;
                loginRet.Status = 0;
                this.Response.Write(jss.Serialize(loginRet));
              
            }
        }
    }
}