using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Data;
using LingYunDemo.Model;
using LingYunDemo.Dal;
using LingYunDemo.Helper.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace LingYunDemo.Web.Order.CenterStorage
{
    public partial class EnsureCenterInBunch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string MetriesId = this.Request["BuildBunchId"];

                Msg MetriesMsg = Center.QueryInBunch(int.Parse(MetriesId));
                Tbl_CenterStorageBatch oMatries = MetriesMsg.UserData as Tbl_CenterStorageBatch;
                if (oMatries != null)
                {
                    txbPlanId.Value = oMatries.PlanID.ToString();
                    txbMateriesID.Value = oMatries.MateriesID.ToString();
                    txbBuildID.Value = oMatries.BuildID.ToString();
                    txbBuildName.Value = oMatries.BuildName;
                    txbCount.Value = oMatries.Count.ToString();
                    txbMetriesType.Value = oMatries.MateriesType;
                    txbProductNum.Value = oMatries.WorkMapID;
                    txbProjectName.Value = oMatries.ProjectName;
                    txbBuildBunchId.Value = oMatries.BuildBatchID.ToString();

                }
            }
        }

        protected void Ensure_Click(object sender, EventArgs e)
        {
            string sBuildBunchId = this.Request["BuildBunchId"];
            int count = int.Parse(txbCount.Value);
          int iBunildBunchId=int.Parse(sBuildBunchId);
            Tbl_CenterStorage oStorage = new Tbl_CenterStorage();
            oStorage.PlanID = int.Parse(txbPlanId.Value);
            oStorage.BuildBatchID = int.Parse(txbBuildBunchId.Value);
            oStorage.Time = DateTime.Now;
            oStorage.MateriesID = int.Parse(txbMateriesID.Value);
            oStorage.BuildID = txbBuildID.Value;
            oStorage.BuildName = txbBuildName.Value.ToString();
            oStorage.MateriesType = txbMetriesType.Value.ToString();
            oStorage.PreAdmTime = DateTime.Now;
            oStorage.PreAdmStatus = 128;
            oStorage.NowAdmStatus = 128;
            oStorage.NowAdmTime = DateTime.Now;
            oStorage.ProjectName = txbProjectName.Value;
            oStorage.WorkMapID = txbProductNum.Value;
            oStorage.InCount = int.Parse(txbCount.Value);
            oStorage.Count = 0;
            string conStr = ConfigurationManager.AppSettings["ConStr"];
            SqlConnection con = new SqlConnection(conStr);
               con.Open();
               SqlCommand com1 = new SqlCommand("insert into Tbl_CenterStorage(PlanID,MateriesTasbleID,BuildID,BuildBatchID,Time,ProjectName,BuildName,MateriesID,MateriesType,WorkMapID,Count,PreAdmStatus,PreAdmTime,NowAdmStatus,NowAdmTime,InCount) values('" + oStorage.PlanID + "','" + oStorage.MateriesTasbleID + "','" + oStorage.BuildID + "','" + oStorage.BuildBatchID + "','" + oStorage.Time + "','" + oStorage.ProjectName + "','" + oStorage.BuildName + "','" + oStorage.MateriesID + "','" + oStorage.MateriesType + "','" + oStorage.WorkMapID + "','" + oStorage.Count + "','" + oStorage.PreAdmStatus + "','" + DateTime.Now + "','1','" + DateTime.Now + "','" + oStorage.InCount + "')", con);
               SqlCommand com2 = new SqlCommand("UPDATE Tbl_CenterStorageBatch SET NowAdmStatus=128,Count=" + count + ",NowAdmTime='" + DateTime.Now + "' WHERE BuildBatchID=" + iBunildBunchId + "", con);

            Msg msg = Center.UpdateInBunch(int.Parse(sBuildBunchId), count, oStorage);
                if (msg.Status)
                {
                    try
                    {
                        com1.ExecuteScalar();
                        com2.ExecuteScalar();
                        con.Close();
                        PageHelper.ShowAlertMsg(this, "编辑并确认成功");
                    }
                    catch(Exception ex)
                    {
                        PageHelper.ShowAlertMsg(this, ex.Message);
                    }
                   
                }
                else
                {
                    PageHelper.ShowAlertMsg(this, msg.Message);
                }

               
      
        }
    }
}