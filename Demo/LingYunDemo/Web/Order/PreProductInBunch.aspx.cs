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
using LingYunDemo.Helper.Web;

namespace LingYunDemo.Web.Order
{
    public partial class PreEditProductInBunch :BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
      
            StringBuilder sBuild = new StringBuilder();
            
                    if (this.CurrentUserInfo.Type == (int)LoginType.主管密码)
                    {
                        Msg msg = ProductModel.GetAllMetaries();
                        if (msg.Status)
                        {

                            List<Tbl_Materies> lMetries = msg.UserData as List<Tbl_Materies>;
                            if (lMetries.Count > 0)
                            {
                        for (int i = 0; i < lMetries.Count; i++)
                        {

                            sBuild.Append(@"<li><a href='EditProductInBunch.aspx?MateriesID=" + lMetries[i].MateriesID + "'>" + lMetries[i].MateriesID + "</a></li>");
                        }
                            }
                        }
                    }
                    else if (this.CurrentUserInfo.Type == (int)LoginType.确认密码)
                    {
                        Msg msg = ProductModel.GetPreUnsureInBatch();
                        if (msg.Status)
                        {

                            List<Tbl_ProductBatch> lMetries = msg.UserData as List<Tbl_ProductBatch>;//批次表
                            if (lMetries.Count > 0)
                            {
                         for (int i = 0; i < lMetries.Count; i++)
                        {

                            sBuild.Append(@"<li><a href='EnsureProductInBunch.aspx?MateriesID=" + lMetries[i].BuildBatchID + "'>批次编号" + lMetries[i].BuildBatchID + "</a></li>");
                        }
                            }
                        }
                    

                    }
                    else//暂留
                    {
                    }
                
           

           list.InnerHtml = sBuild.ToString();

        }
    }
}