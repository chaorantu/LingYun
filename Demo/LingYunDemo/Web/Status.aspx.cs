using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Model;
using LingYunDemo.Data;
using LingYunDemo.Dal;
using LingYunDemo.Data.Enum;
using System.Text;

namespace LingYunDemo.Web
{
    public partial class Status : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder oBuild = new StringBuilder();
           Msg msg=PlanStatusModel.GetUnFillPlans();//获取未完成的项目
           if (msg.Status)
           {
               List<Tbl_Plan> lPlans = msg.UserData as List<Tbl_Plan>;//项目署
               for (int i = 0; i < lPlans.Count; i++)
               {
                 
                   oBuild.Append("<li>");
                   if (lPlans[i].DesignAdmStatus==128)//如果设计主管已确认
                   {
                       int PlanCount = PlanStatusModel.GetMateriesById(lPlans[i].PlanID);//获取项目的数量
                       List<Tbl_ProductStorage> lProduct = PlanStatusModel.GetPlanPercentById(lPlans[i].PlanID, (int)TableType.加工中心).UserData as List<Tbl_ProductStorage>;

                       List<Tbl_CenterStorage> lCenter = PlanStatusModel.GetPlanPercentById(lPlans[i].PlanID, (int)TableType.中心仓储).UserData as List<Tbl_CenterStorage>;
                       List<Tbl_SiteStorage> lSite = PlanStatusModel.GetPlanPercentById(lPlans[i].PlanID, (int)TableType.现场仓储).UserData as List<Tbl_SiteStorage>;
                       int iPCount = 0;
                       int iCCount = 0;
                       int iSCount = 0;
                       foreach (Tbl_ProductStorage oPro in lProduct)
                       {
                           iPCount += oPro.InCount==null?0:(int)oPro.InCount;
                       }
                       foreach (Tbl_CenterStorage oPro in lCenter)
                       {
                           iCCount += oPro.InCount == null ? 0 : (int)oPro.InCount;
                       }
                       foreach (Tbl_SiteStorage oPro in lSite)
                       {
                           iSCount += oPro.InCount == null ? 0 : (int)oPro.InCount;
                       }
                       string sProduct=(((float)iPCount/PlanCount)*100).ToString();
                                 string sCenter=(((float)iCCount/PlanCount)*100).ToString();
                                 string sSite=(((float)iSCount/PlanCount)*100).ToString();
                                 if (iPCount == 0)
                                 {
                                     oBuild.Append("<spam>项目:" + lPlans[i].PlanID + "></span><span >项目主管确定-></span><span >设计主管确定-></span><span >加工中心已完成: " + sProduct + "%-></span>");
                                 }
                                 else if(iCCount==0)
                                     oBuild.Append("<spam>项目:" + lPlans[i].PlanID + "></span><span >项目主管确定-></span><span >设计主管确定-></span><span>加工中心已完成: " + sProduct + "%-></span> <span>中心仓储已完成: " + sCenter + "%-></span>");
                                 else if (iSCount == 0)
                                     oBuild.Append("<spam>项目:" + lPlans[i].PlanID + "></span><span >项目主管确定-></span><span >设计主管确定-></span><span>加工中心已完成: " + sProduct + "%-></span> <span>中心仓储已完成: " + sCenter + "%-></span><span>现场仓储已完成: " + sSite + "%-></span>");
                                 else
                                 {
                                 }
                   }
                   else if (lPlans[i].PlanAdmStatus == 128)//设计主管确定
                   {
                       oBuild.Append("<spam>项目:" + lPlans[i].PlanID + "></span><span>项目主管确定-></span><span style='color:Orange'>设计主管确定</span>");
                   }
                   else   //项目主管确定
                   {
                       oBuild.Append("<spam>项目:" + lPlans[i].PlanID + "></span><span style='color:Orange'>项目主管确定</span>");
                   }
                   oBuild.Append("</li>");
                 
               }
           }
           planStatus.InnerHtml = oBuild.ToString();
        }
    }
}