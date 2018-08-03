using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LingYun.Data.Enum;

namespace LingYun.Helper
{
    public class StatusClass
    {
        private static StatusClass oStatus = new StatusClass();
        public int CurrPlanId { get; set; }
        public int CurrStatus = (int)CurrentStatus.默认;
        public StatusClass()
        {
        }
        public StatusClass(int id)
        {
            oStatus.CurrPlanId = id;
            oStatus.CurrStatus = (int)CurrentStatus.默认;

        }
        public static StatusClass GetInstance()
        {
            return oStatus;
        }

    }
}