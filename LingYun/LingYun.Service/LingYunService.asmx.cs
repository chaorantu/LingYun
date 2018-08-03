using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using LingYun.Data;
using LingYun.Lib;
using System.Web.Script.Serialization;

namespace LingYun.Service
{
    /// <summary>
    /// LingYunService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class LingYunService : System.Web.Services.WebService
    {
        #region 登录模块
        [WebMethod]
        public string Login(string username, string encodePsd)
        {
            
            JavaScriptSerializer jss = new JavaScriptSerializer();
            IUserLogin userLogin = new UserLogin();
           
            Msg msg = userLogin.Login(username, encodePsd);
            return jss.Serialize(msg);
        }
        #endregion
    }
}
