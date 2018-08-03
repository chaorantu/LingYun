using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LingYunDemo.Data;
using LingYunDemo.Dal;
using LingYunDemo.Data.Enum;

namespace LingYunDemo.Model.AndroidModel
{
    public class APreEnsure
    {
        public static Msg QueryUnsure(int access)
        {
              Msg msg = null;
      
        
                 if (access == (int)UserData.项目主管)
                {
                  msg=PlanModel.QueryUnsurePlan();

                } if (access == (int)UserData.设计主管)
                {
                    msg = MetriesModel.AGetUnsureMatries();

                }
                 return msg;
           
        }        
    }
}