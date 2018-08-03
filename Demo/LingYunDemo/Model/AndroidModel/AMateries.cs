using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LingYunDemo.Data;
using LingYunDemo.Dal;

namespace LingYunDemo.Model.AndroidModel
{
    public class AMateries
    {
        public static Msg GetUnsure()
        {
            Msg msg = null;
            try
            {
                using (var en = new LingYunEntities())
                {
                    List<Tbl_Materies> lMateries = en.Tbl_Materies.OrderByDescending((b => b.Date)).ToList();
                    if (lMateries.Count > 0)
                    {
                        msg = new Msg(true) { UserData = lMateries };
                    }
                    else
                    {
                        msg = new Msg(false);
                    }
                }
            }
            catch (Exception ex)
            {
                msg = new Msg(false);
            } return msg;
        }
    }
}