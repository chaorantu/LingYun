using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Data;
using LingYunDemo.Model.AndroidModel;
using System.Json;
using LingYunDemo.Helper.Web;
using LingYunDemo.Data.Enum;
using LingYunDemo.Dal;

namespace LingYunDemo.Web.android
{
    public partial class PreBatchEnsure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                 string sAccess = this.Request["access"];
            string sType=this.Request["batchType"];
            int iBatchType=int.Parse(sType);
            int iAccess = int.Parse(sAccess);
            JsonArray json = new JsonArray();
            GsonHelper gson = new GsonHelper();
           Msg  msg=APreEnsure2.QueryUnsure(iAccess,iBatchType);
           if (msg.Status)
           {
             
               if (iAccess == (int)UserData.加工主管)
               {
                   if (iBatchType == 1)
                   {
                       List<Tbl_ProductBatch> lPlan = msg.UserData as List<Tbl_ProductBatch>;
                       foreach (Tbl_ProductBatch oPlan in lPlan)
                       {
                           json.Add(JsonValue.Parse(gson.GetSerializerString(oPlan)));
                       }
                   }
                   else if (iBatchType == 2)
                   {
                       List<Tbl_OutProductBatch> lPlan = msg.UserData as List<Tbl_OutProductBatch>;
                       foreach (Tbl_OutProductBatch oPlan in lPlan)
                       {
                           json.Add(JsonValue.Parse(gson.GetSerializerString(oPlan)));
                       }
                   }
                   else
                   {
                   }
                 
                   
               } if (iAccess == (int)UserData.中心仓库主管)
               {

                   if (iBatchType == 1)
                   {
                       List<Tbl_CenterStorageBatch> lPlan = msg.UserData as List<Tbl_CenterStorageBatch>;
                       foreach (Tbl_CenterStorageBatch oPlan in lPlan)
                       {
                           json.Add(JsonValue.Parse(gson.GetSerializerString(oPlan)));
                       }
                   }
                   else if (iBatchType == 2)
                   {
                       List<Tbl_OutCenterStorage> lPlan = msg.UserData as List<Tbl_OutCenterStorage>;
                       foreach (Tbl_OutCenterStorage oPlan in lPlan)
                       {
                           json.Add(JsonValue.Parse(gson.GetSerializerString(oPlan)));
                       }
                   }
                   else
                   {
                   }

               }
               if (iAccess == (int)UserData.现场仓库主管)
               {
                   if (iBatchType == 1)
                   {
                       List<Tbl_SiteStorageBatch> lPlan = msg.UserData as List<Tbl_SiteStorageBatch>;
                       foreach (Tbl_SiteStorageBatch oPlan in lPlan)
                       {
                           json.Add(JsonValue.Parse(gson.GetSerializerString(oPlan)));
                       }
                   }
                   else if (iBatchType == 2)
                   {
                       List<Tbl_OutSiteStorage> lPlan = msg.UserData as List<Tbl_OutSiteStorage>;
                       foreach (Tbl_OutSiteStorage oPlan in lPlan)
                       {
                           json.Add(JsonValue.Parse(gson.GetSerializerString(oPlan)));
                       }
                   }
                   else
                   {
                   }

               }
            
           }
           this.Response.Write(json.ToString());
         
        }
        
    }
}