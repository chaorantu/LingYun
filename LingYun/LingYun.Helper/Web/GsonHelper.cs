using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace LingYun.Helper.Web
{
    public class GsonHelper
    {
        JavaScriptSerializer jss = null;
        public GsonHelper()
        {
            jss = new JavaScriptSerializer();
        }
        public string GetSerializerString(object obj)
        {
            return jss.Serialize(obj);
        }
    }
}
