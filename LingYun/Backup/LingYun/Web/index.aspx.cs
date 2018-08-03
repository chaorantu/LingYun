using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYun.Common;

namespace LingYun.Web
{
    public partial class index :BasePage

    {
        protected override void OnInit(EventArgs e)
        {
            this.ValidateUserLoginState = false;
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }
    }
}