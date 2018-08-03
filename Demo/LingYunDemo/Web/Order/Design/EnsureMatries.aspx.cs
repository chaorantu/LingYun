using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using LingYunDemo.Model;
using LingYunDemo.Data;
using LingYunDemo.Dal;
using LingYunDemo.Helper.Web;

namespace LingYunDemo.Web.Order.Design
{
    public partial class EnsureMatries : System.Web.UI.Page
    {
        public static List<Tbl_Materies> lPlan = new List<Tbl_Materies>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sPlanId = this.Request["PlanID"];
                Msg msg = MetriesModel.GetMetriesByMatriesId(int.Parse(sPlanId));
                if (msg.Status)
                {
                    StringBuilder build = new StringBuilder();
                    lPlan = msg.UserData as List<Tbl_Materies>;
                    GridView1.DataSource = BuildGridViewDataSource(lPlan);
                    GridView1.DataBind();
                    if (lPlan.Count==0)
                    {
                        Ensure.Enabled = false;
                    }
                }
               
            }
        }
        private DataTable BuildGridViewDataSource(List<Tbl_Materies> lBunch)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("项目名");
            dt.Columns.Add("材质");
            dt.Columns.Add("构建编号");
            dt.Columns.Add("构建名称");
            dt.Columns.Add("加工图号");
            dt.Columns.Add("材料序号");
            dt.Columns.Add("数量");

            foreach (Tbl_Materies oBunch in lBunch)
            {
                DataRow dr = dt.NewRow();

                dr[0] = oBunch.ProjectName;
                dr[1] = "铝";
                dr[2] = oBunch.BuildNum;
                dr[3] = "PR铝合金插芯加工图";

                dr[4] = oBunch.ProcessingNum;
                dr[5] = oBunch.MateriesType;
                dr[6] = oBunch.TotalNum;

                dt.Rows.Add(dr);
            }
            return dt;
        }
        protected void Ensure_Click(object sender, EventArgs e)
        {
            List<Tbl_Materies> list = new List<Tbl_Materies>();
            string sPlanId = this.Request["PlanID"];
            if (checkAll.Checked == true)
            {

                for (int i = 0; i < lPlan.Count; i++)
                {
                    Tbl_Materies oMatries = new Tbl_Materies();
                    oMatries.PlanID = int.Parse(sPlanId);
                    oMatries.ProjectName = lPlan[i].ProjectName;
                    oMatries.TotalNum = lPlan[i].TotalNum;
                    oMatries.MateriesType = lPlan[i].MateriesType;
                    oMatries.Date = DateTime.Now;
                    oMatries.BuildName = lPlan[i].BuildName;
                    oMatries.BuildNum = lPlan[i].BuildNum;
                    oMatries.BeforeAdmStatus = 128;
                    oMatries.PreDate = DateTime.Now.ToString();
                    oMatries.NowAdmStatus = 1;
                    oMatries.ProcessingNum = lPlan[i].ProcessingNum;
                    oMatries.NowDate = DateTime.Now.ToString();
                    oMatries.MateriesID = lPlan[i].MateriesID;
                    list.Add(oMatries);
                }
            }
            else
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    if (((System.Web.UI.HtmlControls.HtmlInputCheckBox)this.GridView1.Rows[i].FindControl("chkBox")).Checked == true)
                    {
                        Tbl_Materies oMatries = new Tbl_Materies();
                        oMatries.PlanID = int.Parse(sPlanId);
                        oMatries.ProjectName = GridView1.Rows[i].Cells[1].Text;
                        oMatries.TotalNum = int.Parse(GridView1.Rows[i].Cells[7].Text);
                        oMatries.MateriesType = GridView1.Rows[i].Cells[6].Text;
                        oMatries.Date = DateTime.Now;
                        oMatries.BuildName = GridView1.Rows[i].Cells[4].Text;
                        oMatries.BuildNum = GridView1.Rows[i].Cells[3].Text;
                        oMatries.BeforeAdmStatus = 128;
                        oMatries.PreDate = DateTime.Now.ToString();
                        oMatries.NowAdmStatus = 1;
                        oMatries.ProcessingNum = GridView1.Rows[i].Cells[5].Text;
                        oMatries.NowDate = DateTime.Now.ToString();
                        oMatries.MateriesID = lPlan[i].MateriesID;
                      
                        list.Add(oMatries);

                    }
                }
            }
            Msg msg = MetriesModel.EnsureMateries(list);
            if (msg.Status)
            {
                PageHelper.ShowAlertMsg(this, "确认材料表成功");
            }
            else
            {
                PageHelper.ShowAlertMsg(this, msg.Message);

            }


        }


    }
}