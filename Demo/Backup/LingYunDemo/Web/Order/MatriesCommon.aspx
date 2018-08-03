<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatriesCommon.aspx.cs" Inherits="LingYunDemo.Web.Order.MatriesCommon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="../JS/jquery-1.6.1.js" type="text/javascript"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    </head><body>
    <form id="form1" runat="server">
    <div style="overflow-x:hidden;overflow-y:auto;height:600px; background:#f2f2f3;float:inherit;" runat="server">
    <h4  style="height:32px;line-height:32px;padding-left:20px; border-bottom:3px solid #F53C4A;color:#000;font-size:16px;" ><span runat="server" id="planName"></span></h4>
    <div style="overflow-x:hidden;overflow-y:auto;height:489px; background:#f2f2f2;float:inherit;">
    <ul runat="server" id="list">
      
        </ul>
       
    </div>
   
  <div style="margin-right:100px;margin-left:700px">
    <input type="checkbox" id="checkAll" runat="server" /><asp:Button ID="Button1" OnClientClick="CheckList()" OnClick="ensure_click" runat="server" Text="保存" style="background-image:'../Images/minicalendar/mall_icon_goTop.png' width:600px;height:30px;font-size:18px;font-family:'微软雅黑';cursor:pointer;color:#e52228;" />
    </div>

    </div>
    <input type="hidden" id="hiddenList" runat="server" />
    </form>
    <script type="text/javascript">
        function urlLocation(value) {
       
            window.location = document.getElementById("chk" + value).value;
        }

        function CheckList() {
            var hiddText = ""; 
           var list=document.getElementById("list").getElementsByTagName("input");
           for(var i=0;i<list.length;i++)
           {
               if (list[i].type == "checkbox") {
               if(list[i].checked==true)
                   hiddText += list[i].value+";";
               }
           }
           document.getElementById("hiddenList").value = hiddText;
        }
       

    </script>
</body>
</html>
