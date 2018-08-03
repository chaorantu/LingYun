using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using LingYunDemo.Model;
using LingYunDemo.Data;
using LingYunDemo.Dal;

namespace LingYunDemo.Web.Order.Design
{
    public partial class QueryDesign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Msg msg = MetriesModel.QueryMatries();
                if (msg.Status)
                {
                    List<Tbl_Materies> list = msg.UserData as List<Tbl_Materies>;
                    GridView1.DataSource = BuildGridViewDataSource(list);
                    GridView1.DataBind();

                }

                Msg projectMsg = MetriesModel.QueryProjectName();
                if (projectMsg.Status)
                {
                    StringBuilder build = new StringBuilder();
                    List<Tbl_Plan> planList = projectMsg.UserData as List<Tbl_Plan>;
                    for (int i = 0; i < planList.Count; i++)
                    {
                        build.Append(@"<div onclick='urlLocation(" + planList[i].PlanID + ")' style='margin-bottom:10px;padding:12px 15px;line-height:13px; background:#E5E3E4;'><strong>项目名：" + planList[i].ProjectName + "</strong><span style='right:8px;position:absolute'><img onclick='urlLocation(" + planList[i].PlanID + ")' alt='' style='height: 16px;'src='../../Images/minicalendar/ic_enter.png'/></span></div>");
                    }
                    list.InnerHtml = build.ToString();
                }
             
              
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

        protected void rdbQueryAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbQueryAll.Checked)
            {
                divShow.Style["display"] = "none";
                rdbQueryProject.Checked = false;
                this.GridView1.Visible = true;
                rdbQueryAll.Checked = true;
            }
        
        }

        protected void rdbQueryProject_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbQueryProject.Checked)
            {
                divShow.Style["display"]="block";
                rdbQueryProject.Checked = true;
                this.GridView1.Visible = false;
                rdbQueryAll.Checked = false;
            } 

        }
    }
}