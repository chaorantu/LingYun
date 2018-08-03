
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryDesign.aspx.cs" Inherits="LingYunDemo.Web.Order.Design.QueryDesign" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:RadioButton ID="rdbQueryAll" runat="server" Text="查看所有" 
            oncheckedchanged="rdbQueryAll_CheckedChanged" style="margin-left:300px" 
            checked="true" AutoPostBack="True" />
         <asp:RadioButton ID="rdbQueryProject" runat="server" Text="按项目查看" 
            oncheckedchanged="rdbQueryProject_CheckedChanged" AutoPostBack="True" />
    </div>
    <div>
    
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    
    </div>
    <div id="divShow" style="display:none" runat="server">
    <ul runat="server" id="list">
    <li style="margin-bottom:10px;padding:12px 15px;line-height:26px; background:#E5E3E4;"></li>
        </ul>

    </div>
    </form>
   <script type="text/javascript">
       function urlLocation(value) {
           window.location = "QueryProject.aspx?PlanId=" + value;
       }
   </script>
</body>
</html>
