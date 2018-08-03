using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Model;
using LingYunDemo.Data;
using LingYunDemo.Dal;
using System.Text;
using LingYunDemo.Common;
using LingYunDemo.Data.Enum;

namespace LingYunDemo.Web.Order
{
    public partial class PreSiteOutBunch : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           Msg msg=SiteStorageModel.QueryOutBunch();
          
               if (msg.Status)
               {
                   List<Tbl_SiteStorage> lBunch = msg.UserData as List<Tbl_SiteStorage>;
                   StringBuilder sBuild = new StringBuilder();

                   if (this.CurrentUserInfo.Type == (int)LoginType.主管密码)
                   {
                       foreach (Tbl_SiteStorage oBunch in lBunch)
                       {

                           sBuild.Append("<a href='EditSiteOutBunch.aspx?BuildBunchId=" + oBunch.BuildBatchID + "'>构建批次：" + oBunch.BuildBatchID + "</a>");
                       }
                   }
                   else if (this.CurrentUserInfo.Type == (int)LoginType.确认密码)
                   {

                       foreach (Tbl_SiteStorage oBunch in lBunch)
                       {

                           sBuild.Append("<a href='EnsureSiteOutBunch.aspx?BuildBunchId=" + oBunch.BuildBatchID + "'>构建批次：" + oBunch.BuildBatchID + "</a>");
                       }

                   }
                   else//暂留
                   {
                   }

                  
                   list.InnerHtml = sBuild.ToString();
               
           }
        }
    }
}