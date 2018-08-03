using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LingYunDemo.Data;
using LingYunDemo.Dal;
using LingYunDemo.Data.Enum;

namespace LingYunDemo.Model
{
    public class PlanStatusModel
    {

        /// <summary>
        /// 获取未完成的项目
        /// </summary>
        /// <returns></returns>
        public static Msg GetUnFillPlans()
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    List<Tbl_Plan> lPlans = en.Tbl_Plan.OrderByDescending(a=>a.PlanID).ToList();//没有领料完
                    if (lPlans.Count > 0)
                    {
                        msg = new Msg(true) { UserData = lPlans };
                    }
                    else
                    {
                        msg = new Msg(false) { Message = "未查找到记录" };
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
        /// 获取项目完成的百分比
        /// </summary>
        /// <param name="iPlanId">项目id</param>
        /// <param name="iTableType">表类型</param>
        /// <returns></returns>
        public static Msg GetPlanPercentById(int iPlanId,int iTableType)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {

                  
                 
                        if (iTableType == (int)TableType.加工中心)
                        {
                           List<Tbl_ProductStorage> li=en.Tbl_ProductStorage.Where(b => b.PlanID == iPlanId).ToList();
                           msg = new Msg(true) { UserData = li };
                        }
                        else if (iTableType == (int)TableType.中心仓储)
                        {
                            List<Tbl_CenterStorage> li = en.Tbl_CenterStorage.Where(b => b.PlanID == iPlanId).ToList();
                            msg = new Msg(true) { UserData = li };
                        }
                        else if (iTableType == (int)TableType.现场仓储)
                        {
                            List<Tbl_SiteStorage> li = en.Tbl_SiteStorage.Where(b => b.PlanID == iPlanId).ToList();
                            msg = new Msg(true) { UserData = li };
                        }
                        else 
                        {
                           
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
        /// 获取项目的总数目
        /// </summary>
        /// <param name="iPlanId">项目id</param>
        /// <returns></returns>
        public static int GetMateriesById(int iPlanId)
        {
            int count=0;
         
                using (var en = new LingYunEntities())
                {

                   count=en.Tbl_Materies.Where(a => a.PlanID == iPlanId).FirstOrDefault().TotalNum;
                }


                return count;
        }

        public static string GetProjectName(int iPlanId)
        {
            string ProjectName;

            using (var en = new LingYunEntities())
            {

                ProjectName = en.Tbl_Materies.Where(a => a.PlanID == iPlanId).FirstOrDefault().ProjectName;
            }


            return ProjectName;
        }
        /// <summary>
        /// 获取项目的总数目
        /// </summary>
        /// <param name="iPlanId">项目id</param>
        /// <returns></returns>
        public static int NGetMateriesCountById(int iPlanId)
        {
            int count = 0;

            using (var en = new LingYunEntities())
            {

                List<Tbl_Materies> list = en.Tbl_Materies.Where(a => a.PlanID == iPlanId&&a.BeforeAdmStatus==128).ToList();
                if (list.Count > 0)
                {
                    foreach (Tbl_Materies obj in list)
                    {
                        count += obj.TotalNum;
                    }
                }
            }


            return count;
        }

    }
}