using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Common;
using LingYunDemo.Data.Enum;

namespace LingYunDemo.Web
{
    public partial class Menu: BasePage
    {
        protected override void OnInit(EventArgs e)
        {
            this.ValidateUserLoginState = true;
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //项目中心 
            addPlan.Visible = false;
            editPlan.Visible = false;
            queryWaitEnsurePlan.Visible = false;
            queryEnsurePlan.Visible = false;
            //设计中心
            editMatries.Visible = false;
            ensureMatries.Visible = false;
            queryMatries.Visible = false;
            //加工中心
            editInPuductBuntch.Visible = false;
            ensureInPuductBuntch.Visible = false;
            queryProductStotrage.Visible = false;
            editOutProductBuntch.Visible = false;
            ensureOutProductBuntch.Visible = false;
            //中心仓储
            ensureInCenterBuntch.Visible = false;
            queryCenterStotrage.Visible = false;
            editOutCenterBuntch.Visible = false;
            ensureOutCenterBuntch.Visible = false;
            //现场仓储
            ensureInSiteBuntch.Visible = false;
            querySiteStotrage.Visible = false;
            editOutSiteBuntch.Visible = false;
            ensureOutSiteBuntch.Visible = false;

            if (this.CurrentUserInfo != null)
            {
                if ((this.CurrentUserInfo.Identify & (int)UserData.系统管理员) != 0)
                {
                    


                    if (this.CurrentUserInfo.Type == (int)LoginType.主管密码)
                    {
                        addPlan.Visible = true;
                        editPlan.Visible = true;
                      
                        queryEnsurePlan.Visible = true;
                        editMatries.Visible = true;
                    
                        queryMatries.Visible = true;
                        editInPuductBuntch.Visible = true;
                
                        queryProductStotrage.Visible = true;
                        editOutProductBuntch.Visible = true;
                
                       
                        queryCenterStotrage.Visible = true;
                        editOutCenterBuntch.Visible = true;
       
                 
                        querySiteStotrage.Visible = true;
                        editOutSiteBuntch.Visible = true;
                      
                    }
                    else if (this.CurrentUserInfo.Type == (int)LoginType.确认密码)
                    {
                        addPlan.Visible = true;
                    
                        queryWaitEnsurePlan.Visible = true;
                        queryEnsurePlan.Visible = true;
                
                        ensureMatries.Visible = true;
                        queryMatries.Visible = true;
            
                        ensureInPuductBuntch.Visible = true;
                        queryProductStotrage.Visible = true;
              
                        ensureOutProductBuntch.Visible = true;
                        ensureInCenterBuntch.Visible = true;
                        queryCenterStotrage.Visible = true;
                   
                        ensureOutCenterBuntch.Visible = true;
                        ensureInSiteBuntch.Visible = true;
                        querySiteStotrage.Visible = true;
            
                        ensureOutSiteBuntch.Visible = true;
                    }
                    else { }
                        

                }
           
                if ((this.CurrentUserInfo.Identify & (int)UserData.项目主管) != 0)
                {
                    if (this.CurrentUserInfo.Type == (int)LoginType.主管密码)
                    {
                        addPlan.Visible = true;
                        editPlan.Visible = true;
       
                        queryEnsurePlan.Visible = true;
                    }
                    else if(this.CurrentUserInfo.Type == (int)LoginType.确认密码)
                    {
                            addPlan.Visible = true;
                        editPlan.Visible = true;
                        queryWaitEnsurePlan.Visible = true;
                        queryEnsurePlan.Visible = true;

                    }
                    else { }
                        
                }
                if ((this.CurrentUserInfo.Identify & (int)UserData.设计主管) != 0)
                {
                    if (this.CurrentUserInfo.Type == (int)LoginType.主管密码)
                    {
                        editMatries.Visible = true;
                        queryMatries.Visible = true;
                    }
                    else if (this.CurrentUserInfo.Type == (int)LoginType.确认密码)
                    {
                        
                        ensureMatries.Visible = true;
                        queryMatries.Visible = true;

                    }
                    else { }

                 


                }
                if ((this.CurrentUserInfo.Identify & (int)UserData.加工主管) != 0)
                {
                    if (this.CurrentUserInfo.Type == (int)LoginType.主管密码)
                    {
                        editInPuductBuntch.Visible = true;
                    
                        queryProductStotrage.Visible = true;
                        editOutProductBuntch.Visible = true;
                  
                    }
                    else if (this.CurrentUserInfo.Type == (int)LoginType.确认密码)
                    {
                       
                        ensureInPuductBuntch.Visible = true;
                        queryProductStotrage.Visible = true;
                 
                        ensureOutProductBuntch.Visible = true;

                    }
                    else { }
                 



                  
            
                }
                if ((this.CurrentUserInfo.Identify & (int)UserData.中心仓库主管) != 0)
                {
                    if (this.CurrentUserInfo.Type == (int)LoginType.主管密码)
                    {

                        queryCenterStotrage.Visible = true;
                        editOutCenterBuntch.Visible = true;


                    }
                    else if (this.CurrentUserInfo.Type == (int)LoginType.确认密码)
                    {
                        ensureInCenterBuntch.Visible = true;
                        queryCenterStotrage.Visible = true;
                    
                        ensureOutCenterBuntch.Visible = true;

                    }
                    else { }


              
                }
                if ((this.CurrentUserInfo.Identify & (int)UserData.现场仓库主管) != 0)
                {
                    if (this.CurrentUserInfo.Type == (int)LoginType.主管密码)
                    {

          
                        querySiteStotrage.Visible = true;
                        editOutSiteBuntch.Visible = true;
                

                    }
                    else if (this.CurrentUserInfo.Type == (int)LoginType.确认密码)
                    {
                        ensureInSiteBuntch.Visible = true;
                        querySiteStotrage.Visible = true;
                     
                        ensureOutSiteBuntch.Visible = true;

                    }
                    else { }



           

                }
                if ((this.CurrentUserInfo.Identify & (int)UserData.员工) != 0)
                {
             

                }
                if ((this.CurrentUserInfo.Identify & (int)UserData.系统管理员) != 0)
                {


                }
            
            }

        }
    }
}
