using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Data;
using LingYunDemo.Dal;
using System.Text;
using LingYunDemo.Common;
using LingYunDemo.Data.Enum;
using LingYunDemo.Model;

namespace LingYunDemo.Web.Order.CenterStorage
{
    public partial class PreCenterInBunch : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Msg msg = Center.QueryWaitInBunch();
            if (msg.Status)
            {
                List<Tbl_CenterStorageBatch> lBunch = msg.UserData as List<Tbl_CenterStorageBatch>;
                StringBuilder sBuild = new StringBuilder();

                if (this.CurrentUserInfo.Type == (int)LoginType.确认密码)
                {

                    foreach (Tbl_CenterStorageBatch oBunch in lBunch)
                    {

                        sBuild.Append("<li><a href='EnsureCenterInBunch.aspx?BuildBunchId=" + oBunch.BuildBatchID + "'>构建批次" + oBunch.BuildBatchID + "</a></li>");
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