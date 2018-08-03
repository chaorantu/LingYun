using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;


namespace LingYun.Web.Plan
{
    public partial class PrePlan : BasePage
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                Msg msg = PlanModel.QueryUnsurePlan();

                if (msg.Status)
                {
                 List<Tbl_Plan>   lPlans = msg.UserData as List<Tbl_Plan>;

                    if (lPlans.Count > 0)
                    {
                        StringBuilder build2 = new StringBuilder();
                        int all = (lPlans.Count / 5);
                        if (lPlans.Count / 5 != 0)
                        {
                            all++;
                        }
                      
                        StringBuilder build = new StringBuilder();
                        if (this.CurrentUserInfo.Type == (int)LoginType.主管密码)
                        {
                            identify.Value = "1";
                            for (int i = 0; i < lPlans.Count; i++)
                            {
                             
                                build.Append(@"<div onclick='urlLocation(" + lPlans[i].PlanID + ")' style='margin-bottom:10px;padding:12px 15px;line-height:13px; background:#E5E3E4;'><strong>项目名：" + lPlans[i].ProjectName + "</strong><span style='right:8px;position:absolute'><img onclick='urlLocation(" + lPlans[i].PlanID + ")' alt='' style='height: 16px;'src='../../Images/minicalendar/ic_enter.png'/></span></div>");
                            
                            }

                        }
                        else if (this.CurrentUserInfo.Type == (int)LoginType.确认密码)
                        {
                            identify.Value = "2";
                            for (int i = 0; i < lPlans.Count; i++)
                            {
                              
                                string sPlanId = lPlans[i].PlanID.ToString();
                              
                                build.Append(@"<div onclick='urlLocation(" + lPlans[i].PlanID + ")' style='margin-bottom:10px;padding:12px 15px;line-height:13px; background:#E5E3E4;'><strong>项目名：" + lPlans[i].ProjectName + "</strong><span style='right:8px;position:absolute'><img alt='' onclick='urlLocation(" + lPlans[i].PlanID + ")' style='height: 16px;'src='../../Images/minicalendar/ic_enter.png'/></span></div>");
                            
                            }

                        }
                        else//暂留
                        {
                        }

                    
                        list.InnerHtml = build.ToString();


                    }
                    else
                    {
                        PageHelper.ShowAlertMsg(this, "您当前没有待编辑的项目");
                    }

                }
                else
                {
                    PageHelper.ShowAlertMsg(this, msg.Message);
                }
            }

         
        }
    }
}