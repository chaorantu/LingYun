using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Data.Enum;
using LingYunDemo.Helper.Web;
using LingYunDemo.Model.AndroidModel;
using LingYunDemo.Data;
using LingYunDemo.Dal;
using LingYunDemo.Model;

namespace LingYunDemo.Web.android
{
    public partial class PreBarcodeEnsure : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

            string sAccess = this.Request["access"];
            int iAccess=int.Parse(sAccess);
            string sType = this.Request["type"];
            int iType=int.Parse(sType);
            string sBarcode = this.Request["barcode"];
           
           Msg barcodeMsg=PrintModel.QueryBatchId(sBarcode);
           int iBatchId = 0;
            if(barcodeMsg.Status)
            {
                iBatchId = int.Parse((barcodeMsg.UserData as Tbl_BarCodeBatch).BuildBatchID.ToString());
                }
            GsonHelper gson = new GsonHelper();
         string res=string.Empty;
            if (iAccess == (int)TableType.加工中心)
            {
                if (iType == 1)
                {
                   Msg msg=APreEnsure2.queryByBarcode((int)BatchStatus.加工仓库入库待审批,iBatchId);
                    if(msg.Status)
                    {
                        res=gson.GetSerializerString(msg.UserData);
                    }
                }
                else if (iType == 2)
                {  Msg msg=APreEnsure2.queryByBarcode((int)BatchStatus.加工仓库待出库审批,iBatchId);
                    if(msg.Status)
                    {
                         res=gson.GetSerializerString(msg.UserData);
                    }

                }
                else
                {
                }
            }


            if (iAccess == (int)TableType.中心仓储)
            {
                if (iType == 1)
                {
  Msg msg=APreEnsure2.queryByBarcode((int)BatchStatus.中心仓库入库待审批,iBatchId);
                    if(msg.Status)
                    {
                         res=gson.GetSerializerString(msg.UserData);
                    }
                }
                else if (iType == 2)
                {  Msg msg=APreEnsure2.queryByBarcode((int)BatchStatus.中心仓库待出库审批,iBatchId);
                    if(msg.Status)
                    {
                         res=gson.GetSerializerString(msg.UserData);
                    }
                }
                else
                {
                }
            }

            if (iAccess == (int)TableType.现场仓储)
            {
                if (iType == 1)
                {
                      Msg msg=APreEnsure2.queryByBarcode((int)BatchStatus.现场仓库入库待审批,iBatchId);
                    if(msg.Status)
                    {
                         res=gson.GetSerializerString(msg.UserData);
                    }
                }
                else if (iType == 2)
                {  Msg msg=APreEnsure2.queryByBarcode((int)BatchStatus.现场仓库待出库审批,iBatchId);
                    if(msg.Status)
                    {
                         res=gson.GetSerializerString(msg.UserData);
                    }
                }
                else
                {
                }
            }
            this.Response.Write(res);

        }
    }
}