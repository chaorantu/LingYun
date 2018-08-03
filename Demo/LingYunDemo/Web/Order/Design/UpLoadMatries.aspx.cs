using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Model;
using LingYunDemo.Data;
using LingYunDemo.Dal;
using LingYunDemo.Model.upload;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using LingYunDemo.Helper.Web;

namespace LingYunDemo.Web.Order.Design
{
    public partial class UpLoadMatries : System.Web.UI.Page
    {
        public static List<int> checkList = new List<int>();
        List<Tbl_InMaries> inList = new List<Tbl_InMaries>();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                string sPlanId = this.Request["PlanID"];
                Msg msg = PlanModel.QyeryPlanById(int.Parse(sPlanId));
                if (msg.Status)
                {

                    txbPlanId.Text = (msg.UserData as Tbl_Plan).ProjectName;
                }
                List<string> list = UpLoadModel.QueryMatriesName();
                DropDownList1.DataSource = list;
                DropDownList1.DataBind();

            }
            int index = GridView1.PageIndex;
            List<int> li = new List<int>();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((System.Web.UI.HtmlControls.HtmlInputCheckBox)this.GridView1.Rows[i].FindControl("chkBox")).Checked == true)
                {
                    li.Add(i + 1);
                }
            }
            ViewState["page" + index] = li;

            if (DropDownList1.Text != null)
            {
                Msg sqlMsg = UpLoadModel.GetMatriesByName(DropDownList1.Text);
                if (sqlMsg.Status)
                {
                    inList = sqlMsg.UserData as List<Tbl_InMaries>;
                    GridView1.DataSource = BuildGridViewDataSource(inList);
                    GridView1.DataBind();

                }
            }
        }

        private DataTable BuildGridViewDataSource(List<Tbl_InMaries> lBunch)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("项目名");
            dt.Columns.Add("材质");
            dt.Columns.Add("构建编号");
            dt.Columns.Add("构建名称");
            dt.Columns.Add("加工图号");
            dt.Columns.Add("材料序号");
            dt.Columns.Add("数量");

            foreach (Tbl_InMaries oBunch in lBunch)
            {
                DataRow dr = dt.NewRow();

                dr[0] = oBunch.TableName;
                dr[1] = "铝";
                dr[2] = oBunch.BuildId;
                dr[3] = "PR铝合金插芯加工图";

                dr[4] = oBunch.MapId;
                dr[5] = oBunch.Num;
                dr[6] = oBunch.Count;


                dt.Rows.Add(dr);
            }
            return dt;
        }
        protected void rdbQueryAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rdbQueryProject_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void changed(object sender, GridViewPageEventArgs e)
        {


            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = BuildGridViewDataSource(inList);
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            List<Tbl_Materies> MatriesList = new List<Tbl_Materies>();
            if (checkAll.Checked != false)
            {
                for (int i = 0; i < GridView1.PageCount; i++)
                {
                    if (i != GridView1.PageCount - 1)
                    {
                        List<int> li = new List<int>();
                        for (int j = 1; j <= 10; j++)
                            li.Add(j);
                        ViewState["page" + i] = li;
                    }
                    else
                    {
                        List<int> li = new List<int>();

                        int k = 0;
                             if(GridView1.Rows.Count % 10==0) k=10;
                             else
                               k=GridView1.Rows.Count % 10;
                        for (int j = 1; j <= k; j++)
                            li.Add(j);
                        ViewState["page" + i] = li;

                    }
                }
            }
            for (int i = 0; i < GridView1.PageCount; i++)
            {
                if (ViewState["page" + i] != null)
                {
                    List<int> pages = ViewState["page" + i] as List<int>;
                    foreach (int index in pages)
                    {
                        try
                        {
                            int obj = i*10+index-1;
                            string sPlanId = this.Request["PlanID"];

                            Tbl_Materies oMatries = new Tbl_Materies();
                            oMatries.PlanID = int.Parse(sPlanId);
                            oMatries.ProjectName = txbPlanId.Text;
                            oMatries.TotalNum = int.Parse(inList[obj].Count.ToString());
                            oMatries.MateriesType = inList[obj].Num.ToString();
                            oMatries.Date = DateTime.Now;
                            oMatries.BuildName = "铝";
                            oMatries.BuildNum = inList[obj].BuildId;
                            oMatries.NowAdmStatus = 1;
                            oMatries.NowDate = DateTime.Now.ToString();
                            oMatries.BeforeAdmStatus = 128;
                            oMatries.PreDate = DateTime.Now.ToString();
                            oMatries.ProcessingNum = inList[obj].MapId;
                            MatriesList.Add(oMatries);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }




            }
            Msg msg = MetriesModel.AddMateries(MatriesList);
            if (msg.Status)
            {
                PageHelper.ShowAlertMsg(this, "编辑成功");
            }
        }
    }
}