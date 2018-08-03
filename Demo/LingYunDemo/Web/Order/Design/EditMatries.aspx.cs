using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using LingYunDemo.Model;
using LingYunDemo.Data;
using LingYunDemo.Dal;
using LingYunDemo.Helper.Web;

namespace LingYunDemo.Web.Order.Design
{
    public partial class EditMatries : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            string sPlanId=this.Request["PlanID"];

            txbPlanId.Text = sPlanId.ToString();
    

        
        
        
        }

        protected void Ensure(object sender, EventArgs e)
        {
            string sPlanId = this.Request["PlanID"];
            bool isHave = MetriesModel.GetMetriesById(int.Parse(sPlanId));
            Tbl_Materies oMatries = new Tbl_Materies();
            oMatries.PlanID = int.Parse(sPlanId);
            oMatries.ProjectName = txbProjectName.Text;
            oMatries.TotalNum = int.Parse(txbCount.Text);
            oMatries.MateriesType = txbMatriesType.Text;
            oMatries.Date = DateTime.Now;
            oMatries.BuildName = txbBuildName.Text;
            oMatries.BuildNum = txbBuildId.Text;
            oMatries.NowAdmStatus = 1;
            oMatries.ProcessingNum = txbWorkMapId.Text;
            if (!isHave)//不存在，插入
            {
               Msg msg=MetriesModel.AddMateries(oMatries);
               if (msg.Status)
               {
                   PageHelper.ShowAlertMsg(this, "编辑材料表成功");
               }
               else
               {
                   PageHelper.ShowAlertMsg(this, msg.Message);
               }

            }
            else
            {
                Msg msg = MetriesModel.UpdateMateries(oMatries);
                if (msg.Status)
                {
                    PageHelper.ShowAlertMsg(this, "修改材料表成功");
                }
                else
                {
                    PageHelper.ShowAlertMsg(this, msg.Message);
                }
            }
        }

      
    }
}