using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Helper.Web;
using LingYunDemo.Common;
using LingYunDemo.Dal;
using LingYunDemo.Model;
using LingYunDemo.Data;
using System.Text;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace LingYun.Web.Plan
{
    public partial class AddPlan :BasePage
    {
      
    
        protected override void OnInit(EventArgs e)
        {
            this.ValidateUserLoginState = false;
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                List<string> list = new List<string>();
                List<Tbl_User> lUsers = new List<Tbl_User>();
                Msg msg = UserLoginModel.GetAllUser();
                if (msg.Status)
                {
                    lUsers = msg.UserData as List<Tbl_User>;

                for (int i = 0; i < lUsers.Count; i++)
                {
                    list.Add("用户名:" + lUsers[i].Name);
                }
                ViewState["lUsers"] = lUsers;
         
                DropDownList2.DataSource = list;
                DropDownList2.DataBind();
                DropDownList3.DataSource = list;
                DropDownList3.DataBind();
                DropDownList4.DataSource = list;
                DropDownList4.DataBind();
                DropDownList5.DataSource = list;
                DropDownList5.DataBind();
                }
            }
        }




        protected void btnAdd_Click(object sender, EventArgs e)
        {



            List<Tbl_User> lUsers = ViewState["lUsers"] as List<Tbl_User>;

            int iPlanAdm = 1;
            int iDesignAdm = lUsers[DropDownList2.SelectedIndex].ID;

            int iProductAdm = lUsers[DropDownList3.SelectedIndex].ID;

            int iCenterStorateAdm = lUsers[DropDownList4.SelectedIndex].ID;

            int iSiteStorageAdm = lUsers[DropDownList5.SelectedIndex].ID;
     
          
                DateTime now = DateTime.Now;
                if ((this.CurrentUserInfo.Identify & 128) != 0)
                {
                    Tbl_Plan oPlan = new Tbl_Plan();
                    oPlan.ProjectName = txtProjectName.Text;
                    oPlan.PlanDate = now;
                    oPlan.Planer = this.CurrentUserInfo.Id;//项目人员id
                    oPlan.PlanerStatus = 128;
                    oPlan.PlanAdm = iPlanAdm;
                    oPlan.PlanAdmStatus = 128;
                    oPlan.DesignAdm = iDesignAdm;
                    oPlan.DesignAdmStatus = 1;
                    oPlan.ProductAdm = iProductAdm;
                    oPlan.ProductAdmStatus = 1;
                    oPlan.CenterStorageAdm = iCenterStorateAdm;
                    oPlan.CenterStorageAdmStatus = 1;
                    oPlan.SiteStorageAdm = iSiteStorageAdm;
                    oPlan.SiteStorageAdmStatus = 1;
                   Msg msg=PlanModel.AddPlan(oPlan);
                   if (msg.Status)
                   {
                           StatusClass oStatus = StatusClass.GetInstance();//此处运用单例模式
                           oStatus.CurrPlanId = this.CurrentUserInfo.Id;
                           oStatus.CurrStatus++;//已提交项目
            
                       PageHelper.ShowAlertMsg(this, "增加成功");
                   }
                   else
                   {
                       PageHelper.ShowAlertMsg(this,msg.Message);
                   }
                }
                else
                {
                    PageHelper.ShowAlertMsg(this, "您当前没有增加项目的权限");
                }
            } 
        
    }
}