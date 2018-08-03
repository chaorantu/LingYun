using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Model.AndroidModel;
using LingYunDemo.Data;
using LingYunDemo.Dal;
using LingYunDemo.Helper.Web;
using System.Collections;
using System.Json;


namespace LingYunDemo.Web.android
{
    public partial class QueryMateries : System.Web.UI.Page
    {

        public class RetMateries
        {
          
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           Msg msg= AMateries.GetUnsure();
           if (msg.Status)
           {
               
               JsonArray json = new JsonArray();
               List<Tbl_Materies> list = msg.UserData as List<Tbl_Materies>;
               GsonHelper gson = new GsonHelper();
         
               for (int i = 0; i < list.Count;i++)
               {

                   json.Add(JsonValue.Parse(gson.GetSerializerString(list[i])));       
                  
               }
               this.Response.Write(json.ToString());
           }
        }
    }
}