using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Model;
using LingYunDemo.Data;
using System.Net;
using System.Web.Script.Serialization;
using LingYunDemo.Common;
using LingYunDemo.Dal;
using System.Json;
using LingYunDemo.Helper.Web;

namespace LingYunDemo.Web.android
{
    public partial class Login : System.Web.UI.Page
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
            this.Response.ContentType = "text/plain";


            string imei = this.Request["imei"];
            Msg msg = UserLoginModel.Login(imei);
            JsonArray json = new JsonArray();
            GsonHelper gson = new GsonHelper();
          
            if (msg.Status)//支持多身份
            {

                List<Tbl_User> list = msg.UserData as List<Tbl_User>;


                for (int i = 0; i < list.Count; i++)
                {



                    LoginRet oLogin = new LoginRet();
                    oLogin.UserName = list[i].Name;
                    oLogin.Identify = list[i].Access;
                    oLogin.Status = 1;
                    json.Add(JsonValue.Parse(gson.GetSerializerString(oLogin)));
                }
             
            }
            else
            {
              
                LoginRet oLogin = new LoginRet();
                oLogin.Message = msg.Message;
                oLogin.Status = 0;
                json.Add(JsonValue.Parse(gson.GetSerializerString(oLogin)));

            }

            this.Context.Response.Write(json);
        }
    }
}