using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LingYunDemo.Dal;
using LingYunDemo.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace LingYunDemo.Model.upload
{
    public class UpLoadModel
    {
        public static List<string> QueryMatriesName()
        {
            string conStr = ConfigurationManager.AppSettings["ConStr"];
            SqlConnection con = new SqlConnection(conStr);
            con.Open(); List<string> list = new List<string>();
            try
            {
                string sql = "SELECT distinct TableName FROM Tbl_InMaries";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader da = cmd.ExecuteReader();
          
                while (da.Read())
                {
                    list.Add(da.GetString(0));
                }
            }
            catch (SqlException ex)
            {
                con.Close();

            }
         
            return list;

        }
        public static Msg GetMatriesByName(string Name)
        {
            Msg msg = null;
            using (var en = new LingYunEntities())
            {
              List<Tbl_InMaries> list= en.Tbl_InMaries.Where(a => a.TableName == Name).ToList();
              if (list.Count > 0)
                  msg = new Msg(true) { UserData = list };
              else
                  msg = new Msg(false) { Message = "没有找到记录" };
            }
            return msg;
        }
    }
}