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
using LingYunDemo.Android;

namespace LingYunDemo.Web.Order
{
    public partial class EditSiteOutBunch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string BuildBunchId = this.Request["BuildBunchId"];

            Msg msg = SiteStorageModel.QueryStorageById(int.Parse(BuildBunchId));
            Tbl_SiteStorage oStorage = msg.UserData as Tbl_SiteStorage;
            if (oStorage != null)
            {
                txbPlanId.Value = oStorage.PlanID.ToString();
                txbMateriesID.Value = oStorage.MateriesID.ToString();
                txbBuildID.Value = oStorage.BuildID.ToString();
                txbBuildName.Value = oStorage.BuildName;
                txbCount.Value = oStorage.InCount.ToString();
                txbMetriesType.Value = oStorage.MateriesType;
                txbProjectName.Value = oStorage.ProjectName;
                txbBuildBunchID.Value = oStorage.BuildBatchID.ToString();
                txbProductNum.Value = oStorage.WorkMapID.ToString();
              
            }
        }

        protected void ensure_Click(object sender, EventArgs e)
        {

           bool isHave=SiteStorageModel.QueryOutBunchById(int.Parse(txbBuildBunchID.Value));
           if (isHave)
           {
             Msg msg= SiteStorageModel.UpdateOutBunch(int.Parse(txbBuildBunchID.Value),int.Parse(txbCount.Value));
             if (msg.Status)
             {
                 PageHelper.ShowAlertMsg(this, "编辑成功");
             }
             else
             {
                 PageHelper.ShowAlertMsg(this, msg.Message);
             }
           
           }
           else
           {
               Tbl_OutSiteStorage oBunch = new Tbl_OutSiteStorage();
               oBunch.PlanID = int.Parse(txbPlanId.Value);
               oBunch.Time = DateTime.Now;
               oBunch.MateriesID = int.Parse(txbMateriesID.Value);
               oBunch.BuildID = txbBuildID.Value;
               oBunch.BuildName = txbBuildName.Value.ToString();
               oBunch.MateriesType = txbMetriesType.Value.ToString();
               oBunch.PreAdmTime = DateTime.Now;
               oBunch.Count = int.Parse(txbCount.Value);
               oBunch.BuildBatchID = int.Parse(txbBuildBunchID.Value);
               oBunch.ProjectName = txbProjectName.Value;
               oBunch.MateriesTasbleID = 0;
               oBunch.Time = DateTime.Now;
               oBunch.WorkMapID = txbProductNum.Value;
              Msg msg=SiteStorageModel.EditOutBunch(oBunch);
              if (msg.Status)
              {
                  PageHelper.ShowAlertMsg(this, "编辑成功");
              }
              else
              {
                  PageHelper.ShowAlertMsg(this, msg.Message);
              }

           
           
           }
            
        }
    }
}