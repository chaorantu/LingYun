using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Data.Enum;
using LingYunDemo.Dal;
using LingYunDemo.Model;
using LingYunDemo.Data;
using System.Web.Script.Serialization;

namespace LingYunDemo.Web.android
{
    public partial class AdmEnsure : System.Web.UI.Page
    {
        public class ReturnMsg
        {
            public int Status
            {
                get;
                set;
            }
            public string Massage
            {
                get;
                set;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ReturnMsg ret = new ReturnMsg();
            ret.Status = 0;
            this.Response.ContentType = "text/plain";
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string sImei = this.Request["imei"];
            string Id = this.Request["username"];
            string table = this.Request["tablename"];
            if (table != null)
            {

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
                else
                {
                    ret.Status = 0;
                }

            }
            this.Response.Write(jss.Serialize(ret));
     

        }
    }
}