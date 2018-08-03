using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace LingYunDemo.Helper.VerifyCode
{
    public class BuildVerifyCodeHelper
    {
        /// <summary>
        /// 验证码生成的取值范围
        /// </summary>
        private static string[] verifycodeRange = { "1","2","3","4","5","6","7","8","9","0",
                                                    "a","b","c","d","e","f","g",
                                                    "h","i", "j","k","l","m","n",
                                                        "o","p","q",    "r","s","t",
                                                    "u","v","w",    "x","y","z"
                                                  };
        /// <summary>
        /// 生成验证码所使用的随机数发生器
        /// </summary>
        private static Random verifycodeRandom = new Random();

       
        /// <summary>
        /// 产生验证码
        /// </summary>
        /// <param name="len">长度</param>
        /// <param name="OnlyNum">是否仅为数字</param>
        /// <returns>string</returns>
        public static string CreateAuthStr(int len, bool OnlyNum)
        {
            int number;
            StringBuilder checkCode = new StringBuilder();

            for (int i = 0; i < len; i++)
            {
                if (!OnlyNum)
                    number = verifycodeRandom.Next(0, verifycodeRange.Length);
                else
                    number = verifycodeRandom.Next(0, 10);

                checkCode.Append(verifycodeRange[number]);
            }
            return checkCode.ToString();
        }
    }
}