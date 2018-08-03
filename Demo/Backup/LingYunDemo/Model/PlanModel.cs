using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LingYunDemo.Data;
using LingYunDemo.Dal;

namespace LingYunDemo.Model
{
    public class PlanModel
    {
        //创建人：梁林
        //时间：3/29
        /// <summary>
        ///向项目汇总表增加一条项目
        /// </summary>
        /// <param name="oPlan">项目表对象</param>
        /// <returns>消息传输实体</returns>
        public static Msg AddPlan(Tbl_Plan oPlan)
        {
            Msg msg = null;
            if (oPlan != null)
            {
                try
                {
                    using (var en = new LingYunEntities())
                    {
                        en.Tbl_Plan.AddObject(oPlan);
                        en.SaveChanges();
                        msg =Msg.Default;
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
        ///向项目汇总表增加一条项目
        /// </summary>
        /// <param name="oPlan">项目表对象</param>
        /// <returns>消息传输实体</returns>
        public static Msg EditPlan(Tbl_Plan oPlan)
        {
            Msg msg = null;
            if (oPlan != null)
            {
                try
                {
                    using (var en = new LingYunEntities())
                    {
                        Tbl_Plan obj = en.Tbl_Plan.Where(a => a.PlanID == oPlan.PlanID).FirstOrDefault();
                        if (obj != null)
                        {
                            obj.ProjectName = oPlan.ProjectName; 
                            obj.ProductAdm = oPlan.ProductAdm;
                            obj.DesignAdm = oPlan.DesignAdm;
                            obj.CenterStorageAdm = obj.CenterStorageAdm;
                            obj.SiteStorageAdm = obj.SiteStorageAdm;
                            obj.PlanDate = DateTime.Now;
                            en.SaveChanges();
                            msg = Msg.Default;
                        }
                        else
                        {
                            msg = new Msg(false) { Message = "没有查到要确认的项目" };
                        }
                    }


                }
                catch (Exception ex)
                {
                    msg = new Msg(false) { Message = "没有查到要确认的项目" };
                }

            }
            return msg;
        }

        /// <summary>
        ///向项目汇总表增加一条项目
        /// </summary>
        /// <param name="oPlan">项目表对象</param>
        /// <returns>消息传输实体</returns>
        public static Msg EnsurePlan(Tbl_Plan oPlan)
        {
            Msg msg = null;
            if (oPlan != null)
            {
                try
                {
                    using (var en = new LingYunEntities())
                    {
                        Tbl_Plan obj = en.Tbl_Plan.Where(a => a.PlanID == oPlan.PlanID).FirstOrDefault();
                        if (obj != null)
                        {
                            obj.PlanAdmStatus = 128;
                            obj.ProductAdm = oPlan.ProductAdm;
                            obj.DesignAdm = oPlan.DesignAdm;
                            obj.CenterStorageAdm = obj.CenterStorageAdm;
                            obj.SiteStorageAdm = obj.SiteStorageAdm;
                            en.SaveChanges();
                            msg = Msg.Default;
                        }
                        else
                        {
                            msg = new Msg(false) { Message = "没有查到要确认的项目" };
                        }
                    }


                }
                catch (Exception ex)
                {
                           msg = new Msg(false) { Message = "没有查到要确认的项目" };
                }

            }
            return msg;
        }

        //创建人：梁林
        //时间：3/29
        /// <summary>
        ///查看所有项目
        /// </summary>
        /// <param name="oPlan">项目表对象</param>
        /// <returns>消息传输实体</returns>
        public static Msg ShowAllPlan()
        {
            Msg msg = null;
            List<Tbl_Plan> lPlans = new List<Tbl_Plan>(); ;
            try
            {
                using (var en = new LingYunEntities())
                {
                    lPlans = en.Tbl_Plan.OrderByDescending(a=>a.PlanID).ToList();
                }
                msg = new Msg() { UserData = lPlans, Status = true };
            }
            catch (Exception ex)
            {
                msg = new Msg() { Status = false, Message = ex.Message };
            }

            return msg;
        }

        /// <summary>
        /// 2014 5.6  能够编辑所有项目
        /// </summary>
        /// <returns></returns>
        public static Msg QueryUnsurePlan()
        {
            Msg msg = null;
            List<Tbl_Plan> lPlans = new List<Tbl_Plan>(); ;
            try
            {
                using (var en = new LingYunEntities())
                {
                    lPlans = en.Tbl_Plan.OrderByDescending(a=>a.PlanDate).ToList();
                }
                if(lPlans!=null&&lPlans.Count>0)
                msg = new Msg() { UserData = lPlans, Status = true };
                else
                    msg = new Msg(false) { Message="未找到记录"};
             }
            catch (Exception ex)
            {
                msg = new Msg() { Status = false, Message = ex.Message };
            }

            return msg;
        }

        public static Msg QyeryPlanById(int iPlanId)
        {
            Msg msg = null;
            Tbl_Plan oUsers = new Tbl_Plan(); ;
            try
            {
                using (var en = new LingYunEntities())
                {
                    oUsers = en.Tbl_Plan.Where(a => a.PlanID == iPlanId).FirstOrDefault();
                }
                msg = new Msg() { UserData = oUsers, Status = true };
            }
            catch (Exception ex)
            {
                msg = new Msg() { Status = false, Message = ex.Message };
            }

            return msg;
           
        }
       


        public static string GetPlanAdmName(int  iAdmId)
        {
            
            string sAdmName  ;
       
                using (var en = new LingYunEntities())
                {
                    sAdmName = en.Tbl_User.Where(a => a.ID == iAdmId).FirstOrDefault().Name;
                }



                return sAdmName;
           
        }


    }
}