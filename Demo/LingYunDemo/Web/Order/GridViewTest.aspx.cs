using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LingYunDemo.Dal;

namespace LingYunDemo.Web.Order
{
    public partial class GridViewTest : System.Web.UI.Page
    {
     public static  List<Tbl_User> lUsers = new List<Tbl_User>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lUsers = getData();
                //  addCol();

                GridView1.DataSource = BuildGridViewDataSource(lUsers);
                GridView1.DataBind();
            }
         
        }
        /// <summary>
        /// 添加列
        /// </summary>
        private void addCol()
        {
          
        }
        /// <summary>
        /// 绑定数据到DataTable
        /// </summary>
        /// <returns></returns>
        private DataTable BuildGridViewDataSource(List<Tbl_User> lUsers)
        {
            DataTable dt = new DataTable();
       
            dt.Columns.Add("用户名");
            dt.Columns.Add("身份");
            dt.Columns.Add("密码");

            
            foreach (Tbl_User oUser in lUsers)
            {
                DataRow dr = dt.NewRow();
   
                dr[0] =oUser.Name;
                dr[1] = oUser.Access;
                dr[2] = oUser.LoginPwd;
                dt.Rows.Add(dr);
            }
            return dt;
        }
 

        private List<Tbl_User> getData()
        {
            List<Tbl_User> li=new List<Tbl_User>();
            using (var en = new LingYunEntities())
            {
                li=en.Tbl_User.ToList();

            }
            return li;
        }

        protected void addRows_Click(object sender, EventArgs e)
        {
            string sUserName = txbUsername.Text;
            string sPsd = txbPsd.Text;
            string sIdentify = txbIdentify.Text;
            Tbl_User oUser = new Tbl_User();
            oUser.Name = sUserName;
            oUser.LoginPwd = sPsd;
            oUser.Access =int.Parse(sIdentify);
            lUsers.Add(oUser);

            GridView1.DataSource = BuildGridViewDataSource(lUsers);
            GridView1.DataBind();
      
        }

        protected void deleteRows_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((System.Web.UI.HtmlControls.HtmlInputCheckBox)this.GridView1.Rows[i].FindControl("chkBox")).Checked == true)
                {
                    lUsers.RemoveAt(i);
                }
            }

               
            GridView1.DataSource = BuildGridViewDataSource(lUsers);
            GridView1.DataBind();
      
        }

        protected void chagneRows_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((System.Web.UI.HtmlControls.HtmlInputCheckBox)this.GridView1.Rows[i].FindControl("chkBox")).Checked == true)
                {
                   
                    string username = GridView1.Rows[i].Cells[1].Text;
                    string psd = GridView1.Rows[i].Cells[2].Text;
                    string identfy = GridView1.Rows[i].Cells[3].Text;
                    txbUsername.Text = username;
                    txbPsd.Text = psd;
                    txbIdentify.Text = identfy;
                }
            }
          
           
        }

        protected void submit_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((System.Web.UI.HtmlControls.HtmlInputCheckBox)this.GridView1.Rows[i].FindControl("chkBox")).Checked == true)
                {

                    lUsers[i].Name = txbUsername.Text;
                    lUsers[i].LoginPwd = txbPsd.Text;
                    lUsers[i].Access = int.Parse(txbIdentify.Text); 
                }
            }
          
            GridView1.DataSource = BuildGridViewDataSource(lUsers);
            GridView1.DataBind();
        }

    }
}