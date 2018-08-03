using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Data.Enum;
using LingYunDemo.Model.AndroidModel;
using LingYunDemo.Data;
using LingYunDemo.Dal;
using System.Json;
using LingYunDemo.Helper.Web;

namespace LingYunDemo.Web.android
{
    public partial class QueryStorage : System.Web.UI.Page
    {
        class RetMsg
        {
            public int BuildBatchId { get; set; }
            public string BuildName{get; set;}
            public int Count{get;set;}
            public string NowAdmStatus{get;set;}
            public int MateriesId{get;set;}
            public string Time { get; set; }
            public string BuildId { get; set; }
        }


        /// <summary>
        /// andorid 邰惟 查询仓储
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string sPlanId = this.Request["planId"];
            string sTableId = this.Request["tableId"];
            int iPlanId=int.Parse(sPlanId);
            int iTableId = int.Parse(sTableId);
            JsonArray json = new JsonArray();
            GsonHelper gson = new GsonHelper();
            if (iTableId == (int)TableType.加工中心)
            {
              Msg  msg=  AQueryStorage.QueryStorage(iPlanId, iTableId);
                if(msg.Status)
                {
                    List<Tbl_ProductStorage> lProduct = msg.UserData as List<Tbl_ProductStorage>;
                 
         
                    foreach (Tbl_ProductStorage oProduct in lProduct)
                    {
                        RetMsg ret = new RetMsg();
                        ret.BuildBatchId = oProduct.BuildBatchID;
                        if (oProduct.NowAdmStatus == 128)
                        {
                            ret.NowAdmStatus = "是";
                        }
                        else
                        {
                            ret.NowAdmStatus = "否";
                        }
                        ret.MateriesId = oProduct.MateriesID;
                        ret.Count =oProduct.InCount==null?0:(int)oProduct.InCount;
                        ret.BuildName = oProduct.BuildName;
                        ret.Time = oProduct.Time.ToString();
                        ret.BuildId = oProduct.BuildID;
                        json.Add(JsonValue.Parse(gson.GetSerializerString(ret)));     
                    }
                }
            }
            if (iTableId == (int)TableType.中心仓储)
            {
                 Msg  msg=  AQueryStorage.QueryStorage(iPlanId, iTableId);
                if(msg.Status)
                {
                    List<Tbl_CenterStorage> lProduct = msg.UserData as List<Tbl_CenterStorage>;
                 
         
                    foreach (Tbl_CenterStorage oProduct in lProduct)
                    {
                        RetMsg ret = new RetMsg();
                        ret.BuildBatchId = oProduct.BuildBatchID;
                        if (oProduct.NowAdmStatus == 128)
                        {
                            ret.NowAdmStatus = "是";
                        }
                        else
                        {
                            ret.NowAdmStatus = "否";
                        }
                        ret.BuildId = oProduct.BuildID;
                        ret.MateriesId = oProduct.MateriesID;
                        ret.Count =oProduct.InCount==null?0:(int)oProduct.InCount;
                        ret.BuildName = oProduct.BuildName;
                        ret.Time = oProduct.Time.ToString();
                        json.Add(JsonValue.Parse(gson.GetSerializerString(ret)));     
                    }
                }
            

            }
            if (iTableId == (int)TableType.现场仓储)
            {
                Msg msg = AQueryStorage.QueryStorage(iPlanId, iTableId);
                if (msg.Status)
                {
                    List<Tbl_SiteStorage> lProduct = msg.UserData as List<Tbl_SiteStorage>;


                    foreach (Tbl_SiteStorage oProduct in lProduct)
                    {
                        RetMsg ret = new RetMsg();
                        ret.BuildBatchId = oProduct.BuildBatchID;
                        if (oProduct.NowAdmStatus == 128)
                        {
                            ret.NowAdmStatus = "是";
                        }
                        else
                        {
                            ret.NowAdmStatus = "否";
                        }
                        ret.BuildId = oProduct.BuildID;
                        ret.MateriesId = oProduct.MateriesID;
                        ret.Count = oProduct.InCount == null ? 0 : (int)oProduct.InCount;
                        ret.BuildName = oProduct.BuildName;
                        ret.Time = oProduct.Time.ToString();
                        json.Add(JsonValue.Parse(gson.GetSerializerString(ret)));
                    }
                }


            }
            this.Response.Write(json.ToString());
        }
    }
}