using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Model.AndroidModel;
using LingYunDemo.Data;
using System.Json;
using LingYunDemo.Dal;
using LingYunDemo.Helper.Web;

namespace LingYunDemo.Web.android
{
    public partial class ATrackStatus : System.Web.UI.Page
    {
        public class RetMsg
        {
            public int BuildBatchId { get; set; }
            public string BuildName { get; set; }
            public string Time { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            JsonArray json = new JsonArray();

            string sPlanId = this.Request["planId"];
             Msg msg=ATrack.TrackStausByPlanId(int.Parse(sPlanId));
             if (msg.Status)
             {
                
               List<Tbl_ProductBatch> list = msg.UserData as List<Tbl_ProductBatch>;
               GsonHelper gson = new GsonHelper();

               for (int i = 0; i < list.Count; i++)
               {
                   RetMsg oPro = new RetMsg();
                   oPro.BuildBatchId = int.Parse(list[i].BuildBatchID.ToString());
                   oPro.BuildName = list[i].BuildName;
                   oPro.Time = list[i].NowAdmTime.ToString();

                   json.Add(JsonValue.Parse(gson.GetSerializerString(oPro)));       
              
               }
             }
             this.Response.Write(json);
         
        }
    }
}