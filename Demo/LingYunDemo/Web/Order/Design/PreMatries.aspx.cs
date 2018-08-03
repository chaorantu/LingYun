using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using LingYunDemo.Data.Enum;
using LingYunDemo.Common;
using LingYunDemo.Model;
using LingYunDemo.Data;
using LingYunDemo.Dal;

namespace LingYunDemo.Web.Order.Design
{
    public partial class PreMatries : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Msg msg = MetriesModel.GetUnDesignedPlan();
            StringBuilder build = new StringBuilder();

            if (msg.Status)
            {
                List<Tbl_Plan> lPlans = msg.UserData as List<Tbl_Plan>;
                if (lPlans.Count > 0)
                {

                    for (int i = 0; i < lPlans.Count; i++)//循环查找材料表中未提交的项目，并动态添加控件
                    {
                        string sPlanId = lPlans[i].PlanID.ToString(); ;

                        build.Append(@"<div onclick='urlLocation(" + lPlans[i].PlanID + ")' style='margin-bottom:10px;padding:12px 15px;line-height:13px; background:#E5E3E4;'><strong>项目名：" + lPlans[i].ProjectName + "</strong><span style='right:8px;position:absolute'><img onclick='urlLocation(" + lPlans[i].PlanID + ")' alt='' style='height: 16px;'src='../../Images/minicalendar/ic_enter.png'/></span></div>");

                    }
                }
                list.InnerHtml = build.ToString();
            }

        }


    }
}