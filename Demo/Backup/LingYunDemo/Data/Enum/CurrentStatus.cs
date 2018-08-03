using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LingYunDemo.Data.Enum
{
    //当前状态
    public enum CurrentStatus
    {
        错误 = -1,
        默认 = 0,
        项目主管确认 = 1,
        设计主管确认 = 2,
        加工主管确认 = 3,
        中心仓储主管确认 = 4,
        现场仓储主管确认 = 5,
        领料 = 6,
        完成 = 7

    }
    public enum BatchStatus
    {

    加工仓库入库待审批=1,
    加工仓库待出库审批 = 2,
    中心仓库入库待审批 = 3,
    中心仓库待出库审批 =4,
   现场仓库入库待审批 = 5,
   现场仓库待出库审批 = 6,
        待领料=7,
        已领料=8
    }

}