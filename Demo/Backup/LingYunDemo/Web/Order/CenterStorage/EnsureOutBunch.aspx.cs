using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using LingYunDemo.Data;
using LingYunDemo.Model;
using LingYunDemo.Dal;
using LingYunDemo.Helper.Web;

namespace LingYunDemo.Web.Order.CenterStorage                    //主管确认出库
{
    public partial class EnsureOutBunch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)        //将Tbl_CenterStorageBatch表中的数据显示到Table中
        {
            if (!IsPostBack)
            {
                string BuildBunchId = this.Request["BuildBunchId"];

                Msg MetriesMsg = Center.QueryProductOutBunchById(int.Parse(BuildBunchId));
                if (MetriesMsg.Status)
                {
                    Tbl_OutCenterStorage oOutBunch = MetriesMsg.UserData as Tbl_OutCenterStorage;
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
            Tbl_SiteStorageBatch oSiteInBunch=new Tbl_SiteStorageBatch();

            oSiteInBunch.PlanID = int.Parse(txbPlanId.Value);
            oSiteInBunch.MateriesTasbleID = 0;
            oSiteInBunch.BuildID = txbBuildID.Value;
            oSiteInBunch.BuildBatchID = int.Parse(txbBuildBunchID.Value);
            oSiteInBunch.Time = DateTime.Now;
            oSiteInBunch.ProjectName = txbProjectName.Value;
            oSiteInBunch.BuildName = txbBuildName.Value;

            oSiteInBunch.MateriesID = int.Parse(txbMateriesID.Value);
            oSiteInBunch.MateriesType = txbMetriesType.Value.ToString();
            oSiteInBunch.WorkMapID = txbProductNum.Value;
            oSiteInBunch.Count = int.Parse(txbCount.Value);
            oSiteInBunch.NowAdmStatus = 1;
            oSiteInBunch.PreAdmStatus = 128;
            oSiteInBunch.PreAdmTime = DateTime.Now;
            oSiteInBunch.NowAdmTime = DateTime.Now;
        
            Msg msg = Center.EnsureOutBunch(int.Parse(txbBuildBunchID.Value), int.Parse(txbCount.Value), oSiteInBunch);
            if (msg.Status)
            {
                PageHelper.ShowAlertMsg(this, "确认成功");
            }
            else
            {
                PageHelper.ShowAlertMsg(this, msg.Message);
            }
        }

    }
}