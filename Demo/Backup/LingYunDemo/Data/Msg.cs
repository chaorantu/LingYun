using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LingYunDemo.Data
{
    [Serializable]
    /// <summary>
    /// 用于传输的消息实体
    /// </summary>
   public class Msg
    {
       /// <summary>
       /// 消息状态
       /// </summary>
       public bool Status
       {
           get;
           set;
       }
       /// <summary>
       /// 消息文本
       /// </summary>
       public string Message
       {
           get;
           set;
       }
       /// <summary>
       /// 需要传递的用户数据
       /// </summary>
       public object UserData
       {
           get;
           set;
       }
       /// <summary>
       /// 异常信息
       /// </summary>
       public Exception ex
       {
           get;
           set;
       }
       public Msg()
       { 
       
       }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bSuccess"></param>
       public Msg(bool bSuccess)
       {
           Status = bSuccess;
       }
        /// <summary>
        /// 默认消息体
        /// </summary>
        /// <returns></returns>
       public static Msg Default
       {
           get
           {
               return new Msg(true);
           }
       }

    }
}
