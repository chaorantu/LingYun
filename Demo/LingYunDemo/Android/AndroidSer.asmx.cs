using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using LingYunDemo.Model;
using System.Web.Script.Serialization;
using LingYunDemo.Data;
using LingYunDemo.Dal;

namespace LingYunDemo.Android
{
    /// <summary>
    /// AndroidSer 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class AndroidSer : System.Web.Services.WebService
    {
        public class LoginRet
        {
            public string UserName { get; set; }
            public int Indetify { get; set; }
            public int Status { get; set; }
            public string Message { get; set; }
        }
        [WebMethod]
        public void Get()
        {
            this.Context.Response.ContentType = "text/plain";

            if (string.IsNullOrEmpty(this.Context.Request.QueryString["username"]))
            {

                string imei = this.Context.Request.QueryString["imei"];
                Msg msg = UserLoginModel.Login(imei);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                if (msg.Status)
                {
                    Tbl_User oUser = msg.UserData as Tbl_User;
                    LoginRet oLogin = new LoginRet();
                    oLogin.UserName = oUser.Name;
                    oLogin.Indetify = oUser.Access;
                    oLogin.Status = 1;
                    this.Context.Response.Write(jss.Serialize(oLogin));
                    this.Context.Response.Write("#");
                }
                else
                {
                    Tbl_User oUser = msg.UserData as Tbl_User;
                    LoginRet oLogin = new LoginRet();

                    oLogin.Status = 0;
                    this.Context.Response.Write(jss.Serialize(oLogin));
                    this.Context.Response.Write("#");
                }
            }
            else
            {
                string username = this.Context.Request.QueryString["username"];
                string psd = this.Context.Request.QueryString["psd"];
                string imei = this.Context.Request.QueryString["imei"];
                Msg msg = UserLoginModel.Login(username, psd, imei);
                JavaScriptSerializer jss = new JavaScriptSerializer();

                if (msg.Status)
                {

                    Tbl_User oUser = msg.UserData as Tbl_User;
                    LoginRet loginRet = new LoginRet();
                    loginRet.Indetify = oUser.Access;
                    loginRet.UserName = oUser.Name;
                    loginRet.Status = 1;
                    this.Context.Response.Write(jss.Serialize(loginRet));
                    this.Context.Response.Write("#");



                }
                else
                {

                    LoginRet loginRet = new LoginRet();
                    loginRet.Message = msg.Message;
                    loginRet.Status = 0;
                    this.Context.Response.Write(jss.Serialize(loginRet));
                    this.Context.Response.Write("#");
                }

            }

        }
    }
}
