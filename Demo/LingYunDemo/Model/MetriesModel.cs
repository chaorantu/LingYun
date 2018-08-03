using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LingYunDemo.Data;
using LingYunDemo.Dal;
using System.Configuration;
using System.Data.SqlClient;

namespace LingYunDemo.Model
{
    public class MetriesModel
    {
        public static Msg AddMateries(Tbl_Materies oMatries)
        {
            Msg msg = null;
            try
            {

                using (var en = new LingYunEntities())
                {
                    en.AddToTbl_Materies(oMatries);
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
        public static Msg AddMateries(List<Tbl_Materies> oMatries)
        {
            Msg msg = null;
            try
            {

                using (var en = new LingYunEntities())
                {
                    foreach (Tbl_Materies ma in oMatries)
                    {
                        en.AddToTbl_Materies(ma);
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
        public static Msg UpdateMateries(Tbl_Materies oMatries)
        {
            Msg msg = null;
            try
            {

                using (var en = new LingYunEntities())
                {
                   Tbl_Materies obj=en.Tbl_Materies.Where(a=>a.PlanID==oMatries.PlanID).FirstOrDefault();
                   obj.Date = oMatries.Date;
                   obj.BuildNum = oMatries.BuildNum;
                   obj.BuildName = oMatries.BuildName;
                   obj.NowAdmStatus = oMatries.NowAdmStatus;
                   obj.TotalNum = oMatries.TotalNum;
                   obj.MateriesType = oMatries.MateriesType;
                   obj.ProcessingNum = oMatries.ProcessingNum;
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

        public static Msg EnsureMateries(Tbl_Materies oMatries)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    Tbl_Materies obj = en.Tbl_Materies.Where(a => a.PlanID == oMatries.PlanID).FirstOrDefault();
                    obj.Date = oMatries.Date;
                    obj.BuildNum = oMatries.BuildNum;
                    obj.BuildName = oMatries.BuildName;
                    obj.NowAdmStatus = oMatries.NowAdmStatus;
                    obj.TotalNum = oMatries.TotalNum;
                    obj.MateriesType = oMatries.MateriesType;
                    obj.NowDate = DateTime.Now.ToString();
                    obj.ProcessingNum = oMatries.ProcessingNum;
                    Tbl_Plan oPlan = en.Tbl_Plan.Where(b => b.PlanID == oMatries.PlanID).FirstOrDefault();
                    if(oPlan!=null)
                    oPlan.DesignAdmStatus = 128;
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
        /// 批量确认
        /// </summary>
        /// <param name="oMatries"></param>
        /// <returns></returns>
        public static Msg EnsureMateries(List<Tbl_Materies> lMatries)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    foreach (Tbl_Materies oMatries in lMatries)
                    {
                        Tbl_Materies obj = en.Tbl_Materies.Where(a => a.MateriesID == oMatries.MateriesID).FirstOrDefault();
                        obj.Date = oMatries.Date;
                        obj.BuildNum = oMatries.BuildNum;
                        obj.BuildName = oMatries.BuildName;
                        obj.NowAdmStatus = oMatries.NowAdmStatus;
                        obj.TotalNum = oMatries.TotalNum;
                        obj.MateriesType = oMatries.MateriesType;
                        obj.BeforeAdmStatus = 128;
                        obj.PreDate = DateTime.Now.ToString();
                        obj.NowAdmStatus = 1;
                        obj.NowDate = DateTime.Now.ToString();
                        obj.ProcessingNum = oMatries.ProcessingNum;

                      
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
        public static Msg GetUnDesignedPlan()
        {

         
            Msg msg = null;
            try
            {
                 List<Tbl_Plan> lPlans=new List<Tbl_Plan>();
                using (var en = new LingYunEntities())
                {
               lPlans = en.Tbl_Plan.OrderByDescending(a=>a.PlanID).ToList();
                }
                if (lPlans.Count > 0)
                {
                    msg = new Msg(true) { UserData = lPlans };
                }
                else
                {
                    msg = new Msg(false){Message="您当前没有要编辑的项目" };

                }
            }
            catch(Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;

        }
        /// <summary>
        /// 获取没有确认的材料表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetUnsureMatries()
        {
            string conStr = ConfigurationManager.AppSettings["ConStr"];
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sql = "SELECT distinct PlanID FROM Tbl_Materies";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader da = cmd.ExecuteReader();
            List<string> list = new List<string>();
            while (da.Read())
            {
                list.Add(da.GetSqlInt32(0).ToString());
            }
            con.Close();
            return list;
        }
        /// <summary>
        /// 获取没有确认的材料表
        /// </summary>
        /// <returns></returns>
        public static Msg AGetUnsureMatries()
        {
            Msg msg = null;
            try
            {
                List<Tbl_Materies> oMetries = new List<Tbl_Materies>();
                using (var en = new LingYunEntities())
                {
                    oMetries = en.Tbl_Materies.Where(a => a.NowAdmStatus!=128).ToList();
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
        public static List<string> GetMetriesProjectName(List<string> li)
        {
            List<string> list = new List<string>();


            using (var en = new LingYunEntities())
            {
                foreach (string oo in li)
                {
                    int ii = Int32.Parse(oo);
                    list.Add(en.Tbl_Plan.Where(a => a.PlanID == ii).FirstOrDefault().ProjectName);
                }
            }


                return list;
        }
        public static Msg GetMetriesByPlanId(int iPlanId)
        {
            Msg msg = null;
            try
            {
                Tbl_Plan oMetries = new Tbl_Plan();
                using (var en = new LingYunEntities())
                {
                    oMetries = en.Tbl_Plan.Where(a => a.PlanID== iPlanId).FirstOrDefault();
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
        public static Msg GetMetriesByMatriesId(int iPlanId)
        {
            Msg msg = null;
            try
            {
                List<Tbl_Materies> oMetries = new List<Tbl_Materies>();
                using (var en = new LingYunEntities())
                {
                    oMetries = en.Tbl_Materies.Where(a => a.PlanID == iPlanId).Where(a=>a.NowAdmStatus!=128).ToList();
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
     
           public static bool GetMetriesById(int IMatriesid)
        {
            bool msg = false;
        
                Tbl_Materies oMetries = new Tbl_Materies();
              
                    using (var en = new LingYunEntities())
                    {
                        oMetries = en.Tbl_Materies.Where(a => a.MateriesID == IMatriesid).FirstOrDefault();
                    }
                    if (oMetries != null)
                    {
                        msg = true;
                    }
             
           
                return msg;
        }
    
        public static Msg  QueryMatries()
        {
            Msg msg = null;
            List<Tbl_Materies> lMetries = new List<Tbl_Materies>();
            try
            {
                using (var en = new LingYunEntities())
                {
                    lMetries = en.Tbl_Materies.Where(a => a.BeforeAdmStatus == 128).OrderByDescending(a=>a.Date).ToList();
                }
                if (lMetries != null)
                {
                    msg = new Msg(true) { UserData = lMetries };
                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }

        public static Msg QueryProjectName()
        {
            Msg msg = null;
            List<Tbl_Plan> lMetries = new List<Tbl_Plan>();
            try
            {
                using (var en = new LingYunEntities())
                {
                    lMetries = en.Tbl_Plan.OrderByDescending(a=>a.PlanDate).ToList();
                }
                if (lMetries != null)
                {
                    msg = new Msg(true) { UserData = lMetries };
                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }

        public static Msg QueryProject(int iPlanId)
        {
            Msg msg = null;
            List<Tbl_Materies> lMetries = new List<Tbl_Materies>();
            try
            {
                using (var en = new LingYunEntities())
                {
                    lMetries = en.Tbl_Materies.Where(a => a.PlanID == iPlanId).OrderByDescending(a => a.Date).ToList();
                }
                if (lMetries != null)
                {
                    msg = new Msg(true) { UserData = lMetries };
                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false) { Message = ex.Message };
            }
            return msg;
        }

        public static Msg GetMatriesCount(int iMatriesId)
        {
            Msg msg = null;
            Tbl_Materies oMetries = new Tbl_Materies();
            try
            {
                using (var en = new LingYunEntities())
                {
                    oMetries = en.Tbl_Materies.Where(a => a.MateriesID == iMatriesId).FirstOrDefault();
                }
                if (oMetries != null)
                {
                    msg = new Msg(true) { UserData = oMetries };
                }
                else
                {
                    msg = new Msg(false) { Message = "未找到记录数" };
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
        /// <param name="oMatries"></param>
        /// <returns></returns>
        public static Msg AndroidEnsure(int iPlanid)
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    Tbl_Materies obj = en.Tbl_Materies.Where(a => a.MateriesID == iPlanid).FirstOrDefault();
                    obj.NowAdmStatus = 128;
                    obj.NowDate = DateTime.Now.ToString();
                    Tbl_Plan oPlan = en.Tbl_Plan.Where(b => b.PlanID == obj.PlanID).FirstOrDefault();
                    if (oPlan != null)
                        oPlan.DesignAdmStatus = 128;
                   

                 
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


       
    }
}