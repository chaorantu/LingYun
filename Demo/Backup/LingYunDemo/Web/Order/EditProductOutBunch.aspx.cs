using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using LingYunDemo.Model;
using LingYunDemo.Data;
using LingYunDemo.Dal;
using LingYunDemo.Helper.Web;
using LingYunDemo.Android;

namespace LingYunDemo.Web.Order
{
    public partial class EditProductOutBunch : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string BuildBunchId = this.Request["BuildBunchId"];

                Msg msg = ProductModel.QueryProductStorageById(int.Parse(BuildBunchId));
                Tbl_ProductStorage oStorage = msg.UserData as Tbl_ProductStorage;
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
                    txbPrintCount.Text = oStorage.InCount.ToString();
                }


            }
        }
        protected void ensure_Click(object sender, EventArgs e)
        {
            //首先判断是否存在此批次
            string MetriesId = this.Request["BuildBunchId"];
            Tbl_OutProductBatch oBunch = new Tbl_OutProductBatch();
            oBunch.PlanID = int.Parse(txbPlanId.Value);
            oBunch.MateriesID = int.Parse(txbMateriesID.Value);
            oBunch.BuildID = txbBuildID.Value;
            oBunch.BuildName = txbBuildName.Value;
            oBunch.MateriesType = txbMetriesType.Value;
            oBunch.MateriesTasbleID = int.Parse(txbMateriesID.Value);
            oBunch.ProjectName = txbProductNum.Value;
            oBunch.Time = DateTime.Now;
            oBunch.WorkMapID = txbProductNum.Value;
            oBunch.Count = int.Parse(txbCount.Value);
            oBunch.PreAdmStatus = 1;
            oBunch.NowAdmStatus = 1;
            oBunch.PreAdmTime = DateTime.Now;
            oBunch.NowAdmTime = DateTime.Now;
            oBunch.BuildBatchID = int.Parse(txbBuildBunchID.Value);
            Msg msg = ProductModel.EditOutBunch(oBunch);
            if (CheckBox1.Checked)
            {
                Msg printMsg = PrintModel.GetBarCodeNum(oBunch.BuildBatchID, int.Parse(txbPrintCount.Text));
                if (printMsg.Status)
                {
                    CsPrint print = new CsPrint();
                    print.bartext = printMsg.UserData as List<string>;
                    print.printpreview();

                }
            }
            if (msg.Status)
            {
                PageHelper.ShowAlertMsg(this, "编辑成功");

            }
            else
            {
                PageHelper.ShowAlertMsg(this, "编辑失败:"+msg.Message);
            }
        }
    }
}