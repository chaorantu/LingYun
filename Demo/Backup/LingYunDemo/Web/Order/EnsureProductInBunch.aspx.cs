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

namespace LingYunDemo.Web.Order
{
    public partial class EnsureProductInBunch : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string MetriesId = this.Request["BuildBunchId"];

            Msg MetriesMsg = ProductModel.GetUnsureInBunch(int.Parse(MetriesId));
            Tbl_ProductBatch oMatries = MetriesMsg.UserData as Tbl_ProductBatch;
            if (oMatries != null)
            {
                txbPlanId.Value = oMatries.PlanID.ToString();
                txbMateriesID.Value = oMatries.MateriesID.ToString();
                txbBuildID.Value = oMatries.BuildID.ToString();
                txbBuildName.Value = oMatries.BuildName;
                txbCount.Value = oMatries.Count.ToString();
                txbMetriesType.Value = oMatries.MateriesType;
                txbProductNum.Value = oMatries.ProjectName;
                txbProjectName.Value = oMatries.ProjectName;
                hiddCount.Value = oMatries.Count.ToString() ;
                txbBuildBatchID.Value = oMatries.BuildBatchID.ToString();
            }

        }

        protected void ensure_Click(object sender, EventArgs e)
        {
            int iTotalCount = int.Parse(hiddCount.Value);
            string metriesId = this.Request["BuildBunchId"];
            int count=int.Parse(txbCount.Value);
         //  bool  isHave=ProductModel.QueryInBunch(int.Parse(metriesId));
           Tbl_ProductStorage oStorage = new Tbl_ProductStorage();
           oStorage.BuildBatchID = int.Parse(txbBuildBatchID.Value);
           oStorage.PlanID = int.Parse(txbPlanId.Value);
           oStorage.Time = DateTime.Now;
           oStorage.MateriesID = int.Parse(txbMateriesID.Value);
           oStorage.BuildID =txbBuildID.Value;
           oStorage.BuildName = txbBuildName.Value.ToString();
           oStorage.MateriesType = txbMetriesType.Value.ToString();
           oStorage.PreAdmTime = DateTime.Now;
           oStorage.PreAdmStatus = 128;
           oStorage.NowAdmStatus = 1;
           oStorage.NowAdmTime = DateTime.Now;
           oStorage.ProjectName = txbProjectName.Value;
           oStorage.WorkMapID = txbProductNum.Value;
            oStorage.InCount=int.Parse(txbCount.Value);
            if (iTotalCount >= count)
            {

                Msg msg = ProductModel.UpdateInBunch(int.Parse(metriesId), count, oStorage);
                if (msg.Status)
                {
                    PageHelper.ShowAlertMsg(this, "编辑并确认成功");
                }
                else
                {
                    PageHelper.ShowAlertMsg(this, msg.Message);
                }
                //}
                //else
                //{
                //    Tbl_ProductBatch oBunch = new Tbl_ProductBatch();
                //    oBunch.PlanID = int.Parse(txbPlanId.Value);
                //    oBunch.MateriesID = int.Parse(txbMateriesID.Value);
                //    oBunch.BuildID = int.Parse(txbBuildID.Value);
                //    oBunch.BuildName = txbBuildName.Value.ToString();
                //    oBunch.MateriesType = txbMetriesType.Value.ToString();
                //    oBunch.PreAdmTime = DateTime.Now;
                //    oBunch.WorkMapID = txbProductNum.Value;
                //    oBunch.ProjectName = txbProjectName.Value;

                //    oBunch.NowAdmStatus = 128;
                //    oBunch.NowAdmTime = DateTime.Now;
                //    oBunch.Count = int.Parse(txbCount.Value);
                //    Msg bunchMsg = ProductModel.EnsureInBunch(oBunch, oStorage);
                //    if (bunchMsg.Status)
                //    {
                //        PageHelper.ShowAlertMsg(this, "确认成功");
                //    }
                //    else
                //    {
                //        PageHelper.ShowAlertMsg(this, bunchMsg.Message);
                //    }

            }

        }
    }
}