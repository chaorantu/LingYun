using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Model;
using LingYunDemo.Data;
using System.Text;
using LingYunDemo.Dal;

namespace LingYunDemo.Web.Order.Design
{
    public partial class PreEnsureMatries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> msg = MetriesModel.GetUnsureMatries();
            StringBuilder build = new StringBuilder();

            List<string> listName = MetriesModel.GetMetriesProjectName(msg);

                    for (int i = 0; i < msg.Count; i++)//循环查找材料表中未提交的项目，并动态添加控件
                    {
                        string sPlanId = msg[i].ToString(); ;

                        build.Append(@"<div onclick='urlLocation(" + msg[i] + ")' style='margin-bottom:10px;padding:12px 15px;line-height:13px; background:#E5E3E4;'><strong>项目名：" + listName[i] + "</strong><span style='right:8px;position:absolute'><img onclick='urlLocation(" + msg[i] + ")' alt='' style='height: 16px;'src='../../Images/minicalendar/ic_enter.png'/></span></div>");
                    }
                
                list.InnerHtml = build.ToString();
           
        }
    }
}