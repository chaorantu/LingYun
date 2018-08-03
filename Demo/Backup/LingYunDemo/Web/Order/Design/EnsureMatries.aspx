<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnsureMatries.aspx.cs" Inherits="LingYunDemo.Web.Order.Design.EnsureMatries" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
<body>
<h4  style="height:32px;line-height:32px;padding-left:20px; border-bottom:3px solid #F53C4A;color:#000;font-size:16px;">用户导航:确认材料</h4>
    <form id="form1" runat="server">
      <div style="overflow-x:hidden;overflow-y:auto;height:300px; background:#f2f2f2;float:inherit;">
   
        <asp:GridView ID="GridView1" 
            style="display:block;margin-left: auto;margin-right: auto;" runat="server" CellPadding="4" 
              ForeColor="#333333" Width="471px" GridLines="None" >
              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
              <EditRowStyle BackColor="#999999" />
              <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
              <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
              <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" Font-Overline="True" 
                  ForeColor="#333333" />
              <SortedAscendingCellStyle BackColor="#E9E7E2" />
              <SortedAscendingHeaderStyle BackColor="#506C8C" />
              <SortedDescendingCellStyle BackColor="#FFFDF8" />
              <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
              <Columns>
                  <asp:TemplateField HeaderText="选择">
                      <ItemTemplate>
                        
               <input type="checkbox" name="chkBox" id="chkBox"  runat="server"  />
                  
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
          </asp:GridView>
       
   &nbsp;<ul runat="server" id="list" >
       
    
        </ul>
        </div>

   <div>
  
     <asp:Button ID="Ensure" style="margin-left:600px" runat="server" Height="24px" Text="确认" Width="57px" 
            onclick="Ensure_Click" /><input id="checkAll" runat="server" value="全选" type="checkbox" />   
    
    </div>
    </form>
    <script type="text/javascript">
      
    
    </script>
</body>
</html>
