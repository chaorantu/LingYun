using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Model;
using LingYunDemo.Data;
using System.Json;
using LingYunDemo.Helper.Web;
using LingYunDemo.Dal;

namespace LingYunDemo.Web.android
{
    public partial class QueryPlan : System.Web.UI.Page
    {
        public class RetMsg
        {
        public int planId { get; set; }
        public string Time { get; set; }
        public string ProjectName { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            JsonArray json = new JsonArray();
            Msg msg = PlanStatusModel.GetUnFillPlans();//获取未完成的项目
            if (msg.Status)
            {
               
                List<Tbl_Plan> list = msg.UserData as List<Tbl_Plan>;
                GsonHelper gson = new GsonHelper();

                for (int i = 0; i < list.Count; i++)
                {
                    RetMsg ret = new RetMsg();
                    ret.planId = list[i].PlanID;
                    ret.Time = list[i].PlanDate.ToString();
                    ret.ProjectName = list[i].ProjectName;
                    json.Add(JsonValue.Parse(gson.GetSerializerString(ret)));

                }
            }
               this.Response.Write(json.ToString());

        }
    }
}