using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using LingYunDemo.Model;
using LingYunDemo.Data;

namespace LingYunDemo.Android
{
    /// <summary>
    /// PrintService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://Lingyun/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class PrintService : System.Web.Services.WebService
    {

        [WebMethod]
        public string AdmEnsure(string Id,string table)
        {
       
            JavaScriptSerializer jss = new JavaScriptSerializer();
            ////  string sImei = this.Request["imei"];
            //string Id = this.Context.Request.QueryString["id"];
            //string table =this.Context.Request.QueryString["table"];
            if (table != null)
            {
                LingYunDemo.Web.android.AdmEnsure.ReturnMsg ret = new LingYunDemo.Web.android.AdmEnsure.ReturnMsg();
                ret.Status = 1;
                if (table.Equals("Tbl_Materies"))
                {
                    Msg msg = MetriesModel.AndroidEnsure(int.Parse(Id));
                    if (msg.Status)
                    {
                        ret.Status = 1;
                    }
                }
                else if (table.Equals("Tbl_ProductBatch"))
                {
                    Msg msg = ProductModel.AndroidInBunch(int.Parse(Id));
                    if (msg.Status)
                    {
                        ret.Status = 1;
                    }

                }
                else if (table.Equals("Tbl_OutProductBatch"))
                {
                    Msg msg = ProductModel.AndroidOutEnsure(int.Parse(Id));
                    if (msg.Status)
                    {
                        ret.Status = 1;
                    }

                }
                else if (table.Equals("Tbl_CenterStorageBatch"))
                {
                    Msg msg = Center.AndroidInEnsure(int.Parse(Id));
                    if (msg.Status)
                    {
                        ret.Status = 1;
                    }
                }
                else if (table.Equals("Tbl_OutCenterStorage"))
                {
                    Msg msg = Center.AndroidOutBatch(int.Parse(Id));
                    if (msg.Status)
                    {
                        ret.Status = 1;
                    }
                }
                else if (table.Equals("Tbl_SiteStorageBatch"))
                {
                    Msg msg = SiteStorageModel.AndroidInEnsure(int.Parse(Id));
                    if (msg.Status)
                    {
                        ret.Status = 1;
                    }
                }
                else if (table.Equals("Tbl_OutSiteStorage"))
                {
                    Msg msg = SiteStorageModel.AndroidOutBatch(int.Parse(Id));
                    if (msg.Status)
                    {
                        ret.Status = 1;
                    }
                }
                //this.Response.Write(jss.Serialize(ret));
                //this.Response.Write("#");


            }
            //this.Context.Response.Write(Id);
            //this.Context.Response.Write(table);
            return Id;
        }

    }
}
