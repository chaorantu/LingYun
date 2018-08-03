using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LingYunDemo.Dal;
using LingYunDemo.Data;

namespace LingYunDemo.Model
{
    public class PrintModel
    {
        public static Msg GetBarCodeNum(int iBatchId,int count)
        {
            Msg msg = null;
            List<string> res=new List<string>();
            using (var en = new LingYunEntities())
            {
               List<Tbl_BarCodeBatch> li=en.Tbl_BarCodeBatch.Where(a=>a.BuildBatchID==iBatchId&&a.BarCodeNo.StartsWith("B")).ToList();
               for (int i=0;i<li.Count;i++)
               {
                   res.Add(li[i].BarCodeNo);
               }
               msg = new Msg(true) { UserData = res };
            }
            return msg;
        }

        public static Msg GetBarCodeNum(string BarcodeNum)
        {
            Msg msg = null;
           
            try
            {
                using (var en = new LingYunEntities())
                {
                    Tbl_BarCodeBatch oBarcode = en.Tbl_BarCodeBatch.Where(a => a.BarCodeNo == BarcodeNum).FirstOrDefault();
                    if (oBarcode != null)
                    {
                        Tbl_BarCodeInfo oBarCodeInfo = en.Tbl_BarCodeInfo.Where(a => a.BarCodeBatchID == oBarcode.BuildBatchID).FirstOrDefault();
                        if (oBarCodeInfo!=null)
                        msg = new Msg(true) { UserData = oBarCodeInfo };
                        else
                            msg = new Msg(false) { Message = "没有找到条码信息" };
                    }
                    else
                    {
                        msg = new Msg(false) { Message = "没有找到条码信息" };
                    }
                }
            }
            catch (Exception ex)
            {
              msg = new Msg(false) { Message = ex.Message }; }
            return msg;
        }

        public static Msg QueryBatchId(string sBarcode)
        {
              Msg msg = null;
           
            try
            {
                using (var en = new LingYunEntities())
                {
                    Tbl_BarCodeBatch oBarcode = en.Tbl_BarCodeBatch.Where(a => a.BarCodeNo == sBarcode).FirstOrDefault();
                    if (oBarcode != null)
                    {
                       
                            msg = new Msg(true) { UserData=oBarcode };
                    }
                    else
                    {
                        msg = new Msg(false) { Message = "没有找到条码信息" };
                    }
                }
            }
            catch (Exception ex)
            {
              msg = new Msg(false) { Message = ex.Message }; }
            return msg;
        }

    }
}