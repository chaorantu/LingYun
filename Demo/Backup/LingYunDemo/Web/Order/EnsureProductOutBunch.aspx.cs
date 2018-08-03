using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Data;
using LingYunDemo.Dal;
using LingYunDemo.Model;
using LingYunDemo.Common;
using LingYunDemo.Helper.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace LingYunDemo.Web.Order
{
    public partial class EnsureProductOutBunch : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string BuildBunchId = this.Request["BuildBunchId"];

                Msg MetriesMsg = ProductModel.QueryProductOutBunchById(int.Parse(BuildBunchId));
                if (MetriesMsg.Status)
                {
                    Tbl_OutProductBatch oOutBunch = MetriesMsg.UserData as Tbl_OutProductBatch;
                    if (oOutBunch != null)
                    {
                        txbPlanId.Value = oOutBunch.PlanID.ToString();
                        txbMateriesID.Value = oOutBunch.MateriesID.ToString();
                        txbBuildID.Value = oOutBunch.BuildID.ToString();
                        txbBuildName.Value = oOutBunch.BuildName;
                        txbCount.Value = oOutBunch.Count.ToString();
                        txbMetriesType.Value = oOutBunch.MateriesType;
                        txbProjectName.Value = oOutBunch.ProjectName;
                        txbProductNum.Value = oOutBunch.WorkMapID;
                        txbBuildBunchID.Value = oOutBunch.BuildBatchID.ToString();

                    }
                }
            }
        }

        protected void ensure_Click(object sender, EventArgs e)
        {

                Tbl_OutProductBatch oBunch = new Tbl_OutProductBatch();
                oBunch.PlanID = int.Parse(txbPlanId.Value);
                oBunch.Time = DateTime.Now;
                oBunch.MateriesID = int.Parse(txbMateriesID.Value);
                oBunch.BuildID = txbBuildID.Value;
                oBunch.BuildName = txbBuildName.Value.ToString();
                oBunch.MateriesType = txbMetriesType.Value.ToString();
                oBunch.PreAdmTime = DateTime.Now;
                oBunch.PreAdmStatus = 128;
                oBunch.Count = int.Parse(txbCount.Value);
                oBunch.BuildBatchID = int.Parse(txbBuildBunchID.Value);

                //出库批次表
                Tbl_CenterStorageBatch oCenterBunch = new Tbl_CenterStorageBatch();
                oCenterBunch.PlanID = int.Parse(txbPlanId.Value);
                oBunch.MateriesTasbleID = 0;
                oCenterBunch.BuildID = txbBuildID.Value;
                oCenterBunch.BuildBatchID = int.Parse(txbBuildBunchID.Value);
                oCenterBunch.Time = DateTime.Now;
                oBunch.ProjectName = txbProjectName.Value;
                oCenterBunch.BuildName = txbBuildName.Value;
                oCenterBunch.ProjectName = txbProjectName.Value;
                oCenterBunch.MateriesID = int.Parse(txbMateriesID.Value);
                oCenterBunch.MateriesType = txbMetriesType.Value.ToString();
                oCenterBunch.WorkMapID = txbProductNum.Value;
                oCenterBunch.Count = int.Parse(txbCount.Value);
                oCenterBunch.NowAdmStatus = 1;
                oCenterBunch.PreAdmStatus = 128;
                oCenterBunch.PreAdmTime = DateTime.Now;
                oCenterBunch.NowAdmTime = DateTime.Now;


                //string conStr = ConfigurationManager.AppSettings["ConStr"];
                //SqlConnection con = new SqlConnection(conStr);
                //con.Open();
                //SqlCommand com1 = new SqlCommand("insert into Tbl_CenterStorageBatch(PlanID,MateriesTasbleID,BuildID,BuildBatchID,Time,ProjectName,BuildName,MateriesID,MateriesType,WorkMapID,Count,PreAdmStatus,PreAdmTime,NowAdmStatus,NowAdmTime) values('" + oCenterBunch.PlanID + "','" + oCenterBunch.MateriesTasbleID + "','" + oCenterBunch.BuildID + "','" + oCenterBunch.BuildBatchID + "','" + oCenterBunch.Time + "','" + oCenterBunch.ProjectName + "','" + oCenterBunch.BuildName + "','" + oCenterBunch.MateriesID + "','" + oCenterBunch.MateriesType + "','" + oCenterBunch.WorkMapID + "','" + oCenterBunch.Count + "','" + oCenterBunch.PreAdmStatus + "','"+DateTime.Now+"','1','" + DateTime.Now + "')", con);
                //com1.ExecuteScalar();
                //con.Close();
                ////using (var en = new LingYunEntities())
                ////{
                ////    en.Tbl_CenterStorageBatch.AddObject(oCenterBunch);
                ////    en.SaveChanges();
                ////}
                Msg msg = ProductModel.UpdateOutBunch(oBunch, oCenterBunch);
                if (msg.Status)
                {
                    PageHelper.ShowAlertMsg(this, "编辑并确认成功");
                }
                else
                {
                    PageHelper.ShowAlertMsg(this, msg.Message);
                }

           
        }
    }
}