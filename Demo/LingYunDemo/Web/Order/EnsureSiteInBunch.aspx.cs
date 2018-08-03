using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Model;
using LingYunDemo.Data;
using LingYunDemo.Dal;
using LingYunDemo.Helper.Web;

namespace LingYunDemo.Web.Order
{
    public partial class EnsureSiteInBunch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sBuildBunchId = this.Request["BuildBunchId"];
          Msg msg=SiteStorageModel.QueryInBunchById(int.Parse(sBuildBunchId));
          if (msg.Status)
          {
              Tbl_SiteStorageBatch oBunch = msg.UserData as Tbl_SiteStorageBatch;
              txbPlanId.Value = oBunch.PlanID.ToString();
              txbMateriesID.Value = oBunch.MateriesID.ToString();
              txbBuildID.Value = oBunch.BuildID.ToString();
              txbBuildName.Value = oBunch.BuildName;
              txbCount.Value = oBunch.Count.ToString();
              txbMetriesType.Value = oBunch.MateriesType;
              txbProjectName.Value = oBunch.ProjectName;
              txbBuildBunchID.Value = oBunch.BuildBatchID.ToString();
              txbProductNum.Value = oBunch.WorkMapID.ToString();
          }
        }

        protected void Ensure_Click(object sender, EventArgs e)
        {
            Tbl_SiteStorage oBunch = new Tbl_SiteStorage();
            oBunch.PlanID = int.Parse(txbPlanId.Value);
            oBunch.Time = DateTime.Now;
            oBunch.MateriesID = int.Parse(txbMateriesID.Value);
            oBunch.BuildBatchID = int.Parse(txbBuildBunchID.Value);
            oBunch.BuildID = txbBuildID.Value;
            oBunch.BuildName = txbBuildName.Value.ToString();
            oBunch.MateriesType = txbMetriesType.Value.ToString();
            oBunch.PreAdmTime = DateTime.Now;
            oBunch.PreAdmStatus = 128;
            oBunch.InCount = int.Parse(txbCount.Value);
            oBunch.NowAdmStatus = 1;
            oBunch.NowAdmTime = DateTime.Now;
            oBunch.MateriesTasbleID = 1;
            oBunch.ProjectName = txbProjectName.Value;
            oBunch.WorkMapID = txbProductNum.Value;
          Msg msg= SiteStorageModel.EnsureInBunch(int.Parse(txbBuildBunchID.Value), oBunch);
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