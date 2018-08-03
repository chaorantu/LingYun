using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using LingYunDemo.Data;
using LingYunDemo.Model;
using LingYunDemo.Dal;
using LingYunDemo.Common;
using LingYunDemo.Data.Enum;

namespace LingYunDemo.Web.Order.CenterStorage
{
    public partial class PreEnsureOutBunch : BasePage            //页面一：显示确认批次并进行选择
    {

        protected void Page_Load(object sender, EventArgs e)
        {


            Msg msg = Center.QueryOutBunch();

            if (msg.Status)
            {
                List<Tbl_CenterStorage> lBunch = msg.UserData as List<Tbl_CenterStorage>;
                StringBuilder sBuild = new StringBuilder();

                if (this.CurrentUserInfo.Type == (int)LoginType.主管密码)
                {
                    foreach (Tbl_CenterStorage oBunch in lBunch)
                    {

                        sBuild.Append("<li><a href='EditOutBunch.aspx?BuildBunchId=" + oBunch.BuildBatchID + "'>构建批次" + oBunch.BuildBatchID + "</a></li>");
                    }
                }
                else if (this.CurrentUserInfo.Type == (int)LoginType.确认密码)
                {

                    foreach (Tbl_CenterStorage oBunch in lBunch)
                    {

                        sBuild.Append("<li><a href='EnsureOutBunch.aspx?BuildBunchId=" + oBunch.BuildBatchID + "'>构建批次" + oBunch.BuildBatchID + "</a></li>");
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