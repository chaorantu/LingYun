using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LingYunDemo.Data.Enum;
using LingYunDemo.Data;

namespace LingYunDemo.Common
{
    public class BarCode
    {
        /// <summary>
        /// 批次条码调用
        /// </summary>
        /// <param name="iBatchId"></param>
        /// <param name="iType"></param>
        /// <returns></returns>
        public static List<string> BuildBarCode(string iBatchId, int iType)
        {
          return  BuildBarCode(iBatchId,iType,1);
        }
        /// <summary>
        /// 单件生成调用
        /// </summary>
        /// <param name="iBatchId"></param>
        /// <param name="iType"></param>
        /// <returns></returns>
        public static List<string> BuildBarCode(string iBatchId, int iType, int count)
        {
           
            List<string> lBarCode = new List<string>(); 
            if ((int)BarCodeType.批次 == iType)
            {
                string sBatchCode =string.Empty;
                sBatchCode += iBatchId.ToString();
              
                lBarCode.Add(sBatchCode);
         
            }
            else if ((int)BarCodeType.单件 == iType)
            {
               
                for (int i = 1; i <= count; i++)
                {
                    string sBatchCode = string.Empty;
                    sBatchCode += iBatchId.ToString();
                  
                    lBarCode.Add(sBatchCode);
                }
            }
            return lBarCode; 
        }

       
    }
}