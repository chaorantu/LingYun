<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MenuTemplate.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="LingYunDemo.Web.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="Guide_back">
            <ul>
                <li id="Guide_top">
                    <div id="Guide_toptext">
                        
    凌云科技

                    </div>
                </li>
                <li id="Guide_main">
                    <div id="Guide_box">
                        
    <div class="guideexpand" onclick="Switch(this)">
        项目主管</div>
    <div class="guide">
        <ul>
           
            <li runat="server" id="addPlan"><a href="~/Web/Order/Plan/AddPlan.aspx" runat="server" target="Data" >增加项目</a></li>
            <li runat="server" id="editPlan"><a href="~/Web/Order/Plan/PrePlan.aspx" runat="server"  target="Data">编辑项目</a></li>
         <li runat="server" id="queryWaitEnsurePlan"><a href="~/Web/Order/Plan/PrePlan.aspx" runat="server"  target="Data">确认项目</a></li>
           <li runat="server" id="queryEnsurePlan"><a href="~/Web/Order/Plan/QueryPlan.aspx" runat="server"  target="Data">查看项目</a></li>
        </ul>
    </div>
       <div class="guideexpand" onclick="Switch(this)">
        设计主管</div>
    <div class="guide">
        <ul>
            <li runat="server" id="editMatries"><a href="~/Web/Order/Design/PreMatries.aspx" runat="server"  target="Data" >编辑材料表</a></li>
            <li runat="server" id="ensureMatries"><a href="~/Web/Order/Design/PreEnsureMatries.aspx" runat="server"  target="Data">确认提交材料表</a></li>
            <li runat="server" id="queryMatries"><a href="~/Web/Order/Design/QueryDesign.aspx" runat="server"  target="Data" >查看已提交材料表</a></li>
        </ul>
    </div>
     <div class="guideexpand" onclick="Switch(this)">
         加工主管</div>
    <div class="guide">
        <ul>
            <li runat="server" id="editInPuductBuntch"><a  href="Order/PlanCommon.aspx?Type=1"  target="Data" >编辑生产批次项目</a></li>
            <li runat="server" id="ensureInPuductBuntch"><a href="Order/PlanCommon.aspx?Type=1"  target="Data">确认生产批次项目</a></li>
            <li runat="server" id="queryProductStotrage"><a href="Order/QueryProductStorage.aspx"  target="Data">查看仓储</a></li>
            <li runat="server" id="editOutProductBuntch"><a href="Order/PlanCommon.aspx?Type=2"  target="Data" >编辑出库批次项目</a></li>
            <li runat="server" id="ensureOutProductBuntch"><a href="Order/PlanCommon.aspx?Type=2"  target="Data">确认出库批次项目</a></li>
        </ul>
    </div>
     <div class="guideexpand" onclick="Switch(this)">
        中心仓储</div>
    <div class="guide">
        <ul>
            <li runat="server" id="ensureInCenterBuntch"><a href="Order/PlanCommon.aspx?Type=3"  target="Data">确认入库批次表</a></li>
            <li href="/temp.aspx" runat="server" id="queryCenterStotrage"><a  href="Order/CenterStorage/QueryCenterStorage.aspx" target="Data">查看仓储</a></li>
            <li href="/temp.aspx" runat="server" id="editOutCenterBuntch"><a href="Order/PlanCommon.aspx?Type=4" target="Data" >编辑出库批次项目</a></li>
            <li href="/temp.aspx" runat="server" id="ensureOutCenterBuntch"><a href="Order/PlanCommon.aspx?Type=4" target="Data">确认出库批次项目</a></li>
        </ul>
    </div>
      <div class="guideexpand" onclick="Switch(this)">
        现场仓储</div>
    <div class="guide">
        <ul>
            <li runat="server" id="ensureInSiteBuntch"><a href="Order/PlanCommon.aspx?Type=5"  target="Data">确认入库批次表</a></li>
            <li runat="server" id="querySiteStotrage"><a href="Order/QuerySiteStorage.aspx"   target="Data">查看仓储</a></li>
              <li runat="server" id="editOutSiteBuntch"><a href="Order/PlanCommon.aspx?Type=6"  target="Data" >编辑出库批次项目</a></li>
            <li runat="server" id="ensureOutSiteBuntch"><a href="Order/PlanCommon.aspx?Type=6"  target="Data">确认出库批次项目</a></li>
        </ul>
    </div>
         <div class="guideexpand" onclick="Switch(this)">
        施工</div>
    <div class="guide">
        <ul>
            <li><a href="/temp.aspx" runat="server" id="take" target="main_right" >领料</a></li>
    
     
        </ul>
    </div>
                    </div>
                </li>
                <li id="Guide_bottom"></li>
            </ul>
        </div>
        <script type="text/javascript">
            var obj = document.getElementsByTagName("div"); //先得到所有的SPAN标记
            for (var i = 0; i < obj.length; i++) {
                if (obj[i].className == 'guideexpand')//找出span标记中class=a的那个标记
                {
                    Switch(obj[i]);
                }
            }

</script>
</asp:Content>
