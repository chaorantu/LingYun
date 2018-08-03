using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Model.AndroidModel;
using LingYunDemo.Data;
using LingYunDemo.Data.Enum;
using LingYunDemo.Dal;
using System.Json;
using LingYunDemo.Helper.Web;
using LingYunDemo.Model;

namespace LingYunDemo.Web.android
{
    public partial class PreEnsure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              
            string sAccess = this.Request["access"];
            int iAccess = int.Parse(sAccess);
           Msg  msg=APreEnsure.QueryUnsure(iAccess);
           JsonArray json = new JsonArray();
           GsonHelper gson = new GsonHelper();
           if (msg.Status)
           {
               if (iAccess == (int)UserData.项目主管)
               {
                   List<Tbl_Plan> lPlan = msg.UserData as List<Tbl_Plan>;
                   foreach (Tbl_Plan oPlan in lPlan)
                   {
                      
                       json.Add(JsonValue.Parse(gson.GetSerializerString(oPlan)));
                   }

               } if (iAccess == (int)UserData.设计主管)
               {
                   List<Tbl_Materies> lPlan = msg.UserData as List<Tbl_Materies>;
                   foreach (Tbl_Materies oPlan in lPlan)
                   {
                     

                       json.Add(JsonValue.Parse(gson.GetSerializerString(oPlan)));
                   }
               }
           }
           else
           {

           }
           this.Response.Write(json.ToString());
        }
    }
}