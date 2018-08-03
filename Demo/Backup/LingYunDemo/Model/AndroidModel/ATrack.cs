using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LingYunDemo.Data;
using LingYunDemo.Dal;
using LingYunDemo.Data.Enum;

namespace LingYunDemo.Model.AndroidModel
{
    public class ATrack
    {
        public class TrackMsg
        {
            public int Status { get; set; }
            public string STime { get; set; }
        }
        /// <summary>
        ///跟踪指定项目 
        /// </summary>
        /// <returns></returns>
        public static Msg TrackStausByPlanId(int iPlanId)
        {

            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    List<Tbl_ProductBatch> list = en.Tbl_ProductBatch.Where(a => a.PlanID == iPlanId).ToList();
                    msg = new Msg(true) { UserData = list };

                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }

        public static TrackMsg TrackByBatchId(int iBatchId)
        {
            TrackMsg track = null;
            string list=string.Empty;
            // List<string> list = new List<string>();
             try
             {
                 track = new TrackMsg();
                 int res = 0;
                 using (var en = new LingYunEntities())
                 {
                     Tbl_ProductBatch oProIn = en.Tbl_ProductBatch.Where(a => a.BuildBatchID == iBatchId&&a.NowAdmStatus==128).FirstOrDefault();
                     if (oProIn != null)
                     {
                         list+=oProIn.NowAdmTime.Value.ToString();
                         Tbl_OutProductBatch oProOut = en.Tbl_OutProductBatch.Where(a => a.BuildBatchID == iBatchId && a.PreAdmStatus == 128).FirstOrDefault();
                         if (oProOut != null)
                         {
                             list += ";"+oProOut.PreAdmTime.Value.ToString();
                             Tbl_CenterStorageBatch oCenIn = en.Tbl_CenterStorageBatch.Where(a => a.BuildBatchID == iBatchId && a.NowAdmStatus == 128).FirstOrDefault();
                             if (oCenIn != null)
                             {
                                  list += ";"+oCenIn.NowAdmTime.Value.ToString();
                                 Tbl_OutCenterStorage oCenOut = en.Tbl_OutCenterStorage.Where(a => a.BuildBatchID == iBatchId && a.PreAdmStatus == 128).FirstOrDefault();
                                 if (oCenOut != null)
                                 {
                                    list += ";"+oCenOut.PreAdmTime.Value.ToString();
                                     Tbl_SiteStorageBatch oSiteIn = en.Tbl_SiteStorageBatch.Where(a => a.BuildBatchID == iBatchId && a.NowAdmStatus == 128).FirstOrDefault();
                                     if (oSiteIn != null)
                                     {
                                               list += ";"+oSiteIn.NowAdmTime.Value.ToString();
                                              Tbl_OutSiteStorage oSiteOut = en.Tbl_OutSiteStorage.Where(a => a.BuildBatchID == iBatchId && a.PreAdmStatus == 128).FirstOrDefault();
                                              if (oSiteOut != null)
                                              {
                                                  list += ";" + oSiteOut.PreAdmTime.Value.ToString();
                                                  res = (int)BatchStatus.待领料;
                                              }
                                              else
                                              {
                                                  res = (int)BatchStatus.现场仓库待出库审批;
                                              }
                                     }
                                     else
                                     {
                                         res = (int)BatchStatus.现场仓库入库待审批;
                                     }
                                 
                                 }
                                 else
                                 {
                                     res = (int)BatchStatus.中心仓库待出库审批;
                                 }
                             }
                             else
                             {

                                 res = (int)BatchStatus.中心仓库入库待审批;
                             }
                         
                         }
                         else
                         {
                             res = (int)BatchStatus.加工仓库待出库审批;

                         }
                     
                     }
                     else
                     {
                         res = (int)BatchStatus.加工仓库入库待审批;
                     }





                     //Tbl_SiteStorage oSite = en.Tbl_SiteStorage.Where(a => a.BuildBatchID == iBatchId).FirstOrDefault();
                     //Tbl_CenterStorage oCenter = en.Tbl_CenterStorage.Where(a => a.BuildBatchID == iBatchId).FirstOrDefault();
                     //Tbl_ProductStorage oPro = en.Tbl_ProductStorage.Where(a => a.BuildBatchID == iBatchId).FirstOrDefault();
                     //if (oSite != null)
                     //{
                     //    Tbl_OutSiteStorage oOut = en.Tbl_OutSiteStorage.Where(a => a.BuildBatchID == iBatchId).FirstOrDefault();
                     //    if (oOut ==null)
                     //        res = (int)BatchStatus.现场仓库待出库审批;
                     //    else
                     //        res = (int)BatchStatus.待领料;
                     //}
                     //else if (oCenter != null)
                     //{
                     //    Tbl_OutCenterStorage oOut = en.Tbl_OutCenterStorage.Where(a => a.BuildBatchID == iBatchId).FirstOrDefault();
                     //    if (oOut==null)
                     //        res = (int)BatchStatus.中心仓库待出库审批;
                     //    else
                     //        res = (int)BatchStatus.现场仓库入库待审批;
                     //}
                     //else if (oPro != null)
                     //{
                     //    Tbl_OutProductBatch oOut = en.Tbl_OutProductBatch.Where(a => a.BuildBatchID == iBatchId).FirstOrDefault();
                     //    if (oOut==null)
                     //    res = (int)BatchStatus.加工仓库待出库审批;
                     //    else 
                     //        res = (int)BatchStatus.中心仓库入库待审批;
                     //}
                     //else
                     //{
                     //    
                     //}
                     track.STime = list;
                     track.Status = res;
                 }
             }
             catch (Exception ex)
             {
                 track = new TrackMsg() { Status = -1 };
             }
             return track;
        }

    }
}