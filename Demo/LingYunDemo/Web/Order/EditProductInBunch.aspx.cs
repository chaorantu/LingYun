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
using LingYunDemo.Common;
using LingYunDemo.Data.Enum;
using System.Threading;
using LingYunDemo.Android;

namespace LingYunDemo.Web.Order
{
    public partial class EditProductInBunch : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string MetriesId = this.Request["MateriesID"];

                Msg MetriesMsg = ProductModel.GetMetriesByMatriesid(int.Parse(MetriesId));
                Tbl_Materies oMatries = MetriesMsg.UserData as Tbl_Materies;
                if (oMatries != null)
                {
                    txbPlanId.Value = oMatries.PlanID.ToString();
                    txbMateriesID.Value = oMatries.MateriesID.ToString();
                    txbBuildID.Value = oMatries.BuildNum;
                    txbBuildName.Value = oMatries.BuildName;
                    txbCount.Value = oMatries.TotalNum.ToString();
                    txbMetriesType.Value = oMatries.MateriesType;
                    txbProductNum.Value = oMatries.ProcessingNum;
                    txbProjectName.Value = oMatries.ProjectName;
                    hiddCount.Value = oMatries.TotalNum.ToString();

                }


            }
        }
        public delegate void CallBack(Msg msg);
        protected void ensure_Click(object sender, EventArgs e)
        {
            //首先判断是否存在此批次
            string MetriesId = this.Request["MateriesID"];
           

            Tbl_ProductBatch oBunch = new Tbl_ProductBatch();
            oBunch.PlanID = int.Parse(txbPlanId.Value);
            oBunch.MateriesID = int.Parse(txbMateriesID.Value);
            oBunch.BuildID = txbBuildID.Value;
            oBunch.BuildName = txbBuildName.Value;
            oBunch.MateriesType = txbMetriesType.Value;
            oBunch.MateriesTasbleID = int.Parse(txbMateriesID.Value);
            oBunch.ProjectName = txbProjectName.Value;
            oBunch.Time = DateTime.Now;
            oBunch.WorkMapID = txbProductNum.Value;
            oBunch.Count = int.Parse(txbCount.Value);
            oBunch.PreAdmStatus = 1;
            oBunch.NowAdmStatus = 1;

            Msg msg = ProductModel.EditInBunch(oBunch);
            if(msg.Status)
            {

                PageHelper.ShowAlertMsg(this, "编辑成功");

            }
            else
            {
                PageHelper.ShowAlertMsg(this, "编辑失败:" + msg.Message);
            }
            //CallBack call =ReturnMsg;
            //Thread thread = new Thread(() => GetBarCode(oBunch, call));
            //thread.IsBackground = true;
            //thread.Start();
         
                
        }
        void ReturnMsg(Msg msg)
        {
            if (msg.Status)
            {
                List<string> list = msg.UserData as List<string>;
                
                if (msg.Status)
                {

                 //   CsPrint print = new CsPrint();
                  //  print.bartext = list;
                  //  print.print();
                }
            }
        }
          void GetBarCode(Tbl_ProductBatch oBunch,CallBack call)
        {
            Msg msg = ProductModel.EditInBunch(oBunch);
           
            if (call != null)
                call(msg);
          
        }
        
    }
}