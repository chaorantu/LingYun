using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Data;
using LingYunDemo.Model;
using LingYunDemo.Dal;
using System.Text;
using LingYunDemo.Common;
using LingYunDemo.Data.Enum;

namespace LingYunDemo.Web.Order
{
    public partial class PreSiteInBunch :BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Msg msg = SiteStorageModel.QueryInBunch();
            if (msg.Status)
            {
                List<Tbl_SiteStorageBatch> lBunch = msg.UserData as List<Tbl_SiteStorageBatch>;
             StringBuilder sBuild = new StringBuilder();

              if (this.CurrentUserInfo.Type == (int)LoginType.确认密码)
             {

                 foreach (Tbl_SiteStorageBatch oBunch in lBunch)
                 {

                     sBuild.Append("<li><a href='EnsureSiteInBunch.aspx?BuildBunchId=" + oBunch.BuildBatchID + "'>批次:" + oBunch.BuildBatchID + "</a><li>");
                 }
             }
             else//暂留
             {
             }

                 
                   list.InnerHtml=sBuild.ToString();
            }

        }
    }
}