using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace LingYunDemo.Helper.Security
{
    public class Md5Helper
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input">要加密的字符串</param>
        /// <returns></returns>
        public static string GetMD5Hash(String input)
        {
         
            byte[] b = Encoding.UTF8.GetBytes(input);
            b = new MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');

            return ret;
        }
    }
}