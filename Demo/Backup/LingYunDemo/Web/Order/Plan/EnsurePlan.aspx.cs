using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using LingYunDemo.Dal;
using LingYunDemo.Model;
using LingYunDemo.Data;
using LingYunDemo.Helper.Web;

namespace LingYunDemo.Web.Order.Plan
{
    public partial class EnsurePlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sPlanId=this.Request["PlanId"];
                List<string> list = new List<string>();
                List<Tbl_User> lUsers = new List<Tbl_User>();
                Msg msg = UserLoginModel.GetAllUser();

       
                if (msg.Status)
                {
                    Msg planMsg = PlanModel.QyeryPlanById(int.Parse(sPlanId));
                    if (planMsg.Status)
                    {
                  
                        lUsers = msg.UserData as List<Tbl_User>;
                        for (int i = 0; i < lUsers.Count; i++)
                        {
                            list.Add("用户名：" + lUsers[i].Name);
                        }
                        ViewState["lUsers"]=lUsers;
                        DropDownList2.DataSource = list;
                        DropDownList2.DataBind();
                        DropDownList3.DataSource = list;
                        DropDownList3.DataBind();
                        DropDownList4.DataSource = list;
                        DropDownList4.DataBind();
                        DropDownList5.DataSource = list;
                        DropDownList5.DataBind();
                        Tbl_Plan oPlan = planMsg.UserData as Tbl_Plan;
                        txtProjectName.Text = oPlan.ProjectName;
                        for (int i = 0; i < lUsers.Count; i++)
                        {
                         
                            if (lUsers[i].ID == oPlan.DesignAdm)
                            {
                                DropDownList2.SelectedIndex = i;
                            }
                            if (lUsers[i].ID == oPlan.ProductAdm)
                            {
                                DropDownList3.SelectedIndex = i;
                            }
                            if (lUsers[i].ID ==oPlan.CenterStorageAdm)
                            {
                                DropDownList4.SelectedIndex = i;
                            }
                            if (lUsers[i].ID == oPlan.SiteStorageAdm)
                            {
                                DropDownList5.SelectedIndex = i;
                            }

                        }
                        
                       
                    
                    
                    }

                   

                }
             
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string sPlanId = this.Request["PlanId"];
            List<Tbl_User> lUsers = ViewState["lUsers"] as List<Tbl_User>;

            int iDesignAdm = lUsers[DropDownList2.SelectedIndex].ID;

            int iProductAdm = lUsers[DropDownList3.SelectedIndex].ID;

            int iCenterStorateAdm = lUsers[DropDownList4.SelectedIndex].ID;

            int iSiteStorageAdm = lUsers[DropDownList5.SelectedIndex].ID;
            Tbl_Plan oPlan = new Tbl_Plan();
            oPlan.PlanID = int.Parse(sPlanId);
            oPlan.PlanAdm = 1;
            oPlan.PlanAdmStatus = 128;
            oPlan.DesignAdm = iDesignAdm;
            oPlan.ProductAdm = iProductAdm;
            oPlan.CenterStorageAdm = iCenterStorateAdm;
            oPlan.SiteStorageAdm = iSiteStorageAdm;

          Msg msg = PlanModel.EnsurePlan(oPlan);
          if (msg.Status)
          {
              PageHelper.ShowAlertMsg(this, "您已成功确认项目");

          }
          else
          {
              PageHelper.ShowAlertMsg(this, msg.Message);
            }
        }

     
        
    }
}