using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LingYunDemo.Data;
using LingYunDemo.Dal;
using LingYunDemo.Common;
using LingYunDemo.Data.Enum;
using System.Configuration;
using System.Data.SqlClient;

namespace LingYunDemo.Model
{
    public class ProductModel
    {

        public static Msg GetMetriesByMatriesid(int IMatriesid)
        {
            Msg msg = null;

            Tbl_Materies oMetries = new Tbl_Materies();
            try
            {

                using (var en = new LingYunEntities())
                {
                  

                    oMetries = en.Tbl_Materies.Where(a => a.MateriesID == IMatriesid).FirstOrDefault();
                }
                if (oMetries != null)
                {
                    msg = new Msg(true) { UserData = oMetries };
                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;

           
        }
        public static Msg GetUnsureInBunch(int iMateries)
        {
            Msg msg = null;

            Tbl_ProductBatch oMetries = new Tbl_ProductBatch();
            try
            {
                using (var en = new LingYunEntities())
                {
                    oMetries = en.Tbl_ProductBatch.Where(a => a.BuildBatchID == iMateries).FirstOrDefault();
                }
                if (oMetries != null)
                {
                    msg = new Msg(true) { UserData = oMetries };
                }
                else
                {
                    msg = new Msg(false) { Message = "查找失败" };

                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;

      
        }
        public static Msg GetAllMetaries()
        {
            Msg msg = null;
            List<Tbl_Materies> lMeteries = new List<Tbl_Materies>();
            try
            {
                List<Tbl_Plan> lPlans = new List<Tbl_Plan>();
                using (var en = new LingYunEntities())
                {
                    lPlans = en.Tbl_Plan.Where(a => a.DesignAdmStatus == 128 && a.ProductAdmStatus == 1).ToList();

                    if (lPlans.Count > 0)
                    {
                        foreach (Tbl_Plan oPlan in lPlans)
                        {
                            var metaries = en.Tbl_Materies.Where(a => oPlan.PlanID == a.PlanID).FirstOrDefault();
                            if (metaries != null)
                            {
                                int count = 0;
                             List<Tbl_ProductBatch> li=en.Tbl_ProductBatch.Where(a => a.PlanID == metaries.PlanID).ToList();
                             if (li != null)
                             {
                                 foreach (Tbl_ProductBatch oPro in li)
                                 {
                                     count += oPro.Count;
                                 }
                             }
                             if (count <= metaries.TotalNum)
                             {
                                 metaries.TotalNum = metaries.TotalNum - count;
                             }

                             lMeteries.Add(metaries);
                            }
                        }
                        msg = new Msg(true) { UserData = lMeteries };
                    }
                    else
                    {
                        msg = new Msg(false) { Message = "您当前没有要编辑材料表" };

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
        /// 新获取未确认材料表
        /// </summary>
        /// <returns></returns>
        public static Msg NGetAllMetaries(int iPlanId)
        {
            Msg msg = null;
           
            try
            {
              
                using (var en = new LingYunEntities())
                {
                   
                       
                                List<Tbl_Materies> li = en.Tbl_Materies.Where(a => a.PlanID == iPlanId&&a.NowAdmStatus==1&&a.BeforeAdmStatus==128).ToList();
                                if (li.Count>0)
                                {
                                   msg=new Msg(true){UserData=li};
                                }
                                else
                                {
                                   msg=new Msg(false){Message="未找到记录"};
                                }
                        
                       
                    }
                  

                    
                
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;

        }
        public static Msg EditInBunch(Tbl_ProductBatch oBunch)
        {
            //构造调码对象
            List<Tbl_BarCodeBatch> lBarcode = new List<Tbl_BarCodeBatch>();
   
        //    List<Tbl_BarCodeInfo> lBarCodeInfo = new List<Tbl_BarCodeInfo>();

            Msg msg = null;
            if (oBunch != null)
            {
                try
                {
                    using (var en = new LingYunEntities())
                    {
                        Tbl_ProductBatch obj = en.Tbl_ProductBatch.Where(a => a.PlanID == oBunch.PlanID && oBunch.MateriesID == a.MateriesID).FirstOrDefault();
                        //if (obj == null)
                        {
                             en.Tbl_ProductBatch.AddObject(oBunch);
                             en.SaveChanges();
                          Tbl_ProductBatch oProduct= en.Tbl_ProductBatch.Where(a => a.PlanID == oBunch.PlanID).ToList().LastOrDefault();

                            //批次
                          List<string> lCodes = BarCode.BuildBarCode(oProduct.WorkMapID, (int)BarCodeType.批次);
                             Tbl_BarCodeBatch oBunchBarCode = new Tbl_BarCodeBatch();
                             oBunchBarCode.BarCodeBatchID = oProduct.BuildBatchID;
                             oBunchBarCode.BarCodeType = (int)BarCodeType.批次;
                             oBunchBarCode.BarCodeNo = lCodes[0];
                             oBunchBarCode.CreateTime = DateTime.Now;
                             oBunchBarCode.BuildBatchID = oProduct.BuildBatchID;
                             Tbl_BarCodeInfo oBarCodeInfo = new Tbl_BarCodeInfo();
                             oBarCodeInfo.BarCodeInfoID = oProduct.BuildBatchID;
                             oBarCodeInfo.BuildName = oBunch.BuildName;
                             oBarCodeInfo.CreateTime = DateTime.Now;
                             oBarCodeInfo.MateriesType = oBunch.MateriesType;
                             oBarCodeInfo.WorkMapID = oBunch.WorkMapID;
                             oBarCodeInfo.ProjectName = oBunch.ProjectName;
                            oBarCodeInfo.BarCodeBatchID=oProduct.BuildBatchID;
                             en.Tbl_BarCodeBatch.AddObject(oBunchBarCode);
                             en.Tbl_BarCodeInfo.AddObject(oBarCodeInfo);

                            //
                             List<string> lSigleCodes = BarCode.BuildBarCode(oProduct.WorkMapID, (int)BarCodeType.单件, oBunch.Count);
                            for(int i=0;i<lSigleCodes.Count;i++)
                            {
                                Tbl_BarCodeBatch oSigleBunch = new Tbl_BarCodeBatch();
                                oSigleBunch.BarCodeBatchID = oProduct.BuildBatchID;
                                oSigleBunch.BarCodeType = (int)BarCodeType.单件;
                                oSigleBunch.BarCodeNo = lSigleCodes[i];
                                oSigleBunch.CreateTime = DateTime.Now;
                                Tbl_BarCodeInfo oSigleInfo = new Tbl_BarCodeInfo();
                                oSigleInfo.BarCodeBatchID = oProduct.BuildBatchID;
                                oSigleInfo.BarCodeInfoID = oProduct.BuildBatchID;
                                oSigleInfo.BuildName = oBunch.BuildName;
                                oSigleInfo.CreateTime = DateTime.Now;
                                oSigleInfo.MateriesType = oBunch.MateriesType;
                                oSigleInfo.WorkMapID = oBunch.WorkMapID;
                                oSigleInfo.ProjectName = oBunch.ProjectName;
                                en.Tbl_BarCodeBatch.AddObject(oSigleBunch);
                                en.Tbl_BarCodeInfo.AddObject(oSigleInfo);
                            }


                            en.SaveChanges();
                            msg = new Msg(true) { UserData = lCodes };
                        }
                        //else
                        //{
                        //    obj.Count = oBunch.Count;

                        //    List<Tbl_BarCodeBatch> lDelBunch = en.Tbl_BarCodeBatch.Where(a => a.BuildBatchID == obj.BuildBatchID).ToList();
                        //    List<Tbl_BarCodeInfo> lDelInfo = en.Tbl_BarCodeInfo.Where(a => a.BarCodeBatchID == obj.BuildBatchID).ToList();
                        //     for(int j=0;j<lDelBunch.Count;j++)
                        //     {
                        //         en.Tbl_BarCodeBatch.DeleteObject(lDelBunch[j]);
                        //         en.Tbl_BarCodeInfo.DeleteObject(lDelInfo[j]);
                            
                        //     }en.SaveChanges();


                        //     string conStr = ConfigurationManager.AppSettings["ConStr"];
                        //     SqlConnection con = new SqlConnection(conStr);
                        //     con.Open();
                        //    //插入单件
                        //  //   SqlTransaction tran = con.BeginTransaction();//开始事务
                        //    List<string> lSigleCodes = BarCode.BuildBarCode(int.Parse(obj.BuildBatchID.ToString()), (int)BarCodeType.单件, oBunch.Count);
                        //    for (int i = 0; i < lSigleCodes.Count; i++)
                        //    {
                        //        Tbl_BarCodeBatch oSigleBunch = new Tbl_BarCodeBatch();
                        //        oSigleBunch.BuildBatchID = obj.BuildBatchID;
                        //        oSigleBunch.BarCodeType = (int)BarCodeType.单件;
                        //        oSigleBunch.BarCodeNo = lSigleCodes[i];
                        //        oSigleBunch.CreateTime = DateTime.Now;
                        //        Tbl_BarCodeInfo oSigleInfo = new Tbl_BarCodeInfo();
                        //        oSigleInfo.BarCodeBatchID = obj.BuildBatchID;
                        //        oSigleInfo.BuildName = oBunch.BuildName;
                        //        oSigleInfo.CreateTime = DateTime.Now;
                        //        oSigleInfo.MateriesType = oBunch.MateriesType;
                        //        oSigleInfo.WorkMapID = oBunch.WorkMapID;
                        //        oSigleInfo.ProjectName = oBunch.ProjectName;
                        //        //en.Tbl_BarCodeBatch.AddObject(oSigleBunch);
                        //        //en.Tbl_BarCodeInfo.AddObject(oSigleInfo);
                        //        SqlCommand com1 = new SqlCommand("insert into Tbl_BarCodeBatch(BuildBatchID,BarCodeNo,CreateTime,BarCodeType) values(" + oSigleBunch.BuildBatchID + ",'" + oSigleBunch.BarCodeNo + "','" + oSigleBunch.CreateTime + "'," + oSigleBunch.BarCodeType + ")", con);
                        //        SqlCommand com2 = new SqlCommand("insert into Tbl_BarCodeInfo(BarCodeBatchID,CreateTime,ProjectName,BuildName,MateriesType,WorkMapID) values(" + oSigleInfo.BarCodeBatchID + ",'" + oSigleInfo.CreateTime + "','" + oSigleInfo.ProjectName + "','" + oSigleInfo.BuildName + "','" + oSigleInfo.MateriesType + "','" + oSigleInfo.WorkMapID + "')", con);
                        //        com1.ExecuteScalar();
                        //        com2.ExecuteScalar();
                              
                        //    }





                        //    //批次
                        //    List<string> lCodes = BarCode.BuildBarCode(int.Parse(obj.BuildBatchID.ToString()), (int)BarCodeType.批次);
                        //    Tbl_BarCodeBatch oBunchBarCode = new Tbl_BarCodeBatch();
                        //    oBunchBarCode.BuildBatchID = obj.BuildBatchID;
                        //    oBunchBarCode.BarCodeType = (int)BarCodeType.批次;
                        //    oBunchBarCode.BarCodeNo = lCodes[0];
                        //    oBunchBarCode.CreateTime = DateTime.Now;

                        //    Tbl_BarCodeInfo oBarCodeInfo = new Tbl_BarCodeInfo();
                        //    oBarCodeInfo.BarCodeBatchID = obj.BuildBatchID;
                        //    oBarCodeInfo.BuildName = oBunch.BuildName;
                        //    oBarCodeInfo.CreateTime = DateTime.Now;
                        //    oBarCodeInfo.MateriesType = oBunch.MateriesType;
                        //    oBarCodeInfo.WorkMapID = oBunch.WorkMapID;
                        //    oBarCodeInfo.ProjectName = oBunch.ProjectName;
                           
                        //    SqlCommand com3 = new SqlCommand("insert into Tbl_BarCodeBatch(BuildBatchID,BarCodeNo,CreateTime,BarCodeType) values(" + oBunchBarCode.BuildBatchID + ",'" + oBunchBarCode.BarCodeNo + "','" + oBunchBarCode.CreateTime + "'," + oBunchBarCode.BarCodeType + ")", con);
                        //    SqlCommand com4 = new SqlCommand("insert into Tbl_BarCodeInfo(BarCodeBatchID,CreateTime,ProjectName,BuildName,MateriesType,WorkMapID) values(" + oBarCodeInfo.BarCodeBatchID + ",'" + oBarCodeInfo.CreateTime + "','" + oBarCodeInfo.ProjectName + "','" + oBarCodeInfo.BuildName + "','" + oBarCodeInfo.MateriesType + "','" + oBarCodeInfo.WorkMapID + "')", con);
                        //    com3.ExecuteScalar();
                        //    com4.ExecuteScalar();
                        //   // tran.Commit();
                        //    con.Close();
                        //    msg = new Msg(true) { UserData = lCodes };
                        
                   
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
        /// 新编辑如库
        /// </summary>
        /// <param name="oBunch"></param>
        /// <returns></returns>
        public static Msg NEditInBunch(List<Tbl_ProductBatch> list)
        {
             Msg msg = null;
            //构造调码对象
            List<Tbl_BarCodeBatch> lBarcode = new List<Tbl_BarCodeBatch>();

            //    List<Tbl_BarCodeInfo> lBarCodeInfo = new List<Tbl_BarCodeInfo>();

           
        
                try
                {
                    using (var en = new LingYunEntities())
                    {
                        List<string> BarCodes=new List<string>();
                        foreach(Tbl_ProductBatch oPro in list)
                        {
                     
                        
                            en.Tbl_ProductBatch.AddObject(oPro);
                            en.SaveChanges();
                            Tbl_ProductBatch oProduct = en.Tbl_ProductBatch.Where(a => a.MateriesID == oPro.MateriesID).ToList().LastOrDefault();

                            //批次
                            List<string> lCodes = BarCode.BuildBarCode(oProduct.WorkMapID, (int)BarCodeType.批次);
                           BarCodes.Add(lCodes[0]);
                            Tbl_BarCodeBatch oBunchBarCode = new Tbl_BarCodeBatch();
                            oBunchBarCode.BarCodeBatchID = oProduct.BuildBatchID;
                            oBunchBarCode.BarCodeType = (int)BarCodeType.批次;
                            oBunchBarCode.BarCodeNo = lCodes[0];
                            oBunchBarCode.CreateTime = DateTime.Now;
                            oBunchBarCode.BuildBatchID = oProduct.BuildBatchID;
                            Tbl_BarCodeInfo oBarCodeInfo = new Tbl_BarCodeInfo();
                            oBarCodeInfo.BarCodeInfoID = oProduct.BuildBatchID;
                            oBarCodeInfo.BuildName = oPro.BuildName;
                            oBarCodeInfo.CreateTime = DateTime.Now;
                            oBarCodeInfo.MateriesType = oPro.MateriesType;
                            oBarCodeInfo.WorkMapID = oPro.WorkMapID;
                            oBarCodeInfo.ProjectName = oPro.ProjectName;
                            oBarCodeInfo.BarCodeBatchID = oProduct.BuildBatchID;
                            en.Tbl_BarCodeBatch.AddObject(oBunchBarCode);
                            en.Tbl_BarCodeInfo.AddObject(oBarCodeInfo);

                            //
                            List<string> lSigleCodes = BarCode.BuildBarCode(oProduct.WorkMapID, (int)BarCodeType.单件, oPro.Count);
                            for (int i = 0; i < lSigleCodes.Count; i++)
                            {
                                Tbl_BarCodeBatch oSigleBunch = new Tbl_BarCodeBatch();
                                oSigleBunch.BarCodeBatchID = oProduct.BuildBatchID;
                                oSigleBunch.BarCodeType = (int)BarCodeType.单件;
                                oSigleBunch.BarCodeNo = lSigleCodes[i];
                                oSigleBunch.CreateTime = DateTime.Now;
                                Tbl_BarCodeInfo oSigleInfo = new Tbl_BarCodeInfo();
                                oSigleInfo.BarCodeBatchID = oProduct.BuildBatchID;
                                oSigleInfo.BarCodeInfoID = oProduct.BuildBatchID;
                                oSigleInfo.BuildName = oPro.BuildName;
                                oSigleInfo.CreateTime = DateTime.Now;
                                oSigleInfo.MateriesType = oPro.MateriesType;
                                oSigleInfo.WorkMapID = oPro.WorkMapID;
                                oSigleInfo.ProjectName = oPro.ProjectName;
                                en.Tbl_BarCodeBatch.AddObject(oSigleBunch);
                                en.Tbl_BarCodeInfo.AddObject(oSigleInfo);
                            }
                        
                        }
                            en.SaveChanges();
                            msg = new Msg(true) { UserData = BarCodes };
                        
                    
                    }

                }
                catch (Exception ex)
                {
                    msg = new Msg() { Status = false, Message = ex.Message };
                }

            
            return msg;
        }
        public static bool QueryInBunch(int matries)
        {
          
           
                try
                {
                    using (var en = new LingYunEntities())
                    {
                        var oMatries = en.Tbl_ProductBatch.Where(a => a.MateriesID == matries).FirstOrDefault();
                        if (oMatries != null)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }


                }
                catch
                {
                    return false;
                }

            
      
        }
        public static Msg EnsureInBunch(Tbl_ProductBatch oBunch,Tbl_ProductStorage oStorage)
        {
            Msg msg = null;
            if (oBunch != null)
            {
                try
                {
                    using (var en = new LingYunEntities())
                    {

                        var oPlan = en.Tbl_Plan.Where(a => a.PlanID == oBunch.PlanID).FirstOrDefault();
                        oPlan.ProductAdmStatus = 128;
                        en.Tbl_ProductBatch.AddObject(oBunch);
                        en.SaveChanges();
                     var obj= en.Tbl_ProductBatch.Where(a => a.MateriesID == oBunch.MateriesID).FirstOrDefault();
                     oStorage.BuildBatchID = int.Parse(obj.BuildBatchID.ToString());
                        en.AddToTbl_ProductStorage(oStorage);
                      
                        msg = Msg.Default;
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
        /// 更新入库批次表
        /// </summary>
        /// <param name="matriesId"></param>
        /// <param name="count"></param>
        /// <param name="oStorage">仓储表</param>
        /// <returns></returns>
        public static Msg UpdateInBunch(int matriesId,int count,Tbl_ProductStorage oStorage)
        {
            Msg msg = null;
        
                try
                {
                    using (var en = new LingYunEntities())
                    {
                       
                        var obj = en.Tbl_ProductBatch.Where(a => a.BuildBatchID == oStorage.BuildBatchID).FirstOrDefault();
                       obj.Count = count;
                       obj.NowAdmStatus = 128;
                        obj.NowAdmTime=DateTime.Now;
                   
                         en.AddToTbl_ProductStorage(oStorage);
                        en.SaveChanges();

                       List<Tbl_ProductBatch> list=en.Tbl_ProductBatch.Where(a => a.PlanID == oStorage.PlanID&&a.NowAdmStatus==128).ToList();

                       int proCount = 0;
                       foreach (Tbl_ProductBatch oPro in list)
                       {
                           proCount += oPro.Count;
                       }
                      Tbl_Materies oMa= en.Tbl_Materies.Where(a => a.PlanID == oStorage.PlanID).FirstOrDefault();//最后如果确认完成对加工主管状态改变
                      if (oMa.TotalNum == proCount)
                      {
                          var oPlan = en.Tbl_Plan.Where(a => a.PlanID == oStorage.PlanID).FirstOrDefault();
                          oPlan.ProductAdmStatus = 128;
                          en.SaveChanges();
                      }
                        msg = Msg.Default;
                    }


                }
                catch (Exception ex)
                {
                    msg = new Msg() { Status = false, Message = ex.Message };
                }

            
            return msg;
        }
        /// <summary>
        /// 新确认入库批次表
        /// </summary>
        /// <param name="matriesId"></param>
        /// <param name="count"></param>
        /// <param name="oStorage">仓储表</param>
        /// <returns></returns>
        public static Msg NEnsureInBunch(List<Tbl_ProductStorage> list)
        {
            Msg msg = null;

            try
            {
                using (var en = new LingYunEntities())
                {

                   
                 foreach(Tbl_ProductStorage oPro in list)
                   
                 {
                     var oMatries = en.Tbl_Materies.Where(a => a.MateriesID == oPro.MateriesID).FirstOrDefault();
                     oMatries.NowAdmStatus = 128;
                     oMatries.NowDate = DateTime.Now.ToString();
                        var oBatch = en.Tbl_ProductBatch.Where(a =>a.BuildBatchID ==oPro.BuildBatchID).FirstOrDefault();
                        oBatch.NowAdmStatus = 128;
                        oBatch.NowAdmTime = DateTime.Now;
              
                        en.Tbl_ProductStorage.AddObject(oPro);
                       
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
        /// <summary>
        /// 新编辑出库批次表
        /// </summary>
        /// <param name="matriesId"></param>
        /// <param name="count"></param>
        /// <param name="oStorage">仓储表</param>
        /// <returns></returns>
        public static Msg NEditOurBunch(List<Tbl_OutProductBatch> list)
        {
            Msg msg = null;

            try
            {
                using (var en = new LingYunEntities())
                {


                    foreach (Tbl_OutProductBatch oPro in list)
                    {
                        en.Tbl_OutProductBatch.AddObject(oPro);
                        en.SaveChanges();
                    }
                    msg = Msg.Default;
                }


            }
            catch (Exception ex)
            {
                msg = new Msg() { Status = false, Message = ex.Message };
            }


            return msg;
        }

        /// <summary>
        /// 更新出库批次表批次表
        /// </summary>
        /// <param name="matriesId"></param>
        /// <param name="count"></param>
        /// <param name="oStorage">仓储表</param>
        /// <returns></returns>
        public static Msg UpdateOutBunch(Tbl_OutProductBatch oStorage,Tbl_CenterStorageBatch oCenterBunch)
        {
            Msg msg = null;
            if (oStorage != null)
            {
                try
                {
                    using (var en = new LingYunEntities())
                    {

                        var obj = en.Tbl_OutProductBatch.Where(a => a.BuildBatchID == oStorage.BuildBatchID).FirstOrDefault();
                        obj.Count = oStorage.Count;
                        obj.PreAdmStatus = 128;
                        obj.PreAdmTime = DateTime.Now;
       
                       var oProductStorage = en.Tbl_ProductStorage.Where(b => b.BuildBatchID == oStorage.BuildBatchID).FirstOrDefault();
                       oProductStorage.NowAdmStatus = 128;
                       oProductStorage.NowAdmTime = DateTime.Now;
                     en.Tbl_CenterStorageBatch.AddObject(oCenterBunch);//插入入库记录
                        en.SaveChanges();
                        msg = Msg.Default;
                    }


                }
                catch (Exception ex)
                {
                    msg = new Msg() { Status = false, Message = ex.Message };
                }

            }
            return msg;
        }
        /// 新确认出库批次表批次表
        /// </summary>
        /// <param name="matriesId"></param>
        /// <param name="count"></param>
        /// <param name="oStorage">仓储表</param>
        /// <returns></returns>
        public static Msg NEnsureOutBunch(List<Tbl_CenterStorageBatch> list)
        {
            Msg msg = null;
         
                try
                {
                    using (var en = new LingYunEntities())
                    {
                        foreach(Tbl_CenterStorageBatch oPro in list)
                        {
                            var obj = en.Tbl_OutProductBatch.Where(a => a.BuildBatchID == oPro.BuildBatchID).FirstOrDefault();
                        
                        obj.PreAdmStatus = 128;
                        obj.PreAdmTime = DateTime.Now;

                        var oProductStorage = en.Tbl_ProductStorage.Where(b => b.BuildBatchID == oPro.BuildBatchID).FirstOrDefault();
                        oProductStorage.NowAdmStatus = 128;
                        oProductStorage.NowAdmTime = DateTime.Now;
                        en.Tbl_CenterStorageBatch.AddObject(oPro);//插入入库记录
                       
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

        public static Msg AndroidOutEnsure(int iBatchId)
        { Msg msg = null;
            try{
              using (var en = new LingYunEntities())
                    {

                var obj=en.Tbl_ProductStorage.Where(a=>a.BuildBatchID==iBatchId).FirstOrDefault();
                 obj.NowAdmStatus=128;
                  obj.NowAdmTime=DateTime.Now;
                 var oOut=en.Tbl_OutProductBatch.Where(a=>a.BuildBatchID==iBatchId).FirstOrDefault();
                   oOut.PreAdmStatus=128;
                  oOut.PreAdmTime=DateTime.Now;
             //出库批次表
                Tbl_CenterStorageBatch oCenterBunch = new Tbl_CenterStorageBatch();
                oCenterBunch.PlanID = oOut.PlanID;
                oCenterBunch.MateriesTasbleID = oOut.MateriesTasbleID;
                oCenterBunch.BuildID =  oOut.BuildID;
                oCenterBunch.BuildBatchID=oOut.BuildBatchID;
                oCenterBunch.Time = DateTime.Now;
                oCenterBunch.ProjectName = oOut.ProjectName;
                oCenterBunch.BuildName =oOut.BuildName;
                oCenterBunch.ProjectName = oOut.ProjectName;
                oCenterBunch.MateriesID =oOut.MateriesID;
                oCenterBunch.MateriesType =oOut.MateriesType;
                oCenterBunch.WorkMapID = oOut.WorkMapID;
                oCenterBunch.Count =oOut.Count
;
                oCenterBunch.NowAdmStatus = 1;
                oCenterBunch.PreAdmStatus = 128;
                oCenterBunch.PreAdmTime = DateTime.Now;
                oCenterBunch.NowAdmTime = DateTime.Now;
                en.AddToTbl_CenterStorageBatch(oCenterBunch);
                  en.SaveChanges();
                 msg=Msg.Default;
              }
            }catch(Exception ex)
            {
                msg=new Msg(false);
            }
            return msg;
        }
        /// <summary>
        /// 查询所有以确定的加工中心批次表
        /// </summary>
        /// <param name="matries"></param>
        /// <returns></returns>
        public static Msg QueryAllEnsureStorage()
        {
            Msg msg = null;
    
                try
                {
                    using (var en = new LingYunEntities())
                    {
                        List<Tbl_ProductStorage> lMatries = en.Tbl_ProductStorage.Where(a => a.PreAdmStatus == 128).ToList();
                        if (lMatries != null)
                        {
                            msg = new Msg(true) { UserData=lMatries};
                        }
                        else
                        {
                            msg = new Msg(false) { Message="当前没有已确定的批次表" };
                        }
                    }


                }
                catch(Exception ex)
                {
                    msg = new Msg(false) { Message = ex.Message };
                }

            
            return msg;
        }
        /// <summary>
        /// 查询所有以确定的加工中心批次表
        /// </summary>
        /// <param name="matries"></param>
        /// <returns></returns>
        public static Msg QueryProductOutBunch()
        {
            Msg msg = null;

            try
            {
                using (var en = new LingYunEntities())
                {
                    List<Tbl_ProductStorage> lStorage = en.Tbl_ProductStorage.Where(a => a.PreAdmStatus == 128 && a.NowAdmStatus == 1).ToList();
                    if (lStorage != null)
                    {
                        msg = new Msg(true) { UserData = lStorage };

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
        /// 新查询查询出库
        /// </summary>
        /// <param name="matries"></param>
        /// <returns></returns>
        public static Msg NQueryProductOutBunch(int iPlanId)
        {
            Msg msg = null;

            try
            {
                using (var en = new LingYunEntities())
                {
                    List<Tbl_ProductStorage> lStorage = en.Tbl_ProductStorage.Where(a =>a.PlanID==iPlanId&&a.NowAdmStatus == 1).ToList();
                    if (lStorage != null)
                    {
                        msg = new Msg(true) { UserData = lStorage };

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
        /// 新确认出库
        /// </summary>
        /// <param name="matries"></param>
        /// <returns></returns>
        public static Msg NQueryEnsureProductOutBunch(int iPlanId)
        {
            Msg msg = null;

            try
            {
                using (var en = new LingYunEntities())
                {
                    List<Tbl_OutProductBatch> lStorage = en.Tbl_OutProductBatch.Where(a => a.PlanID == iPlanId && a.PreAdmStatus != 128).ToList();
                    if (lStorage != null)
                    {
                        msg = new Msg(true) { UserData = lStorage };

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
                    Tbl_OutProductBatch oStorage = en.Tbl_OutProductBatch.Where(a => a.BuildBatchID == Id).FirstOrDefault();
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
        /// 根据指定的批次编号查询记录
        /// </summary>
        /// <param name="matries"></param>
        /// <returns></returns>
        public static Msg QueryProductStorageById(int Id)
        {
            Msg msg = null;

            try
            {
                using (var en = new LingYunEntities())
                {
                    Tbl_ProductStorage oStorage = en.Tbl_ProductStorage.Where(a => a.BuildBatchID == Id).FirstOrDefault();
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

        public static Msg EditOutBunch(Tbl_OutProductBatch oBunch)
        {
            Msg msg = null;
            if (oBunch != null)
            {
                try
                {
                    using (var en = new LingYunEntities())
                    {
                        Tbl_OutProductBatch obj = en.Tbl_OutProductBatch.Where(a => a.PlanID == oBunch.PlanID && oBunch.MateriesID == a.MateriesID).FirstOrDefault();
                        if (obj == null)
                        {
                            en.Tbl_OutProductBatch.AddObject(oBunch);

                        }
                        else
                        {
                            obj.Count = oBunch.Count;

                        }
                        en.SaveChanges();
                        msg = Msg.Default;
                    }


                }
                catch (Exception ex)
                {
                    msg = new Msg() { Status = false, Message = ex.Message };
                }

            }
            return msg;
        }

        public static Msg GetUnsureOutBunch(int BuildBunchId)
        {
            Msg msg = null;

            try
            {
                using (var en = new LingYunEntities())
                {
                    List<Tbl_OutProductBatch> lStorage = en.Tbl_OutProductBatch.Where(a => a.PreAdmStatus == 1).ToList();
                    if (lStorage != null)
                    {
                        msg = new Msg(true) { UserData = lStorage };
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


        public static Msg GetPreUnsureInBatch()
        {
              Msg msg = null;

              try
              {
                  using (var en = new LingYunEntities())
                  {
                      List<Tbl_ProductBatch> li = en.Tbl_ProductBatch.Where(a => a.NowAdmStatus !=128).ToList();
                      if (li != null)
                      {
                          msg = new Msg(true) { UserData = li };
                      }
                      else
                          msg = new Msg(false) { Message = "当前没有未确认的项目" };
                  }
              }
              catch (Exception ex)
              {
                  msg = new Msg(false) { Message = ex.Message };
              }
              return msg;
        }
        /// <summary>
        /// 新获取未确认状态
        /// </summary>
        /// <returns></returns>
        public static Msg NGetPreUnsureInBatch(int iPlanId)
        {
            Msg msg = null;

            try
            {
                using (var en = new LingYunEntities())
                {
                    List<Tbl_ProductBatch> li = en.Tbl_ProductBatch.Where(a => a.PlanID==iPlanId&&a.NowAdmStatus != 128).ToList();                    if (li != null)
                    {
                        msg = new Msg(true) { UserData = li };
                    }
                    else
                        msg = new Msg(false) { Message = "当前没有未确认的项目" };
                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }

        /// <summary>
        /// android端确认
        /// </summary>
        /// <param name="oBunch"></param>
        /// <param name="oStorage"></param>
        /// <returns></returns>
        public static Msg AndroidInBunch(int iBatchId)
        {
            Msg msg = null;
          
                try
                {
                    using (var en = new LingYunEntities())
                    {

                     
                        var obj = en.Tbl_ProductBatch.Where(a => a.BuildBatchID ==iBatchId).FirstOrDefault();
                       obj.NowAdmStatus=128;
                        obj.NowAdmTime=DateTime.Now;

                         Tbl_ProductStorage oStorage = new Tbl_ProductStorage();
                    oStorage.PlanID = obj.PlanID;
                    oStorage.Time = DateTime.Now;
                    oStorage.MateriesID =obj.MateriesID;
                    oStorage.BuildID =obj.BuildID;
                    oStorage.BuildName =obj.BuildName;
                    oStorage.BuildBatchID = int.Parse(obj.BuildBatchID.ToString());
                    oStorage.MateriesType =obj.MateriesType;
                    oStorage.PreAdmTime = DateTime.Now;
                    oStorage.PreAdmStatus = 128;
                    oStorage.NowAdmStatus = 1;
                    oStorage.NowAdmTime = DateTime.Now;
                    oStorage.ProjectName = obj.ProjectName;
                    oStorage.WorkMapID =obj.WorkMapID;
                    oStorage.InCount = obj.Count;
                      en.Tbl_ProductStorage.AddObject(oStorage);
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