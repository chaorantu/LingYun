<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditMatries.aspx.cs" Inherits="LingYunDemo.Web.Order.Design.EditMatries" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../tablecloth/tablecloth.css" rel="stylesheet" type="text/css" />
    <script src="../tablecloth/tablecloth.js" type="text/javascript"></script>
       <style type="text/css">

    * {margin:0 0 0 0px;
padding:0;list-style:none;font-size:12px;line-height:20px;font-family:Arial;
    }
h1,h2,h3 { font-size:14px; margin:10px 0;}
hr { margin:10px 0; height:1px;clear:both;border:0; background:#c00;}
a:link,a:visited{color:#164A84;text-decoration:none;}
a:hover,a:active{color:#c00;text-decoration:underline;}
table { border-collapse:collapse;border:1px solid #ccc;border-width:1px 1px 0 0; margin-left:20px;}
td,th { padding:5px;border:1px solid #ccc;border-width:0 0 1px 1px;}





body{
	margin:0;
	padding:0;
	background:#f1f1f1;
	font:70% Arial, Helvetica, sans-serif; 
	color:#555;
	line-height:150%;
	text-align:left;
}
a{
	text-decoration:none;
	color:#057fac;
}
a:hover{
	text-decoration:none;
	color:#999;
}
h1{
	font-size:140%;
	margin:0 20px;
	line-height:80px;	
}
h2{
	font-size:120%;
}
#container{
	margin:0 auto;
	width:680px;
	background:#fff;
	padding-bottom:20px;
}
#content{margin:0 20px;}
p.sig{	
	margin:0 auto;
	width:680px;
	padding:1em 0;
}
form{
	margin:1em 0;
	padding:.2em 20px;
	background:#eee;
}
</style>
</head>
<body style="height: 240px">
    <form id="form1" runat="server">
  <%--  <div>
    
        <table style="width: 33%; height: 92px;">
            <tr>
                <td class="auto-style1">项目编号</td>
                <td>
                    <asp:TextBox ID="txbPlanId" runat="server" ReadOnly="True" Width="122px"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td class="auto-style1">选择材料表</td>
                <td>
                    <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
                  
                </td>
            </tr>
     </table>
        <asp:Button ID="Button2" runat="server" Height="24px" OnClick="Ensure" 
            Text="提交" Width="57px" />
&nbsp;&nbsp;&nbsp;&nbsp;--%>

    <div>
    
        <table style="width: 33%; height: 92px;">
            <tr>
                <td class="auto-style1">项目编号</td>
                <td>
                    <asp:TextBox ID="txbPlanId" runat="server" ReadOnly="True" Width="122px"></asp:TextBox>
                </td>
            </tr>
           
            <tr>
                <td class="auto-style1">构件编号</td>
                <td>
                    <asp:TextBox ID="txbBuildId" runat="server" Width="122px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">工程名</td>
                <td>
                    <asp:TextBox ID="txbProjectName" runat="server" Width="122px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">构件名称</td>
                <td>
                    <asp:TextBox ID="txbBuildName" runat="server" Width="122px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">材质</td>
                <td>
                    <asp:TextBox ID="txbMatriesType" runat="server" Width="122px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">加工图号</td>
                <td>
                    <asp:TextBox ID="txbWorkMapId" runat="server" Width="122px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">总数量</td>
                <td>
                    <asp:TextBox ID="txbCount" runat="server" Width="122px"></asp:TextBox>
                </td>
            </tr>
        </table>
     
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Height="24px" OnClick="Ensure" 
            Text="提交" Width="57px" />
&nbsp;&nbsp;&nbsp;&nbsp;
  
    </div>
    </form>
</body>
</html>
