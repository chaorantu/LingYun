<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Status3.aspx.cs" Inherits="LingYunDemo.Web.Status3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<script type="text/javascript">
    function Show() {
        var obj = document.getElementById("GridView1").style.display;
        if (obj == 'block') {
            document.getElementById("img1").src = "Images/minicalendar/lastUpdate_icon_close.png";
            document.getElementById("isShow").innerText = "显示项目进度";
            document.getElementById("GridView1").style.display = "none";
            window.parent.document.getElementsByTagName('frameset')[2].rows = '30,*'; 
        }
        else {
            document.getElementById("img1").src = "Images/minicalendar/lastUpdate_icon_open.png";
            document.getElementById("isShow").innerText = "不显示项目进度";
            window.parent.document.getElementsByTagName('frameset')[2].rows = '250,*';
            document.getElementById("GridView1").style.display = "block";
        }
    
    }

</script>
</head>

<body>
    <form id="form1" runat="server">
    <div id="divShow" onclick="Show()" style="background-color:#EFF3FB; height: 26px;" ><strong id="isShow" onclick="Show()">不显示进度</strong><span style="right:8px;position:absolute"><img 
          id="img1"  alt="" style="height: 16px;" 
            src="Images/minicalendar/lastUpdate_icon_open.png" onclick="Show()" /></span></div>
   
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <div  >
    <asp:GridView ID="GridView1" 
            style="display:block;margin-left: auto;margin-right: auto;"  runat="server" 
            CaptionAlign="Top" CellPadding="4" 
            ForeColor="#333333" Width="834px" AllowPaging="True" 
            onpageindexchanging="changed" PageSize="5">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" HorizontalAlign="Center" Wrap="False" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
            HorizontalAlign="Center" Wrap="False" />
        <PagerSettings FirstPageText="首页" LastPageText="最后页" Mode="NumericFirstLast" 
            NextPageText="下一页" PageButtonCount="5" PreviousPageText="上一页" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" Wrap="False" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        
    </asp:GridView>
    </div>
    </form>
</body>
</html>
