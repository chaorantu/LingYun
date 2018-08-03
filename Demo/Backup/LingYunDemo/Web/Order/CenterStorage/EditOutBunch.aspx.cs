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


namespace LingYunDemo.Web.Order.CenterStorage                                             
{
    public partial class EditOutBunch : System.Web.UI.Page                          //员工确认出库信息
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string BuildBunchId = this.Request["BuildBunchId"];

            Msg msg = Center.QueryStorageById(int.Parse(BuildBunchId));
            Tbl_CenterStorage oStorage = msg.UserData as Tbl_CenterStorage;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }

        protected void ensure_Click(object sender, EventArgs e)
        {
            bool isHave = Center.QueryIsHaveOutBunch(int.Parse(txbBuildBunchID.Value));
            if (isHave)
            {
                Msg msg = Center.UpdateOutBunch(int.Parse(txbBuildBunchID.Value), int.Parse(txbCount.Value));
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
                Tbl_OutCenterStorage oBunch = new Tbl_OutCenterStorage();
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
                oBunch.WorkMapID = txbProductNum.Value;
                Msg msg = Center.EditOutBunch(oBunch);
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