using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Model;
using LingYunDemo.Data;
using LingYunDemo.Data.Enum;
using LingYunDemo.Dal;
using System.Web.Script.Serialization;

namespace LingYunDemo.Web.android
{
    public partial class GetBarCodeInfo : System.Web.UI.Page
    {

        public class BarCodeRet
        {
            public int Status
            {
                get;
                set;
            }
            public string Message
            {
                get;
                set;
            }
            public int BuildBunchId
            {
                get;
                set;
            }
            public string CreateTime
            {
                get;
                set;
            }
            public string ProjectName
            {
                get;
                set;
            }
            public string MetariesType
            {
                get;
                set;
            }
            public string BuildName
            {
                get;
                set;
            }
            public string WorkMapId
            {
                get;
                set;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
              JavaScriptSerializer jss = new JavaScriptSerializer();
            string sBarcodeNum=this.Request["BarCodeNum"];
           Msg msg= PrintModel.GetBarCodeNum(sBarcodeNum);
           BarCodeRet ret = new BarCodeRet();
           if (msg.Status)
           {
               Tbl_BarCodeInfo info = msg.UserData as Tbl_BarCodeInfo;
               ret.Status = (int)MsgStatus.成功;
               ret.Message = "";
               ret.BuildBunchId = int.Parse(info.BarCodeBatchID.ToString());
               ret.BuildName = info.BuildName;
               ret.CreateTime = info.CreateTime.ToString();
               ret.MetariesType = info.MateriesType;
               ret.ProjectName = info.ProjectName;
               ret.WorkMapId = info.WorkMapID;
              
           }
           else
           {
               ret.Status = (int)MsgStatus.失败;
               ret.Message = msg.Message;
           }

           this.Response.Write(jss.Serialize(ret));
        
        }
    }
}