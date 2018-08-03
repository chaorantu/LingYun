<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TabelTest.aspx.cs" Inherits="LingYunDemo.Web.Order.TabelTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Welcome to Tablecloth</title>

<style type="text/css">
body,table{
 font-size:12px;
}
table{
 table-layout:fixed;
 empty-cells:show; 
 border-collapse: collapse;
 margin:0 auto;
}
td{
 height:20px;
}
h1,h2,h3{
 font-size:12px;
 margin:0;
 padding:0;
}
 
.title { background: #FFF; border: 1px solid #9DB3C5; padding: 1px; width:90%;margin:20px auto; }
 .title h1 { line-height: 31px; text-align:center;  background: #2F589C url(th_bg2.gif); background-repeat: repeat-x; background-position: 0 0; color: #FFF; }
  .title th, .title td { border: 1px solid #CAD9EA; padding: 5px; }
 

table.tab_css_1{
 border:1px solid #cad9ea;
 color:#666;
}
table.tab_css_1 th {
 background-image: url(th_bg1.gif);
 background-repeat::repeat-x;
 height:30px;
}
table.tab_css_1 td,table.tab_css_1 th{
 border:1px solid #cad9ea;
 padding:0 1em 0;
}
table.tab_css_1 tr.tr_css{
 background-color:#f5fafe;
}

table.tab_css_2{
 border:1px solid #9db3c5;
 color:#666;
}
table.tab_css_2 th {
 background-image: url(th_bg2.gif);
 background-repeat::repeat-x;
 height:30px;
 color:#fff;
}
table.tab_css_2 td{
 border:1px dotted #cad9ea;
 padding:0 2px 0;
}
table.tab_css_2 th{
 border:1px solid #a7d1fd;
 padding:0 2px 0;
}
table.tab_css_2 tr.tr_css{
 background-color:#e8f3fd;
}

table.tab_css_3{
 border:1px solid #fc58a6;
 color:#720337;
}
table.tab_css_3 th {
 background-image: url(th_bg3.gif);
 background-repeat::repeat-x;
 height:30px;
 color:#35031b;
}
table.tab_css_3 td{
 border:1px dashed #feb8d9;
 padding:0 1.5em 0;
}
table.tab_css_3 th{
 border:1px solid #b9f9dc;
 padding:0 2px 0;
}
table.tab_css_3 tr.tr_css{
 background-color:#fbd8e8;
}
 
.hover{
   background-color: #53AB38;
   color: #fff;
}
</style>

</head>

<body>


	
	<div id="content">
   <form id="Form2" runat="server">
   
		<table cellspacing="0" cellpadding="0">
		
   <tr>
  
   <td><span>项目主管</span></td>
    
   <td>
       
<asp:textbox ID="planAdm" runat="server"></asp:textbox></td>
<td><asp:Button ID="add1" runat="server" Text="增加" /></td>
<td><asp:Button ID="change1" runat="server" Text="修改" /></td>
<td><asp:Button ID="delete1" runat="server" Text="删除" /></td>
  </tr>
   <tr>
       
   <td><span>设计主管</span></td>
   <td><input type="text" runat="server" id="DesignAdm" /></td>
  </tr>
   <tr>
   <td><span>生产主管</span></td>
   <td><input type="text" runat="server" id="ProductAdm" /></td>
   <td><asp:Button ID="add2" runat="server" Text="增加" /></td>
<td><asp:Button ID="change2" runat="server" Text="修改" /></td>
<td><asp:Button ID="delete2" runat="server" Text="删除" /></td>
  </tr>
   <tr>
   <td><span>中心仓库主管</span></td>
   <td><input type="text" runat="server" id="CenterStorageAdm" /></td>
  </tr>
   <tr>
   <td><span>现场仓库主管</span></td>
   <td><input type="text" runat="server" id="SiteStorageAdm" /></td>
   <td><asp:Button ID="add3" runat="server" Text="增加" /></td>
<td><asp:Button ID="delete3" runat="server" Text="修改" /></td>
<td><asp:Button ID="change3" runat="server" Text="删除" /></td>
  </tr>
   </table>
		
	
		</form>
	</div>
 
</body>
</html>
