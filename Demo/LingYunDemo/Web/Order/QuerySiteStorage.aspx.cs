using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LingYunDemo.Model;
using LingYunDemo.Data;
using LingYunDemo.Dal;

namespace LingYunDemo.Web.Order
{
    public partial class QuerySiteStorage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Msg msg = SiteStorageModel.QueryStorage();
            if (msg.Status)
            {
                List<Tbl_SiteStorage> lStorage = msg.UserData as List<Tbl_SiteStorage>;
                gdvStorage.DataSource = BuildGridViewDataSource(lStorage);
                gdvStorage.DataBind();

            }

        }
        private DataTable BuildGridViewDataSource(List<Tbl_SiteStorage> lBunch)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("项目编号");
            dt.Columns.Add("材料编号");
            dt.Columns.Add("时间");
            dt.Columns.Add("批次编号");
            dt.Columns.Add("材质");
            dt.Columns.Add("构建名称");
            dt.Columns.Add("工程名");
            dt.Columns.Add("加工图号");
            dt.Columns.Add("入数量");
            dt.Columns.Add("出数量");
            foreach (Tbl_SiteStorage oBunch in lBunch)
            {
                DataRow dr = dt.NewRow();

                dr[0] = oBunch.PlanID;
                dr[1] = oBunch.MateriesID;
                dr[2] = oBunch.Time;
                dr[3] = oBunch.BuildBatchID;
                dr[4] = oBunch.MateriesType;
                dr[5] = oBunch.BuildName;
                dr[6] = oBunch.ProjectName;
                dr[7] = oBunch.WorkMapID;
                dr[8] = oBunch.InCount;
                dr[9] = oBunch.Count;
                dt.Rows.Add(dr);
            }
            return dt;
        }
 
    }
}