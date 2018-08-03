using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LingYunDemo.Common;
using LingYunDemo.Data.Enum;
using LingYunDemo.Model;
using LingYunDemo.Data;
using LingYunDemo.Dal;
using System.Text;
using LingYunDemo.Helper.Web;
using LingYunDemo.Android;
using System.Threading;

namespace LingYunDemo.Web.Order
{
    public partial class MatriesCommon : BasePage
    {
        public enum CurrentType
        {
            加工登录入库 = 11,
            加工确认入库 = 12,
            加工登录出库 = 21,
            加工确认出库 = 22,
           
            中心确认入库 = 32,
           中心登录出库 = 41,
            中心确认出库 = 42,
            现场确认入库 = 52,
            现场登录出库 = 61,
            现场确认出库 = 62

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string palnId = this.Request["PlanID"];
                string type = this.Request["Type"];
                StringBuilder build = new StringBuilder();
                int iPlanId = int.Parse(palnId);
                Msg planMsg = PlanModel.QyeryPlanById(iPlanId);
                if (planMsg.Status)
                {
                    planName.InnerText = "用户导航:" + (planMsg.UserData as Tbl_Plan).ProjectName + "信息";
                }
                if (this.CurrentUserInfo.Type == (int)LoginType.主管密码)
                {
                    if (int.Parse(type) == (int)BatchStatus.加工仓库入库待审批)
                    {
                        Msg msg = ProductModel.NGetAllMetaries(int.Parse(palnId));
                        if (msg.Status)
                        {

                            List<Tbl_Materies> lMetries = msg.UserData as List<Tbl_Materies>;
                            ViewState["ListData"] = lMetries;
                            ViewState["Identify"] = (int)CurrentType.加工登录入库;
                            if (lMetries.Count > 0)
                            {
                                for (int i = 0; i < lMetries.Count; i++)
                                {
                                    //div的事件onclick='urlLocation(" + i + ")'
                                    build.Append(@"<li><div  style='margin-bottom:10px;padding:12px 15px;line-height:13px; background:#E5E3E4;'><input type='hidden' id='chk" + i + "' value='EditProductInBunch.aspx?MateriesID=" + lMetries[i].MateriesID + "'> <input  id='chk'" + i + " value=" + i + "  type='checkbox'  /><strong><a href='EditProductInBunch.aspx?MateriesID=" + lMetries[i].MateriesID + "'>材料编号：" + lMetries[i].MateriesID + "</a></strong></div></li>");
                                }
                            }
                        }
                    }
                    else if (int.Parse(type) == (int)BatchStatus.加工仓库待出库审批)
                    {

                        Msg msg = ProductModel.NQueryProductOutBunch(iPlanId);
                        if (msg.Status)
                        {

                            List<Tbl_ProductStorage> lStorage = msg.UserData as List<Tbl_ProductStorage>;
                            ViewState["ListData"] = lStorage;
                            ViewState["Identify"] = (int)CurrentType.加工登录出库;
                            if (lStorage.Count > 0)
                            {
                                for (int i = 0; i < lStorage.Count; i++)
                                {
                                    build.Append(@"<li><div  style='margin-bottom:10px;padding:12px 15px;line-height:13px; background:#E5E3E4;'><input type='hidden' id='chk" + i + "' value='EditProductOutBunch.aspx?BuildBunchId=" + lStorage[i].BuildBatchID + "'> <input  id='chk'" + i + " value=" + i + "  type='checkbox'  /><strong><a href='EditProductOutBunch.aspx?BuildBunchId=" + lStorage[i].BuildBatchID + "'>材料编号：" + lStorage[i].BuildBatchID + "</a></strong></div></li>");
                                 
                                }
                            }
                        }
                    }

                    else if (int.Parse(type) == (int)BatchStatus.中心仓库待出库审批)
                    {

                        Msg msg = Center.NQueryOutBunch(iPlanId);
                        if (msg.Status)
                        {

                            List<Tbl_CenterStorage> lStorage = msg.UserData as List<Tbl_CenterStorage>;
                            ViewState["ListData"] = lStorage;
                            ViewState["Identify"] = (int)CurrentType.中心登录出库;
                            if (lStorage.Count > 0)
                            {
                                for (int i = 0; i < lStorage.Count; i++)
                                {

                                    build.Append(@"<li><div  style='margin-bottom:10px;padding:12px 15px;line-height:13px; background:#E5E3E4;'><input type='hidden' id='chk" + i + "' value='CenterStorage/EditOutBunch.aspx?BuildBunchId=" + lStorage[i].BuildBatchID + "'> <input id='chk'" + i + " value=" + i + "  type='checkbox' ' /><strong><a href='CenterStorage/EditOutBunch.aspx?BuildBunchId=" + lStorage[i].BuildBatchID + "'>批次编号：" + lStorage[i].BuildBatchID + "</a></strong></div></li>");
                                }
                            }
                        }
                    }

                    else if (int.Parse(type) == (int)BatchStatus.现场仓库待出库审批)
                    {
                        Msg msg = SiteStorageModel.NQueryOutBunch(iPlanId);

                        if (msg.Status)
                        {


                            List<Tbl_SiteStorage> lBunch = msg.UserData as List<Tbl_SiteStorage>;
                            ViewState["ListData"] = lBunch;
                            ViewState["Identify"] = (int)CurrentType.现场登录出库;
                            if (lBunch.Count > 0)
                            {
                                for (int i = 0; i < lBunch.Count; i++)
                                {

                                    build.Append(@"<li><div  style='margin-bottom:10px;padding:12px 15px;line-height:13px; background:#E5E3E4;'><input type='hidden' id='chk" + i + "' value='EditSiteOutBunch.aspx?BuildBunchId=" + lBunch[i].BuildBatchID + "'> <input id='chk'" + i + " value=" + i + "  type='checkbox' ' /><strong><a href='EditSiteOutBunch.aspx?BuildBunchId=" + lBunch[i].BuildBatchID + "'>批次编号：" + lBunch[i].BuildBatchID + "</a></strong></div></li>");
                                }
                            }
                        }
                    }
                    else
                    {

                    }
                }
                else if (this.CurrentUserInfo.Type == (int)LoginType.确认密码)
                {
                    if (int.Parse(type) == (int)BatchStatus.加工仓库入库待审批)
                    {
                        Msg msg = ProductModel.NGetPreUnsureInBatch(int.Parse(palnId));
                        if (msg.Status)
                        {

                            List<Tbl_ProductBatch> lMetries = msg.UserData as List<Tbl_ProductBatch>;//批次表
                            ViewState["ListData"] = lMetries;
                            ViewState["Identify"] = (int)CurrentType.加工确认入库;
                            if (lMetries.Count > 0)
                            {
                                for (int i = 0; i < lMetries.Count; i++)
                                {
                                  

                                    build.Append(@"<li><div  style='margin-bottom:10px;padding:12px 15px;line-height:13px; background:#E5E3E4;'><input type='hidden' id='chk" + i + "' value='EnsureProductInBunch.aspx?BuildBatchId=" + lMetries[i].BuildBatchID + "'> <input  id='chk'" + i + " value=" + i + "  type='checkbox'  /><strong><a href='EnsureProductInBunch.aspx?BuildBunchId=" + lMetries[i].BuildBatchID + "'>批次编号：" + lMetries[i].BuildBatchID + "</a></strong></div></li>");
                                }
                            }
                        }
                    }
                    else if (int.Parse(type) == (int)BatchStatus.加工仓库待出库审批)
                    {
                        Msg msg = ProductModel.NQueryEnsureProductOutBunch(iPlanId);
                        if (msg.Status)
                        {

                            List<Tbl_OutProductBatch> lStorage = msg.UserData as List<Tbl_OutProductBatch>;
                            ViewState["ListData"] = lStorage;
                            ViewState["Identify"] = (int)CurrentType.加工确认出库;
                            if (lStorage.Count > 0)
                            {
                                for (int i = 0; i < lStorage.Count; i++)
                                {
                                    build.Append(@"<li><div  style='margin-bottom:10px;padding:12px 15px;line-height:13px; background:#E5E3E4;'><input type='hidden' id='chk" + i + "' value='EnsureProductOutBunch.aspx?BuildBunchId=" + lStorage[i].BuildBatchID + "'> <input  id='chk'" + i + " value=" + i + "  type='checkbox'  /><strong><a href='EnsureProductOutBunch.aspx?BuildBunchId=" + lStorage[i].BuildBatchID + "'>批次编号：" + lStorage[i].BuildBatchID + "</a></strong></div></li>");
                                 
                                }
                            }
                        }
                    }
                    else if (int.Parse(type) == (int)BatchStatus.中心仓库入库待审批)
                    {

                        Msg msg = Center.NQueryWaitInBunch(iPlanId);
                        if (msg.Status)
                        {

                            List<Tbl_CenterStorageBatch> lBunch = msg.UserData as List<Tbl_CenterStorageBatch>;
                            ViewState["ListData"] = lBunch;
                            ViewState["Identify"] = (int)CurrentType.中心确认入库;
                            if (lBunch.Count > 0)
                            {
                                for (int i = 0; i < lBunch.Count; i++)
                                {
                                    build.Append(@"<li><div  style='margin-bottom:10px;padding:12px 15px;line-height:13px; background:#E5E3E4;'><input type='hidden' id='chk" + i + "' value='CenterStorage/EnsureCenterInBunch.aspx?BuildBunchId=" + lBunch[i].BuildBatchID + "'> <input  id='chk'" + i + " value=" + i + "  type='checkbox'  /><strong><a href='CenterStorage/EnsureCenterInBunch.aspx?BuildBunchId=" + lBunch[i].BuildBatchID + "'>批次编号：" + lBunch[i].BuildBatchID + "</a></strong></div></li>");
                                 
                                }
                            }
                        }
                    }
                    else if (int.Parse(type) == (int)BatchStatus.中心仓库待出库审批)
                    {

                        Msg msg = Center.NQueryEnsureOutBunch(iPlanId);
                        if (msg.Status)
                        {

                            List<Tbl_OutCenterStorage> lStorage = msg.UserData as List<Tbl_OutCenterStorage>;
                            ViewState["ListData"] = lStorage;
                            ViewState["Identify"] = (int)CurrentType.中心确认出库;
                            if (lStorage.Count > 0)
                            {
                                for (int i = 0; i < lStorage.Count; i++)
                                {
                                    build.Append(@"<li><div  style='margin-bottom:10px;padding:12px 15px;line-height:13px; background:#E5E3E4;'><input type='hidden' id='chk" + i + "' value='CenterStorage/EnsureOutBunch.aspx?BuildBunchId=" + lStorage[i].BuildBatchID + "'> <input  id='chk'" + i + " value=" + i + "  type='checkbox'  /><strong><a href='CenterStorage/EnsureOutBunch.aspx?BuildBunchId=" + lStorage[i].BuildBatchID + "'>批次编号：" + lStorage[i].BuildBatchID + "</a></strong></div></li>");
                                 
                                   
                                }
                            }
                        }
                    }
                    else if (int.Parse(type) == (int)BatchStatus.现场仓库入库待审批)
                    {

                        Msg msg = SiteStorageModel.NQueryInBunch(iPlanId);
                        if (msg.Status)
                        {
                            List<Tbl_SiteStorageBatch> lBunch = msg.UserData as List<Tbl_SiteStorageBatch>;
                            ViewState["ListData"] = lBunch;
                            ViewState["Identify"] = (int)CurrentType.现场确认入库;

                            for (int i = 0; i < lBunch.Count; i++)
                            {
                                build.Append(@"<li><div  style='margin-bottom:10px;padding:12px 15px;line-height:13px; background:#E5E3E4;'><input type='hidden' id='chk" + i + "' value='EnsureSiteInBunch.aspx?BuildBunchId=" + lBunch[i].BuildBatchID + "'> <input  id='chk'" + i + " value=" + i + "  type='checkbox'  /><strong><a href='EnsureSiteInBunch.aspx?BuildBunchId=" + lBunch[i].BuildBatchID + "'>批次编号：" + lBunch[i].BuildBatchID + "</a></strong></div></li>");
                          
                            }

                        }
                    }
                
                else if (int.Parse(type) == (int)BatchStatus.现场仓库待出库审批)
                {
                    Msg msg = SiteStorageModel.NQueryEnsureOutBunch(iPlanId);

                    if (msg.Status)
                    {


                        List<Tbl_OutSiteStorage> lBunch = msg.UserData as List<Tbl_OutSiteStorage>;
                        ViewState["ListData"] = lBunch;
                        ViewState["Identify"] = (int)CurrentType.现场确认出库;
                        if (lBunch.Count > 0)
                        {
                            for (int i = 0; i < lBunch.Count; i++)
                            {
                                build.Append(@"<li><div  style='margin-bottom:10px;padding:12px 15px;line-height:13px; background:#E5E3E4;'><input type='hidden' id='chk" + i + "' value='EnsureSiteOutBunch.aspx?BuildBunchId=" + lBunch[i].BuildBatchID + "'> <input  id='chk'" + i + " value=" + i + "  type='checkbox'  /><strong><a href='EnsureSiteOutBunch.aspx?BuildBunchId=" + lBunch[i].BuildBatchID + "'>批次编号：" + lBunch[i].BuildBatchID + "</a></strong></div></li>");

                            }

                        }
                    }
                }
                else
                {

                }
            }
            else
            {

            }
              
