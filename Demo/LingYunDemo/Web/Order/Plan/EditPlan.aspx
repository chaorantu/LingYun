<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPlan.aspx.cs" Inherits="LingYunDemo.Web.Order.Plan.EditPlan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <link href="../tablecloth/tablecloth.css" rel="stylesheet" type="text/css" />

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

<body>
<h4  style="height:32px;line-height:32px;padding-left:20px; border-bottom:3px solid #F53C4A;color:#000;font-size:16px;">用户导航：编辑项目</h4>
	   <form id="Form1" runat="server">
	<div id="content">

   
		<table cellspacing="0" cellpadding="0">
		
   <tr>
  
   <td><span>项目名</span></td>
    
   <td>  <asp:TextBox ID="txtProjectName" runat="server" Height="26px"></asp:TextBox>
      </td>
  </tr>
   <tr>
       
   <td><span>设计主管</span></td>
   <td>&nbsp;<asp:DropDownList ID="DropDownList2" runat="server" Height="21px" 
           Width="101px">  </asp:DropDownList></td>
  </tr>
   <tr>
   <td><span>生产主管</span></td>
   <td>&nbsp;<asp:DropDownList ID="DropDownList3" runat="server" Height="21px" 
           Width="100px">  </asp:DropDownList></td>
  </tr>
   <tr>
   <td><span>中心仓库主管</span></td>
   <td>&nbsp;<asp:DropDownList ID="DropDownList4" runat="server" Height="21px" 
           Width="98px">  </asp:DropDownList></td>
  </tr>
   <tr>
   <td><span>现场仓库主管</span></td>
   <td>&nbsp;<asp:DropDownList ID="DropDownList5" runat="server" Height="21px" 
           Width="99px">  </asp:DropDownList></td>
  </tr>

   </table>
	
	</div>
    
   <div>
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:Button ID="btnAdd" runat="server" Text="提交项目" OnClick="btnAdd_Click" Width="76px"  
     /></div>
   </form>
</body>
</html>
