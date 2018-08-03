<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpLoadMatries.aspx.cs" Inherits="LingYunDemo.Web.Order.Design.UpLoadMatries" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <div id="Div1" style="overflow-x:hidden;overflow-y:auto;height:600px; background:#f2f2f3;float:inherit;" runat="server">
     <h4  style="height:32px;line-height:32px;padding-left:20px; border-bottom:3px solid #F53C4A;color:#000;font-size:16px;">用户导航:编辑材料表</h4>
      <div>
      
      <span  style="margin-left:300px">项目名</span><asp:TextBox ID="txbPlanId" 
              runat="server" ReadOnly="True" Width="122px" Height="30px"></asp:TextBox>
               
        <asp:RadioButton ID="rdbQueryAll" runat="server" Text="从数据库选择" 
            oncheckedchanged="rdbQueryAll_CheckedChanged"  
            checked="true" AutoPostBack="True" />
            <asp:DropDownList ID="DropDownList1" runat="server" 
              onselectedindexchanged="DropDownList1_SelectedIndexChanged">
          </asp:DropDownList>
    
         <asp:RadioButton ID="rdbQueryProject" runat="server" Text="导入数据源" Enabled="false" 
            oncheckedchanged="rdbQueryProject_CheckedChanged" AutoPostBack="True" />
          <asp:Button ID="Button3" runat="server" Text="导入" Enabled="false" />
    
          <asp:GridView ID="GridView1" style="display:block;margin-left: auto;margin-right: auto;" runat="server" AllowPaging="True" CellPadding="4" 
              ForeColor="#333333" Width="471px" onpageindexchanging="changed">
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
                        
               <input type="checkbox" id="chkBox" runat="server"  />
                  
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
          </asp:GridView>
      
          <asp:CheckBox ID="checkAll" style="margin-left:300px"  runat="server" Text="全选" />
      
          <asp:Button ID="Button4"  runat="server" onclick="Button4_Click" Text="提交" />
          <br />
    </div>
    <input type="hidden" id="hiddCheck" runat="server" />
      <%--  <asp:Button ID="Button2" runat="server" Height="24px" OnClick="Ensure" 
            Text="提交" Width="57px" />--%>
  </div>
    </form>
  
</body>
</html>