                list.InnerHtml = build.ToString();
        }
        }
    


        protected void ensure_click(object sender, EventArgs e)
        {
            
            
                int iIdentify=int.Parse(ViewState["Identify"].ToString());
                object data = ViewState["ListData"];
           
                    GetIdentify(data, iIdentify);
                
        }

        public void GetIdentify(object data, int iIdentify)
        {
            if (checkAll.Checked)
            {
                Save(data, iIdentify);
            }
            else
            {

                Save(GetList(data, iIdentify), iIdentify);
            }
        }

        private object GetList(object data,int identify)
        {

            string ss = hiddenList.Value;
            string[] li = ss.Split(';');
            object obj = null;
            if (identify == (int)CurrentType.加工登录入库)
            {
                List<Tbl_Materies> lMa = data as List<Tbl_Materies>;
                List<Tbl_Materies> resList = new List<Tbl_Materies>();
                for (int i = 0; i < li.Length - 1; i++)
                {
                    resList.Add(lMa[int.Parse(li[i])]);
                }
                obj = resList;
            }
            else if (identify == (int)CurrentType.加工确认入库)
            {
                List<Tbl_ProductBatch> lMa = data as List<Tbl_ProductBatch>;
                List<Tbl_ProductBatch> resList = new List<Tbl_ProductBatch>();
                for (int i = 0; i < li.Length - 1; i++)
                {
                    resList.Add(lMa[int.Parse(li[i])]);
                }
                obj = resList;
            }
            else if (identify == (int)CurrentType.加工登录出库)
            {
                List<Tbl_ProductStorage> lMa = data as List<Tbl_ProductStorage>;
                List<Tbl_ProductStorage> resList = new List<Tbl_ProductStorage>();
                for (int i = 0; i < li.Length - 1; i++)
                {
                    resList.Add(lMa[int.Parse(li[i])]);
                }
                obj = resList;
            }
            else if (identify == (int)CurrentType.加工确认出库)
            {
                List<Tbl_OutProductBatch> lMa = data as List<Tbl_OutProductBatch>;
                List<Tbl_OutProductBatch> resList = new List<Tbl_OutProductBatch>();
                for (int i = 0; i < li.Length - 1; i++)
                {
                    resList.Add(lMa[int.Parse(li[i])]);
                }
                obj = resList;
            }
            else if (identify == (int)CurrentType.中心确认入库)
            {
                List<Tbl_CenterStorageBatch> lMa = data as List<Tbl_CenterStorageBatch>;
                List<Tbl_CenterStorageBatch> resList = new List<Tbl_CenterStorageBatch>();
                for (int i = 0; i < li.Length - 1; i++)
                {
                    resList.Add(lMa[int.Parse(li[i])]);
                }
                obj = resList;
            }
            else if (identify == (int)CurrentType.中心登录出库)
            {
                List<Tbl_CenterStorage> lMa = data as List<Tbl_CenterStorage>;
                List<Tbl_CenterStorage> resList = new List<Tbl_CenterStorage>();
                for (int i = 0; i < li.Length - 1; i++)
                {
                    resList.Add(lMa[int.Parse(li[i])]);
                }
                obj = resList;
            }
            else if (identify == (int)CurrentType.中心确认出库)
            {
                List<Tbl_OutCenterStorage> lMa = data as List<Tbl_OutCenterStorage>;
                List<Tbl_OutCenterStorage> resList = new List<Tbl_OutCenterStorage>();
                for (int i = 0; i < li.Length - 1; i++)
                {
                    resList.Add(lMa[int.Parse(li[i])]);
                }
                obj = resList;
            }
            else if (identify == (int)CurrentType.现场确认入库)
            {
                List<Tbl_SiteStorageBatch> lMa = data as List<Tbl_SiteStorageBatch>;
                List<Tbl_SiteStorageBatch> resList = new List<Tbl_SiteStorageBatch>();
                for (int i = 0; i < li.Length - 1; i++)
                {
                    resList.Add(lMa[int.Parse(li[i])]);
                }
                obj = resList;
            }
            else if (identify == (int)CurrentType.现场登录出库)
            {
                List<Tbl_SiteStorage> lMa = data as List<Tbl_SiteStorage>;
                List<Tbl_SiteStorage> resList = new List<Tbl_SiteStorage>();
                for (int i = 0; i < li.Length - 1; i++)
                {
                    resList.Add(lMa[int.Parse(li[i])]);
                }
                obj = resList;
            }
            else if (identify == (int)CurrentType.现场确认出库)
            {
                List<Tbl_OutSiteStorage> lMa = data as List<Tbl_OutSiteStorage>;
                List<Tbl_OutSiteStorage> resList = new List<Tbl_OutSiteStorage>();
                for (int i = 0; i < li.Length - 1; i++)
                {
                    resList.Add(lMa[int.Parse(li[i])]);
                }
                obj = resList;
            }
            return obj;               
        }

