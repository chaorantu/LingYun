using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LingYunDemo.Data;
using LingYunDemo.Dal;

namespace LingYunDemo.Model
{
    public class Center
    {
        public static Msg QueryWaitInBunch()
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    List<Tbl_CenterStorageBatch> lBunch = en.Tbl_CenterStorageBatch.Where(a => a.PreAdmStatus == 128 && a.NowAdmStatus == 1).ToList();
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
        ///新确认中心仓储入库
        /// </summary>
        /// <returns></returns>
        public static Msg NQueryWaitInBunch(int iPlanId)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    List<Tbl_CenterStorageBatch> lBunch = en.Tbl_CenterStorageBatch.Where(a =>a.PlanID==iPlanId&&a.PreAdmStatus == 128 && a.NowAdmStatus  !=128).ToList();
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
        public static Msg QueryInBunch(int iInBunch)
        {
              Msg msg = null;
              Tbl_CenterStorageBatch oBunch = new Tbl_CenterStorageBatch();
              try
              {
                  using (var en = new LingYunEntities())
                  {
                      oBunch = en.Tbl_CenterStorageBatch.Where(a => a.BuildBatchID == iInBunch).FirstOrDefault();
                      if (oBunch != null)
                      {
                          msg = new Msg(true) { UserData = oBunch };
                      }
                      else
                      {
                          msg = new Msg(false) { Message = "您当前没有待确认的入库批次" };
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
        public static bool QueryIsHaveOutBunch(int BuildBunchId)
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
        /// 根据指定的批次编号查询记录
        /// </summary>
        /// <param name="matries"></param>
        /// <returns></returns>
        public static Msg QueryProductOutBunchById(int Id)
        {
            Msg msg = null;

            try
            {
                using (var en = new LingYunEntities())
                {
                    Tbl_OutCenterStorage oStorage = en.Tbl_OutCenterStorage.Where(a => a.BuildBatchID == Id).FirstOrDefault();
                    if (oStorage != null)
                    {
                        msg = new Msg(true) { UserData = oStorage };
                    }
                    else
                    {
                        msg = new Msg(false) { Message = "当前没有待出库的批次表" };
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
        /// 更新出库批次表
        /// </summary>
        /// <returns></returns>
        public static Msg UpdateOutBunch(int BuildBunchId, int count)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    Tbl_OutCenterStorage oBunch = en.Tbl_OutCenterStorage.Where(a => a.BuildBatchID == BuildBunchId).FirstOrDefault();

                    if (oBunch != null)
                    {
                        oBunch.Count = count;

                    }
                    en.SaveChanges();

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
        public static Msg EditOutBunch(Tbl_OutCenterStorage oBunch)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    en.Tbl_OutCenterStorage.AddObject(oBunch);


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
        ///新插入出库批次表
        /// </summary>
        /// <returns></returns>
        public static Msg NEditOutBunch(List<Tbl_OutCenterStorage> list)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    foreach(Tbl_OutCenterStorage obj in list)
                    en.Tbl_OutCenterStorage.AddObject(obj);


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
        /// 更新入库批次表
        /// </summary>
        /// <param name="matriesId"></param>
        /// <param name="count"></param>
        /// <param name="oStorage">仓储表</param>
        /// <returns></returns>
        public static Msg UpdateInBunch(int matriesId, int count, Tbl_CenterStorage oStorage)
        {
            Msg msg = null;

            try
            {
                using (var en = new LingYunEntities())
                {

                    Tbl_OutProductBatch oProduct = en.Tbl_OutProductBatch.Where(a => a.BuildBatchID == matriesId).FirstOrDefault();

                    oProduct.NowAdmStatus = 128;
                    oProduct.NowAdmTime = DateTime.Now;
                    ////Tbl_CenterStorageBatch oCenter = en.Tbl_CenterStorageBatch.Where(a => a.BuildBatchID == matriesId).FirstOrDefault();
                    ////oCenter.Count = count;
                    ////oCenter.NowAdmStatus = 128;
                    //oCenter.NowAdmTime = DateTime.Now;
                    //en.AddToTbl_CenterStorage(oStorage);
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
        public static Msg EnsureInBunch(Tbl_CenterStorageBatch oBunch,Tbl_CenterStorage oStorage)
        {
            Msg msg = null;
            if (oBunch != null)
            {
                try
                {
                    using (var en = new LingYunEntities())
                    {

                       var obj= en.Tbl_OutProductBatch.Where(a => a.BuildBatchID == oBunch.BuildBatchID).FirstOrDefault();
                       obj.NowAdmStatus = 128;
                        en.Tbl_CenterStorageBatch.AddObject(oBunch);
                        en.SaveChanges();
                    }


                }
                catch (Exception ex)
                {
                    msg = new Msg() { Status = false, Message = ex.Message };
                }

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

                    List<Tbl_CenterStorage> lStorage = en.Tbl_CenterStorage.Where(a => a.PreAdmStatus == 128 && a.NowAdmStatus == 1).ToList();
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

                    List<Tbl_CenterStorage> lStorage = en.Tbl_CenterStorage.Where(a =>a.PlanID==iPlanId&&a.PreAdmStatus == 128 && a.NowAdmStatus !=128).ToList();
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

                    List<Tbl_OutCenterStorage> lStorage = en.Tbl_OutCenterStorage.Where(a => a.PlanID == iPlanId && a.PreAdmStatus !=128).ToList();
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
                    Tbl_CenterStorage lBunch = en.Tbl_CenterStorage.Where(a => a.BuildBatchID == BuildBunchId).FirstOrDefault();
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
        public static bool QueryOutBunchById(int BuildBunchId)
        {

            using (var en = new LingYunEntities())
            {
                Tbl_OutCenterStorage oBunch = en.Tbl_OutCenterStorage.Where(a => a.BuildBatchID == BuildBunchId).FirstOrDefault();
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
        /// 确认出库批次表
        /// </summary>
        /// <returns></returns>
        public static Msg EnsureOutBunch(int iBuildBunch, int count, Tbl_SiteStorageBatch oSiteInBunch)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    Tbl_CenterStorage oSiteStorage = en.Tbl_CenterStorage.Where(a => a.BuildBatchID == iBuildBunch).FirstOrDefault();
                    if (oSiteStorage != null)
                    {
                        oSiteStorage.NowAdmStatus = 128;
                        oSiteStorage.NowAdmTime = DateTime.Now;
                    }
                    Tbl_OutCenterStorage oSiteBunch = en.Tbl_OutCenterStorage.Where(a => a.BuildBatchID == iBuildBunch).FirstOrDefault();
                    if (oSiteStorage != null)
                    {
                        oSiteBunch.PreAdmStatus = 128;
                        oSiteBunch.PreAdmTime = DateTime.Now;
                        oSiteBunch.Count = count;
                    }
                    en.Tbl_SiteStorageBatch.AddObject(oSiteInBunch);

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
        public static Msg NEnsureOutBunch(List<Tbl_SiteStorageBatch> list)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    foreach(Tbl_SiteStorageBatch oSite in list)
                    {
                    Tbl_CenterStorage oStorage = en.Tbl_CenterStorage.Where(a => a.BuildBatchID == oSite.BuildBatchID).FirstOrDefault();
                    if (oStorage != null)
                    {
                        oStorage.NowAdmStatus = 128;
                        oStorage.NowAdmTime = DateTime.Now;
                    }
                    Tbl_OutCenterStorage oSiteBunch = en.Tbl_OutCenterStorage.Where(a => a.BuildBatchID == oSite.BuildBatchID).FirstOrDefault();
                    if (oSiteBunch != null)
                    {
                        oSiteBunch.PreAdmStatus = 128;
                        oSiteBunch.PreAdmTime = DateTime.Now;
                   
                    }
                    en.Tbl_SiteStorageBatch.AddObject(oSite);
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
        public static Msg QueryStorage()
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    var objs = en.Tbl_CenterStorage.Where(a => a.PreAdmStatus == 128 && a.NowAdmStatus == 1).ToList();
                    if (objs != null)
                    {
                        msg = new Msg(true) { UserData = objs };
                    }
                    else
                    {
                        msg = new Msg(false) { Message = "当前没有要记录" };
                    }
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

                    var last = en.Tbl_OutProductBatch.Where(a => a.BuildBatchID == iBatchId).FirstOrDefault();
                    last.NowAdmStatus = 128;
                    last.NowAdmTime=DateTime.Now;

                    var obj = en.Tbl_CenterStorageBatch.Where(a => a.BuildBatchID == iBatchId).FirstOrDefault();
                    obj.NowAdmStatus = 128;
                    obj.NowAdmTime = DateTime.Now;

                    Tbl_CenterStorage oStorage = new Tbl_CenterStorage();
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
                    en.Tbl_CenterStorage.AddObject(oStorage);
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

                    var obj = en.Tbl_CenterStorage.Where(a => a.BuildBatchID == iBatchid).FirstOrDefault();
                    obj.NowAdmStatus = 128;
                    obj.NowAdmTime = DateTime.Now;
                    var oOut = en.Tbl_OutCenterStorage.Where(a => a.BuildBatchID == iBatchid).FirstOrDefault();
                    oOut.PreAdmStatus = 128;
                    oOut.PreAdmTime = DateTime.Now;
                    //出库批次表
                    Tbl_SiteStorageBatch oCenterBunch = new Tbl_SiteStorageBatch();
                    oCenterBunch.PlanID = oOut.PlanID;
                    oCenterBunch.MateriesTasbleID = oOut.MateriesTasbleID;
                    oCenterBunch.BuildID = oOut.BuildID;
                    oCenterBunch.BuildBatchID = oOut.BuildBatchID;
                    oCenterBunch.Time = DateTime.Now;
                    oCenterBunch.ProjectName = oOut.ProjectName;
                    oCenterBunch.BuildName = oOut.BuildName;
                    oCenterBunch.ProjectName = oOut.ProjectName;
                    oCenterBunch.MateriesID = oOut.MateriesID;
                    oCenterBunch.MateriesType = oOut.MateriesType;
                    oCenterBunch.WorkMapID = oOut.WorkMapID;
                    oCenterBunch.Count = oOut.Count
    ;
                    oCenterBunch.NowAdmStatus = 1;
                    oCenterBunch.PreAdmStatus = 128;
                    oCenterBunch.PreAdmTime = DateTime.Now;
                    oCenterBunch.NowAdmTime = DateTime.Now;
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
           /// 新确认入批次表批次表
        /// </summary>
        /// <param name="matriesId"></param>
        /// <param name="count"></param>
        /// <param name="oStorage">仓储表</param>
        /// <returns></returns>
        public static Msg NEnsureInBunch(List<Tbl_CenterStorage> list)
        {
            Msg msg = null;
         
                try
                {
                    using (var en = new LingYunEntities())
                    {
                        foreach(Tbl_CenterStorage oPro in list)
                        {
                            var obj = en.Tbl_OutProductBatch.Where(a => a.BuildBatchID == oPro.BuildBatchID).FirstOrDefault();
                        
                        obj.NowAdmStatus = 128;
                        obj.NowAdmTime = DateTime.Now;

                        var oBatch = en.Tbl_CenterStorageBatch.Where(b => b.BuildBatchID == oPro.BuildBatchID).FirstOrDefault();
                        oBatch.NowAdmStatus = 128;
                        oBatch.NowAdmTime = DateTime.Now;
                        en.Tbl_CenterStorage.AddObject(oPro);//插入入库记录
                       
                    }
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

   
    }
}