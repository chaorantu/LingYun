using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LingYun.Data.Enum
{
    public enum UserData
    {
        系统管理员 = 128,
        项目主管 = 64,
        设计主管 = 32,
        加工主管 = 16,
        中心仓库主管 = 8,
        现场仓库主管 = 4,
        员工 = 2,
        系统调试 = 1

    }
    public enum LoginType
    {
        主管密码=0,
        确认密码=1
        
    }
}