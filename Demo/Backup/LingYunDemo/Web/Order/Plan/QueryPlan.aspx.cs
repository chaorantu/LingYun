using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Model;
using LingYunDemo.Data;
using LingYunDemo.Dal;
using System.Data;

namespace LingYunDemo.Web.Order.Plan
{
    public partial class QueryPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           Msg msg= PlanModel.ShowAllPlan();//获取所有项目数据
           if (msg.Status)
           {
               List<Tbl_Plan> Tbl_Plan = msg.UserData as List<Tbl_Plan>;

               Gridview1.DataSource = BuildGridViewDataSource(Tbl_Plan);
               Gridview1.DataBind();//绑定数据
            
           }
        }

        private DataTable BuildGridViewDataSource(List<Tbl_Plan> lPlans)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("项目名称");
            dt.Columns.Add("项目提交日期");
            dt.Columns.Add("设计主管");
            dt.Columns.Add("设计主管状态");
            dt.Columns.Add("加工主管");
            dt.Columns.Add("加工主管状态");
            dt.Columns.Add("中心库主管");
            dt.Columns.Add("中心库主管状态");
            dt.Columns.Add("现场库主管");
            dt.Columns.Add("现场库主管状态");

            foreach (Tbl_Plan oPlan in lPlans)
            {
                DataRow dr = dt.NewRow();

                dr[0] = oPlan.ProjectName;
                dr[1] = oPlan.PlanDate;
       
            
                dr[2] = PlanModel.GetPlanAdmName(int.Parse(oPlan.DesignAdm.ToString()));
                dr[3] = GetString(oPlan.DesignAdmStatus);
                dr[4] = PlanModel.GetPlanAdmName(int.Parse(oPlan.ProductAdm.ToString()));
                dr[5] = GetString(oPlan.ProductAdmStatus);
                dr[6] =  PlanModel.GetPlanAdmName(int.Parse(oPlan.CenterStorageAdm.ToString()));
                dr[7] = GetString(oPlan.CenterStorageAdmStatus);
                dr[8] =  PlanModel.GetPlanAdmName(int.Parse(oPlan.SiteStorageAdm.ToString()));
       
                dr[9] = GetString(oPlan.SiteStorageAdmStatus);
               
                dt.Rows.Add(dr);
            }
            return dt;
        }
        private string GetString(int iStatus)
        {
            if (iStatus == 128)
            {
                return "已确认";
            }
            else
            {
                return "未确认";
            }
            
        }

        protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}