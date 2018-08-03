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

namespace LingYunDemo.Web.Order.Design
{
    public partial class QueryProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           string sPlanId=this.Request["PlanId"];
                   Msg msg= MetriesModel.QueryProject(int.Parse(sPlanId));
                   if (msg.Status)
                   {
                       List<Tbl_Materies> list = msg.UserData as List<Tbl_Materies>;
                       GridView1.DataSource = BuildGridViewDataSource(list);
                       GridView1.DataBind();
                   }
        }

        private DataTable BuildGridViewDataSource(List<Tbl_Materies> lBunch)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("项目名");
            dt.Columns.Add("材料编号");
            dt.Columns.Add("时间");
            dt.Columns.Add("材质");
            dt.Columns.Add("构建编号");
            dt.Columns.Add("构建名称");
            dt.Columns.Add("项目编号");
            dt.Columns.Add("加工图号");
            dt.Columns.Add("数量");

            foreach (Tbl_Materies oBunch in lBunch)
            {
                DataRow dr = dt.NewRow();

                dr[0] = oBunch.ProjectName;
                dr[1] = oBunch.MateriesID;
                dr[2] = oBunch.Date;
                dr[3] = oBunch.MateriesType;
                dr[4] = oBunch.BuildNum;
                dr[5] = oBunch.BuildName;
                dr[6] = oBunch.PlanID;
                dr[7] = oBunch.ProcessingNum;
                dr[8] = oBunch.TotalNum;

                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}