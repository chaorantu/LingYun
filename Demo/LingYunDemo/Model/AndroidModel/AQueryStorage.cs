using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LingYunDemo.Data;
using LingYunDemo.Dal;
using LingYunDemo.Data.Enum;

namespace LingYunDemo.Model.AndroidModel
{
    public class AQueryStorage
    {
        public static Msg QueryStorage(int iPlanid,int iTableId)
    {
        Msg msg = null;
        try
        {
            using (var en = new LingYunEntities())
            {
                if (iTableId == (int)TableType.加工中心)
                {
                    List<Tbl_ProductStorage> lProduct=en.Tbl_ProductStorage.Where(a => a.PlanID == iPlanid).ToList();
                    if (lProduct != null)
                    {
                        msg = new Msg(true) { UserData = lProduct };

                    }
                    else
                    {
                        msg = new Msg(false) {Message="没有找到记录" };

                    }

                }
                if (iTableId == (int)TableType.中心仓储)
                {
                    List<Tbl_CenterStorage> lProduct = en.Tbl_CenterStorage.Where(a => a.PlanID == iPlanid).ToList();
                    if (lProduct != null)
                    {
                        msg = new Msg(true) { UserData = lProduct };

                    }
                    else
                    {
                        msg = new Msg(false) { Message = "没有找到记录" };

                    }

                }
                if (iTableId == (int)TableType.现场仓储)
                {
                    List<Tbl_SiteStorage> lProduct = en.Tbl_SiteStorage.Where(a => a.PlanID == iPlanid).ToList();
                    if (lProduct != null)
                    {
                        msg = new Msg(true) { UserData = lProduct };

                    }
                    else
                    {
                        msg = new Msg(false) { Message = "没有找到记录" };

                    }

                }

            }
        }
        catch (Exception ex)
        {
            msg = new Msg(false) { Message=ex.Message};
        } return msg;
    }
    }
}