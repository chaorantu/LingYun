<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="Header.aspx.cs" Inherits="LingYunDemo.Web.Header" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 
</head>
<body>
<form runat="server">
    <TABLE cellSpacing=0 cellPadding=0 width="100%" 
background="images/header_bg.jpg" border=0>
  <TR height=56>
    <TD width=260><IMG height=56 src="images/header_left.jpg" 
    width=260></TD>
    <TD style="FONT-WEIGHT: bold; COLOR: #fff; PADDING-TOP: 20px" 
      align=middle>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 当前用户：<span id="currUsername" runat="server"></span> &nbsp;&nbsp; </TD>
       <TD style="FONT-WEIGHT: bold; COLOR: #fff; PADDING-TOP: 20px" 
      align=middle>身份：<span id="currIdentify" runat="server"></span> &nbsp;&nbsp; &nbsp;&nbsp;<span id="Span1" runat="server"></span>
           <asp:LinkButton style="COLOR: #fff" ID="logout" runat="server" onclick="UserLogOut" 
              >退出系统</asp:LinkButton>
    </TD>
   
    <TD align=right width=268><IMG height=56 
      src="images/header_right.jpg" width=268></TD></TR></TABLE>
<TABLE cellSpacing=0 cellPadding=0 width="100%" border=0>
  <TR bgColor=#1c5db6 height=4>
    <TD>
    <li id="liStatus" runat="server" >
    <%--<span>技术下单-></span>
  <span>技术下单-></span>
<span   style="background-color:Orange">加工中心</span>--%></li>
 </TD></TR></TABLE>
    </form>
</body>
</html>
