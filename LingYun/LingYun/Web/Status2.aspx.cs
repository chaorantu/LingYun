using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace LingYun.Web
{
    public partial class Status2 : System.Web.UI.Page
    {
        public  class PlanStatus
        {
            public string PlanName { get; set; }
            public string PlanAdm { get; set; }
            public string Design { get; set; }
            public string Produnt { get; set; }
            public string Center { get; set; }
            public string Site { get; set; }
            
        }
        public static List<PlanStatus> lUsers = new List<PlanStatus>();
        protected void Page_Load(object sender, EventArgs e)
        {
           

            //    lUsers = getData();
                //  addCol();

               // GridView1.DataSource = BuildGridViewDataSource(lUsers);
               // GridView1.DataBind();
                //GridView1.Columns[0].HeaderStyle.Width= 200;
                //GridView1.Columns[1].HeaderStyle.Width = 200;
                //GridView1.Columns[2].HeaderStyle.Width = 200;
                //GridView1.Columns[3].HeaderStyle.Width = 200;
                //GridView1.Columns[4].HeaderStyle.Width = 200;
                //GridView1.Columns[5].HeaderStyle.Width = 200;

       

        }
        /// <summary>
        /// 绑定数据到DataTable
        /// </summary>
        /// <returns></returns>
        //private DataTable BuildGridViewDataSource(List<PlanStatus> lUsers)
        //{

            //DataTable dt = new DataTable();
            //dt.Columns.Add("项目名");
            //dt.Columns.Add("项目确认");
            //dt.Columns.Add("设计主管确认");
            //dt.Columns.Add("加工主管完成情况");
            //dt.Columns.Add("中心主管完成情况");
            //dt.Columns.Add("现场主管情况");
            //for (int i = 0; i < lUsers.Count; i++)
            //{
            //    DataRow dr = dt.NewRow();

            //    dr[0] = lUsers[i].PlanName;
            //    dr[1] = lUsers[i].PlanAdm;
            //    dr[2] = lUsers[i].Design;
            //    dr[3] = lUsers[i].Produnt;
            //    dr[4] = lUsers[i].Center;
            //    dr[5] = lUsers[i].Site;
            //    dt.Rows.Add(dr);
            //}
           
            //if (lUsers.Count > 5)
            //{
            //    for (int i = 0; i < 5; i++)
            //    {
            //        DataRow dr = dt.NewRow();

            //        dr[0] = lUsers[i].PlanName;
            //        dr[1] = lUsers[i].PlanAdm;
            //        dr[2] = lUsers[i].Design;
            //        dr[3] = lUsers[i].Produnt;
            //        dr[4] = lUsers[i].Center;
            //        dr[5] = lUsers[i].Site;
            //        dt.Rows.Add(dr);
            //    }
            //}
            //else
            //{
            //    GridView1.AllowPaging = false;
            //    for (int i = 0; i < lUsers.Count; i++)
            //    {
            //        DataRow dr = dt.NewRow();

            //        dr[0] = lUsers[i].PlanName;
            //        dr[1] = lUsers[i].PlanAdm;
            //        dr[2] = lUsers[i].Design;
            //        dr[3] = lUsers[i].Produnt;
            //        dr[4] = lUsers[i].Center;
            //        dr[5] = lUsers[i].Site;
            //        dt.Rows.Add(dr);
            //    }
            //}
        //    return dt;
    //    }


        //private List<PlanStatus> getData()
        //{

            //StringBuilder oBuild = new StringBuilder();
            //Msg msg = PlanStatusModel.GetUnFillPlans();//获取未完成的项目
            //List<PlanStatus> list = new List<PlanStatus>();
            //if (msg.Status)
            //{
            //    List<Tbl_Plan> lPlans = msg.UserData as List<Tbl_Plan>;//项目署

            //    for (int i = 0; i < lPlans.Count; i++)
            //    {
            //        PlanStatus status = new PlanStatus();

            //        status.PlanName = lPlans[i].ProjectName;
            //        if (lPlans[i].DesignAdmStatus == 128)//如果设计主管已确认
            //        {
                      
            //            status.PlanAdm = "已确认";
            //            status.Design = "已确认";
            //            int PlanCount = PlanStatusModel.GetMateriesById(lPlans[i].PlanID);//获取项目的数量
            //            List<Tbl_ProductStorage> lProduct = PlanStatusModel.GetPlanPercentById(lPlans[i].PlanID, (int)TableType.加工中心).UserData as List<Tbl_ProductStorage>;

            //            List<Tbl_CenterStorage> lCenter = PlanStatusModel.GetPlanPercentById(lPlans[i].PlanID, (int)TableType.中心仓储).UserData as List<Tbl_CenterStorage>;
            //            List<Tbl_SiteStorage> lSite = PlanStatusModel.GetPlanPercentById(lPlans[i].PlanID, (int)TableType.现场仓储).UserData as List<Tbl_SiteStorage>;
            //            int iPCount = 0;
            //            int iCCount = 0;
            //            int iSCount = 0;
            //            foreach (Tbl_ProductStorage oPro in lProduct)
            //            {
            //                iPCount += oPro.InCount == null ? 0 : (int)oPro.InCount;
            //            }
            //            foreach (Tbl_CenterStorage oPro in lCenter)
            //            {
            //                iCCount += oPro.InCount == null ? 0 : (int)oPro.InCount;
            //            }
            //            foreach (Tbl_SiteStorage oPro in lSite)
            //            {
            //                iSCount += oPro.InCount == null ? 0 : (int)oPro.InCount;
            //            }
            //            string sProduct = (((float)iPCount / PlanCount) * 100).ToString();
            //            string sCenter = (((float)iCCount / PlanCount) * 100).ToString();
            //            string sSite = (((float)iSCount / PlanCount) * 100).ToString();
            //            if (iPCount == 0)
            //            {
            //                status.Produnt = "加工中心已完成: " + sProduct + "%";
            //             //   oBuild.Append("<spam>项目:" + lPlans[i].PlanID + "></span><span >项目主管确定-></span><span >设计主管确定-></span><span >加工中心已完成: " + sProduct + "%-></span>");
            //            }
            //            else if (iCCount == 0)
            //            {
            //                 status.Produnt = "加工中心已完成: " + sProduct + "%";
            //                status.Center = "中心仓储已完成: " + sCenter + "%";
            //            }
            //             //   oBuild.Append("<spam>项目:" + lPlans[i].PlanID + "></span><span >项目主管确定-></span><span >设计主管确定-></span><span>加工中心已完成: " + sProduct + "%-></span> <span>中心仓储已完成: " + sCenter + "%-></span>");
            //            else if (iSCount == 0)
            //            {
            //                status.Produnt = "加工中心已完成: " + sProduct + "%";
            //                status.Center = "中心仓储已完成: " + sCenter + "%";
            //                status.Site = "现场仓储已完成: " + sSite + "%";
            //            }
            //            else
            //            {
            //            }
            //        }
            //        else if (lPlans[i].PlanAdmStatus == 128)//设计主管确定
            //        {
            //            status.PlanAdm = "已确认";
            //            status.Design = "未确认";
                     
            //        }
            //        else   //项目主管确定
            //        {
            //            status.PlanAdm = "未确认";
                        
            //        }

            //        list.Add(status);
            //    }
                
            //}
         
            //return list;
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (GridView1.Visible == true)
            //{
            //    Button1.Text = "显示进度";
            //    this.GridView1.Visible = false;
            //    Response.Write("<script language='javascript'>window.parent.document.getElementsByTagName('frameset')[2].rows='30,*'; </script>");

            //}
            //else
            //{
            //    Button1.Text = "不显示进度";
            //    Response.Write("<script language='javascript'>window.parent.document.getElementsByTagName('frameset')[2].rows='200,*'; </script>");
            //    this.GridView1.Visible = true;
            //}
        }

        protected void changed(object sender, GridViewPageEventArgs e)
        {
            ////List<PlanStatus> list = new List<PlanStatus>();
           
            ////int page = lUsers.Count/5;
            ////if (lUsers.Count % 5 != 0) page+= 1;
            ////if (e.NewPageIndex != page - 1)
            ////{
            ////    for (int i = e.NewPageIndex * 5; i < e.NewPageIndex * 5+5; i++)
            ////    {
            ////        list.Add(lUsers[i]);
            ////    }
            ////}
            ////else
            ////{
            ////    for (int i = e.NewPageIndex * 5; i <lUsers.Count; i++)
            ////    {
            ////        list.Add(lUsers[i]);
            ////    }

            //}
            //GridView1.PageIndex = e.NewPageIndex;
            //GridView1.DataSource = BuildGridViewDataSource(lUsers);
            //GridView1.DataBind();
            
        }

      
    }
}