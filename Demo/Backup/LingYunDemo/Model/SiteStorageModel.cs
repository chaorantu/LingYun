using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LingYunDemo.Data;
using LingYunDemo.Dal;

namespace LingYunDemo.Model
{
    public class SiteStorageModel
    {

        /// <summary>
        /// 查询入库批次表
        /// </summary>
        /// <returns></returns>
        public static Msg QueryInBunch()
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    List<Tbl_SiteStorageBatch> lBunch = en.Tbl_SiteStorageBatch.Where(a => a.PreAdmStatus == 128 && a.NowAdmStatus == 1).ToList();
                    if (lBunch != null)
                    {
                        msg = new Msg(true) { UserData = lBunch };
                    }
                    else
                    {
                        msg = new Msg(false) { Message = "您当前没有待确认的入库批次记录" };
                    }

                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }

        /// <summary>
        ///新查询入库批次表
        /// </summary>
        /// <returns></returns>
        public static Msg NQueryInBunch(int iPlanId)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    List<Tbl_SiteStorageBatch> lBunch = en.Tbl_SiteStorageBatch.Where(a =>a.PlanID==iPlanId&&a.PreAdmStatus == 128 && a.NowAdmStatus !=128).ToList();
                    if (lBunch != null)
                    {
                        msg = new Msg(true) { UserData = lBunch };
                    }
                    else
                    {
                        msg = new Msg(false) { Message = "您当前没有待确认的入库批次记录" };
                    }

                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }

        /// <summary>
        /// 查询出库批次表
        /// </summary>
        /// <returns></returns>
        public static Msg QueryOutBunch(int iBuildBunch)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    Tbl_OutSiteStorage lBunch = en.Tbl_OutSiteStorage.Where(a => a.BuildBatchID == iBuildBunch).FirstOrDefault();
                    if (lBunch != null)
                    {
                        msg = new Msg(true) { UserData = lBunch };
                    }
                    else
                    {
                        msg = new Msg(false) { Message = "您当前没有待确认的入库批次记录" };
                    }

                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }
        /// <summary>
        /// 根据编号查询入库批次表
        /// </summary>
        /// <returns></returns>
        public static Msg QueryInBunchById(int BuildBunchId)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                   Tbl_SiteStorageBatch lBunch = en.Tbl_SiteStorageBatch.Where(a => a.BuildBatchID == BuildBunchId).FirstOrDefault();
                    if (lBunch!=null)
                    {
                        msg = new Msg(true) { UserData = lBunch };
                    }
                    else
                    {
                        msg = new Msg(false) { Message = "您当前没有待确认的入库批次记录" };
                    }

                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }

        /// <summary>
        /// 查看仓储
        /// </summary>
        /// <returns></returns>
        public static Msg QueryStorage()
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    List<Tbl_SiteStorage> lBunch = en.Tbl_SiteStorage.Where(a => a.PreAdmStatus == 128).ToList();
                    if (lBunch != null)
                    {
                        msg = new Msg(true) { UserData = lBunch };
                    }
                    else
                    {
                        msg = new Msg(false) { Message = "您当前没有待确认的入库批次记录" };
                    }

                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }
        /// <summary>
        /// 根据编号查询入库批次表
        /// </summary>
        /// <returns></returns>
        public static Msg EnsureInBunch(int iBuildBunch,Tbl_SiteStorage oStorage)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                   Tbl_OutCenterStorage oCenterBunch=en.Tbl_OutCenterStorage.Where(a => a.BuildBatchID == iBuildBunch).FirstOrDefault();
                   if (oCenterBunch != null)
                   {
                       oCenterBunch.NowAdmStatus = 128;
                       oCenterBunch.NowAdmTime = DateTime.Now;
                   }
                   Tbl_SiteStorageBatch oSiteInBunch = en.Tbl_SiteStorageBatch.Where(a => a.BuildBatchID == iBuildBunch).FirstOrDefault();
                   if (oCenterBunch != null)
                   {
                       oSiteInBunch.NowAdmStatus = 128;
                       oCenterBunch.NowAdmTime = DateTime.Now;
                   }
                    en.Tbl_SiteStorage.AddObject(oStorage);
                        en.SaveChanges();
                        msg = Msg.Default;
                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }


        /// <summary>
        /// 根据编号查询入库批次表
        /// </summary>
        /// <returns></returns>
        public static Msg NEnsureInBunch(List<Tbl_SiteStorage> list)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    foreach (Tbl_SiteStorage oSto in list)
                    {
                        Tbl_OutCenterStorage oCenterBunch = en.Tbl_OutCenterStorage.Where(a => a.BuildBatchID == oSto.BuildBatchID).FirstOrDefault();
                        if (oCenterBunch != null)
                        {
                            oCenterBunch.NowAdmStatus = 128;
                            oCenterBunch.NowAdmTime = DateTime.Now;
                        }
                        Tbl_SiteStorageBatch oSiteInBunch = en.Tbl_SiteStorageBatch.Where(a => a.BuildBatchID == oSto.BuildBatchID).FirstOrDefault();
                        if (oCenterBunch != null)
                        {
                            oSiteInBunch.NowAdmStatus = 128;
                            oCenterBunch.NowAdmTime = DateTime.Now;
                        }
                        en.Tbl_SiteStorage.AddObject(oSto);
                    } en.SaveChanges();
                    msg = Msg.Default;
                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }
        /// <summary>
        /// 确认出库批次表
        /// </summary>
        /// <returns></returns>
        public static Msg EnsureOutBunch(int iBuildBunch,int count)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    Tbl_SiteStorage oSiteStorage = en.Tbl_SiteStorage.Where(a => a.BuildBatchID == iBuildBunch).FirstOrDefault();
                    if (oSiteStorage != null)
                    {
                        oSiteStorage.NowAdmStatus = 128;
                        oSiteStorage.NowAdmTime = DateTime.Now;
                    }
                    Tbl_OutSiteStorage oSiteBunch = en.Tbl_OutSiteStorage.Where(a => a.BuildBatchID == iBuildBunch).FirstOrDefault();
                    if (oSiteStorage != null)
                    {
                        oSiteBunch.PreAdmStatus = 128;
                        oSiteBunch.PreAdmTime = DateTime.Now;
                        oSiteBunch.Count = count;
                    }

                    en.SaveChanges();
                    msg = Msg.Default;

                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }
        /// <summary>
        /// 新确认出库批次表
        /// </summary>
        /// <returns></returns>
        public static Msg EnsureOutBunch(List<Tbl_OutSiteStorage> list)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    foreach (Tbl_OutSiteStorage oSto in list)
                    {
                        Tbl_SiteStorage oSiteStorage = en.Tbl_SiteStorage.Where(a => a.BuildBatchID == oSto.BuildBatchID).FirstOrDefault();
                        if (oSiteStorage != null)
                        {
                            oSiteStorage.NowAdmStatus = 128;
                            oSiteStorage.NowAdmTime = DateTime.Now;
                        }
                        Tbl_OutSiteStorage oSiteBunch = en.Tbl_OutSiteStorage.Where(a => a.BuildBatchID == oSto.BuildBatchID).FirstOrDefault();
                        if (oSiteStorage != null)
                        {
                            oSiteBunch.PreAdmStatus = 128;
                            oSiteBunch.PreAdmTime = DateTime.Now;
                          
                        }
                    }
                    en.SaveChanges();
                    msg = Msg.Default;

                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }
        /// <summary>
        ///查询出库批次
        /// </summary>
        /// <returns></returns>
        public static Msg QueryOutBunch()
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {

                    List<Tbl_SiteStorage> lStorage=en.Tbl_SiteStorage.Where(a => a.PreAdmStatus == 128 && a.NowAdmStatus == 1).ToList();
                    if (lStorage.Count > 0)
                    {
                        msg = new Msg(true) { UserData = lStorage };
                    }
                    else
                        msg = new Msg(false) { Message = "您当前没有待出库的记录" };
                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }

        /// <summary>
        ///新查询出库批次
        /// </summary>
        /// <returns></returns>
        public static Msg NQueryOutBunch(int iPlanId)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {

                    List<Tbl_SiteStorage> lStorage = en.Tbl_SiteStorage.Where(a =>a.PlanID==iPlanId&&a.PreAdmStatus == 128 && a.NowAdmStatus !=128).ToList();
                    if (lStorage.Count > 0)
                    {
                        msg = new Msg(true) { UserData = lStorage };
                    }
                    else
                        msg = new Msg(false) { Message = "您当前没有待出库的记录" };
                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }

        /// <summary>
        ///新查询确认出库批次
        /// </summary>
        /// <returns></returns>
        public static Msg NQueryEnsureOutBunch(int iPlanId)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {

                    List<Tbl_OutSiteStorage> lStorage = en.Tbl_OutSiteStorage.Where(a => a.PlanID == iPlanId && a.PreAdmStatus !=128).ToList();
                    if (lStorage.Count > 0)
                    {
                        msg = new Msg(true) { UserData = lStorage };
                    }
                    else
                        msg = new Msg(false) { Message = "您当前没有待出库的记录" };
                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }
        /// <summary>
        /// 根据编号查询入库批次表
        /// </summary>
        /// <returns></returns>
        public static Msg QueryStorageById(int BuildBunchId)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    Tbl_SiteStorage lBunch = en.Tbl_SiteStorage.Where(a => a.BuildBatchID == BuildBunchId).FirstOrDefault();
                    if (lBunch!=null)
                    {
                        msg = new Msg(true) { UserData = lBunch };
                    }
                    else
                    {
                        msg = new Msg(false) { Message = "您当前没有待确认的入库批次记录" };
                    }

                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }

        /// <summary>
        /// 根据编号查询入库批次表
        /// </summary>
        /// <returns></returns>
        public static bool QueryOutBunchById(int BuildBunchId)
        {
          
                using (var en = new LingYunEntities())
                {
                    Tbl_OutSiteStorage oBunch = en.Tbl_OutSiteStorage.Where(a => a.BuildBatchID == BuildBunchId).FirstOrDefault();
                    if (oBunch != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

              
        }


        /// <summary>
        /// 更新出库批次表
        /// </summary>
        /// <returns></returns>
        public static Msg UpdateOutBunch(int BuildBunchId,int count)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    Tbl_OutSiteStorage oBunch = en.Tbl_OutSiteStorage.Where(a => a.BuildBatchID == BuildBunchId).FirstOrDefault();

                    if (oBunch != null)
                    {
                        oBunch.Count = count;

                    }
                    en.SaveChanges();
                    msg = Msg.Default;
                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }
        /// <summary>
        /// 插入出库批次表
        /// </summary>
        /// <returns></returns>
        public static Msg EditOutBunch(Tbl_OutSiteStorage oBunch)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    en.Tbl_OutSiteStorage.AddObject(oBunch);

                
                    en.SaveChanges();
                    msg = Msg.Default;

                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }
        /// <summary>
        /// 新插入出库批次表
        /// </summary>
        /// <returns></returns>
        public static Msg NEditOutBunch(List<Tbl_OutSiteStorage> list)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    foreach(Tbl_OutSiteStorage obj in list)
                       
                    en.Tbl_OutSiteStorage.AddObject(obj);


                    en.SaveChanges();
                    msg = Msg.Default;

                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }
        public static Msg AndroidInEnsure(int iBatchId)
        {
            Msg msg = null;

            try
            {
                using (var en = new LingYunEntities())
                {

                    var last = en.Tbl_OutCenterStorage.Where(a => a.BuildBatchID == iBatchId).FirstOrDefault();
                    last.NowAdmStatus = 128;
                    last.NowAdmTime = DateTime.Now;

                    var obj = en.Tbl_SiteStorageBatch.Where(a => a.BuildBatchID == iBatchId).FirstOrDefault();
                    obj.NowAdmStatus = 128;
                    obj.NowAdmTime = DateTime.Now;

                    Tbl_SiteStorage oStorage = new Tbl_SiteStorage();
                    oStorage.PlanID = obj.PlanID;
                    oStorage.Time = DateTime.Now;
                    oStorage.MateriesID = obj.MateriesID;
                    oStorage.BuildID = obj.BuildID;
                    oStorage.BuildName = obj.BuildName;

                    oStorage.MateriesType = obj.MateriesType;
                    oStorage.PreAdmTime = DateTime.Now;
                    oStorage.PreAdmStatus = 128;
                    oStorage.NowAdmStatus = 1;
                    oStorage.NowAdmTime = DateTime.Now;
                    oStorage.ProjectName = obj.ProjectName;
                    oStorage.WorkMapID = obj.WorkMapID;
                    oStorage.InCount = obj.Count;
                    en.Tbl_SiteStorage.AddObject(oStorage);
                    en.SaveChanges();
                    msg = Msg.Default;
                }


            }
            catch (Exception ex)
            {
                msg = new Msg() { Status = false, Message = ex.Message };
            }


            return msg;
        }
        public static Msg AndroidOutBatch(int iBatchid)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {

                    var obj = en.Tbl_SiteStorage.Where(a => a.BuildBatchID == iBatchid).FirstOrDefault();
                    obj.NowAdmStatus = 128;
                    obj.NowAdmTime = DateTime.Now;
                    var oOut = en.Tbl_OutSiteStorage.Where(a => a.BuildBatchID == iBatchid).FirstOrDefault();
                    oOut.PreAdmStatus = 128;
                    oOut.PreAdmTime = DateTime.Now;
                   
                    en.SaveChanges();
                    msg = Msg.Default;
                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false);
            }
            return msg;
        }
    }
}