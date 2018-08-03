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
    public partial class PreProductOutBunch :BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           Msg msg=ProductModel.QueryProductOutBunch();
           if (msg.Status)
           {

               List<Tbl_ProductStorage> lStorage = msg.UserData as List<Tbl_ProductStorage>;
               if (lStorage.Count > 0)
               {
                   StringBuilder sBuild = new StringBuilder();
                   if (this.CurrentUserInfo.Type == (int)LoginType.主管密码)
                   {
                       foreach (Tbl_ProductStorage oStorage in lStorage)
                       {

                           sBuild.Append("<li><a href='EditProductOutBunch.aspx?BuildBunchId=" + oStorage.BuildBatchID + "'>批次编号:" + oStorage.BuildBatchID + "</a></li>");
                       }
                   }
                   else if (this.CurrentUserInfo.Type == (int)LoginType.确认密码)
                   {

                       foreach (Tbl_ProductStorage oStorage in lStorage)
                       {

                           sBuild.Append("<li><a href='EnsureProductOutBunch.aspx?BuildBunchId=" + oStorage.BuildBatchID + "'>批次编号:" + oStorage.BuildBatchID + "</a></li>");
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
}