        public delegate void CallBack(Msg msg);
        private void Save(object data,int identify)
        {
            if (identify == (int)CurrentType.加工登录入库)
            {
                List<Tbl_Materies> lMa = data as List<Tbl_Materies>;
                List<Tbl_ProductBatch> lObj = new List<Tbl_ProductBatch>();
                foreach (Tbl_Materies oPro in lMa)
                {
                    Tbl_ProductBatch oSto = new Tbl_ProductBatch();
                    
                    oSto.BuildID = oPro.BuildNum;
                    oSto.BuildName = oPro.BuildName;
                    oSto.Count = oPro.TotalNum;
                    oSto.MateriesID = oPro.MateriesID;
                    oSto.MateriesTasbleID = 0;
                    oSto.MateriesType = oPro.MateriesType;
                    oSto.PlanID = oPro.PlanID;
                    oSto.PreAdmStatus = 1;
                    oSto.PreAdmTime = DateTime.Now;
                    oSto.NowAdmStatus = 1;
                    oSto.NowAdmTime = DateTime.Now;
                    oSto.ProjectName = oPro.ProjectName;
                    oSto.Time = DateTime.Now;
                    oSto.WorkMapID = oPro.ProcessingNum;
                    lObj.Add(oSto);
                }
                Msg msg = ProductModel.NEditInBunch(lObj);
                if (msg.Status)
                {
                    PageHelper.ShowAlertMsg(this,"编辑成功");
                }


             //  CallBack call = ReturnMsg;
             //   Thread thread = new Thread(() => GetBarCode(lObj, call));
               // thread.IsBackground = true;
             //   thread.Start();
         
              
            }
            else if (identify == (int)CurrentType.加工确认入库)
            {
                List<Tbl_ProductBatch> lMa = data as List<Tbl_ProductBatch>;
                List<Tbl_ProductStorage> lObj = new List<Tbl_ProductStorage>();
                foreach(Tbl_ProductBatch oPro in lMa)
                {
                    Tbl_ProductStorage oSto = new Tbl_ProductStorage();
                    oSto.BuildBatchID = (int)oPro.BuildBatchID;
                    oSto.BuildID = oPro.BuildID;
                    oSto.BuildName = oPro.BuildName;
                    oSto.InCount = oPro.Count;
                    oSto.MateriesID = oPro.MateriesID;
                    oSto.MateriesTasbleID = oPro.MateriesTasbleID;
                    oSto.MateriesType = oPro.MateriesType;
                    oSto.PlanID = oPro.PlanID;
                    oSto.PreAdmStatus = 128;
                    oSto.PreAdmTime = DateTime.Now;
                    oSto.NowAdmStatus = 1;
                    oSto.NowAdmTime = DateTime.Now;
                    oSto.ProjectName = oPro.ProjectName;
                    oSto.Time = DateTime.Now;
                    oSto.WorkMapID = oPro.WorkMapID;
                    lObj.Add(oSto);
                }
                Msg msg = ProductModel.NEnsureInBunch(lObj);
                if (msg.Status)
                {
                    PageHelper.ShowAlertMsg(this, "确认成功");
                }
                else
                {
                    PageHelper.ShowAlertMsg(this,"确认失败："+msg.Message);
                }
            }
            else if (identify == (int)CurrentType.加工登录出库)
            {
                List<Tbl_ProductStorage> lMa = data as List<Tbl_ProductStorage>;

                List<Tbl_OutProductBatch> lObj = new List<Tbl_OutProductBatch>();
                foreach (Tbl_ProductStorage oPro in lMa)
                {
                    Tbl_OutProductBatch oSto = new Tbl_OutProductBatch();
                    oSto.BuildBatchID = (int)oPro.BuildBatchID;
                    oSto.BuildID = oPro.BuildID;
                    oSto.BuildName = oPro.BuildName;
                    oSto.Count = oPro.InCount==null?0:(int)oPro.InCount;
                    oSto.MateriesID = oPro.MateriesID;
                    oSto.MateriesTasbleID = oPro.MateriesTasbleID;
                    oSto.MateriesType = oPro.MateriesType;
                    oSto.PlanID = oPro.PlanID;
                    oSto.PreAdmStatus = 1;
                    oSto.PreAdmTime = DateTime.Now;
                    oSto.NowAdmStatus = 1;
                    oSto.NowAdmTime = DateTime.Now;
                    oSto.ProjectName = oPro.ProjectName;
                    oSto.Time = DateTime.Now;
                    oSto.WorkMapID = oPro.WorkMapID;
                    lObj.Add(oSto);
                }
                Msg msg = ProductModel.NEditOurBunch(lObj);
                if (msg.Status)
                {
                    PageHelper.ShowAlertMsg(this, "确认成功");
                }
                else
                {
                    PageHelper.ShowAlertMsg(this, "确认失败：" + msg.Message);
                }
            }
            else if (identify == (int)CurrentType.加工确认出库)
            {
                List<Tbl_OutProductBatch> lMa = data as List<Tbl_OutProductBatch>;


                List<Tbl_CenterStorageBatch> lObj = new List<Tbl_CenterStorageBatch>();
                foreach (Tbl_OutProductBatch oPro in lMa)
                {
                    Tbl_CenterStorageBatch oSto = new Tbl_CenterStorageBatch();
                    oSto.BuildBatchID = (int)oPro.BuildBatchID;
                    oSto.BuildID = oPro.BuildID;
                    oSto.BuildName = oPro.BuildName;
                    oSto.Count = oPro.Count;
                    oSto.MateriesID = oPro.MateriesID;
                    oSto.MateriesTasbleID = oPro.MateriesTasbleID;
                    oSto.MateriesType = oPro.MateriesType;
                    oSto.PlanID = oPro.PlanID;
                    oSto.PreAdmStatus = 128;
                    oSto.PreAdmTime = DateTime.Now;
                    oSto.NowAdmStatus = 1;
                    oSto.NowAdmTime = DateTime.Now;
                    oSto.ProjectName = oPro.ProjectName;
                    oSto.Time = DateTime.Now;
                    oSto.WorkMapID = oPro.WorkMapID;
                    lObj.Add(oSto);
                }
                Msg msg = ProductModel.NEnsureOutBunch(lObj);
                if (msg.Status)
                {
                    PageHelper.ShowAlertMsg(this, "确认成功");
                }
                else
                {
                    PageHelper.ShowAlertMsg(this, "确认失败：" + msg.Message);
                }
            }
            else if (identify == (int)CurrentType.中心确认入库)
            {
                List<Tbl_CenterStorageBatch> lMa = data as List<Tbl_CenterStorageBatch>;


                List<Tbl_CenterStorage> lObj = new List<Tbl_CenterStorage>();
                foreach (Tbl_CenterStorageBatch oPro in lMa)
                {
                    Tbl_CenterStorage oSto = new Tbl_CenterStorage();
                    oSto.BuildBatchID = (int)oPro.BuildBatchID;
                    oSto.BuildID = oPro.BuildID;
                    oSto.BuildName = oPro.BuildName;
                    oSto.InCount = oPro.Count;
                    oSto.MateriesID = oPro.MateriesID;
                    oSto.MateriesTasbleID = oPro.MateriesTasbleID;
                    oSto.MateriesType = oPro.MateriesType;
                    oSto.PlanID = oPro.PlanID;
                    oSto.PreAdmStatus = 128;
                    oSto.PreAdmTime = DateTime.Now;
                    oSto.NowAdmStatus = 1;
                    oSto.NowAdmTime = DateTime.Now;
                    oSto.ProjectName = oPro.ProjectName;
                    oSto.Time = DateTime.Now;
                    oSto.WorkMapID = oPro.WorkMapID;
                    lObj.Add(oSto);
                }
                Msg msg = Center.NEnsureInBunch(lObj);
                if (msg.Status)
                {
                    PageHelper.ShowAlertMsg(this, "确认成功");
                }
                else
                {
                    PageHelper.ShowAlertMsg(this, "确认失败：" + msg.Message);
                }
            }
            else if (identify == (int)CurrentType.中心登录出库)
            {
                List<Tbl_CenterStorage> lMa = data as List<Tbl_CenterStorage>;

                List<Tbl_OutCenterStorage> lObj = new List<Tbl_OutCenterStorage>();
                foreach (Tbl_CenterStorage oPro in lMa)
                {
                    Tbl_OutCenterStorage oSto = new Tbl_OutCenterStorage();
                    oSto.BuildBatchID = (int)oPro.BuildBatchID;
                    oSto.BuildID = oPro.BuildID;
                    oSto.BuildName = oPro.BuildName;
                    oSto.Count = oPro.Count;
                    oSto.MateriesID = oPro.MateriesID;
                    oSto.MateriesTasbleID = oPro.MateriesTasbleID;
                    oSto.MateriesType = oPro.MateriesType;
                    oSto.PlanID = oPro.PlanID;
                    oSto.PreAdmStatus = 1;
                    oSto.PreAdmTime = DateTime.Now;
                    oSto.ProjectName = oPro.ProjectName;
                    oSto.Time = DateTime.Now;
                    oSto.WorkMapID = oPro.WorkMapID;
                    lObj.Add(oSto);
                }
                Msg msg = Center.NEditOutBunch(lObj);
                if (msg.Status)
                {
                    PageHelper.ShowAlertMsg(this, "确认成功");
                }
                else
                {
                    PageHelper.ShowAlertMsg(this, "确认失败：" + msg.Message);
                }
            }
            else if (identify == (int)CurrentType.中心确认出库)
            {
                List<Tbl_OutCenterStorage> lMa = data as List<Tbl_OutCenterStorage>;



                List<Tbl_SiteStorageBatch> lObj = new List<Tbl_SiteStorageBatch>();
                foreach (Tbl_OutCenterStorage oPro in lMa)
                {
                    Tbl_SiteStorageBatch oSto = new Tbl_SiteStorageBatch();
                    oSto.BuildBatchID = (int)oPro.BuildBatchID;
                    oSto.BuildID = oPro.BuildID;
                    oSto.BuildName = oPro.BuildName;
                    oSto.Count = oPro.Count;
                    oSto.MateriesID = oPro.MateriesID;
                    oSto.MateriesTasbleID = oPro.MateriesTasbleID;
                    oSto.MateriesType = oPro.MateriesType;
                    oSto.PlanID = oPro.PlanID;
                    oSto.PreAdmStatus = 128;
                    oSto.PreAdmTime = DateTime.Now;
                    oSto.ProjectName = oPro.ProjectName;
                    oSto.Time = DateTime.Now;
                    oSto.WorkMapID = oPro.WorkMapID;
                    lObj.Add(oSto);
                }
                Msg msg = Center.NEnsureOutBunch(lObj);
                if (msg.Status)
                {
                    PageHelper.ShowAlertMsg(this, "确认成功");
                }
                else
                {
                    PageHelper.ShowAlertMsg(this, "确认失败：" + msg.Message);
                }
            }
            else if (identify == (int)CurrentType.现场确认入库)
            {
                List<Tbl_SiteStorageBatch> lMa = data as List<Tbl_SiteStorageBatch>;

                List<Tbl_SiteStorage> lObj = new List<Tbl_SiteStorage>();
                foreach (Tbl_SiteStorageBatch oPro in lMa)
                {
                    Tbl_SiteStorage oSto = new Tbl_SiteStorage();
                    oSto.BuildBatchID = (int)oPro.BuildBatchID;
                    oSto.BuildID = oPro.BuildID;
                    oSto.BuildName = oPro.BuildName;
                    oSto.InCount = oPro.Count;
                    oSto.MateriesID = oPro.MateriesID;
                    oSto.MateriesTasbleID = oPro.MateriesTasbleID;
                    oSto.MateriesType = oPro.MateriesType;
                    oSto.PlanID = oPro.PlanID;
                    oSto.PreAdmStatus = 128;
                    oSto.PreAdmTime = DateTime.Now;
                    oSto.ProjectName = oPro.ProjectName;
                    oSto.Time = DateTime.Now;
                    oSto.WorkMapID = oPro.WorkMapID;
                    lObj.Add(oSto);
                }
                Msg msg = SiteStorageModel.NEnsureInBunch(lObj);
                if (msg.Status)
                {
                    PageHelper.ShowAlertMsg(this, "确认成功");
                }
                else
                {
                    PageHelper.ShowAlertMsg(this, "确认失败：" + msg.Message);
                }
            }
            else if (identify == (int)CurrentType.现场登录出库)
            {
                List<Tbl_SiteStorage> lMa = data as List<Tbl_SiteStorage>;
                List<Tbl_OutSiteStorage> lObj = new List<Tbl_OutSiteStorage>();
                foreach (Tbl_SiteStorage oPro in lMa)
                {
                    Tbl_OutSiteStorage oSto = new Tbl_OutSiteStorage();
                    oSto.BuildBatchID = (int)oPro.BuildBatchID;
                    oSto.BuildID = oPro.BuildID;
                    oSto.BuildName = oPro.BuildName;
                    oSto.Count = oPro.Count;
                    oSto.MateriesID = oPro.MateriesID;
                    oSto.MateriesTasbleID = oPro.MateriesTasbleID;
                    oSto.MateriesType = oPro.MateriesType;
                    oSto.PlanID = oPro.PlanID;
                    oSto.PreAdmStatus = 1;
                    oSto.PreAdmTime = DateTime.Now;
                    oSto.ProjectName = oPro.ProjectName;
                    oSto.Time = DateTime.Now;
                    oSto.WorkMapID = oPro.WorkMapID;
                    lObj.Add(oSto);
                }
                Msg msg = SiteStorageModel.NEditOutBunch(lObj);
                if (msg.Status)
                {
                    PageHelper.ShowAlertMsg(this, "确认成功");
                }
                else
                {
                    PageHelper.ShowAlertMsg(this, "确认失败：" + msg.Message);
                }
            }
            else if (identify == (int)CurrentType.现场确认出库)
            {
                List<Tbl_OutSiteStorage> lMa = data as List<Tbl_OutSiteStorage>;


                Msg msg = SiteStorageModel.EnsureOutBunch(lMa);
                if (msg.Status)
                {
                    PageHelper.ShowAlertMsg(this, "确认成功");
                }
                else
                {
                    PageHelper.ShowAlertMsg(this, "确认失败：" + msg.Message);
                }
            }



        }
        
         
         
                
       
        void ReturnMsg(Msg msg)
        {
            if (msg.Status)
            {
                List<string> list = msg.UserData as List<string>;
                
                if (msg.Status)
                {

                    CsPrint print = new CsPrint();
                    print.bartext = list;
                    print.print();
                }
            }
        }
          void GetBarCode(List<Tbl_ProductBatch> oBunch,CallBack call)
        {
            Msg msg = ProductModel.NEditInBunch(oBunch);
           
            if (call != null)
                call(msg);
          
        }

    }
}


