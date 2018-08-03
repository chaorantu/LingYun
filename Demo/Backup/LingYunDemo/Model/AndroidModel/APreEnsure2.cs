using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LingYunDemo.Data;
using LingYunDemo.Data.Enum;
using LingYunDemo.Dal;

namespace LingYunDemo.Model.AndroidModel
{
    public class APreEnsure2
    {
        /// <summary>
        /// 查询未确认
        /// </summary>
        /// <param name="access"></param>
        /// <param name="iType"></param>
        /// <returns></returns>
        public static Msg QueryUnsure(int access,int iType)
        {
            Msg msg = null;


            if (access == (int)UserData.加工主管)
            {
                if(iType==1)
                {
                    using (var en = new LingYunEntities())
                    {
                       List<Tbl_ProductBatch> list= en.Tbl_ProductBatch.Where(a => a.NowAdmStatus == 1).ToList();
                       if (list != null && list.Count > 0)
                       {
                           msg = new Msg(true) { UserData = list };
                       }
                       else
                       {
                           msg = new Msg(false) { Message = "未找到记录" };
                       }
                    }
                }

                else if (iType == 2)
                {
                    using (var en = new LingYunEntities())
                    {
                        List<Tbl_OutProductBatch> list = en.Tbl_OutProductBatch.Where(a => a.PreAdmStatus == 1).ToList();
                        if (list != null && list.Count > 0)
                        {
                            msg = new Msg(true) { UserData = list };
                        }
                        else
                        {
                            msg = new Msg(false) { Message = "未找到记录" };
                        }
                    }
                }

            } if (access == (int)UserData.中心仓库主管)
            {
                if (iType == 1)
                {
                    using (var en = new LingYunEntities())
                    {
                        List<Tbl_CenterStorageBatch> list = en.Tbl_CenterStorageBatch.Where(a => a.PreAdmStatus == 1).ToList();
                        if (list != null && list.Count > 0)
                        {
                            msg = new Msg(true) { UserData = list };
                        }
                        else
                        {
                            msg = new Msg(false) { Message = "未找到记录" };
                        }
                    }
                }
                else if (iType == 2)
                {
                    using (var en = new LingYunEntities())
                    {
                        List<Tbl_OutCenterStorage> list = en.Tbl_OutCenterStorage.Where(a => a.PreAdmStatus == 1).ToList();
                        if (list != null && list.Count > 0)
                        {
                            msg = new Msg(true) { UserData = list };
                        }
                        else
                        {
                            msg = new Msg(false) { Message = "未找到记录" };
                        }
                    }
                }

            }
            if (access == (int)UserData.现场仓库主管)
            {
                if (iType == 1)
                {
                    using (var en = new LingYunEntities())
                    {
                        List<Tbl_SiteStorageBatch> list = en.Tbl_SiteStorageBatch.Where(a => a.PreAdmStatus == 1).ToList();
                        if (list != null && list.Count > 0)
                        {
                            msg = new Msg(true) { UserData = list };
                        }
                        else
                        {
                            msg = new Msg(false) { Message = "未找到记录" };
                        }
                    }
                }
                else if (iType == 2)
                {
                    using (var en = new LingYunEntities())
                    {
                        List<Tbl_OutSiteStorage> list = en.Tbl_OutSiteStorage.Where(a => a.PreAdmStatus == 1).ToList();
                        if (list != null && list.Count > 0)
                        {
                            msg = new Msg(true) { UserData = list };
                        }
                        else
                        {
                            msg = new Msg(false) { Message = "未找到记录" };
                        }
                    }
                }

            }
            return msg;

        }

        /// <summary>
        /// android扫码确认
        /// </summary>
        /// <param name="access"></param>
        /// <param name="iType"></param>
        /// <returns></returns>

        public static Msg queryByBarcode(int iTableId,int iBatchId)
        {
            Msg msg = null;


            if (iTableId == (int)BatchStatus.加工仓库入库待审批)
            {
                using (var en = new LingYunEntities())
                {
                   var obj= en.Tbl_ProductBatch.Where(a =>a.BuildBatchID== iBatchId).FirstOrDefault();
                   if (obj != null)
                   {
                       msg = new Msg(true) { UserData = obj };
                   }
                }
               

            } 
            if (iTableId == (int)BatchStatus.加工仓库待出库审批)
            {
                using (var en = new LingYunEntities())
                {
                    var obj = en.Tbl_OutProductBatch.Where(a => a.BuildBatchID == iBatchId).FirstOrDefault();
                    if (obj != null)
                    {
                        msg = new Msg(true) { UserData = obj };
                    }
                }
            }


            if (iTableId == (int)BatchStatus.现场仓库入库待审批)
            {
                using (var en = new LingYunEntities())
                {
                    var obj = en.Tbl_SiteStorageBatch.Where(a => a.BuildBatchID == iBatchId).FirstOrDefault();
                    if (obj != null)
                    {
                        msg = new Msg(true) { UserData = obj };
                    }
                }

            } if (iTableId == (int)BatchStatus.现场仓库待出库审批)
            {
                using (var en = new LingYunEntities())
                {
                    var obj = en.Tbl_OutSiteStorage.Where(a => a.BuildBatchID == iBatchId).FirstOrDefault();
                    if (obj != null)
                    {
                        msg = new Msg(true) { UserData = obj };
                    }
                }
            }
            if (iTableId == (int)BatchStatus.中心仓库入库待审批)
            {
                using (var en = new LingYunEntities())
                {
                    var obj = en.Tbl_CenterStorageBatch.Where(a => a.BuildBatchID == iBatchId).FirstOrDefault();
                    if (obj != null)
                    {
                        msg = new Msg(true) { UserData = obj };
                    }
                }

            } if (iTableId == (int)BatchStatus.中心仓库待出库审批)
            {
                using (var en = new LingYunEntities())
                {
                    var obj = en.Tbl_OutCenterStorage.Where(a => a.BuildBatchID == iBatchId).FirstOrDefault();
                    if (obj != null)
                    {
                        msg = new Msg(true) { UserData = obj };
                    }
                }
            }
            return msg;

        }


        public static int GetBatchId(string sBarCode)
        {
            long obj=0;
            using (var en = new LingYunEntities())
            {
                 obj = en.Tbl_BarCodeBatch.Where(a => a.BarCodeNo == sBarCode).FirstOrDefault().BuildBatchID;
               
            }
            return int.Parse(obj.ToString());
        }


    }
}