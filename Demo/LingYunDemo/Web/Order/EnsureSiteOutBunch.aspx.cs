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
    public partial class EnsureSiteOutBunch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sBuildBunchId = this.Request["BuildBunchId"];
                Msg msg = SiteStorageModel.QueryOutBunch(int.Parse(sBuildBunchId));
                if (msg.Status)
                {
                    Tbl_OutSiteStorage oBunch = msg.UserData as Tbl_OutSiteStorage;
                    txbPlanId.Value = oBunch.PlanID.ToString();
                    txbMateriesID.Value = oBunch.MateriesID.ToString();
                    txbBuildID.Value = oBunch.BuildID.ToString();
                    txbBuildName.Value = oBunch.BuildName;
                    txbCount.Value = oBunch.Count.ToString();
                    txbMetriesType.Value = oBunch.MateriesType;
                    txbProjectName.Value = oBunch.ProjectName;
                    txbBuildBunchID.Value = oBunch.BuildBatchID.ToString();
                    txbProductNum.Value = oBunch.WorkMapID;
                }
            }
        }
        protected void Ensure_Click(object sender, EventArgs e)
        {
            Msg msg = SiteStorageModel.EnsureOutBunch(int.Parse(txbBuildBunchID.Value),int.Parse(txbCount.Value));
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