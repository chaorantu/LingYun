using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Model.AndroidModel;
using System.Web.Script.Serialization;

namespace LingYunDemo.Web.android
{
    public partial class ATrackStatus2 : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string sBuildBatchId = this.Request["buildBatchId"];
            JavaScriptSerializer jss = new JavaScriptSerializer();
            LingYunDemo.Model.AndroidModel.ATrack.TrackMsg res = ATrack.TrackByBatchId(int.Parse(sBuildBatchId));
             
            this.Response.Write(jss.Serialize(res));
        
        }
    }
}