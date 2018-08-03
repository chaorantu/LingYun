using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace LingYunDemo.Helper.Web
{
    public class PageHelper
    {
        /// <summary>
        /// 弹出页面消息
        /// </summary>
        /// <param name="p">页面对象</param>
        /// <param name="t">类型</param>
        /// <param name="sMsg">消息文本</param>
        public static void ShowAlertMsg(Page p, Type t, string sMsg, Exception ex)
        {

            p.ClientScript.RegisterStartupScript(t, t.Name, string.Format("<script>alert('{0}');</script>", sMsg));
        }
        /// <summary>
        /// 弹出页面消息
        /// </summary>
        /// <param name="p">页面对象</param>
        /// <param name="t">类型</param>
        /// <param name="sMsg">消息文本</param>
        public static void ShowAlertMsg(Page p, Type t, string sMsg)
        {
            ShowAlertMsg(p, t, sMsg, null);
        }
        /// <summary>
        /// 弹出页面消息
        /// </summary>
        /// <param name="p">页面对象</param>
        /// <param name="sMsg">消息文本</param>
        public static void ShowAlertMsg(Page p, string sMsg)
        {
            ShowAlertMsg(p, p.GetType(), sMsg);
        }
        /// <summary>
        /// 弹出页面消息
        /// </summary>
        /// <param name="p">页面对象</param>
        /// <param name="sMsg">消息文本</param>
        public static void ShowAlertMsg(Page p, string sMsg, Exception ex)
        {
            ShowAlertMsg(p, p.GetType(), sMsg, ex);
        }
        /// <summary>
        /// 注册页面客户端启动脚本
        /// </summary>
        /// <param name="p">页面对象</param>
        /// <param name="t">类型</param>
        /// <param name="sKey">keys</param>
        /// <param name="sScripts">脚本代码，不需要包含<script>部分</param>
        public static void RegisterStartupScript(Page p, Type t, string sKey, string sScripts)
        {
            //sScripts = HttpUtility.HtmlEncode(sScripts);
            p.ClientScript.RegisterStartupScript(t, t.Name, sScripts, true);
        }
        /// <summary>
        /// 注册页面客户端启动脚本
        /// </summary>
        /// <param name="p">页面对象</param>
        /// <param name="sScripts">脚本代码，不需要包含<script>部分</param>
        public static void RegisterStartupScript(Page p, string sScripts)
        {
            RegisterStartupScript(p, p.GetType(), Guid.NewGuid().ToString(), sScripts);
        }
        /// <summary>
        /// 注册页面客户端启动脚本
        /// </summary>
        /// <param name="p">页面对象</param>
        /// <param name="t">类型</param>
        /// <param name="sScripts">脚本代码，不需要包含<script>部分</param>
        public static void RegisterStartupScript(Page p, Type t, string sScripts)
        {
            RegisterStartupScript(p, t, Guid.NewGuid().ToString(), sScripts);
        }


        /// <summary>
        /// 调用前台的JS方法
        /// </summary>
        /// <param name="key">脚本块的唯一标识符</param>
        /// <param name="scriptStr">JS脚本</param>
        public static void RegisterClientScriptBlock(Page p, string key, string scriptStr)
        {
            p.ClientScript.RegisterClientScriptBlock(p.GetType(), key, "<script language='javascript'>" + scriptStr + "</script>");
        }
    }
}