using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Timers;
using LingYunDemo.Common;
using LingYunDemo.Data;
using LingYunDemo.Data.Enum;

namespace LingYunDemo.Web
{
    public partial class Header :BasePage
    {
        protected override void OnInit(EventArgs e)
        {
            this.ValidateUserLoginState = true;
            base.OnInit(e);
        }
    
   
        protected void Page_Load(object sender, EventArgs e)
        {
            this.currUsername.InnerText = this.CurrentUserInfo.UserName;
            int iCurrInden=this.CurrentUserInfo.Identify;
            if (iCurrInden == (int)UserData.系统管理员)
            { this.currIdentify.InnerText = "系统管理员"; }
            else if(iCurrInden==(int)UserData.项目主管)
            { this.currIdentify.InnerText = "项目员";}
            else if (iCurrInden == (int)UserData.设计主管)
            { this.currIdentify.InnerText = "设计主管"; }
                else if (iCurrInden == (int)UserData.加工主管)
            { this.currIdentify.InnerText = "加工主管"; }
            else if (iCurrInden == (int)UserData.中心仓库主管)
            { this.currIdentify.InnerText = "中心仓库主管"; }
            else if (iCurrInden == (int)UserData.现场仓库主管)
            { this.currIdentify.InnerText = "现场仓库主管"; }
            else if (iCurrInden == (int)UserData.员工)
            { this.currIdentify.InnerText = "员工"; }
                StatusClass status = StatusClass.GetInstance();
            //if (status.CurrPlanId == (int)CurrentStatus.默认)
            //{
            //    liStatus.InnerHtml = "<span>当前状态：</span><span style='background-color:White'>待提交项目</span>";
            //}
            //else if (status.CurrPlanId == (int)CurrentStatus.已提交项目)
            //{
            //    liStatus.InnerHtml = "<span>当前状态：</span><span>提交</span><span style='background-color:Red'>上传</span>";
            //}
            //else if (status.CurrPlanId == (int)CurrentStatus.已上传物料表)
            //{
            //    liStatus.InnerHtml = "<span>当前状态：</span><span >提交-></span><span style='background-color:Red'>上传-></span><span style='background-color:Red'>复审</span>";
            //}
            //else if (status.CurrPlanId == (int)CurrentStatus.已复审)
            //{
            //    liStatus.InnerHtml = "<span>当前状态：</span><span >提交-></span><span>上传-></span><span>复审-></span></span><span style='background-color:Red'>确认</span>";
            //}
            //else if (status.CurrPlanId == (int)CurrentStatus.已确认物料表)
            //{
            //    liStatus.InnerHtml = "<span>当前状态：</span><span >提交></span><span>上传-></span><span >复审</span><span>确认-></span><span style='background-color:Red' >加工</span>";
            //}
            //else if (status.CurrPlanId == (int)CurrentStatus.已加工)
            //{
            //    liStatus.InnerHtml = "<span>当前状态：</span><span >提交></span><span>上传-></span><span >复审</span><span>确认-></span><span>加工-></span></span><span style='background-color:Red' >中心仓储</span>";
            //}
            //else if (status.CurrPlanId == (int)CurrentStatus.已出中心仓储)
            //{
            //    liStatus.InnerHtml = "<span>当前状态：</span><span >提交></span><span>上传-></span><span >复审</span><span>确认-></span><span>加工-></span></span><span>中心仓储->/span>"
            //        + "<span style='background-color:Red' >现场仓储</span>";
            //}
            //else if (status.CurrPlanId == (int)CurrentStatus.已出现场仓储)
            //{
            //    liStatus.InnerHtml = "<span>当前状态：</span><span >提交></span><span>上传-></span><span >复审</span><span>确认-></span><span>加工-></span></span><span>中心仓储->/span>"
            //    + "<span >现场仓储</span><span style='background-color:Red' >领料</span>";
            //}
        }

     

        protected void UserLogOut(object sender, EventArgs e)
        {
            this.LogOut();
            Response.Write("<script language='javascript'>parent.location='/Web/UserLogin.aspx'</script>"); 
        }
    }
}