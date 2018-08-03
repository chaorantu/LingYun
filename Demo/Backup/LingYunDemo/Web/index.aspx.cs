using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Common;

namespace LingYunDemo.Web
{
    public partial class index :BasePage

    {
        protected override void OnInit(EventArgs e)
        {
            this.ValidateUserLoginState = true;
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }
    }
}