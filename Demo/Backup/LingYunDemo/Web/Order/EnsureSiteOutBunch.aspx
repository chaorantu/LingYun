<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnsureSiteOutBunch.aspx.cs" Inherits="LingYunDemo.Web.Order.EnsureSiteOutBunch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="tablecloth/tablecloth.css" rel="stylesheet" type="text/css" />
    
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
<h4  style="height:32px;line-height:32px;padding-left:20px; border-bottom:3px solid #F53C4A;color:#000;font-size:16px;">用户导航：加工中心->确认出库批次表</h4>
    <form id="form1" runat="server">
  
    <div>
    	<table cellspacing="0" cellpadding="0">
         <tr> 
   <td><span>项目编号
       </span></td> 
   <td><input type="text" runat="server" id="txbPlanId" disabled="disabled" /></td>
  </tr>
   <tr>
       
   <td><span>材料编号</span></td>
   <td><input type="text" runat="server" id="txbMateriesID" disabled="disabled" /></td>
  </tr>
   <tr>
   <td><span>构件编号</span></td>
   <td><input type="text" runat="server" id="txbBuildID" disabled="disabled"/></td>
   </tr>
    <tr>
   <td><span>构件批次编号</span></td>
   <td><input type="text" runat="server" id="txbBuildBunchID" disabled="disabled"/></td>
   </tr>
   <tr>
   <td><span>工程名</span></td>
   <td><input type="text" runat="server" id="txbProjectName" disabled="disabled"/></td>
  </tr>
    <tr>
   <td><span>构件名称</span></td>
   <td><input type="text" runat="server" id="txbBuildName" disabled="disabled"/></td>
  </tr>
    <tr>
   <td><span>材质</span></td>
   <td><input type="text" runat="server" id="txbMetriesType" disabled="disabled"/></td>
  </tr>
      <tr>
   <td><span>加工图号</span></td>
   <td><input type="text" runat="server" id="txbProductNum" disabled="disabled"/></td>
  </tr>
    <tr>
   <td><span>数量</span></td>
   <td><input type="text" runat="server" id="txbCount" /></td>
  </tr>
 </table>
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:Button ID="Ensure" runat="server" Text="Button" onclick="Ensure_Click" />
    </div>
    </form>
</body>
</html>
